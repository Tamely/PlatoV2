using ProjectPlatoV2.Forms;
using ProjectPlatoV2.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlatoV2.Classes
{
    class DarkMessageBoxHelper
    {
        public static void DMB(string Title, string Body) // Makes a custom messagebox with variables sumbitted on the calling form
        {
            Settings.Default.DMBTitle = Title;
            Settings.Default.DMBBody = Body;

            DarkMessageBox msg = new DarkMessageBox();
            msg.Show();
        }
    }
}
