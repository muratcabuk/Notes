using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.AbstractFactory
{
    public class SmallBoxOtherSettings : OtherSettings
    {

        private string _property1 = String.Empty;
        private string _property2 = String.Empty;
        private string _property3 = String.Empty;


        public override string property1 { get =>  _property1; set {

                Console.WriteLine("property1 set edildi");
                _property1 = value;

            } }
        public override string property2
        {
            get => _property2; set
            {

                Console.WriteLine("property2 set edildi");
                _property2 = value;

            }
        }

        public override string property3
        {
            get => _property3; set
            {

                Console.WriteLine("property3 set edildi");
                _property3 = value;

            }
        }
    }
}
