﻿using ProjectPlatoV2.Classes;
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
    public partial class TatAxe : Form
    {
        public TatAxe()
        {
            InitializeComponent();
            if (Settings.Default.tatcvt == true)
            {
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }

        string Pos = "WID_Hrvest_Pickaxe_Valentines";
        string Mat = "W/Materials/MI";
        string Mat1 = "W/Materi1ls/MI";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "LOG: Starting...\n";
            if (Settings.Default.tatcvt != true)
            {
                // Convert
                Utilities.Convert(Pos, Pos, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.pickaxeoffset);
                Utilities.Convert(Mat, Mat1, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Mat added!";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.tatcvt = true;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.RevertButton;
            }
            else
            {
                // Revert
                Utilities.Revert(Pos, Pos, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.pickaxeoffset);
                Utilities.Revert(Mat, Mat1, Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.current_offset);
                richTextBox1.Text += "LOG: Mat removed!";
                DarkMessageBoxHelper.DMB("Swapping Update", "Done swapping!");
                Settings.Default.tatcvt = false;
                Settings.Default.Save();
                pictureBox1.BackgroundImage = Resources.ConvertButton;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            DarkMessageBoxHelper.DMB("Pickaxe", "This pickaxe swaps frozen heart");
        }
    }
}
