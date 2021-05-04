using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.ChainOfResponsibility
{
  public  class Bankamatic
    {

        Money100 _100 = new Money100();
        Money10 _10 = new Money10();
        Money1 _1 = new Money1();


        public List<Amount> Withdraw(int amount)
        {

            Console.WriteLine("Toplam Tutar: " + amount);


            _100.Next(_10);
            _10.Next(_1);


            Amount result = new Amount();

            List<Amount> results = new List<Amount>();

            do
            {

                results.Add(amount = _100.Withdraw(amount));
                amount = result.Balance;

            } while (result.Balance > 0);


            foreach(var r in results)
            {

                Console.WriteLine("Tutar: " +r.Amount + " Adet: " + r.Quantity);

            }

            return null;


        }




    }
}
