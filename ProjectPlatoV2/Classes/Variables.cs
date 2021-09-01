using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;
using RestSharp;
using File = System.IO.File;

namespace ProjectPlatoV2.Classes
{
    public class Vars
    {
        public static readonly long Version = 2;

        public static string? DiscordLink =>
            JObject.Parse(new WebClient().DownloadString(BASEENDPOINT))["discordServer"].ToString();
        public const string? BASEENDPOINT = "https://tamelyapi.azurewebsites.net";
        
        // Checks if it's reading the JSON from local storage or online
        public static bool Prod = false;

        // General swapping things
        public static string PakPath = "";
        public static string Item = "";
        public static string? Note = "";
        public static bool Early = false;

        // Used for cp swaps
        public static string? Malesearch = "";
        public static string? Malereplace = "";
        public static string? Femalesearch = "";
        public static string? Femalereplace = "";
        public static string? Femaleasset = "";
        public static string? Maleasset = "";
        public static string? Defaultgame = "";
        public static string? Bodysearch = "";
        public static string? Headsearch = "";
        public static string? Bodysearchsingle = "";
        public static string? Headsearchsingle = "";
        public static string? LengthSearch = "";
        public static string? LengthReplace = "";

        // Used for Alerts
        public static string? Text = "ERROR PARSING TEXT";
        public static long Time = 5; // Seconds the alert stays open
        public static string? Imageurl = "";

        // Icon on the swapping form
        public static string? Iconurl = "";

        // Long that is no longer in use, but I'm still keeping it here
        public static long CurrentOffset = 0;

        public static bool IsEarly()
        {
            DateTime date;
            try
            {
                dynamic parsed =
                    JObject.Parse(File.ReadAllText(
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Config.json"));
                string datestring = parsed.isEarlyDate;
                date = GetDate(datestring);
            }
            catch
            {
                return false;
            }

            return date >= DateTime.Today;
        }

        private static DateTime GetDate(string input)
        {
            if (!DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.CurrentCulture,
                DateTimeStyles.None, out var result))
                throw new FormatException("date must be in the format: 'MM/dd/yyyy'");

            return result;
        }

        public static string Endpoint(string url)
        {
            var client = new RestClient(url) {Timeout = -1};
            var request = new RestRequest(Method.GET);
            String Key = "\u0701\u06A1\u08C1\u06A1\u0601\u0841\u0621\u0881\u0661\u0621";
            for (int QUEVe = 0, jCARG = 0; QUEVe < 10; QUEVe++)
            {
                jCARG = Key[QUEVe];
                jCARG --;
                jCARG = (((jCARG & 0xFFFF) >> 5) | (jCARG << 11)) & 0xFFFF;
                Key = Key.Substring(0, QUEVe) + (char)(jCARG & 0xFFFF) + Key.Substring(QUEVe + 1);
            }
            request.AddHeader("ApiKey", Key);
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public static string Aes()
        {
            dynamic parsed = JObject.Parse(new WebClient().DownloadString("https://benbot.app/api/v1/aes"));
            return parsed.mainKey;
        }

        private static readonly string Api = "";
    }
}