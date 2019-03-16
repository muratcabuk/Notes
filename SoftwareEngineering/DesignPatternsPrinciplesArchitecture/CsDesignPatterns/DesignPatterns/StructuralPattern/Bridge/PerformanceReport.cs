using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Bridge
{
   public class PerformanceReport : Report
    {
        public PerformanceReport(IReportFormat reportFormat) : base(reportFormat)
        {
        }

        public override void Display()
        {

            Console.WriteLine("Performance raporu oluşturuldu");


            base.Display();
        }
    }
}
