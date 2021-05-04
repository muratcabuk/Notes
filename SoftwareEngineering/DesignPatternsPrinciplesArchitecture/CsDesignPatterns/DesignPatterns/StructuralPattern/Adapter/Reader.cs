using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Adapter
{
  public  class Reader : IReaderAdapter
    {
        public void Read()
        {
           var txtReader = new TxtReader();

            Console.WriteLine(txtReader.ReadFromTxt());

        }
    }
}
