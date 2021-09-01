using ProjectPlatoV2.Classes.Crypto;

namespace ProjectPlatoV2.Classes
{
    public class ApiStrings
    {
        public static string Pass = OldCrypto.Decrypt("9hIheE1dxZe/RPSuzOPAX1YuU48bDL3Kqc9mLbKTYMI=",
            "https://tamely.tk", GetSalt());

        private static string GetSalt()
        {
            var salt = "\uFFB4\uFF90\uFF8C\uFF97\uFF9A\uFF8D";

            for (int womkT = 0, bdUqk = 0; womkT < 6; womkT++)
            {
                bdUqk = salt[womkT];
                bdUqk = ~bdUqk;
                salt = salt.Substring(0, womkT) + (char) (bdUqk & 0xFFFF) + salt.Substring(womkT + 1);
            }

            return salt;
        }
    }
}