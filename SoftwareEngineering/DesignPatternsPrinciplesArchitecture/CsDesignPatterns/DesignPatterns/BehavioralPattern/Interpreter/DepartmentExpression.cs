using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Interpreter
{
    public abstract class DepartmentExpression 
    {

        public abstract void Interpret(Context context);

    }
}
