using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using ProjectPlatoV2.Classes;

namespace ProjectPlatoV2.Forms.V2
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            fnPath.Text = $@"Fortnite Path: {Vars.PakPath.Replace(@"\FortniteGame\Content\Paks", "")}";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Colors.json"))
            {
                dynamic? jsonObj = JsonConvert.DeserializeObject(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Colors.json"));

                if (jsonObj != null && (jsonObj["PrimaryColor"] != SecHex.Text || jsonObj["SecondaryColor"] != PrimHex.Text))
                    MessageBox.Show(@"Most color changes will require a restart!");

                if (jsonObj != null)
                {
                    jsonObj["PrimaryColor"] = SecHex.Text;
                    jsonObj["SecondaryColor"] = PrimHex.Text;
                    string output =
                        JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Colors.json");
                    File.WriteAllText(
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoConfig//Colors.json", output);
                }
            }
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            Utilities._provider.Dispose();
            foreach (var file in Directory.GetFiles(Vars.PakPath))
                if (file.Contains("pakchunk100_"))
                    File.Delete(file);

            foreach (var file in Directory.GetFiles(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "//TAMELYBACKUP"))
                File.Move(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "//TAMELYBACKUP" + "/" +
                    Path.GetFileName(file), Vars.PakPath + "/" + Path.GetFileName(file));

            Directory.Delete(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                "//TAMELYBACKUP", true);

            new Alert("Swaps reverted! You won't be able to swap anything until you restart the swapper!", 3);
        }

        string _items = "";

        private void btnSwapped_Click(object sender, EventArgs e)
        {
            foreach (var dir in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "//TAMELYBACKUP"))
            {
                _items += Path.GetFileName(dir) + Environment.NewLine;
            }

            MessageBox.Show(_items, @"Currently Swapped Items");
        }

        private void PrimR_TextChanged(object sender, EventArgs e)
        {
            if (ColorsWork())
            {
                var myColor = Color.FromArgb(int.Parse(PrimR.Text), int.Parse(PrimG.Text), int.Parse(PrimB.Text));
                PrimHex.Text = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
            }

            try
            {
                BackColor = ColorTranslator.FromHtml(PrimHex.Text);
                SecHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox5.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox7.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox8.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox9.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox1.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox2.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox3.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox4.BackColor = ColorTranslator.FromHtml(SecHex.Text);
            }
            catch
            {
                // ignored
            }
        }

        private void PrimG_TextChanged(object sender, EventArgs e)
        {
            if (ColorsWork())
            {
                var myColor = Color.FromArgb(int.Parse(PrimR.Text), int.Parse(PrimG.Text), int.Parse(PrimB.Text));
                PrimHex.Text = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
            }

            try
            {
                BackColor = ColorTranslator.FromHtml(PrimHex.Text);
                SecHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox5.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox7.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox8.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox9.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox1.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox2.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox3.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox4.BackColor = ColorTranslator.FromHtml(SecHex.Text);
            }
            catch
            {
                // ignored
            }
        }

        private void PrimB_TextChanged(object sender, EventArgs e)
        {
            if (ColorsWork())
            {
                var myColor = Color.FromArgb(int.Parse(PrimR.Text), int.Parse(PrimG.Text), int.Parse(PrimB.Text));
                PrimHex.Text = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
            }

            try
            {
                BackColor = ColorTranslator.FromHtml(PrimHex.Text);
                SecHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox5.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox7.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox8.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox9.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox1.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox2.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox3.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox4.BackColor = ColorTranslator.FromHtml(SecHex.Text);
            }
            catch
            {
                // ignored
            }
        }

        private void SecR_TextChanged(object sender, EventArgs e)
        {
            if (ColorsWork())
            {
                var myColor = Color.FromArgb(int.Parse(SecR.Text), int.Parse(SecG.Text), int.Parse(SecB.Text));
                SecHex.Text = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
            }

            try
            {
                panel1.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox5.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox7.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox8.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox9.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox1.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox2.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox3.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox4.BackColor = ColorTranslator.FromHtml(SecHex.Text);
            }
            catch
            {
                // ignored
            }
        }

        private void SecG_TextChanged(object sender, EventArgs e)
        {
            if (ColorsWork())
            {
                var myColor = Color.FromArgb(int.Parse(SecR.Text), int.Parse(SecG.Text), int.Parse(SecB.Text));
                SecHex.Text = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
            }

            try
            {
                panel1.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox5.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox7.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox8.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox9.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox1.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox2.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox3.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox4.BackColor = ColorTranslator.FromHtml(SecHex.Text);
            }
            catch
            {
                // ignored
            }
        }

        private void SecB_TextChanged(object sender, EventArgs e)
        {
            if (ColorsWork())
            {
                var myColor = Color.FromArgb(int.Parse(SecR.Text), int.Parse(SecG.Text), int.Parse(SecB.Text));
                SecHex.Text = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
            }

            try
            {
                panel1.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox5.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox7.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox8.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox9.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox1.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox2.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox3.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox4.BackColor = ColorTranslator.FromHtml(SecHex.Text);
            }
            catch
            {
                // ignored
            }
        }

        private bool ColorsWork()
        {
            if (PrimR.Text.All(char.IsDigit) && PrimR.Text != "")
            {
                switch (int.Parse(PrimR.Text))
                {
                    case > 255:
                        PrimR.Text = @"255";
                        MessageBox.Show(@"ERROR: MAX COLOR VALUE IS 255", "ERROR");
                        return false;
                    case < 0:
                        PrimR.Text = @"0";
                        MessageBox.Show(@"ERROR: MIN COLOR VALUE IS 0", "ERROR");
                        return false;
                }
            }
            else
                return false;

            if (PrimG.Text.All(char.IsDigit) && PrimG.Text != "")
            {
                switch (int.Parse(PrimG.Text))
                {
                    case > 255:
                        PrimG.Text = @"255";
                        MessageBox.Show(@"ERROR: MAX COLOR VALUE IS 255", "ERROR");
                        return false;
                    case < 0:
                        PrimG.Text = @"0";
                        MessageBox.Show(@"ERROR: MIN COLOR VALUE IS 0", "ERROR");
                        return false;
                }
            }
            else
                return false;

            if (PrimB.Text.All(char.IsDigit) && PrimB.Text != "")
            {
                switch (int.Parse(PrimB.Text))
                {
                    case > 255:
                        PrimB.Text = @"255";
                        MessageBox.Show(@"ERROR: MAX COLOR VALUE IS 255", "ERROR");
                        return false;
                    case < 0:
                        PrimB.Text = @"0";
                        MessageBox.Show(@"ERROR: MIN COLOR VALUE IS 0", "ERROR");
                        return false;
                }
            }
            else
                return false;

            if (SecR.Text.All(char.IsDigit) && SecR.Text != "")
            {
                switch (int.Parse(SecR.Text))
                {
                    case > 255:
                        SecR.Text = @"255";
                        MessageBox.Show(@"ERROR: MAX COLOR VALUE IS 255", "ERROR");
                        return false;
                    case < 0:
                        SecR.Text = @"0";
                        MessageBox.Show(@"ERROR: MIN COLOR VALUE IS 0", "ERROR");
                        return false;
                }
            }
            else
                return false;

            if (SecG.Text.All(char.IsDigit) && SecG.Text != "")
            {
                switch (int.Parse(SecG.Text))
                {
                    case > 255:
                        SecG.Text = @"255";
                        MessageBox.Show(@"ERROR: MAX COLOR VALUE IS 255", "ERROR");
                        return false;
                    case < 0:
                        SecG.Text = @"0";
                        MessageBox.Show(@"ERROR: MIN COLOR VALUE IS 0", "ERROR");
                        return false;
                }
            }
            else
                return false;

            if (SecB.Text.All(char.IsDigit) && SecB.Text != "")
            {
                switch (int.Parse(SecB.Text))
                {
                    case > 255:
                        SecB.Text = @"255";
                        MessageBox.Show(@"ERROR: MAX COLOR VALUE IS 255", "ERROR");
                        return false;
                    case < 0:
                        SecB.Text = @"0";
                        MessageBox.Show(@"ERROR: MIN COLOR VALUE IS 0", "ERROR");
                        return false;
                }
            }
            else
                return false;

            return true;
        }

        private void PrimHex_TextChanged(object sender, EventArgs e)
        {
            if (!PrimHex.Text.Contains("#"))
                PrimHex.Text = $@"#{PrimHex.Text}";

            try
            {
                BackColor = ColorTranslator.FromHtml(PrimHex.Text);

                PrimR.Text = ColorTranslator.FromHtml(PrimHex.Text).R.ToString();
                PrimG.Text = ColorTranslator.FromHtml(PrimHex.Text).G.ToString();
                PrimB.Text = ColorTranslator.FromHtml(PrimHex.Text).B.ToString();

                SecHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox5.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox7.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox8.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox9.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox1.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox2.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox3.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox4.BackColor = ColorTranslator.FromHtml(SecHex.Text);
            }
            catch
            {
                // ignored
            }
        }

        private void SecHex_TextChanged(object sender, EventArgs e)
        {
            if (!SecHex.Text.Contains("#"))
                SecHex.Text = $@"#{SecHex.Text}";

            try
            {
                panel1.BackColor = ColorTranslator.FromHtml(SecHex.Text);

                SecR.Text = ColorTranslator.FromHtml(SecHex.Text).R.ToString();
                SecG.Text = ColorTranslator.FromHtml(SecHex.Text).G.ToString();
                SecB.Text = ColorTranslator.FromHtml(SecHex.Text).B.ToString();

                SecHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                SecB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox5.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox7.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox8.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox9.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimHex.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimR.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimG.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                PrimB.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox1.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox2.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox3.BackColor = ColorTranslator.FromHtml(SecHex.Text);
                textBox4.BackColor = ColorTranslator.FromHtml(SecHex.Text);
            }
            catch
            {
                // ignored
            }
        }

        // Adds plugin to swapper
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Title = "Find Plato Plugin";
            openFileDialog.DefaultExt = "json";
            openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//PlatoPlugins");
                File.Move(openFileDialog.FileName, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $"//PlatoPlugins//{Path.GetFileName(openFileDialog.FileName)}");
                new Alert("Added Plugin to Swapper!");
            }
        }
    }
}
