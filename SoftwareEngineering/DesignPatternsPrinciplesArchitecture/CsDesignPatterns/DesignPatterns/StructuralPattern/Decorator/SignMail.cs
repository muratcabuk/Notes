using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Decorator
{
    class SignMail : Decorator
    {

        string _sign;

        public SignMail(Imail mail) : base(mail)
        {
            _sign = "Murat Çabuk";


        }

        public override void SendMail()
        {

            Console.WriteLine("Mail {0} imzası ile imzalandı.", _sign);

            base.SendMail();
        }


    }
}
