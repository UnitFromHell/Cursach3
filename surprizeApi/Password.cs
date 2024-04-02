using System.Security.Cryptography;
using System.Text;

namespace surprizeApi
{
    public class Password
    {
        public string GenerateSalt()
        {
            byte[] salt = new byte[5];
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            provider.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public string HashPassword(string password, string salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password + salt);
            byte[] hashBytes = new SHA512Managed().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyPassword(string password, string salt, string hashedPassword)
        {
            string hashedInput = HashPassword(password, salt);
            return hashedInput.Equals(hashedPassword);
        }
    }
}
