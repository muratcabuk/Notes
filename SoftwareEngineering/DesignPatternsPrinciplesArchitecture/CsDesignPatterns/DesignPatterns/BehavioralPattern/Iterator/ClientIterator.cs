using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Iterator
{
  public  class ClientIterator
    {

        public ClientIterator()
        {

            var datetimeAggrete = new DateTimeAggregate();


            datetimeAggrete.startDate = new DateTime(2018, 1, 1);
            datetimeAggrete.endDate = DateTime.Now;

            IIterator iterator = datetimeAggrete.CreateAggregator();

            while (iterator.HasDate())
            {

                Console.WriteLine(iterator.CurrentDate());

            }


          




        }


    }
}
