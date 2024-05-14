namespace ImageEncryptCompress
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnCompress = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEncryptDecrypt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.nudTapPos = new System.Windows.Forms.NumericUpDown();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSeedpos = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDecompress = new System.Windows.Forms.Button();
            this.compressionRatioBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.backwardBtn = new System.Windows.Forms.Button();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.breakBtn = new System.Windows.Forms.Button();
            this.seedLen = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTapPos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 360);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(4, 4);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(412, 360);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(805, 503);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(126, 89);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCompress
            // 
            this.btnCompress.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompress.Location = new System.Drawing.Point(200, 500);
            this.btnCompress.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(130, 89);
            this.btnCompress.TabIndex = 2;
            this.btnCompress.Text = "Compress Image";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(565, 484);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Original Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1167, 496);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Encryption Params";
            // 
            // btnEncryptDecrypt
            // 
            this.btnEncryptDecrypt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncryptDecrypt.Location = new System.Drawing.Point(989, 500);
            this.btnEncryptDecrypt.Margin = new System.Windows.Forms.Padding(4);
            this.btnEncryptDecrypt.Name = "btnEncryptDecrypt";
            this.btnEncryptDecrypt.Size = new System.Drawing.Size(147, 89);
            this.btnEncryptDecrypt.TabIndex = 5;
            this.btnEncryptDecrypt.Text = "Apply Encryption";
            this.btnEncryptDecrypt.UseVisualStyleBackColor = true;
            this.btnEncryptDecrypt.Click += new System.EventHandler(this.btnEncryptDecrypt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1172, 531);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tap Position";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1172, 574);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Initial Seed";
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.Location = new System.Drawing.Point(662, 568);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(75, 27);
            this.txtHeight.TabIndex = 8;
            // 
            // nudTapPos
            // 
            this.nudTapPos.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTapPos.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudTapPos.Location = new System.Drawing.Point(1291, 529);
            this.nudTapPos.Margin = new System.Windows.Forms.Padding(4);
            this.nudTapPos.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudTapPos.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudTapPos.Name = "nudTapPos";
            this.nudTapPos.Size = new System.Drawing.Size(76, 27);
            this.nudTapPos.TabIndex = 10;
            this.nudTapPos.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.Location = new System.Drawing.Point(662, 528);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(4);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(75, 27);
            this.txtWidth.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(571, 534);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(565, 568);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "Height";
            // 
            // txtSeedpos
            // 
            this.txtSeedpos.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeedpos.Location = new System.Drawing.Point(1288, 568);
            this.txtSeedpos.Margin = new System.Windows.Forms.Padding(4);
            this.txtSeedpos.Name = "txtSeedpos";
            this.txtSeedpos.Size = new System.Drawing.Size(75, 27);
            this.txtSeedpos.TabIndex = 14;
            this.txtSeedpos.Text = "20";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 456);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(628, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 456);
            this.panel2.TabIndex = 16;
            // 
            // btnDecompress
            // 
            this.btnDecompress.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecompress.Location = new System.Drawing.Point(22, 500);
            this.btnDecompress.Margin = new System.Windows.Forms.Padding(4);
            this.btnDecompress.Name = "btnDecompress";
            this.btnDecompress.Size = new System.Drawing.Size(170, 89);
            this.btnDecompress.TabIndex = 17;
            this.btnDecompress.Text = "Decompress Image";
            this.btnDecompress.UseVisualStyleBackColor = true;
            this.btnDecompress.Click += new System.EventHandler(this.btnDecompress_Click);
            // 
            // compressionRatioBox
            // 
            this.compressionRatioBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compressionRatioBox.Location = new System.Drawing.Point(372, 536);
            this.compressionRatioBox.Margin = new System.Windows.Forms.Padding(4);
            this.compressionRatioBox.Name = "compressionRatioBox";
            this.compressionRatioBox.ReadOnly = true;
            this.compressionRatioBox.Size = new System.Drawing.Size(97, 27);
            this.compressionRatioBox.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(338, 500);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 21);
            this.label7.TabIndex = 19;
            this.label7.Text = "Compression Ratio";
            // 
            // backwardBtn
            // 
            this.backwardBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backwardBtn.Location = new System.Drawing.Point(1234, 325);
            this.backwardBtn.Margin = new System.Windows.Forms.Padding(4);
            this.backwardBtn.Name = "backwardBtn";
            this.backwardBtn.Size = new System.Drawing.Size(147, 89);
            this.backwardBtn.TabIndex = 6;
            this.backwardBtn.Text = "Backward Pass";
            this.backwardBtn.UseVisualStyleBackColor = true;
            this.backwardBtn.Click += new System.EventHandler(this.forwardBtn_Click);
            // 
            // forwardBtn
            // 
            this.forwardBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forwardBtn.Location = new System.Drawing.Point(1234, 212);
            this.forwardBtn.Margin = new System.Windows.Forms.Padding(4);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(147, 89);
            this.forwardBtn.TabIndex = 20;
            this.forwardBtn.Text = "Forward Pass";
            this.forwardBtn.UseVisualStyleBackColor = true;
            // 
            // breakBtn
            // 
            this.breakBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breakBtn.Location = new System.Drawing.Point(1234, 13);
            this.breakBtn.Margin = new System.Windows.Forms.Padding(4);
            this.breakBtn.Name = "breakBtn";
            this.breakBtn.Size = new System.Drawing.Size(147, 89);
            this.breakBtn.TabIndex = 6;
            this.breakBtn.Text = "Break Encryption";
            this.breakBtn.UseVisualStyleBackColor = true;
            this.breakBtn.Click += new System.EventHandler(this.breakBtn_Click);
            // 
            // seedLen
            // 
            this.seedLen.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seedLen.Location = new System.Drawing.Point(1321, 142);
            this.seedLen.Margin = new System.Windows.Forms.Padding(4);
            this.seedLen.Name = "seedLen";
            this.seedLen.Size = new System.Drawing.Size(46, 27);
            this.seedLen.TabIndex = 25;
            this.seedLen.Text = "20";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1196, 142);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 21);
            this.label8.TabIndex = 23;
            this.label8.Text = "Seed Length";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1210, 114);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 24);
            this.label10.TabIndex = 21;
            this.label10.Text = "Break Params";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 664);
            this.Controls.Add(this.seedLen);
            this.Controls.Add(this.compressionRatioBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.breakBtn);
            this.Controls.Add(this.forwardBtn);
            this.Controls.Add(this.backwardBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDecompress);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtSeedpos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.nudTapPos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEncryptDecrypt);
            this.Controls.Add(this.btnCompress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpen);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Image Enctryption and Compression...";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTapPos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEncryptDecrypt;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.NumericUpDown nudTapPos;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSeedpos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDecompress;
        private System.Windows.Forms.TextBox compressionRatioBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button backwardBtn;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.Button breakBtn;
        private System.Windows.Forms.TextBox seedLen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
    }
}

