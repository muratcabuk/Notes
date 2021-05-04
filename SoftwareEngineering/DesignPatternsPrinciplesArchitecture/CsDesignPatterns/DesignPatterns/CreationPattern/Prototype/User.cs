using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Prototype
{
  public  class User : MySite
    {


        public string Name { get; set; }

        
        public override MySite Clone()
        {
            return this.MemberwiseClone() as MySite;
        }
    }
}
