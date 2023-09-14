using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal abstract class AbsBankomat
    {
        internal class ContoCorrente
        {
            internal dynamic Cliente { get; set; }
            internal double Saldo { get; set; }
            internal void Prelievo(double import)
            {
                if (import > 0)
                {
                    Saldo -= import;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Negative import not accepted");
                }
            }
            internal void Versamento(double import)
            {
                if (import > 0)
                {
                    Saldo += import;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Negative import not accepted");
                }
            }

        }

        protected Dictionary<dynamic, ContoCorrente> ContiCorrente { get; set; } = new Dictionary<dynamic, ContoCorrente>();

        public virtual void Add(dynamic conto, double saldoIniziale)
        {
            ContiCorrente[conto] = new ContoCorrente() { Saldo = saldoIniziale, Cliente = conto};
        }
        public virtual double Saldo(dynamic contoCorrente)
        {
            return ContiCorrente[contoCorrente].Saldo;
        }
        public abstract void Prelievo(dynamic contoCorrente, double importo);
        public abstract void Versamento(dynamic contoCorrente, double importo);

    }
}
