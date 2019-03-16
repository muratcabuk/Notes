using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Memento
{
    public class ClientObserver
    {

        public ClientObserver(){
             PersonMemento p = new PersonMemento
             {
                 Age = 34,
                 Name = "Ali",
                 Id = 1
             };


            Console.WriteLine(p.Name);

            PersonMemory pm = new PersonMemory();

            pm.PersonCopy = p.CreateMemento();

            p.Name = "Değştirilen";
            Console.WriteLine(p.Name);


            p.BindMemento(pm.PersonCopy);
            Console.WriteLine(p.Name);



    }

    }

   }

