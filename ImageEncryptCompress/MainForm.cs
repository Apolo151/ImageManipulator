using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ImageEncryptCompress
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        RGBPixel[,] ImageMatrix;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
            }
            txtWidth.Text = ImageOperations.GetWidth(ImageMatrix).ToString();
            txtHeight.Text = ImageOperations.GetHeight(ImageMatrix).ToString();
        }

        private void btnEncryptDecrypt_Click(object sender, EventArgs e)
        {
            bool convert = false;
            string seedPos = (txtSeedpos.Text); // set to 20
            int tapPosition = (int)nudTapPos.Value; // set to 11
            foreach(char c in seedPos)
            {
                if(c != '0' && c != '1')
                {
                    convert = true;
                    break;
                }
            }
            ImageEncryption imageEncryption = new ImageEncryption(seedPos, convert);
            ImageMatrix = imageEncryption.EncryptImage(ImageMatrix, seedPos.Length, tapPosition, "");
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
            }
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            // returns compression ratio
            float compressionRatio = Compression.CompressImage(ImageMatrix);
            compressionRatioBox.Text = Math.Round(compressionRatio, 5).ToString();
        }

        private async void btnDecompress_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                string TreePath = Compression.constructTreePath(OpenedFilePath);
                ImageMatrix = await Compression.DecompressImage(OpenedFilePath, TreePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
            }
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            // Encrypt Image
            string password = "eP$^6trvdsf2@2232jfkdlfs";
            password = "00101";
            string seedPos = txtSeedpos.Text; // set to 20
            int tapPosition = (int)nudTapPos.Value; // set to 11
            ImageEncryption imageEncryption = new ImageEncryption(seedPos);
            ImageMatrix = imageEncryption.EncryptImage(ImageMatrix,seedPos.Length, tapPosition, "");
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
            //
            // Compress Image
            float compressionRatio = Compression.CompressImage(ImageMatrix);
            compressionRatioBox.Text = Math.Round(compressionRatio, 5).ToString();
            //
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0}:{1:00}",
                ts.Minutes, ts.Seconds);

            textBox1.Text = elapsedTime;
        }

        private async void backwardBtn_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            stopWatch.Start();
            // DecompressImage
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                string TreePath = Compression.constructTreePath(OpenedFilePath);
                ImageMatrix = await Compression.DecompressImage(OpenedFilePath, TreePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
            }

            // Decrypt Image
            string password = "eP$^6trvdsf2@2232jfkdlfs";
            int k = 5;
            int seedPos = int.Parse(txtSeedpos.Text); // set to 20
            int tapPosition = (int)nudTapPos.Value; // set to 11
            ImageEncryption imageEncryption = new ImageEncryption(password);
            ImageMatrix = imageEncryption.EncryptImage(ImageMatrix, k, tapPosition, "");
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
            //
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0}:{1:00}",
                ts.Minutes, ts.Seconds);

            textBox2.Text = elapsedTime;
        }

        private void breakBtn_Click(object sender, EventArgs e)
        {
            // Initialize ImageBreaker object
            ImageBreaker imageBreaker = new ImageBreaker();

            //Break the image encryption
            //now lets break encryption
            int length = int.Parse(seedLen.Text);
            var (seed, tap) = imageBreaker.FindBestSeedAndTap(ImageMatrix, length);
            Console.WriteLine(seed);
            Console.WriteLine(tap);
            ImageEncryption imageEncryption = new ImageEncryption(seed, false);
            ImageMatrix = imageEncryption.EncryptImage(ImageMatrix, length, tap, "");
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);

            /*ImageBreaker imageBreaker = new ImageBreaker();
            long d = imageBreaker.FrequencyDeviation(ImageMatrix);
            Console.WriteLine(d);*/

        }
    }
}
