using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Bridge.Connection
{
  public  class OracleConnection : IConnection
    {
        public void Connect()
        {
            Console.WriteLine("Oracle a Bağlandı");
        }
    }
}
