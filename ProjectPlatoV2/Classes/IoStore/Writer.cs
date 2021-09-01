using System;
using System.IO;

namespace ProjectPlatoV2.Classes.IoStore
{
    public class Writer
    {
        public static byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        public void ReplaceBytes(string path, byte[] search, byte[] replace)
        {
            var replace1fill = search.Length - replace.Length;
            while (replace1fill > 0)
            {
                byte[] fill = { 0 };
                replace = Combine(replace, fill);
                replace1fill = replace1fill - 1;
            }

            var stream09 = (Stream) File.OpenRead(path);
            foreach (var offset in Researcher.FindPosition(stream09, 0, 0, search))
            {
                stream09.Close();
                var binaryWriter = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(replace);
                binaryWriter.Close();
            }
        }
        
        public void ReplaceBytesWithOffset(string path, byte[] search, byte[] replace, long offset)
        {
            var replace1fill = search.Length - replace.Length;
            while (replace1fill > 0)
            {
                byte[] fill = { 0 };
                replace = Combine(replace, fill);
                replace1fill = replace1fill - 1;
            }

            var stream09 = (Stream) File.OpenRead(path);
            foreach (var _offset in Researcher.FindPosition(stream09, (int)offset, 0, search))
            {
                stream09.Close();
                var binaryWriter = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(_offset, SeekOrigin.Begin);
                binaryWriter.Write(replace);
                binaryWriter.Close();
            }
        }

        public void ReplaceByte(string path, byte[] replace, long offset)
        {
            using (var stream0 = File.Open(path, FileMode.Open, FileAccess.Write))
            {
                stream0.Seek(offset, SeekOrigin.Begin);
                stream0.Write(replace);
                stream0.Close();
            }
        }

        public void ReplaceBytesInPak(string path, byte[] replace, long offset)
        {
            using (var stream0 = File.Open(path, FileMode.Open, FileAccess.Write))
            {
                stream0.Seek(offset, SeekOrigin.Begin);
                stream0.Write(replace);
                stream0.Close();
            }
        }
    }
}