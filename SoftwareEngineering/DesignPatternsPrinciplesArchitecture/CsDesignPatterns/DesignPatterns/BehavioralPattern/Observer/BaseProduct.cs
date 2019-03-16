using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Observer
{
   public abstract class BaseProduct
    {

        public string ProductName { get; set; }
        private decimal _Price { get; set; }

        public List<IMember> memberList = new List<IMember>();

        public BaseProduct(string productName, decimal price)
        {

            ProductName = productName;
            _Price = price;

        }


        public Decimal Price
        {

            get { return _Price}
            set
            {

                if(_Price > value)
                {

                    _Price = value;
                    NotifyProduct();

                }

                _Price = value;
            }


        }

        public void NotifyProduct()
        {
            foreach(IMember item in memberList)
            {

                item.Update(this);

            }


        }



    }
}
