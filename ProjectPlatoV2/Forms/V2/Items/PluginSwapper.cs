using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectPlatoV2.Classes;
using ProjectPlatoV2.Classes.Oodle;

namespace ProjectPlatoV2.Forms.V2.Items
{
    public partial class PluginSwapper : Form
    {
        public PluginSwapper()
        {
            InitializeComponent();

            // Need to set this up here so the next item you open doesnt have this items note
            Vars.Note = "";

            var cpObject = JObject.Parse(Vars.Endpoint($"{Vars.BASEENDPOINT}/api/v1/ProjectPlatoV2/items/characterparts"));
            foreach (var file in Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoPlugins"))
            {
                JObject cosmetics = JObject.Parse(File.ReadAllText(file));
                if (cosmetics["name"]?.ToString() == Vars.Item)
                {
                    try
                    {
                        Vars.Early = bool.Parse(cosmetics["early"]?.ToString() ?? string.Empty);
                    }
                    catch
                    {
                        //ignored
                    }

                    try
                    {
                        pictureBox2.ImageLocation = cosmetics["icon"]?.ToString();
                        Vars.Iconurl = pictureBox2.ImageLocation;
                    }
                    catch
                    {
                        // ignored
                    }

                    try
                    {
                        Vars.Note = cosmetics["extrainfo"]?.ToString();
                    }
                    catch
                    {
                        // ignored
                    }

                    try
                    {
                        Vars.Malesearch = cpObject["malesearch"]?.ToString();
                        Vars.Malereplace = cpObject["malereplace"]?.ToString();
                        Vars.Maleasset = cpObject["maleasset"]?.ToString();
                        Vars.Femalesearch = cpObject["femalesearch"]?.ToString();
                        Vars.Femalereplace = cpObject["femalereplace"]?.ToString();
                        Vars.Femaleasset = cpObject["femaleasset"]?.ToString();
                        Vars.Defaultgame = cpObject["defaultgame"]?.ToString();
                        Vars.Bodysearch = cpObject["bodysearch"]?.ToString();
                        Vars.Bodysearchsingle = cpObject["bodysinglesearch"]?.ToString();
                        Vars.Headsearch = cpObject["headsearch"]?.ToString();
                        Vars.Headsearchsingle = cpObject["headsinglesearch"]?.ToString();
                        Vars.LengthSearch = cpObject["lengthsearch"]?.ToString();
                        Vars.LengthReplace = cpObject["lengthreplace"]?.ToString();
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
                

            if (Vars.Note != "" && !string.IsNullOrEmpty(Vars.Note))
            {
                new Alert(Vars.Note, 7, Vars.Iconurl);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            // Close was closing the whole program, but since I close by terming all threads, this should be fine
            Hide();
        }

        private bool _pressed;
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (!_pressed)
                if (Vars.Early && !Vars.IsEarly())
                {
                    new Alert("This item is early access only for the time being!", 7);
                }
                else
                {
                    _pressed = true;
                    richTextBox2.Text = "";
                    richTextBox2.Text += $@"[LOG]: Starting...{Environment.NewLine}";

                    if (Utilities.Disposed)
                    {
                        Utilities.InitProvider(Vars.Aes());
                    }

                    if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                         $"//TAMELYBACKUP//{Vars.Item}"))
                        richTextBox2.Text += @"ERROR: ITEM ALREADY CONVERTED!" + Environment.NewLine;
                    else
                    {
                        foreach (var f1le in Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoPlugins"))
                        {
                            JObject cosmetics = JObject.Parse(File.ReadAllText(f1le));
                            if (cosmetics["name"]?.ToString() == Vars.Item) //Checks if it's the right cosmetic
                                if (cosmetics["type"]?.ToString() == "mesh") //Swapper handles swapping in two ways, mesh and cp
                                {
                                    foreach (var assets in cosmetics["assets"]) //All FModel paths have their own swaps
                                    {
                                        var parentasset = assets["parentasset"]?.ToString();
                                        Utilities.ExportCompressed(parentasset + ".uasset",
                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

                                        string searchtype = null;
                                        foreach (var swap in assets["swaps"])
                                        {
                                            try
                                            {
                                                searchtype = swap["searchtype"]?.ToString();
                                            }
                                            catch { }

                                            switch (searchtype)
                                            {
                                                case "string":
                                                    Utilities.Convert(swap["search"]?.ToString(), swap["replace"]?.ToString(),
                                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                                        assets["parentasset"] + ".uasset", 0);
                                                    richTextBox2.Text += $@"[LOG]: Swapped {swap["type"]}" + Environment.NewLine;
                                                    break;
                                                case "hex":
                                                    Utilities.ConvertHex(swap["search"]?.ToString(), swap["replace"]?.ToString(),
                                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                                        assets["parentasset"] + ".uasset", 0);
                                                    richTextBox2.Text += $@"[LOG]: Swapped {swap["type"]}" + Environment.NewLine;
                                                    break;
                                                default:
                                                    if (swap["search"].Contains("hex="))
                                                    {
                                                        Utilities.ConvertHex(swap["search"]?.ToString().Replace("hex=", ""), swap["replace"]?.ToString().Replace("hex=", ""),
                                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                                            assets["parentasset"] + ".uasset", 0);
                                                    }
                                                    else
                                                    {
                                                        Utilities.Convert(swap["search"]?.ToString(), swap["replace"]?.ToString(),
                                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                                            assets["parentasset"] + ".uasset", 0);
                                                    }
                                                    break;
                                            }
                                        }

                                        try
                                        {
                                            File.Move(
                                                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                                assets["parentasset"] + ".uasset",
                                                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                                "/Temp/" +
                                                Path.GetFileName(assets["parentasset"] + ".uasset"));
                                        }
                                        catch
                                        {
                                            Directory.CreateDirectory(
                                                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                                "/Temp/");
                                            File.Copy(
                                                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                                assets["parentasset"] + ".uasset",
                                                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                                "/Temp/" +
                                                Path.GetFileName(assets["parentasset"] + ".uasset"));
                                        }
                                    }

                                    Directory.CreateDirectory(
                                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                        $"//TAMELYBACKUP//{cosmetics["name"]}");
                                    foreach (var file in Directory.EnumerateFiles(
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                        "//CompressedOutput"))
                                        File.Move(file,
                                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                            $"//TAMELYBACKUP//{cosmetics["name"]}//{Path.GetFileName(file)}");

                                    Directory.Delete(
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/FortniteGame",
                                        true);

                                    foreach (var file in Directory.GetFiles(
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Temp/"))
                                        Oodle.Compress(file, file + ".compressed");

                                    foreach (var assets in cosmetics["assets"])
                                        foreach (var file in Directory.EnumerateFiles(
                                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                            $"//TAMELYBACKUP//{cosmetics["name"]}//"))
                                            if (file.Contains(Path.GetFileName(assets["parentasset"]?.ToString())))
                                            {
                                                var data = File.ReadAllBytes(
                                                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                                    "/Temp/" + Path.GetFileName(assets["parentasset"]?.ToString()) +
                                                    ".uasset.compressed");

                                                var newfile = Path.GetFileName(file);

                                                var asset = newfile.Split(".uasset").First() + ".uasset";
                                                newfile = newfile.Replace(asset + " ", "");

                                                var offset = long.Parse(newfile.Split(" in ").First());
                                                var pakfile = newfile.Split(" in ").Last();
                                                pakfile = pakfile.Replace("10_", "100_");

                                                Utilities.OutdatedResearcher(Vars.PakPath + "//" + pakfile, offset, data);

                                                richTextBox2.Text += @"[LOG]: Added Asset to Fortnite" + Environment.NewLine;
                                            }

                                    Directory.Delete(
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Temp/", true);

                                    new Alert("Successfully Completed!", 3, pictureBox2.ImageLocation);
                                }
                                else
                                {
                                    Utilities.ExportCompressed(Vars.Defaultgame,
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

                                    Utilities.ExportCompressed(Vars.Femaleasset,
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

                                    Utilities.ExportCompressed(Vars.Maleasset,
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

                                    Utilities.ConvertHex(
                                        Vars.Femalesearch,
                                        Vars.Femalereplace,
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                        Vars.Femaleasset, 0);

                                    Utilities.ConvertHex(
                                        Vars.Malesearch,
                                        Vars.Malereplace,
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                        Vars.Maleasset, 0);

                                    Utilities.Convert(
                                        Vars.Bodysearchsingle,
                                        "",
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                        Vars.Defaultgame, 0);

                                    Utilities.Convert(
                                        Vars.Headsearchsingle,
                                        "",
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                        Vars.Defaultgame, 0);
                                    
                                    Utilities.ConvertHex(Vars.LengthSearch,
                                        Vars.LengthReplace,
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                        Vars.Defaultgame, 0);

                                    Utilities.Convert(
                                        Vars.Bodysearch,
                                        cosmetics["bodycp"]?.ToString(),
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                        Vars.Defaultgame, 0);
                                    richTextBox2.Text += "[LOG]: Swapped Body Character Part" + Environment.NewLine;

                                    Utilities.Convert(
                                        Vars.Headsearch,
                                        cosmetics["headcp"]?.ToString(),
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                        Vars.Defaultgame, 0);
                                    richTextBox2.Text += "[LOG]: Swapped Head Character Part" + Environment.NewLine;

                                    try
                                    {
                                        File.Move(
                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                            Vars.Defaultgame,
                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Temp/" +
                                            Path.GetFileName(Vars.Defaultgame));

                                        File.Move(
                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                            Vars.Femaleasset,
                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Temp/" +
                                            Path.GetFileName(Vars.Femaleasset));

                                        File.Move(
                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                            Vars.Maleasset,
                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Temp/" +
                                            Path.GetFileName(Vars.Maleasset));
                                    }
                                    catch
                                    {
                                        Directory.CreateDirectory(
                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Temp/");
                                        File.Move(
                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                            Vars.Defaultgame,
                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Temp/" +
                                            Path.GetFileName(Vars.Defaultgame));

                                        File.Move(
                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                            Vars.Femaleasset,
                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Temp/" +
                                            Path.GetFileName(Vars.Femaleasset));

                                        File.Move(
                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" +
                                            Vars.Maleasset,
                                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Temp/" +
                                            Path.GetFileName(Vars.Maleasset));
                                    }

                                    Directory.CreateDirectory(
                                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                        $"//TAMELYBACKUP//{cosmetics["name"]}");
                                    foreach (var file in Directory.EnumerateFiles(
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                        "//CompressedOutput"))
                                        File.Move(file,
                                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                            $"//TAMELYBACKUP//{cosmetics["name"]}//{Path.GetFileName(file)}");

                                    Directory.Delete(
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/FortniteGame",
                                        true);

                                    foreach (var file in Directory.GetFiles(
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Temp/"))
                                        Oodle.Compress(file, file + ".compressed");


                                    foreach (var file in Directory.EnumerateFiles(
                                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                        $"//TAMELYBACKUP//{cosmetics["name"]}//"))
                                    {
                                        if (file.Contains(Path.GetFileName(Vars.Defaultgame) ?? string.Empty))
                                        {
                                            var data = File.ReadAllBytes(
                                                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                                "/Temp/DefaultGameDataCosmetics.uasset.compressed");

                                            var newfile = Path.GetFileName(file);

                                            var asset = newfile.Split(".uasset").First() + ".uasset";
                                            newfile = newfile.Replace(asset + " ", "");

                                            var offset = long.Parse(newfile.Split(" in ").First());
                                            var pakfile = newfile.Split(" in ").Last();
                                            pakfile = pakfile.Replace("10_", "100_");

                                            Utilities.OutdatedResearcher(Vars.PakPath + "//" + pakfile, offset, data);
                                            richTextBox2.Text += @"[LOG]: Added Asset to Fortnite" + Environment.NewLine;
                                        }

                                        if (file.Contains(Path.GetFileName(Vars.Maleasset) ?? string.Empty))
                                        {
                                            var data = File.ReadAllBytes(
                                                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                                "/Temp/CP_Athena_Body_M_RebirthSoldier.uasset.compressed");

                                            var newfile = Path.GetFileName(file);

                                            var asset = newfile.Split(".uasset").First() + ".uasset";
                                            newfile = newfile.Replace(asset + " ", "");

                                            var offset = long.Parse(newfile.Split(" in ").First());
                                            var pakfile = newfile.Split(" in ").Last();
                                            pakfile = pakfile.Replace("10_", "100_");

                                            Utilities.OutdatedResearcher(Vars.PakPath + "//" + pakfile, offset, data);
                                            richTextBox2.Text += @"[LOG]: Made Male Invalid" + Environment.NewLine;
                                        }

                                        if (file.Contains(Path.GetFileName(Vars.Femaleasset) ?? string.Empty))
                                        {
                                            var data = File.ReadAllBytes(
                                                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                                "/Temp/CP_Body_Commando_F_RebirthDefaultA.uasset.compressed");

                                            var newfile = Path.GetFileName(file);

                                            var asset = newfile.Split(".uasset").First() + ".uasset";
                                            newfile = newfile.Replace(asset + " ", "");

                                            var offset = long.Parse(newfile.Split(" in ").First());
                                            var pakfile = newfile.Split(" in ").Last();
                                            pakfile = pakfile.Replace("10_", "100_");

                                            Utilities.OutdatedResearcher(Vars.PakPath + "//" + pakfile, offset, data);
                                            richTextBox2.Text += @"[LOG]: Made Female Invalid" + Environment.NewLine;
                                        }
                                    }

                                    Directory.Delete(
                                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Temp/",
                                        true);

                                    new Alert("Successfully Completed!", 3, pictureBox2.ImageLocation);
                                }
                        }
                    }
                }

            _pressed = false;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (!_pressed)
                if (Vars.Early && !Vars.IsEarly())
                {
                    new Alert("This item is early access only for the time being!", 7);
                }
                else
                {
                    _pressed = true;
                    richTextBox2.Text = "";
                    richTextBox2.Text += "[LOG]: Starting..." + Environment.NewLine;

                    foreach (var f1le in Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoPlugins"))
                    {
                        JObject cosmetics = JObject.Parse(File.ReadAllText(f1le));
                        if (cosmetics["name"]?.ToString() == Vars.Item)
                        {
                            if (Directory.Exists(
                                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                $"//TAMELYBACKUP//{cosmetics["name"]}//"))
                            {
                                foreach (var file in Directory.EnumerateFiles(
                                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                    $"//TAMELYBACKUP//{cosmetics["name"]}//"))
                                {
                                    long offset;
                                    var data = File.ReadAllBytes(file);

                                    var newfile = Path.GetFileName(file);

                                    var asset = newfile.Split(".uasset").First() + ".uasset";
                                    newfile = newfile.Replace(asset + " ", "");

                                    offset = long.Parse(newfile.Split(" in ").First());
                                    var pakfile = newfile.Split(" in ").Last();
                                    pakfile = pakfile.Replace("10_", "100_");

                                    Utilities.OutdatedResearcher(Vars.PakPath + "//" + pakfile, offset, data);

                                    richTextBox2.Text += @"[LOG]: Removed Asset from Fortnite" + Environment.NewLine;
                                }


                                Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                                 $"//TAMELYBACKUP//{cosmetics["name"]}//", true);
                            }
                            else
                            {
                                richTextBox2.Text += "ERROR: THIS ITEM ISNT CONVERTED" + Environment.NewLine;
                            }
                            new Alert("Successfully Completed!", 3, pictureBox2.ImageLocation);
                        }
                    }
                }

            _pressed = false;
        }

        private void SkinSwapper_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                             "//PlatoConfig//Colors.json")) return;
            dynamic jsonObj = JsonConvert.DeserializeObject(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Colors.json"));
            pictureBox3.BackColor = ColorTranslator.FromHtml(jsonObj["PrimaryColor"].ToString());
            pictureBox2.BackColor = ColorTranslator.FromHtml(jsonObj["PrimaryColor"].ToString());
            pictureBox2.BackColor = ColorTranslator.FromHtml(jsonObj["PrimaryColor"].ToString());
            richTextBox1.BackColor = ColorTranslator.FromHtml(jsonObj["PrimaryColor"].ToString());
            richTextBox2.BackColor = ColorTranslator.FromHtml(jsonObj["PrimaryColor"].ToString());
            BackColor = ColorTranslator.FromHtml(jsonObj["SecondaryColor"].ToString());

        }
    }
}