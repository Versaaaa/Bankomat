using System;

namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountDataset.LoadDefault();
            BankomatMenu menu = new BankomatMenu(DefaultBankomat(), UserLogin());
            menu.OperationMenu();

        }

        public static dynamic UserLogin() 
        {
            string x = "";
            string y = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Inserisci Username");
                x = Console.ReadLine();
                Console.WriteLine("Inserisci Password");
                y = Console.ReadLine();

                try
                {
                    if (AccountDataset.Login(x, y))
                    {
                        return AccountDataset.GetAccount(x,y);
                    }
                    else
                    {
                        ConsoleUtilities.WriteError("Username o Password errate");
                    }
                }
                catch
                {
                    ConsoleUtilities.WriteError($"\nAccount {x} Bloccato\n");
                }
            }
            while (true);
        }

        public static BankomatTemplate DefaultBankomat()
        {
            BankomatTemplate res = new BankomatTemplate();

            foreach (var item in AccountDataset.accounts)
            {
                res.Add(item, 1000);
            }

            return res;
        }

    }
}
