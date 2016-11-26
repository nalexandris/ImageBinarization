namespace FingerprintTest01
{
    partial class Form1
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
            this.pb01 = new System.Windows.Forms.PictureBox();
            this.pb02 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnBinarize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb02)).BeginInit();
            this.SuspendLayout();
            // 
            // pb01
            // 
            this.pb01.Location = new System.Drawing.Point(25, 54);
            this.pb01.Name = "pb01";
            this.pb01.Size = new System.Drawing.Size(255, 289);
            this.pb01.TabIndex = 0;
            this.pb01.TabStop = false;
            // 
            // pb02
            // 
            this.pb02.Location = new System.Drawing.Point(780, 54);
            this.pb02.Name = "pb02";
            this.pb02.Size = new System.Drawing.Size(255, 289);
            this.pb02.TabIndex = 1;
            this.pb02.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Original Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(777, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Processed Image";
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(25, 480);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(75, 23);
            this.btnLoadImage.TabIndex = 4;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnBinarizeImg_Click);
            // 
            // btnBinarize
            // 
            this.btnBinarize.Location = new System.Drawing.Point(24, 519);
            this.btnBinarize.Name = "btnBinarize";
            this.btnBinarize.Size = new System.Drawing.Size(75, 23);
            this.btnBinarize.TabIndex = 5;
            this.btnBinarize.Text = "Binarize";
            this.btnBinarize.UseVisualStyleBackColor = true;
            this.btnBinarize.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 661);
            this.Controls.Add(this.btnBinarize);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb02);
            this.Controls.Add(this.pb01);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb02)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb01;
        private System.Windows.Forms.PictureBox pb02;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnBinarize;
    }
}

