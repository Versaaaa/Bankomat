using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class BankomatMenu
    {
        AbsBankomat Bankomat { get; set; }
        dynamic Conto { get; set; }
        List<OperazioniBankomat> OperazioniConsentite { get; set; }

        public BankomatMenu(AbsBankomat bankomat, dynamic conto, List<OperazioniBankomat> operazioniConsentite = null)
        {
            Bankomat = bankomat;
            Conto = conto;
            OperazioniConsentite = new List<OperazioniBankomat>();
            if (operazioniConsentite == null)
            {
                OperazioniConsentite.Add(OperazioniBankomat.Saldo);
                OperazioniConsentite.Add(OperazioniBankomat.Prelievo);
                OperazioniConsentite.Add(OperazioniBankomat.Versamento);
            }
            else
            {
                OperazioniConsentite = operazioniConsentite;
            }
        }

        public void OperationMenu()
        {
            while (true)
            {
                OperazioniBankomat input;
                do
                {
                    Console.Clear();

                    Console.WriteLine($"{(int)OperazioniBankomat.Esci} - {OperazioniBankomat.Esci}");
                    foreach (var item in OperazioniConsentite.OrderBy(x => x))
                    {
                        Console.WriteLine($"{(int)item} - {item}");
                    }
                    Console.WriteLine("----------------------------------------------------\nInserisci indice Comando");
                 
                    try
                    {
                        input = (OperazioniBankomat)int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        input = (OperazioniBankomat)(-1);
                    } //input = readline

                    if (input == OperazioniBankomat.Esci) 
                    {
                        Console.WriteLine("Chiusura del OperationMenu Bankomat");
                        return;
                    } // Exit System

                }
                while (!OperazioniConsentite.Contains(input));
                MenuOptions(input, Conto);

            }
        }

        void ConsoleWriteSaldo(dynamic contoCorrente)
        {
            Console.WriteLine($"Saldo disponibile : {Bankomat.Saldo(contoCorrente)}       {DateTime.UtcNow}");
        }

        public void MenuOptions(OperazioniBankomat input, dynamic contoCorrente)
        {

            switch (input)
            {
                case OperazioniBankomat.Saldo:
                    {
                        ConsoleWriteSaldo(contoCorrente);
                        Console.ReadKey();
                        break;
                    }

                case OperazioniBankomat.Versamento:
                    {
                        try
                        {
                            Console.WriteLine("Inserisci quantità da Versare");
                            var importo = double.Parse(Console.ReadLine());
                            Bankomat.Versamento(contoCorrente,importo);
                            Console.WriteLine("Versamento Effettuato con Successo");
                            ConsoleWriteSaldo(contoCorrente);
                            Console.ReadKey();
                        }
                        catch (System.FormatException)
                        {
                            ConsoleUtilities.WriteError("Valore Inserito non è numerico");
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            ConsoleUtilities.WriteError("Importo Valore negativo non accettato");
                        }
                        break;
                    }

                case OperazioniBankomat.Prelievo:
                    {
                        try
                        {
                            Console.WriteLine("Inserisci quantità da Prelevare");
                            var importo = double.Parse(Console.ReadLine());
                            Bankomat.Prelievo(contoCorrente,importo);
                            Console.WriteLine("Prelievo Effettuato con Successo");
                            ConsoleWriteSaldo(contoCorrente);
                            Console.ReadKey();

                        }
                        catch (System.FormatException)
                        {
                            ConsoleUtilities.WriteError("Valore Inserito non è numerico");
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            ConsoleUtilities.WriteError("Importo Valore negativo non accettato");
                        }
                        catch (ArgumentException)
                        { 
                            ConsoleUtilities.WriteError("Importo inserito supera Deposio attuale");
                        }
                        break;
                    }

                default:
                    {
                        ConsoleUtilities.WriteError("Operazione Invalida");
                        break;
                    }
            }
        }

    }
}
