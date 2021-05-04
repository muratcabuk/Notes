using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Adapter.DateTimeExample
{
  public  class DateScreen : IDateTimeShow
    {
        public string ShowDateTime()
        {

            var dt = new DateTimeString(DateTime.Now.ToString()).TakeDateTime();

            return dt;
        }
    }
}
