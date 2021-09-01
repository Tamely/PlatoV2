using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectPlatoV2.Properties;

namespace ProjectPlatoV2.Classes
{
    internal class Engine
    {
        public static bool Convert(long start, string file, string? convert, string? revert, long max = 0L,
            long additional = 0L, bool minus = false, bool messages = false)
        {
            var a = Encoding.UTF8.GetBytes(convert);
            var array = Encoding.UTF8.GetBytes(revert);
            var flag = convert.Length - revert.Length >= 0;
            bool result;
            if (flag)
            {
                for (var i = 0; i < convert.Length - revert.Length; i++) array = C(array, 0);
                var flag2 = File.Exists(file);
                if (flag2)
                {
                    Stream s = File.Open(file, FileMode.Open, FileAccess.ReadWrite);
                    var task = Task.Run(() => D(s, start, a, max));
                    var flag3 = task.Wait(TimeSpan.FromSeconds(10.0));
                    long num;
                    if (flag3)
                    {
                        num = task.Result;
                        Vars.CurrentOffset = num;
                    }
                    else
                    {
                        num = 0L;
                    }

                    s.Close();
                    var flag4 = num == 0L;
                    if (flag4)
                    {
                        if (messages)
                            MessageBox.Show("Already converted, or string not found in pak! (Ask for help on discord!)",
                                "- Tamely", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        result = false;
                    }
                    else
                    {
                        var flag5 = additional != 0L && minus;
                        if (flag5)
                        {
                            num -= additional;
                        }
                        else
                        {
                            var flag6 = additional != 0L && !minus;
                            if (flag6) num += additional;
                        }

                        var binaryWriter = new BinaryWriter(File.Open(file, FileMode.Open, FileAccess.ReadWrite));
                        binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                        binaryWriter.Write(array);
                        binaryWriter.Close();
                        if (messages) new Alert("Successfully converted!");
                        result = true;
                    }
                }
                else
                {
                    if (messages) MessageBox.Show("The pak file specified doesn't exist");
                    result = false;
                }
            }
            else
            {
                result = true;
            }

            return result;
        }

        public static bool Revert(long start, string file, string convert, string revert, long max = 0L,
            long additional = 0L, bool messages = false, bool v = false)
        {
            var bytes = Encoding.UTF8.GetBytes(convert);
            var b = Encoding.UTF8.GetBytes(revert);
            var flag = convert.Length - revert.Length >= 0;
            bool result;
            if (flag)
            {
                for (var i = 0; i < convert.Length - revert.Length; i++) b = C(b, 0);
                var flag2 = File.Exists(file);
                if (flag2)
                {
                    Stream s = File.Open(file, FileMode.Open, FileAccess.ReadWrite);
                    var task = Task.Run(() => D(s, start, b, max));
                    var flag3 = task.Wait(TimeSpan.FromSeconds(10.0));
                    long num;
                    if (flag3)
                    {
                        num = task.Result;
                        Vars.CurrentOffset = num;
                    }
                    else
                    {
                        num = 0L;
                    }

                    s.Close();
                    var flag4 = num == 0L;
                    if (flag4)
                    {
                        if (messages) MessageBox.Show("Already converted, or string not found in pak!");
                        result = false;
                    }
                    else
                    {
                        var flag5 = additional != 0L;
                        if (flag5) num += additional;
                        var binaryWriter = new BinaryWriter(File.Open(file, FileMode.Open, FileAccess.ReadWrite));
                        binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
                        binaryWriter.Write(bytes);
                        binaryWriter.Close();
                        if (messages) new Alert("Successfully reverted!");
                        result = true;
                    }
                }
                else
                {
                    if (messages) MessageBox.Show("The pak file specified doesn't exist");
                    result = false;
                }
            }
            else
            {
                if (messages) MessageBox.Show("Revert string is shorter than Convert string");
                result = false;
            }

            return result;
        }

        private static byte[] C(byte[] mahOldByteArray, byte newByte)
        {
            var list = new List<byte>();
            list.AddRange(mahOldByteArray);
            list.Add(newByte);
            return list.ToArray();
        }

        private static long D(Stream a, long b, byte[] c, long max)
        {
            var num = 0;
            var result = 0L;
            a.Position = b;
            var flag = false;
            var flag2 = max == 0L;
            if (flag2)
            {
                flag = false;
            }
            else
            {
                var flag3 = max > 1L;
                if (flag3) flag = true;
            }

            for (;;)
            {
                var flag4 = flag;
                if (flag4)
                {
                    var flag5 = a.Position == max;
                    if (flag5) break;
                }
                else
                {
                    var flag6 = a.Position == 5000000000L;
                    if (flag6) goto Block_5;
                }

                var num2 = a.ReadByte();
                var flag7 = num2 == -1;
                if (flag7) goto Block_6;
                var flag8 = num2 == c[num];
                if (flag8)
                {
                    num++;
                    var flag9 = num == c.Length;
                    if (flag9) goto Block_8;
                }
                else
                {
                    num = 0;
                }
            }

            return result;
            Block_5:
            return result;
            Block_6:
            return result;
            Block_8:
            return a.Position - c.Length;
        }
    }
}