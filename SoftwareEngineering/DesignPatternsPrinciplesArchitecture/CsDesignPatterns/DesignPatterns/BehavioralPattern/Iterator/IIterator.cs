using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Iterator
{
  public interface IIterator
    {

        bool HasDate();


        DateTime CurrentDate();
    }
}
