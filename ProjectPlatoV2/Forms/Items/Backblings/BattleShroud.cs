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
    public partial class BattleShroud : Form
    {
        public BattleShroud()
        {
            InitializeComponent();

            if (Settings.Default.battlecvt == true)
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
            DarkMessageBoxHelper.DMB("Backblings", "This backbling swaps molten battle shroud");
        }

        string Mat = "EagleFirMI__Cap";
        string Mat1 = "Eag1eFirMI__Cap";
        string FX = "eEffects/Fort_Characters/Athena_Parts/DrkEagle_Fire_Backpack";
        string FX1 = "eEffects/Fort_Characters/Athena1Parts/DrkEagle_Fire_Backpack";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "LOG: Starting...\n";
            if (Settings.Default.battlecvt != true)
            {
                // Convert
                Utilities.Convert(Mat, Mat1, Settings.Default.pakPath + "\\pakchunk10_s8-WindowsClient.ucas", Settings.Default.backblinginvalidoffset);
                richTextBox1.Text += "LOG: Mat added!\n";
                Utilities.Convert(FX, FX1, Settings.Default.pakPath + "\\pakchunk10_s12-WindowsClient.ucas", Settings.Default.backblinginvalidoffset);
                richTextBox1.Text += "LOG: FX added!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.battlecvt = true;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                // Revert
                Utilities.Revert(Mat, Mat1, Settings.Default.pakPath + "\\pakchunk10_s8-WindowsClient.ucas", Settings.Default.backblinginvalidoffset);
                richTextBox1.Text += "LOG: Mat removed!\n";
                Utilities.Revert(FX, FX1, Settings.Default.pakPath + "\\pakchunk10_s12-WindowsClient.ucas", Settings.Default.backblinginvalidoffset);
                richTextBox1.Text += "LOG: FX removed!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.battlecvt = false;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }
    }
}
