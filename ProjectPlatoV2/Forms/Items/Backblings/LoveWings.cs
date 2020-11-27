using ProjectPlatoV2.Classes;
using ProjectPlatoV2.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPlatoV2.Forms.Items.Backblings
{
    public partial class LoveWings : Form
    {
        public LoveWings()
        {
            InitializeComponent();

            if (Settings.Default.lovecvt == true)
            {
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            DarkMessageBoxHelper.DMB("Backblings", "This backbling swaps frozen love wings");
        }

        string Mat = "mWings";
        string Mat1 = "mW1ngs";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "LOG: Starting...\n";
            if (Settings.Default.lovecvt != true)
            {
                // Convert
                Utilities.Convert(Mat, Mat1, Settings.Default.pakPath + "\\pakchunk10_s8-WindowsClient.ucas", Settings.Default.backblinginvalidoffset);
                richTextBox1.Text += "LOG: Mat added!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.lovecvt = true;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                // Revert
                Utilities.Revert(Mat, Mat1, Settings.Default.pakPath + "\\pakchunk10_s8-WindowsClient.ucas", Settings.Default.backblinginvalidoffset);
                richTextBox1.Text += "LOG: Mat removed!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.lovecvt = false;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }
    }
}
