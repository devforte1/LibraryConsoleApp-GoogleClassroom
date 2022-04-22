using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ClassLibraryCommon
{
    public class Authentication
    {
        byte[] GenerateSalt(int length)
        {
            var bytes = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            return bytes;
        }

        byte[] GenerateHash(byte[] password, byte[] salt, int iterations, int length)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return deriveBytes.GetBytes(length);
            }
        }

        //public bool AuthenticateUser(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}

        static string GeneratePassword()
        {
            var tryThis = RandomNumberGenerator.Create();
            
            throw new NotImplementedException();
        }
    }
}
