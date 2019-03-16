using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Command
{
    public class CommandPersonAdd : CommandPerson
    {
        public CommandPersonAdd(PersonManager personManager) : base(personManager)
        {


        }

        public override void Execute()
        {
            _personManager.Add();
        }
    }
}
