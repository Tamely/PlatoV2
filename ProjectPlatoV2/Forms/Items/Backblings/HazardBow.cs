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
    public partial class HazardBow : Form
    {
        public HazardBow()
        {
            InitializeComponent();

            if (Settings.Default.hazardcvt == true)
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
            DarkMessageBoxHelper.DMB("Backblings", "This backbling swaps cuddlepool's bow");
        }

        string Pos = "/Game/Accessories/FORT_Backpacks/F_MED_FuzzyBearDonut/Textures/T_F_S";
        string Mat = "]/Game/Accessories/FORT_Backpacks/F_MED_FuzzyBearDonut/";
        string Mat1 = "]/Game/Accessories/FORT_Backpacks/F1MED_FuzzyBearDonut/";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "LOG: Starting...\n";
            if (Settings.Default.hazardcvt != true)
            {
                // Convert
                Utilities.Convert(Pos, Pos, Settings.Default.pakPath + "\\pakchunk10-WindowsClient.ucas", Settings.Default.backblinginvalidoffset);
                Utilities.Convert(Mat, Mat1, Settings.Default.pakPath + "\\pakchunk10-WindowsClient.ucas", Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Mat added!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.hazardcvt = true;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                // Revert
                Utilities.Revert(Pos, Pos, Settings.Default.pakPath + "\\pakchunk10-WindowsClient.ucas", Settings.Default.backblinginvalidoffset);
                Utilities.Revert(Mat, Mat1, Settings.Default.pakPath + "\\pakchunk10-WindowsClient.ucas", Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Mat removed!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.hazardcvt = false;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }
    }
}
