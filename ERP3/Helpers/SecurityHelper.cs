using System.Security.Cryptography;
using System.Text;

namespace ERP3.Helpers
{
    public static class SecurityHelper
    {
        public static string DoubleHash(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] firstHash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                string firstHex = BitConverter.ToString(firstHash).Replace("-", "").ToLower();

                byte[] secondHash = sha.ComputeHash(Encoding.UTF8.GetBytes(firstHex));
                string secondHex = BitConverter.ToString(secondHash).Replace("-", "").ToLower();

                return secondHex.Substring(0, 7);
            }
        }
    }
}
