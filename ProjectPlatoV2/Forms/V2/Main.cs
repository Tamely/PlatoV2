using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectPlatoV2.Classes;
using ProjectPlatoV2.Forms.V2.Items;
using Siticone.UI.WinForms;

namespace ProjectPlatoV2.Forms.V2
{
    public partial class Main : Form
    {
        private static Form _currentChildForm;

        private readonly BackgroundWorker _mover = new();

        private readonly BackgroundWorker _slider1 = new();
        private readonly BackgroundWorker _slider2 = new();
        private readonly BackgroundWorker _slider3 = new();
        private readonly BackgroundWorker _slider4 = new();
        private readonly BackgroundWorker _slider5 = new();
        private string? _file;

        private bool _isdone;

        public Main()
        {
            InitializeComponent();

            var forms = Application.OpenForms.Cast<Form>().Where(f => f.Name == "Login").ToList();

            foreach (var f in forms)
                f.Hide();
            
            Utilities.SetRpcLocation("Dashboard");
            
            var json = JObject.Parse(Vars.Endpoint(Vars.BASEENDPOINT + "/api/v1/ProjectPlatoV2/loading"));

            var processes = Process.GetProcesses();
            var i = processes.Count(process => process.ProcessName.ToLower().Equals("discord"));

            if (i == 0)
            {
                MessageBox.Show("Discord Desktop MUST be open to use the swapper!", "OPEN DISCORD");
                Process.GetCurrentProcess().Kill();
            }

            try
            {
                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//cool"))
                {
                    MessageBox.Show(@"LMFAO YOU TRYNA SKID???");
                    Process.GetCurrentProcess().Kill();
                }

                foreach (var user in json["users"])
                {
                    if (!Utilities.DiscordRpc.CurrentUser.Username.ToLower().Contains(user["id"]?.ToString())) continue;
                    if (!bool.Parse(user["isBanned"].ToString())) continue;
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//cool");
                    File.SetAttributes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//cool",
                        File.GetAttributes(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                           "//cool.json") | FileAttributes.Hidden | FileAttributes.System);
                    MessageBox.Show(@"LMFAO YOU TRYNA SKID???");
                    Process.GetCurrentProcess().Kill();
                }
            }
            catch
            {
            }

            isPaid.Text = Vars.IsEarly() ? "Early Access: True" : "Early Access: False";

            _slider1.DoWork += Slide1;
            _slider2.DoWork += Slide2;
            _slider3.DoWork += Slide3;
            _slider4.DoWork += Slide4;
            _slider5.DoWork += Slide5;
            _mover.DoWork += Backup;

            _slider1.RunWorkerCompleted += OnComplete;
            _slider2.RunWorkerCompleted += OnComplete;
            _slider3.RunWorkerCompleted += OnComplete;
            _slider4.RunWorkerCompleted += OnComplete;
            _slider5.RunWorkerCompleted += OnComplete;
            _mover.RunWorkerCompleted += OnComplete;

            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                      "//PlatoConfig");
        }

        private void OnComplete(object sender, EventArgs e)
        {
            // Added only because program tweaks without it
        }

        private void Slide1(object sender, EventArgs e)
        {
            while (Slider.Location.Y > 35) Slider.Location = new Point(Slider.Location.X, Slider.Location.Y - 1);
        }

        private void Slide2(object sender, EventArgs e)
        {
            while (Slider.Location.Y > 102) Slider.Location = new Point(Slider.Location.X, Slider.Location.Y - 1);

            while (Slider.Location.Y < 102) Slider.Location = new Point(Slider.Location.X, Slider.Location.Y + 1);
        }

        private void Slide3(object sender, EventArgs e)
        {
            while (Slider.Location.Y > 172) Slider.Location = new Point(Slider.Location.X, Slider.Location.Y - 1);

            while (Slider.Location.Y < 172) Slider.Location = new Point(Slider.Location.X, Slider.Location.Y + 1);
        }

        private void Slide4(object sender, EventArgs e)
        {
            while (Slider.Location.Y > 247) Slider.Location = new Point(Slider.Location.X, Slider.Location.Y - 1);

            while (Slider.Location.Y < 247) Slider.Location = new Point(Slider.Location.X, Slider.Location.Y + 1);
        }

        private void Slide5(object sender, EventArgs e)
        {
            while (Slider.Location.Y < 318) Slider.Location = new Point(Slider.Location.X, Slider.Location.Y + 1);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            _slider2.RunWorkerAsync();

            isPaid.Visible = false;
            Flow.Visible = true;
            btnReset.Visible = false;
            searchBox.Visible = false;
            Utilities.SetRpcLocation("Skins");
            Flow.Controls.Clear();


            var pluginlabel = new Label
            {
                Size = new Size(610, 28),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14),
                Text = "Plugin Skins"
            };
            bool onceSkin = false;
            foreach (var file in Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoPlugins"))
            {
                var json = JObject.Parse(File.ReadAllText(file));
                if (!json["itemtype"].ToString().Contains("skin")) continue;
                var imageControl = new SiticonePictureBox
                {
                    Width = 70,
                    Height = 70,
                    Name = json["name"]?.ToString(),
                    Cursor = Cursors.Hand,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                
                
                
                imageControl.Click += pluginOn_Click;
                imageControl.ImageLocation = json["overrideicon"]?.ToString();
                if (!onceSkin)
                {
                    Flow.Controls.Add(pluginlabel);
                    onceSkin = true;
                }
                Flow.Controls.Add(imageControl);
                new ToolTip().SetToolTip(imageControl, imageControl.Name);
            }


            var baselabel = new Label
            {
                Size = new Size(610, 28),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Base Skins"
            };
            Flow.Controls.Add(baselabel);
            var jsonArray = JArray.Parse(Vars.Endpoint(Vars.BASEENDPOINT + "/api/v1/ProjectPlatoV2/items/mainform"));
            foreach (var cosmetics in jsonArray)
            {
                if ((ItemType)int.Parse(cosmetics["type"].ToString()) != ItemType.Character && (ItemType)int.Parse(cosmetics["type"].ToString()) != ItemType.CharacterPart) continue;
                Invoke((MethodInvoker)delegate {
                    var imageControl = new SiticonePictureBox
                    {
                        Width = 70,
                        Height = 70,
                        Name = cosmetics["name"]?.ToString(),
                        Cursor = Cursors.Hand,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    imageControl.Click += buttonOn_Click;
                    imageControl.ImageLocation = cosmetics["icon"]?.ToString();

                    Flow.Controls.Add(imageControl);
                    new ToolTip().SetToolTip(imageControl, imageControl.Name);
                });
                
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            _slider3.RunWorkerAsync();

            isPaid.Visible = false;
            Flow.Visible = true;
            btnReset.Visible = false;
            searchBox.Visible = false;
            Utilities.SetRpcLocation("Backblings");
            Flow.Controls.Clear();

            var pluginlabel = new Label
            {
                Size = new Size(610, 28),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14),
                Text = "Plugin Backblings"
            };
            bool onceBackbling = false;
            foreach (var file in Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoPlugins"))
            {
                var json = JObject.Parse(File.ReadAllText(file));
                if (!json["itemtype"].ToString().Contains("backpack")) continue;
                var imageControl = new SiticonePictureBox
                {
                    Width = 70,
                    Height = 70,
                    Name = json["name"]?.ToString(),
                    Cursor = Cursors.Hand,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                imageControl.Click += pluginOn_Click;
                imageControl.ImageLocation = json["overrideicon"]?.ToString();
                if (!onceBackbling)
                {
                    Flow.Controls.Add(pluginlabel);
                    onceBackbling = true;
                }
                Flow.Controls.Add(imageControl);
                new ToolTip().SetToolTip(imageControl, imageControl.Name);
            }

            var baselabel = new Label
            {
                Size = new Size(610, 28),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14),
                Text = "Base Backblings"
            };
            Flow.Controls.Add(baselabel);


            var jsonArray = JArray.Parse(Vars.Endpoint(Vars.BASEENDPOINT + "/api/v1/ProjectPlatoV2/items/mainform"));
            foreach (var cosmetics in jsonArray)
            {
                if ((ItemType)int.Parse(cosmetics["type"].ToString()) != ItemType.Backpack) continue;
                Invoke((MethodInvoker) delegate
                {
                    var imageControl = new SiticonePictureBox
                    {
                        Width = 70,
                        Height = 70,
                        Name = cosmetics["name"]?.ToString(),
                        Cursor = Cursors.Hand,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    imageControl.Click += buttonOn_Click;
                    imageControl.ImageLocation = cosmetics["icon"]?.ToString();

                    Flow.Controls.Add(imageControl);
                    new ToolTip().SetToolTip(imageControl, imageControl.Name);
                });
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            _slider4.RunWorkerAsync();

            isPaid.Visible = false;
            Flow.Visible = true;
            btnReset.Visible = false;
            searchBox.Visible = false;
            Utilities.SetRpcLocation("Pickaxes");
            Flow.Controls.Clear();

            var pluginlabel = new Label
            {
                Size = new Size(610, 28),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14),
                Text = "Plugin Pickaxes"
            };
            bool oncePickaxe = false;
            foreach (var file in Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoPlugins"))
            {
                var json = JObject.Parse(File.ReadAllText(file));
                if (!json["itemtype"].ToString().Contains("pickaxe")) continue;
                var imageControl = new SiticonePictureBox
                {
                    Width = 70,
                    Height = 70,
                    Name = json["name"]?.ToString(),
                    Cursor = Cursors.Hand,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                imageControl.Click += pluginOn_Click;
                imageControl.ImageLocation = json["overrideicon"]?.ToString();
                if (!oncePickaxe)
                {
                    Flow.Controls.Add(pluginlabel);
                    oncePickaxe = true;
                }
                Flow.Controls.Add(imageControl);
                new ToolTip().SetToolTip(imageControl, imageControl.Name);
            }

            var baselabel = new Label
            {
                Size = new Size(610, 28),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14),
                Text = "Base Pickaxes"
            };
            Flow.Controls.Add(baselabel);

            var jsonArray = JArray.Parse(Vars.Endpoint(Vars.BASEENDPOINT + "/api/v1/ProjectPlatoV2/items/mainform"));
            foreach (var cosmetics in jsonArray)
            {
                if ((ItemType)int.Parse(cosmetics["type"].ToString()) != ItemType.Pickaxe) continue;
                Invoke((MethodInvoker) delegate
                {
                    var imageControl = new SiticonePictureBox
                    {
                        Width = 70,
                        Height = 70,
                        Name = cosmetics["name"]?.ToString(),
                        Cursor = Cursors.Hand,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    imageControl.Click += buttonOn_Click;
                    imageControl.ImageLocation = cosmetics["icon"]?.ToString();

                    Flow.Controls.Add(imageControl);
                    new ToolTip().SetToolTip(imageControl, imageControl.Name);
                });
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            _slider5.RunWorkerAsync();

            isPaid.Visible = false;
            Flow.Visible = true;
            btnReset.Visible = false;
            searchBox.Visible = false;
            Utilities.SetRpcLocation("Emotes");
            Flow.Controls.Clear();

            var pluginlabel = new Label
            {
                Size = new Size(610, 28),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14),
                Text = "Plugin Emotes"
            };
            bool onceEmote = false;
            foreach (var file in Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoPlugins"))
            {
                var json = JObject.Parse(File.ReadAllText(file));
                if (!json["itemtype"].ToString().Contains("emote")) continue;
                var imageControl = new SiticonePictureBox
                {
                    Width = 70,
                    Height = 70,
                    Name = json["name"]?.ToString(),
                    Cursor = Cursors.Hand,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                imageControl.Click += pluginOn_Click;
                imageControl.ImageLocation = json["overrideicon"]?.ToString();
                if (!onceEmote)
                {
                    Flow.Controls.Add(pluginlabel);
                    onceEmote = true;
                }
                Flow.Controls.Add(imageControl);
                new ToolTip().SetToolTip(imageControl, imageControl.Name);
            }

            var baselabel = new Label
            {
                Size = new Size(610, 28),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14),
                Text = "Base Emotes"
            };
            Flow.Controls.Add(baselabel);
            var jsonArray = JArray.Parse(Vars.Endpoint(Vars.BASEENDPOINT + "/api/v1/ProjectPlatoV2/items/mainform"));
            foreach (var cosmetics in jsonArray)
            {
                if ((ItemType)int.Parse(cosmetics["type"].ToString()) != ItemType.Dance) continue;
                Invoke((MethodInvoker) delegate
                {
                    var imageControl = new SiticonePictureBox
                    {
                        Width = 70,
                        Height = 70,
                        Name = cosmetics["name"]?.ToString(),
                        Cursor = Cursors.Hand,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    imageControl.Click += buttonOn_Click;
                    imageControl.ImageLocation = cosmetics["icon"]?.ToString();

                    Flow.Controls.Add(imageControl);
                    new ToolTip().SetToolTip(imageControl, imageControl.Name);
                });
            }
        }

        private void buttonOn_Click(object sender, EventArgs e)
        {
            Vars.Item = ((SiticonePictureBox) sender).Name;
            new Options().Show();
        }

        private void pluginOn_Click(object sender, EventArgs e)
        {
            Vars.Item = ((SiticonePictureBox)sender).Name;
            new PluginSwapper().Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Flow.Controls.Clear();
            isPaid.Visible = true;
            btnReset.Visible = true;
            searchBox.Visible = true;

            _slider1.RunWorkerAsync();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            BackgroundWorker Closer = new();
            Closer.DoWork += Utilities.ClosePrograms;
            
            Closer.RunWorkerAsync();
            
            
            
            
            // These are needed because my VS and Rider say the size are these, but then compile with something completely different
            Size = new Size(730, 450);
            bunifuGradientPanel1.Size = new Size(47, 426);
            Flow.Size = new Size(651, 426);
            btnReset.Size = new Size(156, 36);
            isPaid.Size = new Size(197, 34);

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Colors.json"))
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Colors.json");
            }
            
            dynamic jsonObj = JsonConvert.DeserializeObject(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Colors.json"));
            Flow.BackColor = ColorTranslator.FromHtml(jsonObj["PrimaryColor"].ToString());
            bunifuGradientPanel1.GradientBottomLeft = ColorTranslator.FromHtml(jsonObj["PrimaryColor"].ToString());
            bunifuGradientPanel1.GradientBottomRight = ColorTranslator.FromHtml(jsonObj["PrimaryColor"].ToString());
            bunifuGradientPanel1.GradientTopLeft = ColorTranslator.FromHtml(jsonObj["PrimaryColor"].ToString());
            bunifuGradientPanel1.GradientTopRight = ColorTranslator.FromHtml(jsonObj["PrimaryColor"].ToString());
            searchBox.BackColor = ColorTranslator.FromHtml(jsonObj["PrimaryColor"].ToString());
            isPaid.BackColor = ColorTranslator.FromHtml(jsonObj["PrimaryColor"].ToString());
            BackColor = ColorTranslator.FromHtml(jsonObj["SecondaryColor"].ToString());

            if (!File.Exists("oo2core_5_win64.dll"))
                File.WriteAllBytes("oo2core_5_win64.dll", File.ReadAllBytes(Path.GetFullPath(Path.Combine(Vars.PakPath, @"..\..\")) + "//Binaries//Win64//oo2core_5_win64.dll"));

            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoPlugins");
            var fiiles = "";
            foreach (var file in Directory.GetFiles(Vars.PakPath)) fiiles = fiiles + file;

            if (!fiiles.Contains("pakchunk100_"))
            {
                new Alert("Backing up Fortnite's files! This will take a while...", 20);

                _mover.RunWorkerAsync();

                while (_isdone == false) Task.Delay(500).Wait();
            }

            foreach (var file in Directory.GetFiles(Vars.PakPath))
            {
                if (!file.Contains("pakchunk100_")) continue;
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)))
                    continue;
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "//TAMELYBACKUP" + "/" + Path.GetFileName(file.Replace("100", "10"))))
                {
                    if (file.Contains(".bak")) continue;
                    MessageBox.Show(
                        @"Detected that you have things swapped using Galaxy Swapper! Go into Galaxy Swapper settings and press 'remove duped ucas' then reopen this swapper!",
                        @"ERROR");
                    Process.GetCurrentProcess().Kill();
                }
            }
            
            foreach (var file in Directory.GetFiles(Vars.PakPath))
            {
                if (file.Contains("pakchunk100_"))
                {
                    if (File.Exists(file.Replace("100", "10")))
                    {
                        File.Delete(file.Replace("100", "10"));
                    }
                }
            }
            
            Utilities.InitProvider(Vars.Aes());
        }

        private void Backup(object sender, EventArgs e)
        {
            var jsonOBJ =
                JObject.Parse(Vars.Endpoint(Vars.BASEENDPOINT + "/api/v1/ProjectPlatoV2/loading"));
            foreach (string file in jsonOBJ["paks"])
            {
                if (!File.Exists(Vars.PakPath + "//" + file))
                {
                    MessageBox.Show(
                        @"ERROR: YOU DONT HAVE FORTNITES FILES TO BACKUP! VERIFY YOUR GAME THEN REOPEN THE SWAPPER!",
                        @"ERROR");
                    Process.GetCurrentProcess().Kill();
                }

                if (File.Exists(Vars.PakPath + "/" + file.Replace("pakchunk10", "pakchunk100"))) continue;
                File.Copy(Vars.PakPath + "/" + file,
                    Vars.PakPath + "/" + file.Replace("pakchunk10", "pakchunk100"));
                File.Copy(Vars.PakPath + "/" + file.Split('.').First() + ".pak",
                    Vars.PakPath + "/" + file.Replace("pakchunk10", "pakchunk100").Split('.').First() +
                    ".pak");
                File.Copy(Vars.PakPath + "/" + file.Split('.').First() + ".sig",
                    Vars.PakPath + "/" + file.Replace("pakchunk10", "pakchunk100").Split('.').First() +
                    ".sig");
                File.Copy(Vars.PakPath + "/" + file.Split('.').First() + ".utoc",
                    Vars.PakPath + "/" + file.Replace("pakchunk10", "pakchunk100").Split('.').First() +
                    ".utoc");

                Directory.CreateDirectory(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                    "//TAMELYBACKUP");

                File.Move(Vars.PakPath + "/" + file,
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                    "//TAMELYBACKUP" + "/" + file);
                File.Move(Vars.PakPath + "/" + file.Split('.').First() + ".pak",
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                    "//TAMELYBACKUP" + "/" + file.Split('.').First() + ".pak");
                File.Move(Vars.PakPath + "/" + file.Split('.').First() + ".sig",
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                    "//TAMELYBACKUP" + "/" + file.Split('.').First() + ".sig");
                File.Move(Vars.PakPath + "/" + file.Split('.').First() + ".utoc",
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                    "//TAMELYBACKUP" + "/" + file.Split('.').First() + ".utoc");
            }

            _isdone = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            new Settings().Show();
        }

        string _search = "";
        private void searchTimer_Tick(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                if (_search != searchBox.Text)
                {
                    _search = searchBox.Text;
                    Flow.Controls.Clear();
                    isPaid.Visible = true;
                    btnReset.Visible = true;

                    _slider1.RunWorkerAsync();
                }
            }

            if (searchBox.Text == "" || searchBox.Text.ToLower() == "search") return;
            if (_search != searchBox.Text)
            {
                _search = searchBox.Text;
                isPaid.Visible = false;
                Flow.Visible = true;
                btnReset.Visible = false;
                Utilities.SetRpcLocation("Searching");
                Flow.Controls.Clear();

                var jsonArray = JArray.Parse(Vars.Endpoint(Vars.BASEENDPOINT + "/api/v1/ProjectPlatoV2/items/mainform"));
                foreach (var cosmetics in jsonArray)
                {
                    if (!Utilities.StringRegex(cosmetics["name"]?.ToString()).ToLower().Contains(Utilities.StringRegex(searchBox.Text.ToLower()))) continue;
                    var imageControl = new SiticonePictureBox
                    {
                        Width = 70,
                        Height = 70,
                        Name = cosmetics["name"]?.ToString(),
                        Cursor = Cursors.Hand,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    imageControl.Click += buttonOn_Click;
                    imageControl.ImageLocation = cosmetics["icon"]?.ToString();
                    Flow.Controls.Add(imageControl);
                    new ToolTip().SetToolTip(imageControl, imageControl.Name);
                }
            }
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            searchBox.Text = "";
        }
    }
}