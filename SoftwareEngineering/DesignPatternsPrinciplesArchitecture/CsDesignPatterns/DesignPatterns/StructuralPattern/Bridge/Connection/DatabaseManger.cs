using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Bridge.Connection
{
   public class DatabaseManger
    {

        public IConnection Connection { get; private set; }


        public DatabaseManger(IConnection connection)
        {
            Connection = connection;
        }

        public virtual void Execute(string sql)
        {



            Connection.Connect();
        }








    }
}
