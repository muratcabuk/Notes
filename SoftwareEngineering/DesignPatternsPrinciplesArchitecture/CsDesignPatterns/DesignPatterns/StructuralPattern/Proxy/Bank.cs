using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Proxy
{
    public class Bank : IBank
    {
        public bool MakeDeposite(double amount)
        {
            
            if(amount > 100)
            {

                Console.WriteLine($"100 tl den yüksek olamaz. Fark -> { amount - 100}");
                return false;

            }
            else if (amount < 100)
            {
                Console.WriteLine($"100 tl den az olamaz. Fark -> { 100 - amou}");
                return false;

            }
            else
            {

                Console.WriteLine("Ödeme yapıldı");
            }

            return true;
        }
    }
}
