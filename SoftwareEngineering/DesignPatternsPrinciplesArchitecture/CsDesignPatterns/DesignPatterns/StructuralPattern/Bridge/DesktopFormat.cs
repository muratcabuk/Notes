using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Bridge
{
  public  class DesktopFormat:IReportFormat
    {
        public void Generate()
        {
            Console.WriteLine("Desktop Format oluşturuldu");
        }
    }
}
