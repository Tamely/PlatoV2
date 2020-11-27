using ProjectPlatoV2.Classes;
using ProjectPlatoV2.Forms.Items;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private Form currentChildForm;

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void Home_Load(object sender, EventArgs e)
        {
            List<Form> forms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                if (f.Name == "Login")
                    forms.Add(f);

            foreach (Form f in forms)
                f.Hide();

            OpenChildForm(new Dashboard());

            Settings.Default.newsbool = false;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DarkMessageBoxHelper.DMB("Tamely#9111", "Tamely made this swapper, hope you enjoy it!");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.Skins_ClickedIcon;
            pictureBox4.BackgroundImage = Properties.Resources.BackBlings_Icon;
            pictureBox5.BackgroundImage = Properties.Resources.Pickaxes_Icon;
            pictureBox6.BackgroundImage = Properties.Resources.Misc_Icon;
            pictureBox7.BackgroundImage = Properties.Resources.Settings_Icon;

            OpenChildForm(new Skins());
            PlatoRPC.SetDiscordAction("| In The Skins Tab |");

            if(Settings.Default.newsbool == false)
            {
                Utilities.News(Settings.Default.news);
                Settings.Default.newsbool = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.Skins_Icon;
            pictureBox4.BackgroundImage = Properties.Resources.BackBlings_ClickedIcon;
            pictureBox5.BackgroundImage = Properties.Resources.Pickaxes_Icon;
            pictureBox6.BackgroundImage = Properties.Resources.Misc_Icon;
            pictureBox7.BackgroundImage = Properties.Resources.Settings_Icon;

            OpenChildForm(new Backblings());
            PlatoRPC.SetDiscordAction("| In The Backblings Tab |");

            if (Settings.Default.newsbool == false)
            {
                Utilities.News(Settings.Default.news);
                Settings.Default.newsbool = true;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.Skins_Icon;
            pictureBox4.BackgroundImage = Properties.Resources.BackBlings_Icon;
            pictureBox5.BackgroundImage = Properties.Resources.Pickaxes_ClickedIcon;
            pictureBox6.BackgroundImage = Properties.Resources.Misc_Icon;
            pictureBox7.BackgroundImage = Properties.Resources.Settings_Icon;

            OpenChildForm(new Pickaxes());
            PlatoRPC.SetDiscordAction("| In The Pickaxes Tab |");

            if (Settings.Default.newsbool == false)
            {
                Utilities.News(Settings.Default.news);
                Settings.Default.newsbool = true;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.Skins_Icon;
            pictureBox4.BackgroundImage = Properties.Resources.BackBlings_Icon;
            pictureBox5.BackgroundImage = Properties.Resources.Pickaxes_Icon;
            pictureBox6.BackgroundImage = Properties.Resources.Misc_ClickedIcon;
            pictureBox7.BackgroundImage = Properties.Resources.Settings_Icon;

            OpenChildForm(new Extra());
            PlatoRPC.SetDiscordAction("| In The Misc Tab |");

            if (Settings.Default.newsbool == false)
            {
                Utilities.News(Settings.Default.news);
                Settings.Default.newsbool = true;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.Skins_Icon;
            pictureBox4.BackgroundImage = Properties.Resources.BackBlings_Icon;
            pictureBox5.BackgroundImage = Properties.Resources.Pickaxes_Icon;
            pictureBox6.BackgroundImage = Properties.Resources.Misc_Icon;
            pictureBox7.BackgroundImage = Properties.Resources.Settings_ClickedIcon;

            OpenChildForm(new Options());
            PlatoRPC.SetDiscordAction("| In The Settings Tab |");

            if (Settings.Default.newsbool == false)
            {
                Utilities.News(Settings.Default.news);
                Settings.Default.newsbool = true;
            }
        }
    }
}
