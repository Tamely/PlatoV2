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
    public partial class DarkMessageBox : Form
    {
        public DarkMessageBox()
        {
            InitializeComponent();
        }

        private void DarkMessageBox_Load(object sender, EventArgs e)
        {
            Title.Text = Settings.Default.DMBTitle;
            Body.Text = Settings.Default.DMBBody;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (Settings.Default.quit == true)
            {
                Environment.Exit(-1);
            }
            else
            {
                Close();
            }
        }
    }
}
