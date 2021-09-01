using System;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using Newtonsoft.Json;
using ProjectPlatoV2.Classes;

namespace ProjectPlatoV2.Forms
{
    public partial class AlertBox : Form
    {
        private long _i;

        public AlertBox()
        {
            InitializeComponent();
        }

        private void AlertBox_Load(object sender, EventArgs e)
        {
            txtInfo.MaximumSize = new Size(214, 0);
            txtInfo.AutoSize = true;

            txtInfo.Text = Vars.Text;
            if (Vars.Imageurl != "") imgInfo.ImageLocation = Vars.Imageurl;


            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Colors.json"))
            {
                File.Move(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Colors.json", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Colors.json");
            }

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                             "//PlatoConfig//Colors.json")) return;
            dynamic jsonObj = JsonConvert.DeserializeObject(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Colors.json"));
            BackColor = ColorTranslator.FromHtml(jsonObj?["PrimaryColor"].ToString());
            txtInfo.BackColor = ColorTranslator.FromHtml(jsonObj?["PrimaryColor"].ToString());
        }

        private void Time_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_i < Vars.Time)
                _i++;
            else
                Close();
        }
    }
}