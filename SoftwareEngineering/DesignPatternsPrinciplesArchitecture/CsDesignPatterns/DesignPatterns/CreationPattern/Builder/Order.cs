using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Builder
{
   public class Order
    {
        public void PrepareOrder(MenuBuilder menuBuilder)
        {

            menuBuilder.AddGarniture();
            menuBuilder.AddBeverage();

            Console.WriteLine(menuBuilder.Menu.ToString());


        }


    }
}
