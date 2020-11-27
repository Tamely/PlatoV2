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

namespace ProjectPlatoV2.Forms.Items.Misc
{
    public partial class TheOG : Form
    {
        public TheOG()
        {
            InitializeComponent();

            if (Settings.Default.ogcvt == true)
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
            DarkMessageBoxHelper.DMB("Gliders", "This glider swaps cruiser");
        }

        string Mat = "MStreetRacerMI__DNS";
        string Mat1 = "MStre1tRacerMI__DNS";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "LOG: Starting...\n";
            if (Settings.Default.ogcvt != true)
            {
                // Convert
                Utilities.Convert(Mat, Mat1, Settings.Default.pakPath + "\\pakchunk10_s17-WindowsClient.ucas", Settings.Default.gliderinvalidoffset);
                richTextBox1.Text += "LOG: Mat added!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.ogcvt = true;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                // Revert
                Utilities.Revert(Mat, Mat1, Settings.Default.pakPath + "\\pakchunk10_s17-WindowsClient.ucas", Settings.Default.gliderinvalidoffset);
                richTextBox1.Text += "LOG: Mat removed!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.ogcvt = false;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }
    }
}
