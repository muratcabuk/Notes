using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Command
{
   public class CommandPersonDelete : CommandPerson
    {
        public CommandPersonDelete(PersonManager personManager) : base(personManager)
        {


        }

        public override void Execute()
        {
            _personManager.Delete();
        }
    }
}
