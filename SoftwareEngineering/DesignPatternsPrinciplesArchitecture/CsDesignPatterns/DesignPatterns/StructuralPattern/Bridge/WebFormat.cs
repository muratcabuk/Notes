using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Bridge
{
 public   class WebFormat : IReportFormat
    {
        public void Generate()
        {
            Console.WriteLine("Web Format oluşturuldu");
        }
    }
}
