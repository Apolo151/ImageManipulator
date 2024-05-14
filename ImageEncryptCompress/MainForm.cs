using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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

            string password = "eP$^6trvdsf2@2232jfkdlfs";

            int seedLength = int.Parse(txtSeedLen.Text); // set to 20
            int tapPosition = (int)nudTapPos.Value; // set to 11
            ImageEncryption imageEncryption = new ImageEncryption(password);
            ImageMatrix = imageEncryption.EncryptImage(ImageMatrix, seedLength, tapPosition, "");
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);

            /* Initialize ImageBreaker object
            ImageBreaker imageBreaker = new ImageBreaker(ImageMatrix);

            /* Break the image encryption
            int seedLength = 8; // Example seed length
            imageBreaker.BreakImage(seedLength);
            ImageMatrix = imageEncryption.EncryptImage(ImageMatrix, seedLength, imageBreaker.bestTap, imageBreaker.bestLfsr, true);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
            */
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            // return compression ratio
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

        }

        private void backwardBtn_Click(object sender, EventArgs e)
        {

        }

        private void breakBtn_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}