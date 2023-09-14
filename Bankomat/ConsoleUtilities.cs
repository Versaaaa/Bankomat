using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    static class ConsoleUtilities
    {
        public static void WriteError(dynamic message)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
                Console.WriteLine("Premi qualsiasi pulsante per Continuare");
                Console.ReadKey();
            }
            catch 
            { 
                WriteError(" Errore ");
            }
        }
    }
}
