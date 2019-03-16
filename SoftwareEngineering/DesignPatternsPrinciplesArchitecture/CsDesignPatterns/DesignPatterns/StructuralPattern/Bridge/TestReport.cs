using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Bridge
{
   public class TestReport : Report
    {
        public TestReport(IReportFormat reportFormat) : base(reportFormat)
        {
        }

        public override void Display()
        {

            Console.WriteLine("Test raporu oluşturuldu");

            base.Display();
        }
    }
}
