using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Factory.Roles
{
   public class ContentAddPermission : Permission
    {


        public ContentAddPermission()
        {

            Name = "İçerik Ekleme Yetkisi";
          //  Console.WriteLine("{0}", Name + " yetkisine sahip.");



        }
    }
}
