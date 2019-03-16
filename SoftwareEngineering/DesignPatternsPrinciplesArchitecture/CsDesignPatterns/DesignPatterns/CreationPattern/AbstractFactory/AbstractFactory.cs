using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.AbstractFactory
{
   public class AbstractFactory
    {

        public Box ProductSmallBox()
        {

            SmallBoxProductionProcess smallBoxProductionProcess = new SmallBoxProductionProcess();
            BoxProduction boxProduction = new BoxProduction(smallBoxProductionProcess);

            OtherSettings otherSettings = new SmallBoxOtherSettings();

            otherSettings.property1 = "sdf";
            otherSettings.property2 = "dfg";
            otherSettings.property3 = "rtrt";


           //aslında SmallBox objesi içinde hakikaten small box objesi oluşturabiliriz 
           return boxProduction.ProductBox(100, 100, 100, Colors.Blue, otherSettings);





        }



    }
}
