using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Factory
{
   public class Halvah : Product
    {

        public override void CreateProduct()
        {

            Name = "Helva";

            Ingredients = new List<Ingredient>
            {

                new Powder(),
                new Sugar()


            };


            Console.WriteLine("Helva Üretildi");


        }
    }
}
