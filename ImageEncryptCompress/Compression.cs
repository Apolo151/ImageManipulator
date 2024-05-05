﻿using System;
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
        public static void CompressImage(RGBPixel[,] image)
        {
            //TODO
            // Calculate freq for each pixel
            CalculatePixelsFrequency(image);
            // Fill Priority queue to use for tree building
            FillPQueues(image);
            // Build Huffman Tree
            HuffmanTree.BuildTree(image);
            // Create code for each pixel pixel
            string currentCode = "";
            HuffmanTree.traverseTree(HuffmanTree.rootPixel, currentCode + '0');
            HuffmanTree.traverseTree(HuffmanTree.rootPixel, currentCode + '1');
            // replace each pixel value with its code in the compressed image
            
            // save compressed image

            //
            return;
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

        public static void FillPQueues(RGBPixel[,] image)
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
}
