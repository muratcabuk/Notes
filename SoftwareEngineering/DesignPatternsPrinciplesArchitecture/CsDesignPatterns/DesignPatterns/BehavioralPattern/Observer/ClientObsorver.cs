using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Observer
{
   public class ClientObsorver
    {

        public ClientObsorver()
        {

            var product = new Product("Elma", 12);
            product.memberList.Add(new Member { Email = "tt@tt.com" });
            product.memberList.Add(new Member { Email = "cc@tt.com" });

            product.Price = 3;


          }


    }
}
