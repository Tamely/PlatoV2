using ProjectPlatoV2.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlatoV2.Classes
{
    class Updater
    {
        public static void CheckForUpdate(long Version)
        {
            if(Settings.Default.version >= Version)
            {
                DarkMessageBoxHelper.DMB("Update", "There is an update available! Downloading now!");
                WebClient wc = new WebClient();
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/ProjectPlatoV2.exe"))
                {
                    DarkMessageBoxHelper.DMB("ERROR", "Please rename this swapper or move it off the desktop");
                }
                else
                {
                    wc.DownloadFile("https://github.com/Tamely/PlatoV2/releases/download/v" + Settings.Default.version + ".0/ProjectPlatoV2.exe", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ProjectPlatoV2.exe");
                    DarkMessageBoxHelper.DMB("Update", "Update downloaded on your desktop! Starting new exe!");
                    Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ProjectPlatoV2.exe");

                    string batchCommands = string.Empty;
                    string exeFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", string.Empty).Replace("/", "\\");

                    batchCommands += "@ECHO OFF\n";               
                    batchCommands += "ping 127.0.0.1 > nul\n";       
                    batchCommands += "echo j | del /F ";         
                    batchCommands += exeFileName + "\n";
                    batchCommands += "echo j | del deletePlato.bat";  

                    File.WriteAllText("deletePlato.bat", batchCommands);

                    Process.Start("deletePlato.bat");

                    Environment.Exit(-1);
                }

            }
        }
    }
}
