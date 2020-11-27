using ProjectPlatoV2.Classes;
using ProjectPlatoV2.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPlatoV2.Forms
{
    public partial class PakBackupVerify : Form
    {
        public PakBackupVerify()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Backup.RunWorkerAsync();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Verify.RunWorkerAsync();
        }

        private void Verify_DoWork(object sender, DoWorkEventArgs e)
        {
            MessageBox.Show("This might take a while!" , "Starting!");

            if (File.Exists(Settings.Default.pakPath + Settings.Default.bodypak))
            {
                File.Delete(Settings.Default.pakPath + Settings.Default.bodypak);
            }
            File.Copy(Settings.Default.pakPath + "\\temp" + Settings.Default.bodypak, Settings.Default.pakPath + Settings.Default.bodypak);

            if (File.Exists(Settings.Default.pakPath + Settings.Default.headpak))
            {
                File.Delete(Settings.Default.pakPath + Settings.Default.headpak);
            }
            File.Copy(Settings.Default.pakPath + "\\temp" + Settings.Default.headpak, Settings.Default.pakPath + Settings.Default.headpak);

            if (File.Exists(Settings.Default.pakPath + "\\pakchunk10_s17-WindowsClient.ucas"))
            {
                File.Delete(Settings.Default.pakPath + "\\pakchunk10_s17-WindowsClient.ucas");
            }
            File.Copy(Settings.Default.pakPath + "\\temp" + "\\pakchunk10_s17-WindowsClient.ucas", Settings.Default.pakPath + "\\pakchunk10_s17-WindowsClient.ucas");

            if (File.Exists(Settings.Default.pakPath + "\\pakchunk10_s8-WindowsClient.ucas"))
            {
                File.Delete(Settings.Default.pakPath + "\\pakchunk10_s8-WindowsClient.ucas");
            }
            File.Copy(Settings.Default.pakPath + "\\temp" + "\\pakchunk10_s8-WindowsClient.ucas", Settings.Default.pakPath + "\\pakchunk10_s8-WindowsClient.ucas");

            MessageBox.Show("Done verifying!", "Done!");
        }

        private void Backup_DoWork(object sender, DoWorkEventArgs e)
        {
            MessageBox.Show("This might take a while!", "Starting!");

            if (File.Exists(Settings.Default.pakPath + "\\temp" + Settings.Default.bodypak))
            {
                File.Delete(Settings.Default.pakPath + "\\temp" + Settings.Default.bodypak);
            }
            Directory.CreateDirectory(Settings.Default.pakPath + "\\temp");
            File.Copy(Settings.Default.pakPath + Settings.Default.bodypak, Settings.Default.pakPath + "\\temp" + Settings.Default.bodypak);

            if (File.Exists(Settings.Default.pakPath + "\\temp" + Settings.Default.headpak))
            {
                File.Delete(Settings.Default.pakPath + "\\temp" + Settings.Default.headpak);
            }
            File.Copy(Settings.Default.pakPath + Settings.Default.headpak, Settings.Default.pakPath + "\\temp" + Settings.Default.headpak);

            if (File.Exists(Settings.Default.pakPath + "\\temp" + "\\pakchunk10_s17-WindowsClient.ucas"))
            {
                File.Delete(Settings.Default.pakPath + "\\temp" + "\\pakchunk10_s17-WindowsClient.ucas");
            }
            File.Copy(Settings.Default.pakPath + "\\pakchunk10_s17-WindowsClient.ucas", Settings.Default.pakPath + "\\temp" + "\\pakchunk10_s17-WindowsClient.ucas");

            if (File.Exists(Settings.Default.pakPath + "\\temp" + "\\pakchunk10_s8-WindowsClient.ucas"))
            {
                File.Delete(Settings.Default.pakPath + "\\temp" + "\\pakchunk10_s8-WindowsClient.ucas");
            }
            File.Copy(Settings.Default.pakPath + "\\pakchunk10_s8-WindowsClient.ucas", Settings.Default.pakPath + "\\temp" + "\\pakchunk10_s8-WindowsClient.ucas");

            MessageBox.Show("Done backing up!", "Done!");
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
