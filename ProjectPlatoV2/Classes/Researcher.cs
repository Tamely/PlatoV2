using ProjectPlatoV2.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlatoV2.Classes
{
    class Researcher
    {
        public static bool FindPosition(long start, string file, string convert, long max = 0)
        {
            byte[] a = Encoding.UTF8.GetBytes(convert);

            if (File.Exists(file))
            {
                Stream s = File.Open(file, FileMode.Open, FileAccess.ReadWrite);

                long offset;

                var task = Task.Run(() => d(s, start, a, max));
                if (task.Wait(TimeSpan.FromSeconds(10)))
                {
                    offset = task.Result;
                    Settings.Default.current_offset = offset;
                    Settings.Default.Save();
                }
                else
                {
                    offset = 0;
                }

                s.Close();

                if (offset == 0)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private static long d(Stream a, long b, byte[] c, long max)
        {
            int searchPosition = 0;
            long result = 0;
            a.Position = b;
            bool max1 = false;

            if (max == 0)
            {
                max1 = false;
            }
            else if (max > 1)
            {
                max1 = true;
            }

            while (true)
            {
                if (max1)
                {
                    if (a.Position == max)
                    {
                        return result;
                    }

                }
                else
                {
                    if (a.Position == 5000000000)
                    {
                        return result;
                    }
                }

                var latestbyte = a.ReadByte();
                if (latestbyte == -1)
                {
                    break;
                }

                if (latestbyte == c[searchPosition])
                {
                    searchPosition++;
                    if (searchPosition == c.Length)
                    {
                        result = a.Position - c.Length;
                        return result;
                    }
                }
                else
                {
                    searchPosition = 0;
                }
            }

            return result;
        }
    }
}
