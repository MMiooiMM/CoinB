using System.Security.Cryptography;
using System.Text;

namespace CoinB.Helpers
{
    public static class CodeGeneratorHelper
    {
        public static string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var byteBuffer = new byte[length];
            RandomNumberGenerator.Fill(byteBuffer);
            var result = new StringBuilder(length);
            foreach (var b in byteBuffer)
            {
                result.Append(chars[b % chars.Length]);
            }
            return result.ToString();
        }
    }
}
