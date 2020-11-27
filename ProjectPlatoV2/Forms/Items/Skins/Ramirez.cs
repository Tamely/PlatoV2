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
    public partial class Ramirez : Form
    {
        public Ramirez()
        {
            InitializeComponent();

            if (Settings.Default.ramirezcvt == true)
            {
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }

        string Pos = "/Game/Athena/Heroes/Meshes/Bodies/CP_029__Body_Hallowen";
        string Mat = "gSkins/HWaterialED_Cmmando_HW01";
        string Mat1 = "gSkins/CMaterialED_Cmmando_CM01";
        string HPos = "/Game/Athena/Heroes/Meshes/Heads/F_Med_HIS_Ramirez__HW01_ATH";
        string Hair = "aPlayer/Female/Medium01/Materials/ED_Commando_";
        string Hair1 = "aPlayer/Female/Medium01/Materials/ED_Co1mando_";
        string GPos = "/Heroes/HID_029ommando_F_Halloween";
        string Gender = "FSpecializs/HSi";
        string Gender1 = "FSpecializs/H11";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "LOG: Starting...\n";
            if (Settings.Default.ramirezcvt != true)
            {
                // Convert
                Utilities.Convert(Pos, Pos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.femaleskinsoffset);
                Utilities.Convert(Mat, Mat1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Mat added!\n";
                Utilities.Convert(GPos, GPos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.femalegenderoffset);
                Utilities.Convert(Gender, Gender1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Gender added!\n";
                Utilities.Convert(HPos, HPos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.femaleskinsoffset);
                Utilities.Convert(Hair, Hair1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Hair added!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.ramirezcvt = true;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                // Revert
                Utilities.Revert(Pos, Pos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.femaleskinsoffset);
                Utilities.Revert(Mat, Mat1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Mat removed!\n";
                Utilities.Revert(GPos, GPos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.femalegenderoffset);
                Utilities.Revert(Gender, Gender1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Gender removed!\n";
                Utilities.Revert(HPos, HPos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.femaleskinsoffset);
                Utilities.Revert(Hair, Hair1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Hair removed!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.ramirezcvt = false;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            DarkMessageBoxHelper.DMB("Skins", "This skin swaps ghoul trooper");
        }
    }
}
