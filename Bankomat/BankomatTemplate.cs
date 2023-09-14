using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class BankomatTemplate : AbsBankomat
    {
        public override void Prelievo(dynamic contoCorrente, double importo)
        {
            var conto = ContiCorrente[contoCorrente];
            if (importo <= conto.Saldo)
            {
                conto.Prelievo(importo);
            }
            else
            {
                throw new Exception("Desired quantity Exceed Target's Capacity");
            }
        }

        public override void Versamento(dynamic contoCorrente, double importo)
        {
            ContiCorrente[contoCorrente].Versamento(importo);
        }

    }
}
