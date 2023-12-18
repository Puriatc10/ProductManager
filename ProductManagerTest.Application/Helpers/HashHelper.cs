using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Helpers
{
    public class HashHelper
    {
        private static readonly string PasswordSalt = "993BA245D5E140F7AC59C95FDCBE4E22";

        public static string HashPassword(string password)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            return Convert.ToBase64String(algorithm.ComputeHash(Encoding.UTF8.GetBytes(password + PasswordSalt)));
        }
        public static bool CheckPassword(string password, string hashedPassword)
        {
            return hashedPassword == HashPassword(password);
        }
    }
}
