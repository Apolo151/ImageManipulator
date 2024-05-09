using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEncryptCompress {
    public class ImageEncryption {
        private string lfsr;

        public ImageEncryption(string password, bool convert = true) {
            // Initialize the LFSR with the password
            if (convert) {
                lfsr = GenerateLFSRSeed(password);
                lfsr = HexToBinary(lfsr);
            }
            else {
                lfsr = password;
            }
            //Console.WriteLine(lfsr.Length);  -> 192 bit (most of it is not needed, but whatever) (actually let's make it 16 or something)
        }

        // Convert hexadecimal string to binary string
        public string HexToBinary(string hex) {
            string binary = "";
            foreach (char c in hex) {
                string binaryChar = Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0');
                binary += binaryChar;
            }

            return binary;
        }

        public string GenerateLFSRSeed(string password) {
            // Convert the password to bytes
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);

            // Generate an alphanumeric sequence based on the bytes of the password
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (byte b in bytes) {
                // Convert each byte to a hexadecimal string representation
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

        public RGBPixel[,] EncryptImage(RGBPixel[,] ImageMatrix, int k, int tapPosition, string new_lfsr, bool useNew = false) {
            if (useNew)
                lfsr = new_lfsr;
            // Iterate through each pixel of the image
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

        // Generate k bits using the LFSR algorithm
        public byte GenerateKBits(ref string lfsr, int tapPosition, int k) {
            //Console.Write(lfsr, ' ');
            byte result = 0;
            for (int i = 0; i < k; i++) {
                // Calculate the XOR result using the tap position

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