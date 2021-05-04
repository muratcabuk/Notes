using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Factory.Roles
{
   public class UserFactory
    {

        public UserFactory()
        {

            var erkan = new User
            {

                Name = "Erkin Kilman",

                Role = new Admin()


            };


            Console.WriteLine(erkan.Name);

            Console.WriteLine("{0} Rolü verildi.", erkan.Role.Name);


            Console.WriteLine("--------Yetkileri--------");

            foreach (var permission in erkan.Role.Permissions)
            {

               Console.WriteLine(permission.Name);
                
            }








        }


    }
}
