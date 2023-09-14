using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class Account
    {
        string Username { get; set; }
        string Password { get; set; }
        bool IsBlocked { get; set; }
        int Tries { get; set; }

        public Account(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string GetUser() 
        { 
            return Username;
        }

        public bool Login(string username, string password  )
        {
            if (username.Equals(Username))
            {
                if (IsBlocked)
                {
                    throw new Exception("Account blocked");
                }

                if (password.Equals(Password)) 
                { 
                    return true;
                }

                Tries += 1;

                if (Tries > 2)
                {
                    IsBlocked = true;
                }
            }
            return false; 
        }

    }
}
