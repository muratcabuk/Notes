using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Adapter.DateTimeExample
{
   public class DateTimeString
    {

        private string _dt;
        public DateTimeString(string dt)
        {

            _dt =  dt;

        }


        public string TakeDateTime()
        {
            return _dt.ToString();
        }
    }
}
