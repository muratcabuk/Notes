using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Command
{
   public abstract class CommandPerson
    {
        protected PersonManager _personManager;

        public CommandPerson(PersonManager personManager)
        {


            _personManager = personManager;

        }


        public abstract void Execute();




    }
}
