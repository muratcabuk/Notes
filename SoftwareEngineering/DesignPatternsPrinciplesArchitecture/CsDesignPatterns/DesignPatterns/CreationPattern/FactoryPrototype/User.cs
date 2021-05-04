using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.FactoryPrototype
{
  public  class User : UserPrototype
    {
        public override UserPrototype Clone()
        {
            return this.MemberwiseClone() as User;
        }
    }
}
