using ProjectPlatoV2.Classes;
using ProjectPlatoV2.Forms.Items.Skins;
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

namespace ProjectPlatoV2.Forms
{
    public partial class Skins : Form
    {
        public Skins()
        {
            InitializeComponent();
        }

        private void Skins_Load(object sender, EventArgs e)
        {
            bunifuImageButton1.Image = null;
            bunifuImageButton2.Image = null;
            bunifuImageButton3.Image = null;
            bunifuImageButton4.Image = null;
            bunifuImageButton5.Image = null;
            bunifuImageButton6.Image = null;
            bunifuImageButton7.Image = null;
            bunifuImageButton8.Image = null;
            bunifuImageButton9.Image = null;
            bunifuImageButton10.Image = null;
            bunifuImageButton11.Image = null;
            bunifuImageButton12.Image = null;
            bunifuImageButton13.Image = null;
            bunifuImageButton14.Image = null;
            bunifuImageButton15.Image = null;
            bunifuImageButton16.Image = null;
            bunifuImageButton17.Image = null;
            bunifuImageButton18.Image = null;
            bunifuImageButton19.Image = null;
            bunifuImageButton20.Image = null;
            bunifuImageButton21.Image = null;
            bunifuImageButton22.Image = null;
            bunifuImageButton23.Image = null;
            bunifuImageButton24.Image = null;
            bunifuImageButton25.Image = null;
            bunifuImageButton26.Image = null;
            bunifuImageButton27.Image = null;
            bunifuImageButton28.Image = null;
            bunifuImageButton29.Image = null;
            bunifuImageButton30.Image = null;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            ReconExpert popup = new ReconExpert();
            popup.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Brawler popup = new Brawler();
            popup.Show();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            EliteAgent popup = new EliteAgent();
            popup.Show();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Dazzle popup = new Dazzle();
            popup.Show();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            Ramirez popup = new Ramirez();
            popup.Show();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            AbsoluteZero popup = new AbsoluteZero();
            popup.Show();
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            SparkleSpecialist popup = new SparkleSpecialist();
            popup.Show();
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            CRenegadeRaiderAssault popup = new CRenegadeRaiderAssault();
            popup.Show();
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            Jonesy popup = new Jonesy();
            popup.Show();
        }

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            TacticsOfficer popup = new TacticsOfficer();
            popup.Show();
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            HeadHunter popup = new HeadHunter();
            popup.Show();
        }

        private void bunifuImageButton12_Click(object sender, EventArgs e)
        {
            Banshee popup = new Banshee();
            popup.Show();
        }

        private void bunifuImageButton18_Click(object sender, EventArgs e)
        {
            if (Settings.Default.paid == true)
            {
                CRenegadeRaiderBlaze popup = new CRenegadeRaiderBlaze();
                popup.Show();
            }
            else
            {
                DarkMessageBoxHelper.DMB("ERROR", "This skin is paid only at the moment, come back next update!");
            }
        }

        private void bunifuImageButton17_Click(object sender, EventArgs e)
        {
            if (Settings.Default.paid == true)
            {
                Renegade popup = new Renegade();
                popup.Show();
            }
            else
            {
                DarkMessageBoxHelper.DMB("ERROR", "This skin is paid only at the moment, come back next update!");
            }
        }

        private void bunifuImageButton16_Click(object sender, EventArgs e)
        {
            if (Settings.Default.paid == true)
            {
                Hawk popup = new Hawk();
                popup.Show();
            }
            else
            {
                DarkMessageBoxHelper.DMB("ERROR", "This skin is paid only at the moment, come back next update!");
            }
        }
    }
}
