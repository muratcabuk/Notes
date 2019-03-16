using System;
using System.Collections.Generic;

namespace CreationalPattern.Factory
{
   public class Cake : Product
    {
        
        public override void CreateProduct()
        {

            Name = "Kek";

            Ingredients = new List<Ingredient>
            {

                new Powder(),
                new Sugar()


            };



            Console.WriteLine("Kek Üretildi");


        }
    }
}
