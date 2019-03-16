using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Factory.Roles
{
   public   abstract class Role
    {

                public  string Name { get; set; }


        public Role()
        {

            CreateRole();

            foreach (var permission in Permissions)
            {


                Console.WriteLine("{0} yetkisi {1} Rolüne eklendi", permission.Name, Name);

            }


        }



        public List<Permission> Permissions { get; set; }




        public abstract void CreateRole();



    }
}
