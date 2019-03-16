using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Prototype
{
  public  class Client
    {

        public Client()
        {


            //eğer bunu clone ile değilde normal ekleyerek yapsak ve 40000 - 500000 tane yapıp ekrana basarsak zaten sonuç görülecektir. 

            //StringBuilder aslında bu mantıkla çalışmaktadır.

            //50000 tane string ifadeyi sitring builder la oluşturmakla her defasında yeni string oluşturmak arasındn neredeyse 15 kat fark var.


            List<User> users=new List<User>();

            var user = new User {Name = "Murat"};

            users.Add(user);

            var user2 = user.Clone() as User;

            user2.Name = "merhaba";

            users.Add(user2);






        }


    }
}
