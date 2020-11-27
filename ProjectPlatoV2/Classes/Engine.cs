using ProjectPlatoV2.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPlatoV2.Classes
{
	class Engine
	{
		public static bool Convert(long start, string file, string convert, string revert, long max = 0L, long additional = 0L, bool minus = false, bool messages = false)
		{
			byte[] a = Encoding.UTF8.GetBytes(convert);
			byte[] array = Encoding.UTF8.GetBytes(revert);
			bool flag = convert.Length - revert.Length >= 0;
			bool result;
			if (flag)
			{
				for (int i = 0; i < convert.Length - revert.Length; i++)
				{
					array = Engine.c(array, 0);
				}
				bool flag2 = File.Exists(file);
				if (flag2)
				{
					Stream s = File.Open(file, FileMode.Open, FileAccess.ReadWrite);
					Task<long> task = Task.Run<long>(() => Engine.d(s, start, a, max));
					bool flag3 = task.Wait(TimeSpan.FromSeconds(10.0));
					long num;
					if (flag3)
					{
						num = task.Result;
						Settings.Default.current_offset = num;
						Settings.Default.Save();
					}
					else
					{
						num = 0L;
					}
					s.Close();
					bool flag4 = num == 0L;
					if (flag4)
					{
						if (messages)
						{
							MessageBox.Show("Already converted, or string not found in pak! (Ask for help on discord!)", "- Tamely", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						result = false;
					}
					else
					{
						bool flag5 = additional != 0L && minus;
						if (flag5)
						{
							num -= additional;
						}
						else
						{
							bool flag6 = additional != 0L && !minus;
							if (flag6)
							{
								num += additional;
							}
						}
						BinaryWriter binaryWriter = new BinaryWriter(File.Open(file, FileMode.Open, FileAccess.ReadWrite));
						binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
						binaryWriter.Write(array);
						binaryWriter.Close();
						if (messages)
						{
							MessageBox.Show("Successfully converted!");
						}
						result = true;
					}
				}
				else
				{
					if (messages)
					{
						MessageBox.Show("The pak file specified doesn't exist");
					}
					result = false;
				}
			}
			else
			{
				if (messages)
				{
					MessageBox.Show("Convert string is lower than revert string");
				}
				result = false;
			}
			return result;
		}

		public static bool Revert(long start, string file, string convert, string revert, long max = 0L, long additional = 0L, bool messages = true, bool v = false)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(convert);
			byte[] b = Encoding.UTF8.GetBytes(revert);
			bool flag = convert.Length - revert.Length >= 0;
			bool result;
			if (flag)
			{
				for (int i = 0; i < convert.Length - revert.Length; i++)
				{
					b = Engine.c(b, 0);
				}
				bool flag2 = File.Exists(file);
				if (flag2)
				{
					Stream s = File.Open(file, FileMode.Open, FileAccess.ReadWrite);
					Task<long> task = Task.Run<long>(() => Engine.d(s, start, b, max));
					bool flag3 = task.Wait(TimeSpan.FromSeconds(10.0));
					long num;
					if (flag3)
					{
						num = task.Result;
						Settings.Default.current_offset = num;
						Settings.Default.Save();
					}
					else
					{
						num = 0L;
					}
					s.Close();
					bool flag4 = num == 0L;
					if (flag4)
					{
						if (messages)
						{
							MessageBox.Show("Already converted, or string not found in pak!");
						}
						result = false;
					}
					else
					{
						bool flag5 = additional != 0L;
						if (flag5)
						{
							num += additional;
						}
						BinaryWriter binaryWriter = new BinaryWriter(File.Open(file, FileMode.Open, FileAccess.ReadWrite));
						binaryWriter.BaseStream.Seek(num, SeekOrigin.Begin);
						binaryWriter.Write(bytes);
						binaryWriter.Close();
						if (messages)
						{
							MessageBox.Show("Successfully reverted!");
						}
						result = true;
					}
				}
				else
				{
					if (messages)
					{
						MessageBox.Show("The pak file specified doesn't exist");
					}
					result = false;
				}
			}
			else
			{
				if (messages)
				{
					MessageBox.Show("Revert string is lower than Convert string");
				}
				result = false;
			}
			return result;
		}

		private static byte[] c(byte[] mahOldByteArray, byte newByte)
		{
			List<byte> list = new List<byte>();
			list.AddRange(mahOldByteArray);
			list.Add(newByte);
			return list.ToArray();
		}

		private static long d(Stream a, long b, byte[] c, long max)
		{
			int num = 0;
			long result = 0L;
			a.Position = b;
			bool flag = false;
			bool flag2 = max == 0L;
			if (flag2)
			{
				flag = false;
			}
			else
			{
				bool flag3 = max > 1L;
				if (flag3)
				{
					flag = true;
				}
			}
			for (; ; )
			{
				bool flag4 = flag;
				if (flag4)
				{
					bool flag5 = a.Position == max;
					if (flag5)
					{
						break;
					}
				}
				else
				{
					bool flag6 = a.Position == 5000000000L;
					if (flag6)
					{
						goto Block_5;
					}
				}
				int num2 = a.ReadByte();
				bool flag7 = num2 == -1;
				if (flag7)
				{
					goto Block_6;
				}
				bool flag8 = num2 == (int)c[num];
				if (flag8)
				{
					num++;
					bool flag9 = num == c.Length;
					if (flag9)
					{
						goto Block_8;
					}
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
			return a.Position - (long)c.Length;
		}
	}
}
