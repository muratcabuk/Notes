using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Interpreter
{
    class ClientInterpreter
    {


        public ClientInterpreter()
        {

        Context context = new Context { Formula = "SYIS" };

        InterpreterRun.RunExpression(context);
        }



    }
}
