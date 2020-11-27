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

namespace ProjectPlatoV2.Forms
{
    public partial class Key : Form
    {
        public Key()
        {
            InitializeComponent();
        }

        private void Username_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.KeyClicked == false) // Checks if it's been clicked before
            {
                Settings.Default.KeyClicked = true;
                PassKey.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Settings.Default.KeyClicked = false;
            if(PassKey.Text == Settings.Default.key)
            {
                Home popup = new Home();
                popup.Show();

                if (Settings.Default.paid == true)
                {
                    DarkMessageBoxHelper.DMB("Success", "Successfully logged in as paid user. Have fun swapping!");
                }
                else
                {
                    DarkMessageBoxHelper.DMB("Success", "Successfully logged in as free user. Have fun swapping!");
                }
                Close();
            }
            else
            {
                DarkMessageBoxHelper.DMB("ERROR", "Entered key is incorrect, try again!");
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
