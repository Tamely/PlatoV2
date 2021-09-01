using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectPlatoV2.Classes;

namespace ProjectPlatoV2.Forms.V2
{
    public partial class Key : Form
    {
        bool _passed = false;
        public Key()
        {
            InitializeComponent();

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Key.txt"))
            {
                string key = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Key.txt");
                if (key != _json["key"]?.ToString())
                {
                    lblError.Visible = true;
                }
            }

            Utilities.OpenBrowser(_json["keyLink"].ToString());
        }

        bool _clicked;

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (_clicked) return;
            _clicked = true;
            textBox1.Text = "";
            textBox1.UseSystemPasswordChar = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        readonly JObject _json = JObject.Parse(Vars.Endpoint(Vars.BASEENDPOINT + "/api/v1/ProjectPlatoV2/loading"));

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            if (textBox1.Text != _json["key"]?.ToString()) return;
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Key.txt", textBox1.Text);
            Hide();
            var open = new Main();
            open.Closed += (_, _) => Close();
            open.Show();
        }

        private void Key_Load(object sender, EventArgs e)
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Colors.json"))
            {
                File.Move(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Colors.json", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Colors.json");
            }

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                             "//PlatoConfig//Colors.json")) return;
            dynamic jsonObj = JsonConvert.DeserializeObject(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Colors.json"));
            panel1.BackColor = ColorTranslator.FromHtml(jsonObj["PrimaryColor"].ToString());
            BackColor = ColorTranslator.FromHtml(jsonObj["SecondaryColor"].ToString());
            
        }
    }
}