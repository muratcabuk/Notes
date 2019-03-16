using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.FactoryPrototype
{
    public abstract  class UserPrototype
    {
        public string Name { get; set; }

        public Role Role { get; set; }

        public abstract UserPrototype Clone();



    }
}
