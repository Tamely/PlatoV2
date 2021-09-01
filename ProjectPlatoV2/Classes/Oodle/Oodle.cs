using System;
using ProjectPlatoV2.Classes.Oodle.Utils;

namespace ProjectPlatoV2.Classes.Oodle
{
    public static class Oodle
    {
        public static void Compress(string decompressedFilePath, string outputPath)
        {
            Utils.Oodle.Prepare(decompressedFilePath); // Gets the source prepared
            uint @uint; // Needs to be outside so it always has a value
            try
            {
                @uint = OodleStream.GetCompressedLength(Utils.Oodle.SourceArray, Utils.Oodle.SourceLength,
                    OodleFormat.Kraken, OodleCompressionLevel.Level5);
            }
            catch (AccessViolationException)
            {
                @uint = 64U;
            }

            var compressed = OodleStream.OodleCompress(Utils.Oodle.SourceArray, Utils.Oodle.SourceLength,
                OodleFormat.Kraken, OodleCompressionLevel.Level5, @uint);


            Helper.Write(compressed, outputPath); // Writing the data
        }
    }
}