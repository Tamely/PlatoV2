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
    public partial class Hawk : Form
    {
        public Hawk()
        {
            InitializeComponent();

            if (Settings.Default.hawkcvt == true)
            {
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }

        string Pos = "/Game/Athena/Heroes/Meshes/Bodies/CP_009__Body";
        string Mat = "dSkins/TV_32/aterial_TV32";
        string Mat1 = "dSkins/TV_32/a1erial_TV32";
        string GPos = "/Heroes/HID_009ommando_M";
        string Gender = "<Specializs/HSU";
        string Gender1 = "<Specializs/HFU";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "LOG: Starting...\n";
            if (Settings.Default.hawkcvt != true)
            {
                // Convert
                Utilities.Convert(Pos, Pos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.maleskinsoffset);
                Utilities.Convert(Mat, Mat1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Mat added!\n";
                Utilities.Convert(GPos, GPos, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.malegenderoffset);
                Utilities.Convert(Gender, Gender1, Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Gender added!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.hawkcvt = true;
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
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.hawkcvt = false;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }
    }
}
