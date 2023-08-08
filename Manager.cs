using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePassword
{
    internal class Manager
    {
        int numberOfIterations = 300000;

        HashHandler hh = new HashHandler();
        SaltHandler sh = new SaltHandler();
        DataHandler dh = new DataHandler();

        public bool CheckLogin(string username, string password)
        {
            string salt = dh.GetSaltOnUser(username);
            string hashedPass = hh.GetHash((salt + password), numberOfIterations);

            if (dh.CheckUserLogin(username, hashedPass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateLogin(string username, string password)
        {
            string salt = sh.GenerateSalt();
            string hashedPass = hh.GetHash((salt + password), numberOfIterations);

            if (dh.CreateUser(username, hashedPass, salt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateLogin(string username, string newPassword)
        {
            string salt = dh.GetSaltOnUser(username);
            int id = dh.GetUserId(username);
            string hashedPass = hh.GetHash((salt + newPassword), numberOfIterations);

            if (dh.UpdateUser(username, hashedPass, salt, id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteLogin(string username)
        {
            int id = dh.GetUserId(username);

            if (dh.DeleteUser(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
