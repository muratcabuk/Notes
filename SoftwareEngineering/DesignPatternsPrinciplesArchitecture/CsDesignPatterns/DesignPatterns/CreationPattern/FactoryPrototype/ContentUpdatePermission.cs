using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.FactoryPrototype
{
    public class ContentUpdatePermission : Permission
    {


        public ContentUpdatePermission()
        {

            Name = "İçerik Editleme Yetkisi";
          //  Console.WriteLine("{0}", Name + " yetkisine sahip.");



        }
    }
}
