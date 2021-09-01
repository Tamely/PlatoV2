using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CUE4Parse.Encryption.Aes;
using CUE4Parse.FileProvider;
using CUE4Parse.UE4.Objects.Core.Misc;
using DiscordRPC;
using Newtonsoft.Json.Linq;

namespace ProjectPlatoV2.Classes
{
    internal static class Utilities
    {
        public static readonly DiscordRpcClient DiscordRpc = new("759628564198064158");

        public static DefaultFileProvider _provider;

        public static bool Disposed;

        public static void InitProvider(string aes)
        {
            _provider = new DefaultFileProvider(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "//TAMELYBACKUP" , SearchOption.TopDirectoryOnly);
            _provider.Initialize();
            _provider.SubmitKey(new FGuid(00000000000000000000000000000000), new FAesKey(aes));
            _provider.LoadLocalization();
        }

        public static byte[] ToSingle(this byte[] array)
        {
            return Encoding.Default.GetBytes(Encoding.Default.GetString(array).Split('.')[0]);
        }

        public static byte[] StringToBytes(this string str)
        {
            return Encoding.Default.GetBytes(str);
        }

        // Exports compressed asset from fortnite
        public static void ExportCompressed(string? assetpath, string dir)
        {
            Directory.CreateDirectory(dir + "//" + assetpath.Replace(Path.GetFileName(assetpath), ""));
            if (!_provider.TrySavePackage(assetpath, out var assets)) return;
            foreach (var (key, value) in assets) File.WriteAllBytes(Path.Combine(dir, key), value);
        }

        // Basic write byte[] to offset in file
        public static void OutdatedResearcher(string filePath, long offset, byte[] data)
        {
            using var stream = File.Open(filePath, FileMode.Open);
            stream.Position = offset;
            stream.Write(data, 0, data.Length);
        }

        // Checks if it's valid JSON, only used for the pak path finder
        public static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((!strInput.StartsWith("{") || !strInput.EndsWith("}")) &&
                (!strInput.StartsWith("[") || !strInput.EndsWith("]"))) return false;
            try
            {
                var obj = JToken.Parse(strInput); // Checks if it can be applied
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void Convert(string? find, string? replace, string pak, long offset)
        {
            Engine.Convert(offset, pak, find, replace);
        }

        public static void ConvertHex(string? find, string? replace, string pak, long offset)
        {
            HexResearcher.HexConvert(offset, pak, find, replace);
        }

        public static void SetRpcLocation(string location)
        {
            DiscordRpc.SetPresence(new RichPresence
            {
                Details = "🧊 • | tamely.tk |",
                State = "🥀 • | Best Swapper |",
                Timestamps = Timestamps.Now,
                Buttons = new Button[]
                {
                    new() {Label = "Join Project Plato", Url = Vars.DiscordLink},
                    new() {Label = "Project Plato Source", Url = "https://GitHub.com/Tamely/PlatoV2"}
                },
                Assets = new Assets
                {
                    LargeImageKey = "large", SmallImageKey = "small",
                    LargeImageText = "Project Plato V2 | Powered By Tamely", SmallImageText = $"🧊 • In {location} Tab"
                }
                
            });
        }

        public static string GetVersion =>
            JObject.Parse(new WebClient().DownloadString("https://fortnite-api.com/v2/aes"))["data"]["build"].ToString();

        public static List<string> Programs = new();

        public static void ClosePrograms(object sender, EventArgs e)
        {
            while (true)
                foreach (var proce in Process.GetProcesses())
                    foreach (var process in Programs)
                        if (proce.ProcessName.ToLower().Contains(process))
                        {
                            Process.GetProcessById(proce.Id).Kill();
                            Process.GetCurrentProcess().Kill();
                        }
        }

        public static string StringRegex(string? str)
        {
            return str.Replace(" ", "").Replace("-", "").Replace(".", "").Replace("_", "").Replace("?", "")
                .Replace("!", "");
        }

        public static void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // different way because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") {CreateNoWindow = true});
                }
                else
                {
                    throw; // you never know what bugs might happen
                }
            }
        }
    }
}