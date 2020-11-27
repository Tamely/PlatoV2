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
    public partial class BlackShieldOptions : Form
    {
        public BlackShieldOptions()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BlackShieldOptions_Load(object sender, EventArgs e)
        {
            bunifuImageButton1.Image = null;
            bunifuImageButton2.Image = null;
            bunifuImageButton3.Image = null;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            BlackShieldRedShield popup = new BlackShieldRedShield();
            popup.Show();
            Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            BlackShieldFrozen popup = new BlackShieldFrozen();
            popup.Show();
            Close();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            BlackShieldDark popup = new BlackShieldDark();
            popup.Show();
            Close();
        }
    }
}
