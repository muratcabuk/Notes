using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.ChainOfResponsibility
{
    public class Money100 : Banknote
    {
        public override Amount Withdraw(int amount)
        {
            
            if(amount >= 100)
            {
                return new Amount
                {
                    Quantity = amount / 100,
                    Balance = amount % 100,
                    Total = 100

                };


            }
            else
            {

                

            }

        }
    }
}
