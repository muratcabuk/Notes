using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Bridge.Connection
{
   public class OracleManager : DatabaseManger
    {
        public OracleManager(IConnection connection) : base(connection)
        {


        }

        public override void Execute(string sql)
        {

            sql += "sdfsdsdf";

            base.Execute(sql);
        }
    }
}
