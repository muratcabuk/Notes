using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Adapter.DateTimeExample
{
   public class DateTimeDate
   {

       private DateTime _dt;
        public DateTimeDate(DateTime dt)
        {

            _dt = dt;

        }

        public string GetDateTime()
        {
            return _dt.ToString();
        }
    }
}
