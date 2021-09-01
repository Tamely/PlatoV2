using System.Collections.Generic;
using System.IO;

namespace ProjectPlatoV2.Classes.IoStore
{
    public class Researcher
    {
        public static List<long> FindPosition(Stream stream, int searchPosition, long startIndex, byte[] searchPattern)
        {
            List<long> searchResults = new();
            stream.Position = startIndex;

            while (true)
            {
                if (stream.Position == 5000000000)
                {
                    return searchResults;
                }

                var latestByte = stream.ReadByte();
                if (latestByte == -1)
                {
                    break;
                }

                if (latestByte == searchPattern[searchPosition])
                {
                    searchPosition++;
                    if (searchPosition != searchPattern.Length) continue;
                    searchResults.Add(stream.Position - searchPattern.Length);
                    return searchResults;
                }

                searchPosition = 0;
            }

            return searchResults;
        }
    }
}