using System;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using ProjectPlatoV2.Classes;
using Siticone.UI.WinForms;

namespace ProjectPlatoV2.Forms.V2.Items
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            var jsonArray = JArray.Parse(Vars.Endpoint($"{Vars.BASEENDPOINT}/api/v1/ProjectPlatoV2/items/possibleswaps?to={Vars.Item}"));
            foreach (var json in jsonArray)
            {
                var imageControl = new SiticonePictureBox
                {
                    Width = 110,
                    Height = 110,
                    Name = json["name"]?.ToString(),
                    Cursor = Cursors.Hand,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                imageControl.Click += buttonOn_Click;
                imageControl.ImageLocation = json["icon"]?.ToString();

                Flow.Controls.Add(imageControl);
                new ToolTip().SetToolTip(imageControl, imageControl.Name);
            }
        }

        private void buttonOn_Click(Object sender, EventArgs e)
        {
            Vars.Item = ((SiticonePictureBox) sender).Name + " to " +  Vars.Item;
            new SkinSwapper().Show();
            Close();
        }
    }
}