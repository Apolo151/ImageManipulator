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
        public static PriorityQueues.BinaryPriorityQueue<RGBPixel> pq; // TODO: create with comparator
        /// <summary>
        /// Compress the image's 2D color array using huffman encoding
        /// </summary>
        /// <param name="image"> the 2d image array</param>
        /// <returns>2D array of colors </returns>
        public static RGBPixel[,] CompressImage(RGBPixel[,] image)
        {
            //TODO
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
    }
}
