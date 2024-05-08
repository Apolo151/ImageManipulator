using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEncryptCompress
{
    public class HuffmanTree
    {
        public static Dictionary<int, Tuple<Pixel, Pixel>> treeMap = new Dictionary<int, Tuple<Pixel, Pixel>>();
        public static Dictionary<Pixel, string> pixelCodes = new Dictionary<Pixel, string>();
        public static Pixel rootPixel = new Pixel();


        /// <summary>
        /// Bulids the tree in the form of a map
        /// Complexity: O(C log C), where C is the no. of distinct pixel values
        /// </summary>
        /// <param name="image"></param>
        public static void BuildTree(RGBPixel[,] image)
        {
            Pixel leftPixel;
            Pixel rightPixel;
            Pixel sumPixel;
            sumPixel.value = 256; // value of middle nodes does not matter
            //           
            while (Compression.pqRed.Count() > 1) 
            { 
            
                // Get the lowest two
                leftPixel = Compression.pqRed.Dequeue();
                rightPixel = Compression.pqRed.Dequeue();
                // create new node with their sum
                sumPixel.frequency = leftPixel.frequency + rightPixel.frequency;
                // add new map entry
                treeMap.Add(sumPixel.value, new Tuple<Pixel, Pixel>(leftPixel, rightPixel));
                // add new node to priority queue
                Compression.pqRed.Enqueue(sumPixel);
                // increment value
                sumPixel.value++;
            }
            //
            rootPixel = Compression.pqRed.Dequeue();
            return;
        }
        //
        public static void traverseTree(Pixel pixel,string currentCode)
        {
            // base: if key is doesn't have a value -> node is a leaf node
            if (treeMap.ContainsKey(pixel.value) == false)
            {
                pixelCodes[pixel] = currentCode;
                return;
            }

            // recurse
            traverseTree(treeMap[pixel.value].Item1,currentCode+'1');
            traverseTree(treeMap[pixel.value].Item2,currentCode+'0');
            return;
        }
        //
        public static void savePixelCodes(string filePath, RGBPixel[,] image)
        {
            int height = ImageOperations.GetHeight(image);
            int width = ImageOperations.GetWidth(image);
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var kvp in pixelCodes)
                    {
                        Pixel pixel = kvp.Key;
                        string code = kvp.Value;
                        writer.WriteLine($"{pixel.value},{pixel.frequency},{code}");
                    }
                    /*
                    writer.WriteLine("-------");
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            writer.Write(image[i, j].red);
                        }
                        writer.WriteLine();
                    }
                    */
                }
                Console.WriteLine("Pixel codes saved to file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving pixel codes to file: {ex.Message}");
            }

        }
    }
}
