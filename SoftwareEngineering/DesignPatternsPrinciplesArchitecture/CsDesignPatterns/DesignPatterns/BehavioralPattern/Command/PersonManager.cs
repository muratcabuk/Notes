using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Command
{
   public class PersonManager
    {

        private Person _person;

        public PersonManager(Person person)
        {

            _person = person;


        }

        public void Add()
        {

            Console.WriteLine("{0} Eklendi.", _person.Name);

        }


        public void Delete()
        {

            Console.WriteLine("{0} Silindi.", _person.Name);

        }



    }
}
