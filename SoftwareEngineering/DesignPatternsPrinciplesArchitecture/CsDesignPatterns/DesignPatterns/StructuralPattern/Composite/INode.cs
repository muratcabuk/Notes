using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Composite
{
   public interface INode
    {

        string Title { get; set; }

        INode ParentNode { get;  set; }

        List<INode> ChildNodes { get; }




    }
}
