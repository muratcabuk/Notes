using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.AbstractFactory
{


   public abstract class SizeSettings
    {
        public abstract void Width(int width);

        public abstract void Height(int height);

        public abstract void Depth(int depth);
    }
}
