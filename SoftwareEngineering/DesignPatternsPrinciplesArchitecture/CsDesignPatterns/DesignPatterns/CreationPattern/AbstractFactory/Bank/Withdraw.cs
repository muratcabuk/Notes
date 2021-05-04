using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.AbstractFactory.Bank
{
   public class Withdraw : ProcessPhases
    {
        public override Process BankProcess()
        {
            return  new WithdrawProcess();
        }
    }
}
