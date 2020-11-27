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
    public partial class AbsoluteZero : Form
    {
        public AbsoluteZero()
        {
            InitializeComponent();

            if (Settings.Default.absolutecvt == true)
            {
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }

        string Pos = "/Game/Athena/Heroes/Meshes/Bodies/CP_026__Body";
        string Mat = "Skins/TV_16/aterial_TV16";
        string Mat1 = "Skins/BR_03/aterial_BR03";
        string GPos = "/Heroes/HID_026ommando_M";
        string Gender = "Specializs/HSU";
        string Gender1 = "Specializs/H11";
        string HPos = "_M_Commando_05_V01";
        string Hat = "_M_Commando_06";
        string Hat1 = "_M_Commando_08";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "LOG: Starting...\n";
            if (Settings.Default.absolutecvt != true)
            {
                // Convert
                Utilities.Convert(Pos, Pos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.maleskinsoffset);
                Utilities.Convert(Mat, Mat1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Mat added!\n";
                Utilities.Convert(GPos, GPos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.malegenderoffset);
                Utilities.Convert(Gender, Gender1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Gender added!\n";
                Utilities.Convert(HPos, HPos, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.maleheadoffset);
                Utilities.Convert(Hat, Hat1, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Hat added!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.absolutecvt = true;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                // Revert
                Utilities.Revert(Pos, Pos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.maleskinsoffset);
                Utilities.Revert(Mat, Mat1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Mat removed!\n";
                Utilities.Revert(GPos, GPos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.malegenderoffset);
                Utilities.Revert(Gender, Gender1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Gender removed!\n";
                Utilities.Revert(HPos, HPos, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.maleheadoffset);
                Utilities.Revert(Hat, Hat1, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Hat removed!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.absolutecvt = false;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            DarkMessageBoxHelper.DMB("Skins", "This skin swaps desperado");
        }
    }
}
