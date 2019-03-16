using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Iterator
{
    public class DateTimeAggregate : IAggregator
    {


        public DateTime startDate;
        public DateTime endDate;



        public DateTimeIterator CreateAggregator()
        {


            return new DateTimeIterator(this);

        }
    }
}
