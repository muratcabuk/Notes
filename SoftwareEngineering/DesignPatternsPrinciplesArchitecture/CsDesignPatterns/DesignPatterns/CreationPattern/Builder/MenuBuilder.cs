using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Builder
{
   public abstract class MenuBuilder
   {
       protected Menu _menu;

       public Menu Menu => _menu;

       public abstract void AddGarniture();

       public abstract void AddBeverage();


   }
}
