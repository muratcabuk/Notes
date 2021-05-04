using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.FactoryPrototype
{
    public class Editor : Role
    {
        public override void CreateRole()
        {


            Permissions = new List<Permission>
            {


                new ContentAddPermission(),
                new  ContentUpdatePermission(),
               



            };

            Name = "Editör";

            Console.WriteLine("{0} Rolü oluşturuldu",Name);


        }
    }
}
