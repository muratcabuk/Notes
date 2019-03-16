using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Bridge.Connection
{
   public class MsSqlConnection : IConnection
    {
        public void Connect()
        {
            Console.WriteLine("Sql Server a Bağlandı");
        }
    }
}
