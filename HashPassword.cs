using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LAB5ZhatkoEvseev
{
    class HashPassword
    {
        public static string Hash(string password)
        {
            if (string.IsNullOrEmpty(password)) return string.Empty;
            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);

                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for(int i = 1; i < hashBytes.Length; i++ )
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
            }
            return password;
        }
    }
}
