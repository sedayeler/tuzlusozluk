using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TuzluSozluk.Common
{
    public static class PasswordEncryptor
    {
        public static string Encrypt(string password)
        {
            var sha256 = SHA256.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
