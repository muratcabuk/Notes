using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Iterator
{
    public class DateTimeIterator : IIterator
    {

        DateTimeAggregate _aggregate;
        DateTime _currentDate;



        public DateTimeIterator(DateTimeAggregate aggregate)
        {

            _aggregate = aggregate;

            _currentDate = _aggregate.startDate;
        }


        public DateTime CurrentDate()
        {
            return _currentDate;
        }

        public bool HasDate()
        {
            //bitiş tarihine kadar ki hafta sonlarını hesaplıyor.

            if(_currentDate.DayOfWeek == DayOfWeek.Saturday || _currentDate.DayOfWeek == DayOfWeek.Sunday)
            {

                int dayCount = _currentDate.DayOfWeek == DayOfWeek.Saturday ? 1 : 6;

                _currentDate = _currentDate.AddDays(dayCount);

            }
            else
            {
                int dayCount = (int)_currentDate.DayOfWeek;

                _currentDate = _currentDate.AddDays(6 -dayCount);



            }


            return _currentDate < _aggregate.endDate;
        }
    }
}
