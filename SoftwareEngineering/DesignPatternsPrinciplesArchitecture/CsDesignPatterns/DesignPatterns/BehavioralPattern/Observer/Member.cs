using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Observer
{
    public class Member : IMember
    {

        public string Email { get; set; }

        public void Update(BaseProduct product)
        {
            Console.WriteLine("{0} ın fiyatı {1} oldu {2} adresine göndrildi.", product.ProductName, product.Price.ToString(), Email);
        }
    }
}
