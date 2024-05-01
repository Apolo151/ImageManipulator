using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriorityQueues;

// Used priority queue implementation: https://github.com/mikkul/PriorityQueue/tree/master

namespace ImageEncryptCompress
{
    public struct Pixel{
        
       public byte value;
       public int frequency;
    };
    public unsafe struct TreeNode
    {
         public Pixel data;
         public TreeNode* left;
         public TreeNode* right;
    };
    public class Compression
    {
        // frequency maps for each image channel
        public static Dictionary<byte, int> redFrequency = new Dictionary<byte, int>();
        public static Dictionary<byte, int> greenFrequency = new Dictionary<byte, int>();
        public static Dictionary<byte, int> blueFrequency = new Dictionary<byte, int>();
        //
        public static BinaryPriorityQueue<Pixel> pqRed = new 
            BinaryPriorityQueue<Pixel>((a, b) => a.frequency.CompareTo(b.frequency));
        public static BinaryPriorityQueue<Pixel> pqGreen = new
            BinaryPriorityQueue<Pixel>((a, b) => a.frequency.CompareTo(b.frequency));
        public static BinaryPriorityQueue<Pixel> pqBlue = new
            BinaryPriorityQueue<Pixel>((a, b) => a.frequency.CompareTo(b.frequency));

        
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

        public static void ConstructQueue(RGBPixel[,] image)
        {
            int height = ImageOperations.GetHeight(image);
            int width = ImageOperations.GetWidth(image);
            Pixel temp;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    temp.value = image[i, j].red;
                    temp.frequency = redFrequency[image[i, j].red];
                    pqRed.Enqueue(temp);
                    temp.value = image[i, j].green;
                    temp.frequency = greenFrequency[image[i, j].green];
                    pqRed.Enqueue(temp);
                    temp.value = image[i, j].blue;
                    temp.frequency = blueFrequency[image[i, j].blue];
                    pqRed.Enqueue(temp);
                }
            }
            return;
        }
        public static RGBPixel[,] createCompressedImage(RGBPixel[,] image)
        {
            // TODO: Implement
            return null;
        }
    }
    public class HuffmanTree
    {
        static byte newPixelKey = Convert.ToByte(256);
        public static Dictionary<Pixel, Tuple<Pixel, Pixel>> treeMap = new Dictionary<Pixel, Tuple<Pixel, Pixel>>();
        public static Dictionary<Pixel, byte> pixelCodes = new Dictionary<Pixel, byte>();
        public static Pixel rootPixel;
        //
        public static void BuildTree(RGBPixel[,] image)
        {
            Pixel leftPixel;
            Pixel rightPixel;
            Pixel sumPixel;
            //
            Compression.ConstructQueue(image);            
            while (Compression.pqRed.Count > 1)
            {
                // Get the lowest two
                leftPixel = Compression.pqRed.Dequeue();
                rightPixel = Compression.pqRed.Dequeue();
                // create new node with their sum
                sumPixel.frequency = leftPixel.frequency + rightPixel.frequency;
                sumPixel.value = newPixelKey;
                newPixelKey++;
                // add new map entry
                treeMap.Add(sumPixel, new Tuple<Pixel, Pixel>(leftPixel, rightPixel));
                // add new node to priority queue
                Compression.pqRed.Enqueue(sumPixel);
            }
            rootPixel = Compression.pqRed.Dequeue();
        }
        //
        public static void traverseTree(Pixel key, int bit, byte currentCode)
        {
            // add bit to currentCode (recheck)
            currentCode++;
            // base: if key is doesn't have a value -> node is a leaf node
            if (treeMap.ContainsKey(key) == false)
            {
                pixelCodes[key] = currentCode;
                return;
            }
            // shift currentCode
            var shifted = currentCode << 1;
            currentCode = Convert.ToByte(shifted);
            // recurse
            traverseTree(treeMap[key].Item1, 0, currentCode);
            traverseTree(treeMap[key].Item2, 1, currentCode);
            return;

        }
    }
}
