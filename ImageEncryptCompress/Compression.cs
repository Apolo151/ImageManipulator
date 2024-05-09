﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriorityQueues;
using System.IO;
using System.Linq.Expressions;
using System.Drawing.Imaging;
using System.Windows.Forms.VisualStyles;

// Used priority queue implementation: https://github.com/mikkul/PriorityQueue/tree/master

namespace ImageEncryptCompress
{
    public struct Pixel{
        
       public int value;
       public int frequency;
    };

    public class Compression
    {
        // compressed image file pathD:\Code_projects\Uni\algo\project\ImageEncryptCompress\SampleCases_Compression
        public static string saveImagePath = "../../../SampleCases_Compression/results/res1.txt";
        //
        public static string pixelCodesPath = "../../../SampleCases_Compression/results/pixelCodes.txt";
        // frequency maps for each image channel
        public static Dictionary<int, int> redFrequency = new Dictionary<int, int>();
        public static Dictionary<int, int> greenFrequency = new Dictionary<int, int>();
        public static Dictionary<int, int> blueFrequency = new Dictionary<int, int>();
        //
        public static BinaryPriorityQueue<Pixel> pqRed = new 
            BinaryPriorityQueue<Pixel>((a, b) => a.frequency.CompareTo(b.frequency));
        public static BinaryPriorityQueue<Pixel> pqGreen = new
            BinaryPriorityQueue<Pixel>((a, b) => a.frequency.CompareTo(b.frequency));
        public static BinaryPriorityQueue<Pixel> pqBlue = new
            BinaryPriorityQueue<Pixel>((a, b) => a.frequency.CompareTo(b.frequency));
        // padding for compressed image
        public static int padding;

        /// <summary>
        /// Compress the image's 2D color array using huffman encoding
        /// </summary>
        /// <param name="image"> the 2d image array</param>
        /// <returns>2D array of colors </returns>
        public static float CompressImage(RGBPixel[,] image)
        {
            //getting image parameters
            int height = ImageOperations.GetHeight(image);
            int width = ImageOperations.GetWidth(image);
            // Calculate freq for each pixel
            CalculatePixelsFrequency(image);
            // Fill Priority queue to use for tree building
            FillPQueues(image);
            // Build Huffman Tree
            HuffmanTree.BuildTree(image);
            // Create code for each pixel pixel
            string currentCode = "";
            HuffmanTree.traverseTree(HuffmanTree.rootPixel, currentCode);
            // replace each pixel value with its code in the compressed image
            byte[] compressedImage = createCompressedImage(image, HuffmanTree.pixelCodes);
            // save compressed image
            saveCompressedImage(compressedImage, saveImagePath, height, width);
            string TreePath = constructTreePath(saveImagePath);
            saveTreeFile(TreePath, height, width);
            //
            // ---------for testing
            HuffmanTree.savePixelCodes(pixelCodesPath, image);
            //----------for testing
            // clear map
            HuffmanTree.treeMap.Clear();
            // calculate and save compression ratio
            return getCompressionRatio(width, height, compressedImage.Length); ;
        }
        //
        public static RGBPixel[,] DecompressImage(string imagePath, string treePath)
        {
            string compressedCodes = ReadBinaryFile(imagePath);
            string[] dimensions = ReadTreeFile(treePath);
            //Getting parameters from old image
            int height = Convert.ToInt32(dimensions[0]);
            int width = Convert.ToInt32(dimensions[1]);

            //intializing new image to hold the compressed values
            RGBPixel[,] recoveredImage = new RGBPixel[height, width];

            int bit = 0;
            //iterating over each pixel in the image and getting its value
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    //intialize it with root pixel on huffman tree
                    Pixel pixel = HuffmanTree.rootPixel;
                    //looping over each bit until we find a leaf node
                    for (; bit < compressedCodes.Count()-padding; bit++)
                    {
                        if (compressedCodes[bit] == '0')
                        {
                            pixel = HuffmanTree.treeMap[pixel.value].Item1;
                        }
                        else
                        {
                            pixel = HuffmanTree.treeMap[pixel.value].Item2;
                        }
                        //if leaf node is found assign the value to the image and break;
                        if (HuffmanTree.treeMap.ContainsKey(pixel.value) == false)
                        {
                            recoveredImage[i, j].red = Convert.ToByte(pixel.value);
                            recoveredImage[i, j].green = Convert.ToByte(0);
                            recoveredImage[i, j].blue = Convert.ToByte(0);
                            bit++;
                            break;
                        }
                    }
                }
            }
            return recoveredImage;
        }
        /// <summary>
        /// Decompress the image's 2D color array using reverse huffman encoding
        /// </summary>
        /// <param name="image"> the 2d image array</param>
        /// <returns>2D array of colors </returns>
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
                        redFrequency[Convert.ToInt16(image[i, j].red)] = 0;
                    }
                    redFrequency[image[i, j].red]++;
                    if (!greenFrequency.ContainsKey(image[i, j].green))
                    {
                        greenFrequency[Convert.ToInt16(image[i, j].green)] = 0;
                    }
                    greenFrequency[image[i, j].green]++;
                    if (!blueFrequency.ContainsKey(image[i, j].blue))
                    {
                        blueFrequency[Convert.ToInt16(image[i, j].blue)] = 0;
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
            Pixel pixel;
            foreach(var pair in redFrequency)
            {
                pixel.value = pair.Key;
                pixel.frequency = pair.Value;
                pqRed.Enqueue(pixel);
            }

            return;
        }
        //
        public static byte[] createCompressedImage(RGBPixel[,] image ,Dictionary<Pixel, string> pixelCodes)
        {
            Pixel pixel;
            List<bool> compressedImageBits = new List<bool>();
            int height = ImageOperations.GetHeight(image);
            int width = ImageOperations.GetWidth(image);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pixel.value = image[i, j].red;
                    pixel.frequency = redFrequency[image[i, j].red];

                    //adding every huffman code bit to compressedImageBits list
                    foreach (char bit in pixelCodes[pixel])
                    {
                        compressedImageBits.Add(bit == '1');
                    }
                }
            }
            //Turning bits to bytes to be able to save in binary files
            //Add padding to ensure number of bits are divisible by 8
            padding = (8-(compressedImageBits.Count % 8))%8;
            for(int i=0; i < padding; i++)
            {
                compressedImageBits.Add(false);
                padding--;
            }

            byte[] compressedImage = new byte[compressedImageBits.Count/8 + 1];
            //looping over 8 bits at once to construct compressed image bytes
            for (int i = 0; i < compressedImageBits.Count; i += 8)
            {
                byte b = 0;
                //looping over each bit in the byte
                for (int j = 0; j < 8; j++)
                {
                    //check if bit isn't out of bound and if it's 1 or 0
                    if (i + j < compressedImageBits.Count && compressedImageBits[i + j])
                    {
                        //assign each bit to its right place in the byte using bitwise OR
                        b |= (byte)(1 << (7 - j));
                    }
                }
                //saving bytes
                compressedImage[i / 8] = b;
            }
            //returns list of bytes which represents the compressed image
            return compressedImage;
        }
        //
        public static void saveCompressedImage(byte[] compressedImage, string filePath, int height, int width)
        {
            try
            {
                File.WriteAllBytes(filePath, compressedImage);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in writing file: {e.Message}");
            }
        }
        //
        public static string ReadBinaryFile(string filePath)
        {
            string compressedCodes="";
            try
            {
                // Read all bytes from the file
                byte[] bytes = File.ReadAllBytes(filePath);
                //looping over each byte and converting it to string;
                foreach(byte b in bytes)
                {
                    compressedCodes += Convert.ToString(b, 2).PadLeft(8, '0');
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error reading file: {e.Message}");
            }

            return compressedCodes;
        }
        //
        public static string[] ReadTreeFile(string filePath)
        {
            string[] dimensions;
            // Initialize the StreamReader
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                string line;
                // read height and width
                line = reader.ReadLine();
                if(line == null)
                {
                    throw new Exception("Image dimensions are not present in file");
                }
                dimensions = line.Split(',');
                // skip next line
                line = reader.ReadLine();
                // read root node
                string[] entry;
                Pixel leftPixel;
                Pixel rightPixel;
                line = reader.ReadLine();
                entry = line.Split(',');
                leftPixel.value = Convert.ToInt32(entry[1]);
                leftPixel.frequency = 12;
                rightPixel.value = Convert.ToInt32(entry[2]);
                rightPixel.frequency = 11;
                HuffmanTree.treeMap.Add(Convert.ToInt32(entry[0]), new Tuple<Pixel, Pixel>(leftPixel, rightPixel));
                HuffmanTree.rootPixel.value = Convert.ToInt32(entry[0]);
                // read dictionary entries

                while ((line = reader.ReadLine()) != null)
                {
                    entry = line.Split(',');
                    leftPixel.value = Convert.ToInt32(entry[1]);
                    leftPixel.frequency = 12;
                    rightPixel.value = Convert.ToInt32(entry[2]);
                    rightPixel.frequency = 11;
                    HuffmanTree.treeMap.Add(Convert.ToInt32(entry[0]), new Tuple<Pixel, Pixel>(leftPixel, rightPixel));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw ex;
            }
            finally
            {
                // Close the StreamReader in the finally block
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return dimensions;
        }
        //
        public static void saveTreeFile(string filePath, int height, int width)
        {
            try
            {
                // Write some text to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    //Save Image dimensions
                    string h = Convert.ToString(height);
                    string w = Convert.ToString(width);
                    writer.WriteLine(h + "," + w);
                    // write line
                    writer.WriteLine("------");
                    
                    //Save Huffman Tree
                    string pixelFamily;
                    foreach (var pixel in HuffmanTree.treeMap)
                    {
                        pixelFamily = pixel.Key.ToString() + "," 
                            + pixel.Value.Item1.value.ToString() + ',' + pixel.Value.Item2.value.ToString();
                        writer.WriteLine(pixelFamily);
                    }
                    
                }

                Console.WriteLine("Data has been written to the file.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in writing file: {e.Message}");
            }
        }
        //
        public static string constructTreePath(string filePath)
        {
            int idx = filePath.LastIndexOf("/");
            if(idx == -1)
            {
                idx = filePath.LastIndexOf("\\");
            }
            string baseStr = filePath.Substring(0, idx);
            //
            string suffix = filePath.Substring(idx);
            suffix = suffix.Substring(0, suffix.Length-4);
            suffix += "Tree.txt";
            baseStr += suffix;
            return baseStr;
        }
        //
        public static float getCompressionRatio(int imgWidth, int imgHeight, int compressedLength)
        {
            double oldImgSize = imgWidth* imgHeight*8;
            return (float)(compressedLength*1.0/oldImgSize);
        }

    }
}
