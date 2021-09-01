using System.Drawing;
using System.Windows.Forms;
using ProjectPlatoV2.Forms;

namespace ProjectPlatoV2.Classes
{
    public class Alert
    {
        public Alert(string? text, long time = 5, string? imageurl = "")
        {
            Vars.Text = text;
            Vars.Time = time;
            Vars.Imageurl = imageurl;
            var alert = new AlertBox {StartPosition = FormStartPosition.Manual};
            alert.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - alert.Width,
                Screen.PrimaryScreen.WorkingArea.Height - alert.Height);
            alert.TopMost = true;
            alert.Show();
        }
    }
}