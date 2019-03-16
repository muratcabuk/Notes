using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Command
{
  public  class PersonInvoker
    {

       public List<CommandPerson> CommanPersonList { get; set; }

        public PersonInvoker()
        {


            CommanPersonList = new List<CommandPerson>();

        }

        public void ExecuteAll()

        {
            if(CommanPersonList.Count ==0)
            {
                return;
            }

            foreach(CommandPerson commandPerson in CommanPersonList)
            {

                commandPerson.Execute();

            }



        }




    }
}
