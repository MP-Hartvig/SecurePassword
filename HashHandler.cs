using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurePassword
{
    internal class HashHandler
    {
        public string GetHash(string input, int numberOfIterations)
        {
            byte[] tempInput = Encoding.UTF8.GetBytes(input);

            byte[] tempValue = new byte[1];

            SHA512 sha = SHA512.Create();

            for (int i = 0; i < numberOfIterations; i++)
            {
                if (i == 0)
                {
                    tempValue = sha.ComputeHash(tempInput);
                }
                else
                {
                    tempValue = sha.ComputeHash(tempValue);
                }
            }

            return Convert.ToBase64String(sha.ComputeHash(tempValue));
        }
    }
}
