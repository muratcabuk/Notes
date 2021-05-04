using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Builder
{
   public class Menu3 : MenuBuilder
   {

     
 
        public Menu3()
        {
            _menu = new Menu{Meal = "Tost"};
            

        }

        public override void AddGarniture()
        {
            _menu.Garniture = "garnitur kaşar";
        }

        public override void AddBeverage()
        {
            _menu.Beverage = "içecek kola";
        }
    }
}
