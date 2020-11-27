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

namespace ProjectPlatoV2.Forms.Items.Pickaxes
{
    public partial class CandyAxe : Form
    {
        public CandyAxe()
        {
            InitializeComponent();
            if (Settings.Default.candycvt == true)
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
            DarkMessageBoxHelper.DMB("Pickaxe", "This pickaxe swaps minty");
        }

        string Pos = "WID_Hrvest_Pickaxe_CandyCane";
        string Mat = "IMaterias/MI";
        string Mat1 = "IMateri1s/MI";
        string FX = "/FX/Pdle_FX";
        string FX1 = "/FX/P1le_FX";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "LOG: Starting...\n";
            if (Settings.Default.candycvt != true)
            {
                // Convert
                Utilities.Convert(Pos, Pos, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.pickaxeoffset);
                Utilities.Convert(FX, FX1, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: FX added!\n";
                Utilities.Convert(Mat, Mat1, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Mat added!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.candycvt = true;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                // Revert
                Utilities.Revert(Pos, Pos, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.pickaxeoffset);
                Utilities.Revert(FX, FX1, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: FX removed!\n";
                Utilities.Revert(Mat, Mat1, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Mat removed!\n";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.candycvt = false;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }
    }
}
