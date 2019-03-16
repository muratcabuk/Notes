using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.FactoryPrototype
{
    public class UserUpdatePermission : Permission
    {


        public UserUpdatePermission()
        {

            Name = "Kullanıcı Editleme Yetkisi";
           // Console .WriteLine("{0}", Name + " yetkisine sahip.");



        }
    }
}
