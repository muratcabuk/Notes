﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Composite
{
   public class Tree : INode
    {
        public string Title { get; set; }
        public INode ParentNode { get; set; }

        public List<INode> _ChildNodes;

        public List<INode> ChildNodes {
            get
            {

                if (_ChildNodes == null) { _ChildNodes = new List<INode>(); }
                return _ChildNodes;
            }
        }


        public Tree(string title)
        {

            ParentNode = null;
            Title = title;

        }












    }
}
