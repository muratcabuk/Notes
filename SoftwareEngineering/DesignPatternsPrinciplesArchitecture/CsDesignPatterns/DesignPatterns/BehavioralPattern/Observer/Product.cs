using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Observer
{
    public class Product : BaseProduct
    {
        public Product(string productName, decimal price) : base(productName, price)
        {
        }
    }
}
