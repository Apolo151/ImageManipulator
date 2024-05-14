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
        public static Dictionary<int, Tuple<Pixel, Pixel>> treeMapR = new Dictionary<int, Tuple<Pixel, Pixel>>();
        public static Dictionary<int, Tuple<Pixel, Pixel>> treeMapG = new Dictionary<int, Tuple<Pixel, Pixel>>();
        public static Dictionary<int, Tuple<Pixel, Pixel>> treeMapB = new Dictionary<int, Tuple<Pixel, Pixel>>();
        public static Dictionary<Pixel, string> pixelCodesR = new Dictionary<Pixel, string>();
        public static Dictionary<Pixel, string> pixelCodesG = new Dictionary<Pixel, string>();
        public static Dictionary<Pixel, string> pixelCodesB = new Dictionary<Pixel, string>();
        public static Pixel rootPixelR = new Pixel();
        public static Pixel rootPixelG = new Pixel();
        public static Pixel rootPixelB = new Pixel();


        /// <summary>
        /// Bulids the tree in the form of a map
        /// Complexity: O(C log C), where C is the no. of distinct pixel values
        /// </summary>
        /// <param name="image"></param>
        public static void BuildTree()
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
                treeMapR.Add(sumPixel.value, new Tuple<Pixel, Pixel>(leftPixel, rightPixel));
                // add new node to priority queue
                Compression.pqRed.Enqueue(sumPixel);
                // increment value
                sumPixel.value++;
            }
            //
            rootPixelR = Compression.pqRed.Dequeue();
            while (Compression.pqGreen.Count() > 1)
            {

                // Get the lowest two
                leftPixel = Compression.pqGreen.Dequeue();
                rightPixel = Compression.pqGreen.Dequeue();
                // create new node with their sum
                sumPixel.frequency = leftPixel.frequency + rightPixel.frequency;
                // add new map entry
                treeMapG.Add(sumPixel.value, new Tuple<Pixel, Pixel>(leftPixel, rightPixel));
                // add new node to priority queue
                Compression.pqGreen.Enqueue(sumPixel);
                // increment value
                sumPixel.value++;
            }
            //
            rootPixelG = Compression.pqGreen.Dequeue();
            while (Compression.pqBlue.Count() > 1)
            {

                // Get the lowest two
                leftPixel = Compression.pqBlue.Dequeue();
                rightPixel = Compression.pqBlue.Dequeue();
                // create new node with their sum
                sumPixel.frequency = leftPixel.frequency + rightPixel.frequency;
                // add new map entry
                treeMapB.Add(sumPixel.value, new Tuple<Pixel, Pixel>(leftPixel, rightPixel));
                // add new node to priority queue
                Compression.pqBlue.Enqueue(sumPixel);
                // increment value
                sumPixel.value++;
            }
            //
            rootPixelB = Compression.pqBlue.Dequeue();
            return;
        }
        //
        public static void traverseTree(Pixel pixel, string currentCode, ref Dictionary<Pixel, string> pixelCodes, Dictionary<int, Tuple<Pixel, Pixel>> treeMap)
        {
            // base: if key is doesn't have a value -> node is a leaf node
            if (treeMap.ContainsKey(pixel.value) == false)
            {
                pixelCodes[pixel] = currentCode;
                return;
            }

            // recurse
            traverseTree(treeMap[pixel.value].Item1, currentCode + '0', ref pixelCodes, treeMap);
            traverseTree(treeMap[pixel.value].Item2, currentCode + '1', ref pixelCodes, treeMap);
            return;
        }
        //
        /* public static void savePixelCodes(string filePath, RGBPixel[,] image)
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
                     writer.WriteLine(Compression.constructTreePath(filePath));
                     *//*
                     writer.WriteLine("-------");
                     for (int i = 0; i < height; i++)
                     {
                         for (int j = 0; j < width; j++)
                         {
                             writer.Write(image[i, j].red);
                         }
                         writer.WriteLine();
                     }
                     *//*
                 }
                 Console.WriteLine("Pixel codes saved to file successfully.");
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Error saving pixel codes to file: {ex.Message}");
             }

         }*/
    }
}