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

namespace ProjectPlatoV2.Forms.Items.Skins
{
    public partial class CRenegadeRaiderBlaze : Form
    {
        public CRenegadeRaiderBlaze()
        {
            InitializeComponent();

            if (Settings.Default.renegadeblazecvt == true)
            {
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }

        string Pos = "E/Game/Athena/Heroes/Meshes/Bodies/CP__Body_F_RenegadeRaiderFire";
        string Mat = "tF_MED__/Materials/MI_";
        string Mat1 = "tF_MED__/Materi1ls/MI_";
        string FX = "lEffects/Fort_Parts/CCPM";
        string FX1 = "lEffects/For1_Parts/CCPM";
        string HPos = "PParts/Femal/Medum/Heads/CP__F_RengadeRaidrFire";
        string HMat = "F_MED__/Materials/MI__";
        string HMat1 = "F_MED__/Ma1erials/MI__";
        string HatPos = "hCP_Hat_FN";
        string HatMat = "/Materials/MI_";
        string HatMat1 = "/Mater1als/MI_";
        string GPos = "/Heroes/HID_784ommando_F_RenegadeRiderFre";
        string Gender = "OSpecializs/HS";
        string Gender1 = "OSpecializs/HF";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "LOG: Starting...\n";
            if (Settings.Default.renegadeblazecvt != true)
            {
                // Convert
                Utilities.Convert(Pos, Pos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.femaleskinsoffset);
                Utilities.Convert(Mat, Mat1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Mat added!\n";
                Utilities.Convert(FX, FX1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: FX added!\n";
                Utilities.Convert(GPos, GPos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.femalegenderoffset);
                Utilities.Convert(Gender, Gender1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Gender added!\n";
                Utilities.Convert(HPos, HPos, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.femaleheadsoffset);
                Utilities.Convert(HMat, HMat1, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Head added!\n";
                Utilities.Convert(HatPos, HatPos, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.femaleheadsoffset);
                Utilities.Convert(HatMat, HatMat1, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Hat added!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.renegadeblazecvt = true;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                // Revert
                Utilities.Revert(Pos, Pos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.femaleskinsoffset);
                Utilities.Revert(Mat, Mat1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Mat removed!\n";
                Utilities.Revert(FX, FX1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: FX removed!\n";
                Utilities.Revert(GPos, GPos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.femalegenderoffset);
                Utilities.Revert(Gender, Gender1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Gender removed!\n";
                Utilities.Revert(HPos, HPos, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.femaleheadsoffset);
                Utilities.Revert(HMat, HMat1, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Head removed!\n";
                Utilities.Revert(HatPos, HatPos, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.femaleheadsoffset);
                Utilities.Revert(HatMat, HatMat1, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Hat removed!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.renegadeblazecvt = false;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            DarkMessageBoxHelper.DMB("Skins", "This skin swaps blaze");
        }
    }
}
