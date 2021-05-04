using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Composite
{
   public class CompositeCreator
    {

        public CompositeCreator()
        {
            INode tree = new Tree("Turkiye");

            var ankara = new Node("Ankara", tree);
            var ankara_cankaya = new Node("Çankaya", ankara);
            ankara.ChildNodes.Add(ankara_cankaya);


            var istanbul = new Node("İstanbul", tree);
            var istanbul_uskudar = new Node("üsküdar", istanbul);
            istanbul.ChildNodes.Add(istanbul_uskudar);

            tree.ChildNodes.AddRange(new List<INode> { ankara, istanbul});


            writeTree(tree);
        }


        private void writeTree(INode tree)
        {
            var i = 1;
            Console.WriteLine(tree.Title);
            if(tree.ChildNodes!=null)
            {
                writeChildNode(tree.ChildNodes, i);
            }

        }


       
        private void writeChildNode(List<INode> childNodes, int intend)
        {

            int j = 2;
            foreach (var childnode in childNodes)
            {
                Console.WriteLine(new string('-', intend) + childnode.Title);

                if(childnode.ChildNodes!=null)
                {
                    writeChildNode(childnode.ChildNodes,j);
                   

                }
                j++;
            }
        }












    }
}
