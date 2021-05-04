using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.AbstractFactory.Bank
{
   public class DepositProcess : Process
    {
        public override void Apply()
        {
            Console.WriteLine("Para yatırıldı");
        }
    }
}
