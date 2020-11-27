using DiscordRPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlatoV2.Classes
{
    class PlatoRPC
    {
        public static readonly DiscordRpcClient discordrpc = new DiscordRpcClient("759628564198064158");
        public static void SetDiscordLocation(string Location)
        {
            discordrpc.SetPresence(new RichPresence
            {
                Details = $"🧊 • In {Location} Tab",
                State = "🥀 • | Best Swapper |",
                Assets = new Assets { LargeImageKey = "large", LargeImageText = $"Project Plato V2 | Powered By Tamely" }
            });
        }

        public static void SetDiscordAction(string Action)
        {
            discordrpc.SetPresence(new RichPresence
            {
                Details = $"🧊 • {Action}",
                State = "🥀 • | Best Swapper |",
                Assets = new Assets { LargeImageKey = "large", LargeImageText = $"Project Plato V2 | Powered By Tamely" }
            });
        }
    }
}
