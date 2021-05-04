using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Interpreter
{
    public static class InterpreterRun
    {
        public static List<DepartmentExpression> CreateExpressionTree(string formula)
        {
            List<DepartmentExpression> tree = new List<DepartmentExpression>();

            foreach (var role in formula)
            {

                if (role == 'S')
                    tree.Add(new SalesDepartmentExpression());
                else if (role == 'I')
                    tree.Add(new HRDepartmentExpression());
                else if (role == 'Y')
                    tree.Add(new SoftwareDepartmentExpression());

               
            }


            return tree;


        }


        public static void RunExpression(Context context)
        {

            foreach (DepartmentExpression  expression in CreateExpressionTree(context.Formula))
            {

                expression.Interpret(context);


                Console.WriteLine("{0} için maliyet  {1}", context.Formula, context.TotalCost);


            }


        }



    }
}
