using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Factory
{
   public abstract class Product
    {

        public  string Name { get; set; }
      


        public Product()
        {

            CreateProduct();

            foreach (var ingredient in Ingredients)
            {


                Console.WriteLine("{0} malzemesi  {1} Ürününe Eklendi", ingredient.Name, Name);

            }


        }



        public List<Ingredient> Ingredients { get; set; }
       

        public abstract void CreateProduct();





    }
}
