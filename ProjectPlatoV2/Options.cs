using ProjectPlatoV2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPlatoV2.Forms
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "//ProjectPlatoV2");
            Directory.Delete(fileName, true);
            DarkMessageBoxHelper.DMB("Done!", "Config has been reset!");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PakBackupVerify popup = new PakBackupVerify();
            popup.Show();
        }
    }
}
