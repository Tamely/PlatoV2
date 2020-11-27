using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectPlatoV2.Classes;
using ProjectPlatoV2.Forms;
using ProjectPlatoV2.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPlatoV2
{
    public partial class Login : Form
    {
        private static string GetEpicDirectory() => Directory.Exists(@"C:\ProgramData\Epic") ? @"C:\ProgramData\Epic" : Directory.Exists(@"D:\ProgramData\Epic") ? @"D:\ProgramData\Epic" : Directory.Exists(@"E:\ProgramData\Epic") ? @"E:\ProgramData\Epic" : @"F:\ProgramData\Epic";
        private static bool DatFileExists() => File.Exists($@"{GetEpicDirectory()}\UnrealEngineLauncher\LauncherInstalled.dat");
        public Login()
        {
            InitializeComponent();
        }

        long ChangingVersion = 3;

    private void Login_Load(object sender, EventArgs e)
        {

            foreach (Process process in Process.GetProcessesByName("EpicGamesLauncher"))
            {
                process.Kill();
            }
            foreach (Process process2 in Process.GetProcessesByName("FortniteClient-Win64-Shipping_BE"))
            {
                process2.Kill();
            }
            foreach (Process process3 in Process.GetProcessesByName("FortniteClient-Win64-Shipping_EAC"))
            {
                process3.Kill();
            }
            foreach (Process process4 in Process.GetProcessesByName("FortniteClient-Win64-Shipping"))
            {
                process4.Kill();
            }
            foreach (Process process5 in Process.GetProcessesByName("FortniteLauncher"))
            {
                process5.Kill();
            }
            foreach (Process process6 in Process.GetProcessesByName("BEService"))
            {
                process6.Kill();
            }
            foreach (Process process7 in Process.GetProcessesByName("EasyAntiCheat"))
            {
                process7.Kill();
            }



            Utilities.Hosts();



            WebClient webClient = new WebClient();
            string json = webClient.DownloadString("MYAPILINK");
            JObject jobject = JObject.Parse(json);
            string key = jobject["Content"]["Key"].ToString();
            string version = jobject["Content"]["Version"].ToString();
            string fso = jobject["Content"]["femaleskinsoffset"].ToString();
            string fgo = jobject["Content"]["femalegenderoffset"].ToString();
            string fho = jobject["Content"]["femaleheadsoffset"].ToString();
            string mso = jobject["Content"]["maleskinsoffset"].ToString();
            string mgo = jobject["Content"]["malegenderoffset"].ToString();
            string mho = jobject["Content"]["maleheadoffset"].ToString();
            string bio = jobject["Content"]["backblinginvalidoffset"].ToString();
            string po = jobject["Content"]["pickaxeoffset"].ToString();
            string news = jobject["Content"]["news"].ToString();
            string glider = jobject["Content"]["gliderinvalidoffset"].ToString();
            string headpak = jobject["Content"]["headpak"].ToString();
            string bodypak = jobject["Content"]["bodypak"].ToString();

            Settings.Default.key = key;
            Settings.Default.version = long.Parse(version);
            Settings.Default.news = news;

            Settings.Default.femaleskinsoffset = long.Parse(fso);
            Settings.Default.femalegenderoffset = long.Parse(fgo);
            Settings.Default.femaleheadsoffset = long.Parse(fho);

            Settings.Default.maleskinsoffset = long.Parse(mso);
            Settings.Default.malegenderoffset = long.Parse(mgo);
            Settings.Default.maleheadoffset = long.Parse(mho);

            Settings.Default.backblinginvalidoffset = long.Parse(bio);
            Settings.Default.pickaxeoffset = long.Parse(po);
            Settings.Default.gliderinvalidoffset = long.Parse(glider);

            Settings.Default.bodypak = bodypak;
            Settings.Default.headpak = headpak;

            Settings.Default.Save();



            Updater.CheckForUpdate(ChangingVersion);



            if (DatFileExists())
            {
                string jsonData = File.ReadAllText($@"{GetEpicDirectory()}\UnrealEngineLauncher\LauncherInstalled.dat");
                if (Utilities.IsValidJson(jsonData))
                {
                    JToken FortnitePath = JsonConvert.DeserializeObject<JToken>(jsonData);
                    if (FortnitePath != null)
                    {
                        JArray installationListArray = FortnitePath["InstallationList"].Value<JArray>();
                        if (installationListArray != null)
                        {
                            foreach (JToken FortnitePathReal in installationListArray)
                            {
                                if (string.Equals(FortnitePathReal["AppName"].Value<string>(), "Fortnite"))
                                {
                                    string path = $@"{FortnitePathReal["InstallLocation"].Value<string>()}\FortniteGame\Content\Paks";
                                    Settings.Default.pakPath = path;
                                    Settings.Default.Save();
                                }
                            }
                        }
                    }
                }
            }

            // Sets The Text The Setting

            if (Settings.Default.UsernameStr != "") // checks if the setting isn't empty, if it is, it'll stay on username and password
            {
                Username.Text = Settings.Default.UsernameStr;
            }
            if (Settings.Default.PasswordStr != "")
            {
                Password.Text = Settings.Default.PasswordStr;
            }

            if(Password.Text != "Password")
            {
                Password.UseSystemPasswordChar = true;
            }
        }

        private void Username_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.UserClicked == false) // Checks if it's been clicked before
            {
                Settings.Default.UserClicked = true;
                Username.Text = "";
            }
        }

        private void Password_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.PassClicked == false) // Checks if it's been clicked before
            {
                Settings.Default.PassClicked = true;
                Password.UseSystemPasswordChar = true;
                Password.Text = "";
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Makes Settings The Text
            Settings.Default.UsernameStr = Username.Text;
            Settings.Default.PasswordStr = Password.Text;


            string username;
            string password;

            username = Username.Text;
            password = Password.Text;

            if (Username.Text == "Username" || Username.Text == "") // Lets you in if you are not paid
            {
                Key popup = new Key();
                popup.Show();
                Settings.Default.paid = false;
                Process.Start("https://discord.gg/MeEZXspk65");
            }

            if (API.Login(Username.Text, Password.Text)) // Checks if it is correct info
            {
                Key popup = new Key();
                popup.Show();
                Settings.Default.paid = true;
                Settings.Default.Save();
                Process.Start("https://discord.gg/MeEZXspk65");
            }
        }
    }
}
