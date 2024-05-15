using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace ImageEncryptCompress
{
    public class ImageBreaker
    {
        // Function to find the best seed and tap
        public (string, int) FindBestSeedAndTap(RGBPixel[,] encryptedImage, int length)
        {
            long bestDeviation = 0;
            string bestSeed = "00000000";
            int bestTap = 0;

            string seed = "10001111";
            for (int i = 0; i < (1 << length); i++)
            {
                seed = "";
                int num = 0;
                for (int j = 7; j >= 0; j--)
                {
                    if (((1 << j) & i) != 0)
                    {
                        num |= (1 << j);
                        seed += '1';
                    }
                    else
                        seed += '0';
                }

                for (int tap = 0; tap < length; tap++)
                {
                    RGBPixel[,] decryptedImage = DecryptImage(seed, tap, encryptedImage);
                    long deviation = FrequencyDeviation(decryptedImage);
                    Console.WriteLine(deviation);
                    if (deviation >= bestDeviation)
                    {
                        bestDeviation = deviation;
                        bestSeed = seed;
                        bestTap = tap;
                    }
                }
            }

            return (bestSeed, bestTap);
        }


        // Function to calculate frequency deviation from 128
        public long FrequencyDeviation(RGBPixel[,] image)
        {
            int[,] frequencies = new int[3, 256];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    frequencies[i, j] = 0;
                }
            }
            double ret = 0;

            foreach (RGBPixel p in image)
            {
                frequencies[0, p.red]++;
                frequencies[1, p.green]++;
                frequencies[2, p.blue]++;
            }

            //Now let's calculate deviation 
            double devG = 0, devR = 0, devB = 0;
            for (int i = 0; i < 256; i++)
            {
                devR += Math.Abs(128 - frequencies[0, i]);
                devG += Math.Abs(128 - frequencies[1, i]);
                devB += Math.Abs(128 - frequencies[2, i]);
            }
            devR /= 256;
            devB /= 256;
            devG /= 256;
            ret = (Math.Abs(devR - 128) + Math.Abs(devG - 128) + Math.Abs(devB - 128)) / 3.0;

            return (long)ret;
        }

        RGBPixel[,] DecryptImage(string seed, int tap, RGBPixel[,] encryptedImage)
        {
            RGBPixel[,] decryptedImage = new RGBPixel[encryptedImage.GetLength(0), encryptedImage.GetLength(1)];
            for (int y = 0; y < encryptedImage.GetLength(0); y++)
            {
                for (int x = 0; x < encryptedImage.GetLength(1); x++)
                {
                    // Extract the RGB components of the pixel
                    byte red = encryptedImage[y, x].red;
                    byte green = encryptedImage[y, x].green;
                    byte blue = encryptedImage[y, x].blue;

                    // Encrypt each color component using the LFSR
                    red ^= GenerateKBits(ref seed, tap, 8);
                    green ^= GenerateKBits(ref seed, tap, 8);
                    blue ^= GenerateKBits(ref seed, tap, 8);

                    // Update the pixel with the encrypted color
                    decryptedImage[y, x] = new RGBPixel { red = red, green = green, blue = blue };
                }
            }

            return decryptedImage;
        }

        // Generate k bits using the LFSR algorithm 
        public byte GenerateKBits(ref string lfsr, int tapPosition, int k)
        {
            //Console.Write(lfsr, ' ');
            int n = lfsr.Length;
            byte result = 0;
            for (int i = 0; i < k; i++)
            {
                // Calculate the XOR result using the tap position

                int msb = lfsr[0] - '0';
                int tp = lfsr[n - 1 - tapPosition] - '0';
                int xorResult = msb ^ tp;


                // Shift the LFSR one position to the left  
                lfsr = lfsr.Substring(1) + (char)(xorResult + '0');

                // Append the XOR result to the result
                result = (byte)((result << 1) | xorResult);
            }

            return result;
        }
    }
}