using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.FactoryPrototype
{
    public class UserFactory
    {

        public UserFactory()
        {


            var userList = new List<User>();

            var user1 = new User
            {
                Name = "user",
                Role = new Admin()
            };

            for (int i = 0; i < 50000; i++)
            {
                var user2 = user1.Clone() as User;
                user2.Name = Guid.NewGuid().ToString();
                userList.Add(user2);


            }

            foreach (var user in userList)
            {
                
                Console.WriteLine(user.Name);


            }


           





        }


    }
}
