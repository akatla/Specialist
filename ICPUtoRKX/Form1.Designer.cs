using System.IO;
using System;
using System.Configuration;
using System.Collections.Specialized;

namespace WindowsFormsApplication1
{
    partial class Form1
    {
       
        // string ptt = @"D:\BOARD_ALL_ALL\OLD_Comps\Specialist\Sybr_FIFAN\SYABR_SBORKA\Переписка PVV\GAMES\games_mx_i80\";
        // string pttOut = @"D:\BOARD_ALL_ALL\OLD_Comps\Specialist\Sybr_FIFAN\SYABR_SBORKA\Переписка PVV\GAMES\games_mx_i80\1\";

        string ptt =  @"D:\BOARD_ALL_ALL\OLD_Comps\Specialist\Sybr_FIFAN\SYABR_SBORKA\Переписка PVV\SYS_PROG\soft_mx_i80\";
        string pttOut = @"D:\BOARD_ALL_ALL\OLD_Comps\Specialist\Sybr_FIFAN\SYABR_SBORKA\Переписка PVV\SYS_PROG\soft_mx_i80\1\";

        string[] dr = null;
        int countOFfiles = 0;
        int countOFfilesA = 0;

        byte[] header = { 0x00, 0x00, 0x00, 0x00, 0xE6 };

        byte[] arrOut = null;

        public byte[] DisplayValues(string fileName)
        {
            // byte HexD = 0;
            long siZee = 0;
            byte[] arrFile = null;

            BinaryReader reader = null;

            try
            {
                if (File.Exists(fileName))
                {
                    reader = new BinaryReader(File.Open(fileName, FileMode.Open));

                    siZee = reader.BaseStream.Length;

                    arrFile = new byte[siZee];

                    for (int x = 0; x < arrFile.Length; x++)
                    {
                        arrFile[x] = reader.ReadByte();
                    }
                }
            }
            catch (Exception exx)
            {
                System.Diagnostics.Debug.WriteLine(exx.Message);
            }
            finally
            {
                if (reader != null)
                {

                    reader.Close();
                }
            }

            return arrFile;
        }

        public int ValuesWrite(byte [] arr, string fileName)
        {
            BinaryWriter writerBt = null;
            int rt = 0;            

            try
            {
                writerBt = new BinaryWriter(File.Open(fileName, FileMode.Create));

                writerBt.Write(arr);

                rt = 1;
            }
            catch (Exception exx)
            {
                rt = 0;
                System.Diagnostics.Debug.WriteLine(exx.Message);
                
            }
            finally
            {
                writerBt.Flush();
            }

            return rt;
        }

        public int ReplaceI80ToRKX(byte[] h, string inflname, string outrkx, string pathOut, string pathIn)
        {
            byte[] arrFile = DisplayValues(pathIn + inflname);
            string hexLbuff = string.Empty;
            int zzz = 0;

            hexLbuff = arrFile.Length.ToString("X");

            if (hexLbuff.Length < 4)
            {
                hexLbuff = hexLbuff + "0";
            }

            h[2] = Convert.ToByte((hexLbuff[2].ToString() + hexLbuff[3].ToString()), 16);
            h[3] = Convert.ToByte((hexLbuff[0].ToString() + hexLbuff[1].ToString()), 16);

            arrOut = new byte[arrFile.Length + 5];

            for (int z = 0; z < h.Length; z++)
            {
                arrOut[z] = h[z];
            }

            int stp = 5; // Index of start file.

            for (int w = 0; w < arrFile.Length; w++)
            {
                arrOut[stp] = arrFile[w];
                stp++;
            }

            zzz = ValuesWrite(arrOut, pathOut + outrkx);         

            return zzz;
        }

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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(41, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(197, 381);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Get List of files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 424);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(277, 27);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(197, 381);
            this.listBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 424);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(277, 424);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Convert to RKX";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 488);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}

