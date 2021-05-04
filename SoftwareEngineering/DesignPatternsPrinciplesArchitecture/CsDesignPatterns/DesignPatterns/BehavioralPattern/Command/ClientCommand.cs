using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Command
{
   public class ClientCommand
    {

        public ClientCommand()
        {
            Person person = new Person { Id = 1, Name = "Murat" };

            PersonManager pm = new PersonManager(person);

            CommandPerson cpAdd = new CommandPersonAdd(pm);
            CommandPerson cpDelete = new CommandPersonAdd(pm);


            PersonInvoker pi = new PersonInvoker();


            pi.CommanPersonList.Add(cpAdd);
            pi.CommanPersonList.Add(cpDelete);


            pi.ExecuteAll();








        }








    }
}
