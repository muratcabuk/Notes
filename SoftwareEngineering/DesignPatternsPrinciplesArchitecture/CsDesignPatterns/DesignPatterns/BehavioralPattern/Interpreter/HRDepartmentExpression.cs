﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Interpreter
{
   public class HRDepartmentExpression : DepartmentExpression
    {
        public override void Interpret(Context context)
        {
            context.TotalCost += 10;
        }
    }
}
