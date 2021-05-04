using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Memento
{
   public class PersonMemento 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person CreateMemento()
        {

            return new Person
            {

                Age = this.Age,
                Id = this.Id,
                Name = this.Name


            };


        }


        public void BindMemento(Person person)
        {

            this.Name = person.Name;
            this.Id = person.Id;
            this.Age = person.Age;

        }


    }
}
