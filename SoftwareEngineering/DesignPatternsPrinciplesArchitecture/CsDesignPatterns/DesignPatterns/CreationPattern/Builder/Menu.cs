using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Builder
{
   public class Menu
    {

        public  string Meal { get; set; }

        public string Garniture { get; set; }

        public string Beverage { get; set; }


        public override string ToString()
        {
            return String.Format("{0} \n {1} \n {2} \n", Meal, Garniture, Beverage);
        }
    }
}
