using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.AbstractFactory
{
    public class SmallBoxProductionProcess : ProductionProcess
    {
        public override ColorSettings SetColorSettings()
        {
            return new SmallBoxColorSettings();
        }

        public override SizeSettings SetSizeSettings()
        {
            return new SmallBoxSizeSettings();
        }
        public override OtherSettings SetOtherSettings()
        {
            return new SmallBoxOtherSettings();
        }
    }
}
