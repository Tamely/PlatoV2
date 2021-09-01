using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectPlatoV2.Classes;
using ProjectPlatoV2.Forms.V2;

namespace ProjectPlatoV2.Forms
{
    public partial class Loader : Form
    {
        private byte _holder;

        public Loader()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            Utilities.DiscordRpc.Initialize();
            Utilities.SetRpcLocation("Loader");
            //Utilities.ClosePrograms();
            timer1.Start();

            try
            {
                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Temp"))
                    Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Temp");
            }
            catch
            {
                // ignored
            }

            if (File.Exists("NewAPI.json"))
                Vars.Prod = true;

            try // test if it can connect to the API
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString("https://tamely.tk/api/v1.html");
                JObject.Parse(json);
            }
            catch
            {
                MessageBox.Show(
                    @"Could not establish an active connection to the internet. Please restart the swapper.", @"ERROR");
                Process.GetCurrentProcess().Kill();
            }
        }

        private static bool DatFileExists()
        {
            return File.Exists($@"{GetEpicDirectory()}\UnrealEngineLauncher\LauncherInstalled.dat");
        }

        private static string GetEpicDirectory()
        {
            return Directory.Exists(@"C:\ProgramData\Epic") ? @"C:\ProgramData\Epic" :
                Directory.Exists(@"D:\ProgramData\Epic") ? @"D:\ProgramData\Epic" :
                Directory.Exists(@"E:\ProgramData\Epic") ? @"E:\ProgramData\Epic" : @"F:\ProgramData\Epic";
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void timer1_Tick(object sender, EventArgs e)
        {
            _holder += 4;
            var adv = new List<string> {".", "..", "..."};
            var random = new Random();
            var i = random.Next(adv.Count);
            var strg = adv[i];
            label1.Text = @"Getting data from Plato's API" + strg;
            label2.Text = _holder + @"%";
            if (_holder != 100) return;
            timer1.Enabled = false;
            Hide();

            JObject json = JObject.Parse(new WebClient().DownloadString(Vars.BASEENDPOINT + "/api/v1/ProjectPlatoV2/blacklistedprograms"));
            foreach (var obj in json["blacklistedPrograms"])
                Utilities.Programs.Add(obj.ToString());

            json = JObject.Parse(Vars.Endpoint(Vars.BASEENDPOINT + "/api/v1/ProjectPlatoV2/loading"));
            Utilities.OpenBrowser(Vars.DiscordLink);
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Key.txt"))
            {
                string key = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Key.txt");
                if (key == json["key"]?.ToString())
                {
                    var open = new Main();
                    open.Closed += (_, _) => Close();
                    open.Show();
                }
                else
                {
                    var open = new Key();
                    open.Closed += (_, _) => Close();
                    open.Show();
                }
            }
            else
            {
                if (Vars.IsEarly())
                {
                    var open = new Main();
                    open.Closed += (_, _) => Close();
                    open.Show();
                }
                else
                {
                    var open = new Key();
                    open.Closed += (_, _) => Close();
                    open.Show();
                }
            }
        }

        private void Loader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        readonly dynamic _jSon = JObject.Parse(Vars.Endpoint(Vars.BASEENDPOINT + "/api/v1/ProjectPlatoV2/loading"));
        
        public string JSON = "{" + Environment.NewLine + 
                "\"PrimaryColor\": \"#27293d\"," + Environment.NewLine +
            "\"SecondaryColor\": \"#1e1e29\"" + Environment. NewLine +
            "}";

        private void Loader_Load(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcesses())
            {
                if (process.ProcessName.ToLower().Contains("epic") ||
                    process.ProcessName.ToLower().Contains("fortnite") ||
                    process.ProcessName.ToLower().Replace(" ", "").Contains("easyanti") ||
                    process.ProcessName.ToLower().Replace(" ", "").Contains("battleeye"))
                {
                    process.Kill();
                }
            }
            
            
            List<string> Programs = new();
            foreach (var processs in JObject.Parse(
                new WebClient().DownloadString(
                    Vars.BASEENDPOINT + "/api/v1/ProjectPlatoV2/blacklistedprograms")))
                        Programs.Add(processs.ToString());
            foreach (var proce in Process.GetProcesses())
                foreach (var process in Programs.Where(process => proce.ProcessName.ToLower().Contains(process)))
                {
                    Process.GetProcessById(proce.Id).Kill();
                    Process.GetCurrentProcess().Kill();
                }


            if ((int) _jSon.version > Vars.Version)
            {
                MessageBox.Show(@"There is an update available, please download it from the Discord!", "New Update!");
                Utilities.OpenBrowser(JObject.Parse(new WebClient().DownloadString(Vars.BASEENDPOINT))["discordServer"].ToString());
                Process.GetCurrentProcess().Kill();
            }

            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig");
            try
            {
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Colors.json"))
                {
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Colors.json", JSON);
                }
            }
            catch
            {
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Colors.json", JSON);
            }


            if (!DatFileExists()) return;
            var jsonData = File.ReadAllText($@"{GetEpicDirectory()}\UnrealEngineLauncher\LauncherInstalled.dat");
            if (!Utilities.IsValidJson(jsonData)) return;
            var fortnitePath = JsonConvert.DeserializeObject<JToken>(jsonData);
            var installationListArray = (fortnitePath["InstallationList"] ?? null).Value<JArray>();
            if (installationListArray == null) return;
            foreach (var fortnitePathReal in installationListArray)
                if (string.Equals((fortnitePathReal["AppName"] ?? null).Value<string>(), "Fortnite"))
                {
                    var path =
                        $@"{(fortnitePathReal["InstallLocation"] ?? null).Value<string>()}\FortniteGame\Content\Paks";
                    Vars.PakPath = path;
                }
            
            
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Version.txt"))
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Version.txt" , Utilities.GetVersion);
            else
            if (File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                 "//PlatoConfig//Version.txt") != Utilities.GetVersion)
            {
                new Alert(
                    "Fortnite has been updated since the last backup! Deleting swapper files so it can work on the latest update!");
                foreach (var file in Directory.GetFiles(Vars.PakPath))
                    if (file.Contains("pakchunk100_"))
                        File.Delete(file);

                Directory.Delete(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                    "//TAMELYBACKUP", true);
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Version.txt" , Utilities.GetVersion);
            }
        }
    }
}