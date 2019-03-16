using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Decorator
{
  public abstract  class Decorator : Imail
    {

        private Imail _mail;

        public Decorator(Imail mail)
        {

            _mail = mail;

        }

        public virtual void SendMail()
        {
            _mail.SendMail();
        }
    }
}
