using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FingerprintTest01.Chaincode_processing;


using System.Drawing.Drawing2D;
using System.Net;
using System.Diagnostics;

namespace FingerprintTest01
{
    public partial class Form1 : Form
    {


        private Bitmap Original { get; set; }
        private float OriginalTotalHSB { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pb01.SizeMode = PictureBoxSizeMode.AutoSize;


            pb02.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        //Load Image
        private void btnBinarizeImg_Click(object sender, EventArgs e)
        {
            try
            {

                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Open Image";
                    //     dlg.Filter = "bmp files (*.bmp)|*.bmp";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        Original = new Bitmap(dlg.FileName);

                    }

                    else
                    {
                        MessageBox.Show("Operation Canceled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                pb01.Image = Original;

                OriginalTotalHSB = CalculateTotalOriginalSaturation(0, Original.Height, 0, Original.Width);


            }
            catch (Exception ex)
            {

                MessageBox.Show("ERROR", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Binarize??
        /// Check if there are enough pixels to create a block

        private bool ConditionCheckHeight(int currentPixel, int blockSize)
        {
            bool reply = false;

            int pixelRemain_Y = Original.Height - currentPixel;

            //if(pixelRemain_Y>=blockSize || pixelRemain_X>=blockSize) 
            reply = (pixelRemain_Y >= blockSize) ? true : false;

            return reply;
        }

        private bool ConditionCheckWidth(int currentPixel, int blockSize)
        {
            bool reply = false;

            int pixelRemain_X = Original.Width - currentPixel;

            //if(pixelRemain_Y>=blockSize || pixelRemain_X>=blockSize) 
            reply = (pixelRemain_X >= blockSize) ? true : false;

            return reply;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                pb02.Image = BinarizeFingerPrint(16, Original);
                //Bitmap bit = new Bitmap(Original.Width, Original.Height);



                //int blockSize = 16;

                #region "third attempt"

                //for (int i = 0; i < Original.Height; i = i + blockSize)
                //{

                //    if (ConditionCheckHeight(i, blockSize))
                //    {
                //        for (int j = 0; j < Original.Width; j = j + blockSize)
                //        {

                //            //if there is room to create and use the block
                //            if (ConditionCheckWidth(j, blockSize))
                //            {

                //                float BrightnessThreshold = CalculateIdealSaturation(i, i + blockSize, j, j + blockSize);
                //                /// 
                //                for (int blockHeight = i; blockHeight < i + blockSize; blockHeight++)
                //                {
                //                    for (int blockWidth = j; blockWidth < j + blockSize; blockWidth++)
                //                    {

                //                        if (Original.GetPixel(blockWidth, blockHeight).GetBrightness() > BrightnessThreshold)
                //                        {
                //                            bit.SetPixel(blockWidth, blockHeight, Color.White);
                //                        }
                //                        else bit.SetPixel(blockWidth, blockHeight, Color.Black);


                //                    }
                //                }
                //            }
                //            else
                //            {
                //                float BrightnessThreshold = CalculateIdealSaturation(i, i + blockSize, j, Original.Width);

                //                for (int blockHeight = i; blockHeight < i + blockSize; blockHeight++)
                //                {
                //                    for (int blockWidth = j; blockWidth < Original.Height; blockWidth++)
                //                    {

                //                        if (Original.GetPixel(blockWidth, blockHeight).GetBrightness() > BrightnessThreshold)
                //                        {
                //                            bit.SetPixel(blockWidth, blockHeight, Color.White);
                //                        }
                //                        else bit.SetPixel(blockWidth, blockHeight, Color.Black);
                //                    }
                //                }

                //            }


                //        }
                //    }
                //    else
                //    {
                //        //float BrightnessThreshold = CalculateIdealSaturation(i, Original.Width, 0, Original.Height);


                //        for (int j = 0; j < Original.Width; j = j + blockSize)
                //        {

                //            //if there is room to create and use the block
                //            if (ConditionCheckWidth(j, blockSize))
                //            {

                //                float BrightnessThreshold = CalculateIdealSaturation(i, Original.Height, j, j + blockSize);
                //                /// 
                //                for (int blockHeight = i; blockHeight < Original.Height; blockHeight++)
                //                {
                //                    for (int blockWidth = j; blockWidth < j + blockSize; blockWidth++)
                //                    {

                //                        if (Original.GetPixel(blockWidth, blockHeight).GetBrightness() > BrightnessThreshold)
                //                        {
                //                            bit.SetPixel(blockWidth, blockHeight, Color.White);
                //                        }
                //                        else bit.SetPixel(blockWidth, blockHeight, Color.Black);


                //                    }
                //                }
                //            }
                //            else
                //            {
                //                float BrightnessThreshold = CalculateIdealSaturation(i, Original.Height, j, Original.Width);

                //                for (int blockHeight = i; blockHeight < Original.Height; blockHeight++)
                //                {
                //                    for (int blockWidth = j; blockWidth < Original.Height; blockWidth++)
                //                    {

                //                        if (Original.GetPixel(blockWidth, blockHeight).GetBrightness() > BrightnessThreshold)
                //                        {
                //                            bit.SetPixel(blockWidth, blockHeight, Color.White);
                //                        }
                //                        else bit.SetPixel(blockWidth, blockHeight, Color.Black);
                //                    }
                //                }

                //            }

                //        }

                //    }

                //}



                #endregion



                #region "second attempt"
                /*

              

                bool flagX = true;
                bool flagY = true;


                int blockSize = 32;

                int stepCounterHeight = 0;
                int stepCounterWidth = 0;

                int imagesPixelCounter = Original.Width * Original.Height;


                int startX = 0;
                int endX = blockSize - 1;

                int startY = 0;
                int endY = blockSize - 1;



                //what happens if blocks are fitting perfectly ?
                while (flagX)
                {
                    if ((ConditionCheckHeight((stepCounterHeight + 1) * blockSize, blockSize)))
                    {
                        //go down, height


                        //startX = loopCounter * blockSize;
                        //endX = (loopCounter + 1) * blockSize - 1;

                        startY = stepCounterHeight * blockSize;
                        endY = (stepCounterHeight + 1) * blockSize - 1;

                        float BrightnessThreshold = CalculateIdealSaturation(startX, endX, startY, endY);

                        //this loop repeats twice unfortunatelly.
                        for (int i = startX; i < endX; i++)
                        {
                            for (int j = startY; j < endY; j++)
                            {

                                if (Original.GetPixel(i, j).GetBrightness() > BrightnessThreshold)
                                {
                                    bit.SetPixel(i, j, Color.White);
                                }
                                else bit.SetPixel(i, j, Color.Black);
                            }
                        }


                        while (flagY)
                        {
                            if ((ConditionCheckWidth((stepCounterWidth + 1) * blockSize, blockSize)))
                            {
                                //go right

                                startX = stepCounterWidth * blockSize;
                                endX = (stepCounterWidth + 1) * blockSize - 1;

                                BrightnessThreshold = CalculateIdealSaturation(startX, endX, startY, endY);

                                //this loop repeats twice unfortunatelly.
                                for (int i = startX; i < endX; i++)
                                {
                                    for (int j = startY; j < endY; j++)
                                    {

                                        if (Original.GetPixel(i, j).GetBrightness() > BrightnessThreshold)
                                        {
                                            bit.SetPixel(i, j, Color.White);
                                        }
                                        else bit.SetPixel(i, j, Color.Black);
                                    }
                                }
                            }

                            else
                            {
                                // precaution in case the 


                                BrightnessThreshold = CalculateIdealSaturation((stepCounterWidth + 1) * blockSize - 1, Original.Width, (stepCounterWidth + 1) * blockSize - 1, Original.Height);


                                for (int i = 2 * stepCounterWidth * blockSize - 1; i < Original.Width; i++)
                                {
                                    for (int j = 2 * stepCounterHeight * blockSize - 1; j < Original.Height; j++)
                                    {

                                        if (Original.GetPixel(i, j).GetBrightness() > BrightnessThreshold)
                                        {
                                            bit.SetPixel(i, j, Color.White);
                                        }
                                        else bit.SetPixel(i, j, Color.Black);
                                    }
                                }

                                flagY = false;
                            }

                            stepCounterWidth++;
                        }

                    }
                    else
                    {
                        float BrightnessThreshold = CalculateIdealSaturation((stepCounterHeight + 1) * blockSize - 1, Original.Width, (stepCounterHeight + 1) * blockSize - 1, Original.Height);


                        for (int i = 2 * stepCounterWidth * blockSize - 1; i < Original.Width; i++)
                        {
                            for (int j = 2 * stepCounterHeight * blockSize - 1; j < Original.Height; j++)
                            {

                                if (Original.GetPixel(i, j).GetBrightness() > BrightnessThreshold)
                                {
                                    bit.SetPixel(i, j, Color.White);
                                }
                                else bit.SetPixel(i, j, Color.Black);
                            }
                        }

                        flagX = false;
                    }

                    stepCounterHeight++;

                }

               
                */
                #endregion


                #region "first attempt"

                //while (flag)
                //{

                //    if (loopCounter == 0)
                //    {

                //        float BrightnessThreshold = CalculateIdealSaturation(startX, endX, startY, endY);

                //        for (int i = 0; i < blockSize - 1; i++)
                //        {
                //            for (int j = 0; j < blockSize - 1; j++)
                //            {

                //                if (Original.GetPixel(i, j).GetBrightness() > BrightnessThreshold)
                //                {
                //                    bit.SetPixel(i, j, Color.White);
                //                }
                //                else bit.SetPixel(i, j, Color.Black);
                //            }
                //        }

                //    }
                //    else if (ConditionCheckA((loopCounter + 1) * blockSize, blockSize))
                //    {

                //        //BREAK IT FOR ALL DIRECTIONS

                //        // for X, horizontial, width been the same, then :




                //        startX = loopCounter * blockSize;
                //        endX = (loopCounter + 1) * blockSize - 1;

                //        startY = loopCounter * blockSize;
                //        endY = (loopCounter + 1) * blockSize - 1;

                //        float BrightnessThreshold = CalculateIdealSaturation(startX, endX, startY, endY);


                //        //this loop repeats twice unfortunatelly.
                //        for (int i = startX; i < endX; i++)
                //        {
                //            for (int j = startY; j < endY; j++)
                //            {

                //                if (Original.GetPixel(i, j).GetBrightness() > BrightnessThreshold)
                //                {
                //                    bit.SetPixel(i, j, Color.White);
                //                }
                //                else bit.SetPixel(i, j, Color.Black);
                //            }
                //        }


                //    }

                //    else
                //    {
                //        // God Bless our soul


                //        float BrightnessThreshold = CalculateIdealSaturation((loopCounter + 1) * blockSize - 1, Original.Width, (loopCounter + 1) * blockSize - 1, Original.Height);


                //        for (int i = 2 * loopCounter * blockSize - 1; i < Original.Width; i++)
                //        {
                //            for (int j = 2 * loopCounter * blockSize - 1; j < Original.Height; j++)
                //            {

                //                if (Original.GetPixel(i, j).GetBrightness() > BrightnessThreshold)
                //                {
                //                    bit.SetPixel(i, j, Color.White);
                //                }
                //                else bit.SetPixel(i, j, Color.Black);
                //            }
                //        }


                //        flag = false;
                //    }


                //    loopCounter++;

                //}



                //List<string> pixels = new List<string>();
                //for (int i = 0; i < Original.Width; i++)
                //{
                //    for (int j = 0; j < Original.Height; j++)
                //    {
                //        pixels.Add(Original.GetPixel(i, j).ToKnownColor().ToString());

                //        if (Original.GetPixel(i, j).GetBrightness() > BrightnessThreshold)
                //        {
                //            bit.SetPixel(i, j, Color.White);
                //        }
                //        else bit.SetPixel(i, j, Color.Black);
                //    }
                //}

                #endregion



                //   pb02.Image = BinarizeImage(Original);
            }
            catch (Exception ex)
            {
                throw;
                // MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Get stack trace for the exception with source file information
                //var st = new StackTrace(ex, true);
                //// Get the top stack frame
                //var frame = st.GetFrame(0);
                //// Get the line number from the stack frame
                //var line = frame.GetFileLineNumber();
            }
        }


        private void btnChainProcessing_Click(object sender, EventArgs e)
        {
            try
            {

                Bitmap bit = new Bitmap(Original.Width, Original.Height);
                List<ContourElement> Contour = new List<ContourElement>();

                for (int i = 0; i < Original.Width; i++)
                {
                    for (int j = Original.Height; j < 0; j--)
                    {

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private Bitmap BinarizeImage(Bitmap bit)
        {
            try
            {

                var brush = new SolidBrush(Color.Black);


                Bitmap bmp = new Bitmap(bit.Width, bit.Height);

                var graph = Graphics.FromImage(bmp);

                // uncomment for higher quality output
                graph.InterpolationMode = InterpolationMode.High;
                graph.CompositingQuality = CompositingQuality.HighQuality;
                graph.SmoothingMode = SmoothingMode.AntiAlias;


                //var scaleWidth = (int)(my_bitmap.Width * scale);
                //var scaleHeight = (int)(my_bitmap.Height * scale);

                graph.FillRectangle(brush, new RectangleF(0, 0, bit.Width, bit.Height));
                graph.DrawImage(bit, new Rectangle(bit.Width, bit.Height, 1, 1));
                //my_bitmap.Save();

                //   my_bitmap = Grayscale.CommonAlgorithms.BT709.Apply(bmp);
                graph.Dispose();

                return bmp;
            }
            catch (Exception)
            {

                throw;
            }

        }







        //add below into a new Utilities static class


        private float CalculateIdealSaturation(int startY, int endY, int startX, int endX)
        {

            float idealSaturation = 0;

            List<float> BrightnessValuesList = new List<float>();

            for (int i = startY; i < endY; i++)
            {
                for (int j = startX; j < endX; j++)
                {

                    BrightnessValuesList.Add(Original.GetPixel(j, i).GetBrightness());
                }
            }

            //// How to calculate Threshold : http://www.academia.edu/1946178/Binarization_and_Thinning_of_Fingerprint_Images_by_Pipelining

           // idealSaturation = BrightnessValuesList.Average();

            idealSaturation = (BrightnessValuesList.Average() >= OriginalTotalHSB) ? OriginalTotalHSB : BrightnessValuesList.Average();  

            return idealSaturation;
        }


        private float CalculateTotalOriginalSaturation(int startY, int endY, int startX, int endX)
        {

            float idealSaturation = 0;

            List<float> BrightnessValuesList = new List<float>();

            for (int i = startY; i < endY; i++)
            {
                for (int j = startX; j < endX; j++)
                {

                    BrightnessValuesList.Add(Original.GetPixel(j, i).GetBrightness());
                }
            }

            idealSaturation = BrightnessValuesList.Average();

            return idealSaturation;
        }



        private Bitmap BinarizeFingerPrint(int _blockSize, Bitmap _Original)
        {
            try
            {
                Bitmap bit = new Bitmap(Original.Width, Original.Height);



                int blockSize = _blockSize;

                #region "third attempt"

                for (int i = 0; i < Original.Height; i = i + blockSize)
                {

                    if (ConditionCheckHeight(i, blockSize))
                    {
                        for (int j = 0; j < Original.Width; j = j + blockSize)
                        {

                            ///if there is room to create and use the block on width
                            if (ConditionCheckWidth(j, blockSize))
                            {

                                float BrightnessThreshold = CalculateIdealSaturation(i, i + blockSize, j, j + blockSize);
                                /// 
                                for (int blockHeight = i; blockHeight < i + blockSize; blockHeight++)
                                {
                                    for (int blockWidth = j; blockWidth < j + blockSize; blockWidth++)
                                    {

                                        if (Original.GetPixel(blockWidth, blockHeight).GetBrightness() > BrightnessThreshold)
                                        {
                                            bit.SetPixel(blockWidth, blockHeight, Color.White);
                                        }
                                        else bit.SetPixel(blockWidth, blockHeight, Color.Black);


                                    }
                                }
                            }
                            else /// since you dont have enough pixels to create a block use the remaining pixels of the image.
                            {
                                float BrightnessThreshold = CalculateIdealSaturation(i, i + blockSize, j, Original.Width);

                                for (int blockHeight = i; blockHeight < i + blockSize; blockHeight++)
                                {
                                    for (int blockWidth = j; blockWidth < Original.Width; blockWidth++) //changed this to Original.Width from Original.Height.
                                    {

                                        if (Original.GetPixel(blockWidth, blockHeight).GetBrightness() > BrightnessThreshold)
                                        {
                                            bit.SetPixel(blockWidth, blockHeight, Color.White);
                                        }
                                        else bit.SetPixel(blockWidth, blockHeight, Color.Black);
                                    }
                                }

                            }


                        }
                    }
                    else
                    {
                        //float BrightnessThreshold = CalculateIdealSaturation(i, Original.Width, 0, Original.Height);


                        for (int j = 0; j < Original.Width; j = j + blockSize)
                        {

                            //if there is room to create and use the block
                            if (ConditionCheckWidth(j, blockSize))
                            {

                                float BrightnessThreshold = CalculateIdealSaturation(i, Original.Height, j, j + blockSize);
                                /// 
                                for (int blockHeight = i; blockHeight < Original.Height; blockHeight++)
                                {
                                    for (int blockWidth = j; blockWidth < j + blockSize; blockWidth++)
                                    {

                                        if (Original.GetPixel(blockWidth, blockHeight).GetBrightness() > BrightnessThreshold)
                                        {
                                            bit.SetPixel(blockWidth, blockHeight, Color.White);
                                        }
                                        else bit.SetPixel(blockWidth, blockHeight, Color.Black);


                                    }
                                }
                            }
                            else
                            {
                                float BrightnessThreshold = CalculateIdealSaturation(i, Original.Height, j, Original.Width);

                                for (int blockHeight = i; blockHeight < Original.Height; blockHeight++)
                                {
                                    for (int blockWidth = j; blockWidth < Original.Width; blockWidth++) // changed to Original.Width from Original.Height
                                    {

                                        if (Original.GetPixel(blockWidth, blockHeight).GetBrightness() > BrightnessThreshold)
                                        {
                                            bit.SetPixel(blockWidth, blockHeight, Color.White);
                                        }
                                        else bit.SetPixel(blockWidth, blockHeight, Color.Black);
                                    }
                                }

                            }

                        }

                    }

                }


                return bit;
                #endregion

            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
