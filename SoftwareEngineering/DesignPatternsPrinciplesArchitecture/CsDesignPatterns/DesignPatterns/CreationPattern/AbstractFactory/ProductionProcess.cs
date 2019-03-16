using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.AbstractFactory
{
   public abstract class ProductionProcess
    {

        public abstract SizeSettings SetSizeSettings();

        public abstract ColorSettings SetColorSettings();


        public abstract OtherSettings SetOtherSettings();



    }
}
