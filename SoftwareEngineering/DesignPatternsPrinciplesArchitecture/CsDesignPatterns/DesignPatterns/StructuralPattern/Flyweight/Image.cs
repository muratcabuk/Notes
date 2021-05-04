using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Flyweight
{

    public enum BitList {

        High = 32,
        Small = 8,
        Medium = 24
    }


   public class Image
    {


        public int Id { get; set; }
        public int width { get; set; }
        public int Height { get; set; }
        public BitList BitValue { get; set; }


        public override string ToString()
        {
            return "Resim boyutu " + width + " Height " + Height + " Resim Derinliği " + BitValue;
        }


    }
}
