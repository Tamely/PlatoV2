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
    public partial class Jonesy : Form
    {
        public Jonesy()
        {
            InitializeComponent();

            if (Settings.Default.jonesycvt == true)
            {
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }

        string Pos = "B/Game/Athena/Heroes/Meshes/Bodies/CP__Body_M_CubePaintJonesy";
        string Mat = "iM_MED_Commando/Material_COM__JONESY_CUBE";
        string Mat1 = "iM_MED_Commando/Materi1l_COM__JONESY_CUBE";
        string HPos = "R/Game/CharactersParts/Mal/Medium/Heads/CP_Athna__M_CubePaintJonesy";
        string Head = "jBodies/M_MED_Commano_terial_COM__JONESY_CUBE";
        string Head1 = "jBodies/M_MED_Commano_terial_1OM__JONESY_CUBE";
        string GPos = "/Heroes/HID_513ommando_M_CubePaintJonesy";
        string Gender = "LSpecializations/HSu/";
        string Gender1 = "LSpecializations/11u/";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "LOG: Starting...\n";
            if (Settings.Default.jonesycvt != true)
            {
                // Convert
                Utilities.Convert(Pos, Pos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.maleskinsoffset);
                Utilities.Convert(Mat, Mat1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Mat added!\n";
                Utilities.Convert(GPos, GPos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.malegenderoffset);
                Utilities.Convert(Gender, Gender1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Gender added!\n";
                Utilities.Convert(HPos, HPos, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.maleheadoffset);
                Utilities.Convert(Head, Head1, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Head added!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.jonesycvt = true;
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
                Utilities.Revert(Head, Head1, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Head removed!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.jonesycvt = false;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            DarkMessageBoxHelper.DMB("Skins", "This skin swaps assault trooper");
        }
    }
}
