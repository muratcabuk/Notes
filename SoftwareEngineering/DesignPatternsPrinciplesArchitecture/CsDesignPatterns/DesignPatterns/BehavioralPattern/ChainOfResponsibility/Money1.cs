using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.ChainOfResponsibility
{
    public class Money1 : Banknote
    {
        public override Amount Withdraw(int amount)
        {
            throw new NotImplementedException();
        }

     
       
    }
}
