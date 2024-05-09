using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ImageEncryptCompress {
    public class ImageBreaker {
        private RGBPixel[,] encryptedImage;
        private int imageSize;
        private string lfsr = "";
        public string bestLfsr = "";
        public int bestTap = 0;

        public ImageBreaker(RGBPixel[,] encryptedImage) {
            try {
                this.encryptedImage = encryptedImage;
                imageSize = encryptedImage.GetLength(0) * encryptedImage.GetLength(1);
            }
            catch (Exception e) {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

        public void BreakImage(int seedLength) {
            int maxDeviation = 0;

            // Generate all possible seeds of length seedLength
            List<string> seeds = new List<string>();
            seeds = GeneratePossibleSeeds(seedLength);

            int d = 0;
            /*foreach (string seed in seeds) {
                for (int tap = 1; tap <= seedLength; tap++) {
                    i = tap;
                    // Decrypt the image using the current seed and tap position
                    lfsr = seed;
                    RGBPixel[,] decryptedImage = DecryptImage(encryptedImage, seedLength, tap);

                    // Calculate the frequency distribution of each color component
                    Dictionary<byte, int>[] frequencies = CalculateColorFrequencies(decryptedImage);

                    // Measure the deviation of the frequency distribution from the expected uniform distribution
                    int deviation = MeasureDeviation(frequencies);

                    // Track the seed and tap position combination with maximum deviation
                    if (deviation > maxDeviation) {
                        maxDeviation = deviation;
                        bestLfsr = seed;
                        bestTap = tap;
                    }

                    //   Console.WriteLine(seed);
                }
            }*/
            for (int i = 0; i < 6000080000; i++) {
                d = i;
            }
                    Console.WriteLine(encryptedImage.GetLength(0) * encryptedImage.GetLength(1));
            
        }


        // Generate all possible seeds of length seedLength
        private List<string> GeneratePossibleSeeds(int seedLength) {
            // Implement a method to generate all possible seeds of length seedLength
            // For demonstration purposes, we'll generate all binary strings of length seedLength
            int numSeeds = (int)Math.Pow(2, seedLength);
            List<string> ret = new List<string>();

            for (int i = 0; i < (1 << seedLength); i++)
                ret.Add(toBinary(i, seedLength));

            return ret;
        }

        private string toBinary(int num, int len) {
            string ret = "";
            for (int bit = len - 1; bit >= 0; bit--) {
                if (((1 << bit) & num) != 0)
                    ret += '1';
                else
                    ret += '0';
            }

            return ret;
        }

        // Decrypt the image using the current seed and tap position
        private RGBPixel[,] DecryptImage(RGBPixel[,] ImageMatrix, int k, int tapPosition) {
            // Iterate through each pixel of the image
            try {
                for (int y = 0; y < ImageMatrix.GetLength(0); y++) {
                    for (int x = 0; x < ImageMatrix.GetLength(1); x++) {
                        // Extract the RGB components of the pixel
                        byte red = ImageMatrix[y, x].red;
                        byte green = ImageMatrix[y, x].green;
                        byte blue = ImageMatrix[y, x].blue;

                        // Encrypt each color component using the LFSR
                        red ^= GenerateKBits(ref lfsr, tapPosition, k);
                        green ^= GenerateKBits(ref lfsr, tapPosition, k);
                        blue ^= GenerateKBits(ref lfsr, tapPosition, k);

                        // Update the pixel with the encrypted color
                        ImageMatrix[y, x] = new RGBPixel { red = red, green = green, blue = blue };
                    }
                }

                return ImageMatrix;
            }

            catch (Exception e) {
                Console.WriteLine("An error occurred: " + e.Message);
                return ImageMatrix;
            }
        }

        // Calculate the frequency distribution of each color component
        private Dictionary<byte, int>[] CalculateColorFrequencies(RGBPixel[,] image) {
            Dictionary<byte, int>[] frequencies =
                { new Dictionary<byte, int>(), new Dictionary<byte, int>(), new Dictionary<byte, int>() };

            foreach (RGBPixel pixel in image) {
                frequencies[0][pixel.red] = frequencies[0].ContainsKey(pixel.red) ? frequencies[0][pixel.red] + 1 : 1;
                frequencies[1][pixel.green] =
                    frequencies[1].ContainsKey(pixel.green) ? frequencies[1][pixel.green] + 1 : 1;
                frequencies[2][pixel.blue] =
                    frequencies[2].ContainsKey(pixel.blue) ? frequencies[2][pixel.blue] + 1 : 1;
            }

            return frequencies;
        }

        // Measure the deviation of the frequency distribution from the expected uniform distribution
        private int MeasureDeviation(Dictionary<byte, int>[] frequencies) {
            int totalDeviation = 0;

            foreach (Dictionary<byte, int> freqDict in frequencies) {
                foreach (var pair in freqDict) {
                    totalDeviation += Math.Abs(pair.Value - imageSize / 256);
                }
            }

            return totalDeviation;
        }

        // Generate k bits using the LFSR algorithm
        private byte GenerateKBits(ref string lfsr, int tapPosition, int k) {
            byte result = 0;
            for (int i = 0; i < k; i++) {
                // Calculate the XOR result using the tap position
                if (tapPosition >= lfsr.Length)
                    break;
                int lsb = lfsr[0] - '0';
                int tp = lfsr[tapPosition] - '0';
                int xorResult = lsb ^ tp;

                // Shift the LFSR one position to the left  
                lfsr = lfsr.Substring(1) + (char)(xorResult + '0');

                // Append the XOR result to the result
                result = (byte)((result << 1) | xorResult);
            }

            //Console.WriteLine(result);
            return result;
        }
    }
}