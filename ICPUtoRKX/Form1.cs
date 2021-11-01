using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dr = Directory.GetFiles(ptt);

                foreach (string currentFile in dr)
                {
                    if (currentFile.Split('\\')[currentFile.Split('\\').Length - 1].Split('.')[1] == "I80")
                    {
                        listBox1.Items.Add(currentFile.Split('\\')[currentFile.Split('\\').Length - 1].ToString());
                        countOFfiles++;
                    }
                    else
                    {
                        if (currentFile.Split('\\')[currentFile.Split('\\').Length - 1].Split('.')[1] == "CPU")
                        {
                            listBox2.Items.Add(currentFile.Split('\\')[currentFile.Split('\\').Length - 1].ToString());
                            countOFfilesA++;
                        }
                    }                    
                }

                label1.Text = countOFfiles.ToString();
                label2.Text = countOFfilesA.ToString();
                button2.Enabled = true;
            }
            catch (Exception exx)
            {
                System.Diagnostics.Debug.WriteLine(exx.Message);
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = string.Empty;
            label2.Text = string.Empty;
            button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int b = 0;
            int f = 0;

            listBox2.Items.Clear();

            if (listBox1.Items.Count > 0)
            {
                foreach (string s in listBox1.Items)
                {
                    b = ReplaceI80ToRKX(header, s, s.Split('.')[0].Replace('_', 'A').Replace('-','A') + ".RKX", pttOut, ptt);

                    if (b == 1)
                    {
                        listBox2.Items.Add("T " + s.Split('.')[0].Replace('_', 'A').Replace('-', 'A') + ".RKX");
                    }
                    else
                    {
                        listBox2.Items.Add("F " + s.Split('.')[0].Replace('_', 'A').Replace('-', 'A') + ".RKX");
                    }

                    f++;
                }

                label2.Text = f.ToString() + " files done";
            }
            else
            {
                label2.Text = "No files!";
            }
        }
    }
}
