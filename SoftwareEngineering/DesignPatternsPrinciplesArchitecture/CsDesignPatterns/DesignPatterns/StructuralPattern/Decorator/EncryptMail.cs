using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Decorator
{
    public class EncryptMail : Decorator
    {


        private string _passKey;
        public EncryptMail(Imail mail, string passKey) : base(mail)
        {


            _passKey = passKey;

           
        }

        public override void SendMail()
        {

            Console.WriteLine("Mail {0} key ile Şifrelendi", _passKey);
            base.SendMail();
        }
    }
}
