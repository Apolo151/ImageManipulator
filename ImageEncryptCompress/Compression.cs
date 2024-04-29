using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriorityQueues;

// Used priority queue implementation: https://github.com/mikkul/PriorityQueue/tree/master

namespace ImageEncryptCompress
{
    public class Compression
    {
        // frequency maps for each image channel
        public static Dictionary<byte, int> redFrequency = new Dictionary<byte, int>();
        public static Dictionary<byte, int> greenFrequency = new Dictionary<byte, int>();
        public static Dictionary<byte, int> blueFrequency = new Dictionary<byte, int>();
        //
        public static PriorityQueues.BinaryPriorityQueue<int> pqRed = new 
            BinaryPriorityQueue<int>((a, b) => a.CompareTo(b));
        public static PriorityQueues.BinaryPriorityQueue<int> pqGreen = new
            BinaryPriorityQueue<int>((a, b) => a.CompareTo(b));
        public static PriorityQueues.BinaryPriorityQueue<int> pqBlue = new
            BinaryPriorityQueue<int>((a, b) => a.CompareTo(b));

        /// <summary>
        /// Compress the image's 2D color array using huffman encoding
        /// </summary>
        /// <param name="image"> the 2d image array</param>
        /// <returns>2D array of colors </returns>
        public static RGBPixel[,] CompressImage(RGBPixel[,] image)
        {
            //TODO
            // Calculate freq for each pixel
            CalculatePixelsFrequency(image);
            //

            //
            return null;
        }

        /// <summary>
        /// Decompress the image's 2D color array using reverse huffman encoding
        /// </summary>
        /// <param name="image"> the 2d image array</param>
        /// <returns>2D array of colors </returns>
        public static RGBPixel[,] DecompressImage(RGBPixel[,] image)
        {
            // TODO
            return null;
        }

        private static void CalculatePixelsFrequency(RGBPixel[,] image)
        {
            //note: maybe refactor to use one dict. and call the func. three times,
            //with clear before each one
            int height = ImageOperations.GetHeight(image);
            int width = ImageOperations.GetWidth(image);
            // initialize maps to zero

            // walk through the image
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (!redFrequency.ContainsKey(image[i, j].red))
                    {
                        redFrequency[image[i, j].red] = 0;
                    }
                    redFrequency[image[i, j].red]++;
                    if (!greenFrequency.ContainsKey(image[i, j].green))
                    {
                        greenFrequency[image[i, j].green] = 0;
                    }
                    greenFrequency[image[i, j].green]++;
                    if (!blueFrequency.ContainsKey(image[i, j].blue))
                    {
                        blueFrequency[image[i, j].blue] = 0;
                    }
                    blueFrequency[image[i, j].blue]++;
                }
            }
            return;
        }
        
        private static void ConstructHuffmanTree(RGBPixel[,] image)
        {
            // 
        }
    }
}
