using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlatoV2.Classes
{
    class Utilities
    {
        public static string GetTextFromUrl(string url)
        {
            return new WebClient().DownloadString(url);
        }
        public static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) ||
                (strInput.StartsWith("[") && strInput.EndsWith("]")))
            {
                try
                {
                    JToken obj = JToken.Parse(strInput);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static void Convert(string Find, string Replace, string Pak, long Offset)
        {
            bool flag9 = Engine.Convert(Offset, Pak, Find, Replace, 0L, 0L, false, false);
            bool flag10 = flag9;
            if (flag10)
            {
            }
        }

        public static void Revert(string Find, string Replace, string Pak, long Offset)
        {
            bool flag9 = Engine.Revert(Offset, Pak, Find, Replace, 0L, 0L, false, false);
            bool flag10 = flag9;
            if (flag10)
            {
            }
        }

        public static void News(string news)
        {
            if(news != "")
            {
                DarkMessageBoxHelper.DMB("News", news);
            }
        }

        public static void Hosts()
        {
            if(File.Exists("C:/Windows/System32/drivers/etc\\hosts"))
            {
                
            }
            else
            {
                WebClient wc = new WebClient();
                wc.DownloadFile("https://cdn.discordapp.com/attachments/754879989186560135/780906560666861598/hosts", "C:/Windows/System32/drivers/etc\\hosts");
            }
        }
    }
}
