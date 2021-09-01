using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ProjectPlatoV2.Classes.Crypto
{
    public class Crypto
    {
        private const int AesKeySize = 16;

        public static string StringEncrypt(string src, string pass) =>
            Convert.ToBase64String(AesEncrypt(Encoding.UTF8.GetBytes(src), Encoding.UTF8.GetBytes(pass)));

        public static string StringDecrypt(string src, string pass) =>
            Encoding.UTF8.GetString(AesDecrypt(Convert.FromBase64String(src), Encoding.UTF8.GetBytes(pass)));

        private static byte[] AesEncrypt(byte[] data, byte[] key)
        {
            if (data == null || data.Length <= 0) throw new ArgumentNullException($"{nameof(data)} cannot be empty");

            if (key == null || key.Length != AesKeySize)
                throw new ArgumentException($"{nameof(key)} must be length of {AesKeySize}");

            using (var aes = new AesCryptoServiceProvider
            {
                Key = key,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            })
            {
                aes.GenerateIV();
                var iv = aes.IV;
                using (var encrypter = aes.CreateEncryptor(aes.Key, iv))
                using (var cipherStream = new MemoryStream())
                {
                    using (var tCryptoStream = new CryptoStream(cipherStream, encrypter, CryptoStreamMode.Write))
                    using (var tBinaryWriter = new BinaryWriter(tCryptoStream))
                    {
                        // prepend IV to data
                        cipherStream.Write(iv);
                        tBinaryWriter.Write(data);
                        tCryptoStream.FlushFinalBlock();
                    }

                    var cipherBytes = cipherStream.ToArray();

                    return cipherBytes;
                }
            }
        }

        private static byte[] AesDecrypt(byte[] data, byte[] key)
        {
            if (data == null || data.Length <= 0) throw new ArgumentNullException($"{nameof(data)} cannot be empty");

            if (key == null || key.Length != AesKeySize)
                throw new ArgumentException($"{nameof(key)} must be length of {AesKeySize}");

            using (var aes = new AesCryptoServiceProvider
            {
                Key = key,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            })
            {
                // get first KeySize bytes of IV and use it to decrypt
                var iv = new byte[AesKeySize];
                Array.Copy(data, 0, iv, 0, iv.Length);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(aes.Key, iv), CryptoStreamMode.Write))
                    using (var binaryWriter = new BinaryWriter(cs))
                    {
                        // decrypt cipher text from data, starting just past the IV
                        binaryWriter.Write(
                            data,
                            iv.Length,
                            data.Length - iv.Length
                        );
                    }

                    var dataBytes = ms.ToArray();

                    return dataBytes;
                }
            }
        }
    }
}