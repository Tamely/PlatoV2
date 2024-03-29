﻿using System.IO;

namespace ProjectPlatoV2.Classes.Oodle.Utils
{
    public class Helper
    {
        public static void Write(byte[] writableData, string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            if (fileInfo.IsReadOnly && File.Exists(filePath)) fileInfo.IsReadOnly = false;
            var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            var binaryWriter = new BinaryWriter(fileStream);
            binaryWriter.Write(writableData);
            binaryWriter.Close();
            fileStream.Close();
        }
    }
}