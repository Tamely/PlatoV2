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
    public partial class BlackShieldRedShield : Form
    {
        public BlackShieldRedShield()
        {
            InitializeComponent();

            if (Settings.Default.redblackcvt == true)
            {
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }

        string Mat = "Male_CommandoBR_knightV01";
        string Mat1 = "Male_Com1andoBR_knightV01";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "LOG: Starting...\n";
            if (Settings.Default.redblackcvt != true)
            {
                // Convert
                Utilities.Convert(Mat, Mat1, Settings.Default.pakPath + "\\pakchunk10_s1-WindowsClient.ucas", Settings.Default.backblinginvalidoffset);
                richTextBox1.Text += "LOG: Mat added!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.redblackcvt = true;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                // Revert
                Utilities.Revert(Mat, Mat1, Settings.Default.pakPath + "\\pakchunk10_s1-WindowsClient.ucas", Settings.Default.backblinginvalidoffset);
                richTextBox1.Text += "LOG: Mat removed!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.redblackcvt = false;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            DarkMessageBoxHelper.DMB("Backblings", "This backbling swaps red shield");
        }
    }
}
