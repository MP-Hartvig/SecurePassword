using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurePassword
{
    internal class SaltHandler
    {
        public string GenerateSalt()
        {
            return RandomNumberGenerator.GetInt32(1000000, 9999999).ToString();
        }
    }
}
