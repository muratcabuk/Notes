using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Factory.Roles
{
  public  class Admin : Role
    {
        public override void CreateRole()
        {

            Permissions = new List<Permission>
            {


                new ContentAddPermission(),
               new  ContentUpdatePermission(),
                new UserAddPermission(),
                new UserUpdatePermission()



            };



            Name = "Admin";

            Console.WriteLine("{0} Rolü oluşturuldu", Name);
        }
    }
}
