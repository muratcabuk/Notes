using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Bridge
{
   public class Report
    {


        public IReportFormat ReportFormat { get; private set; }


        public Report(IReportFormat reportFormat)
        {


            ReportFormat = reportFormat;

        }


        //virtual yapılasınınsebebi bu class dan inheritance edilecek class a da bu fonksiyonu overrite yapma imkanı vermek.
        public virtual void Display()
        {

            Console.Write("Rapor objesi oluşturuldu");

            ReportFormat.Generate();

        }









    }
}
