using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Bridge.Connection
{
  public  class SqlServerManager : DatabaseManger
    {
        public SqlServerManager(IConnection connection) : base(connection)
        {
        }
    }
}
