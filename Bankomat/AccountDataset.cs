using System.Collections.Generic;

namespace Bankomat
{
    internal static class AccountDataset
    {
        public static List<Account> accounts = new List<Account>();
        public static void LoadDefault() 
        {
            accounts.Add(new Account("User1", "a"));
            accounts.Add(new Account("User2", "b"));
            accounts.Add(new Account("User3", "c"));
        }
        public static bool Login(string username, string password) 
        {
            bool res = false;
            int i = 0;
            while(!res && i < accounts.Count)
            {
                res = accounts[i].Login(username, password);
                i++;
            }
            return res;
        }
        public static Account GetAccount(string username, string password) 
        {
            bool res = false;
            int i = 0;
            while (!res && i < accounts.Count)
            {
                res = accounts[i].Login(username, password);
                i++;
            }
            return accounts[i-1];
        }

    }
}
