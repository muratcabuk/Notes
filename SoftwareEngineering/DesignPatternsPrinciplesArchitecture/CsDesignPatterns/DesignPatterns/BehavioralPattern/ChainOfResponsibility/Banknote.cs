using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.ChainOfResponsibility
{
    public abstract class Banknote
    {

        protected Banknote _Banknote;



        public void Next(Banknote banknote)
        {

            _Banknote = banknote;

        }


        public abstract Amount Withdraw(int amount);
        





    }
}
