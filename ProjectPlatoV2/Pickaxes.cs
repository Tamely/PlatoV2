using ProjectPlatoV2.Forms.Items.Pickaxes;
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
    public partial class Pickaxes : Form
    {
        public Pickaxes()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            CrimsonAxe popup = new CrimsonAxe();
            popup.Show();
        }

        private void Pickaxes_Load(object sender, EventArgs e)
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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            SkullySplitter popup = new SkullySplitter();
            popup.Show();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            CandyAxe popup = new CandyAxe();
            popup.Show();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            TatAxe popup = new TatAxe();
            popup.Show();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            IronBeak popup = new IronBeak();
            popup.Show();
        }
    }
}
