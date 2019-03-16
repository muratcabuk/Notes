using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Decorator
{
    public class Mail : Imail
    {
        public void SendMail()
        {
            Console.WriteLine("Mail Gönderildi");
        }
    }
}
