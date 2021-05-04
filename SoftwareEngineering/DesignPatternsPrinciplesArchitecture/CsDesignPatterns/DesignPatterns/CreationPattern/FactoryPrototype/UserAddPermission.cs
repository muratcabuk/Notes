using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.FactoryPrototype
{
    public class UserAddPermission : Permission
    {


        public UserAddPermission()
        {

            Name = "Kullanıcı Ekleme Yetkisi";
           // Console.WriteLine("{0}", Name + " yetkisine sahip.");



        }

    }
}
