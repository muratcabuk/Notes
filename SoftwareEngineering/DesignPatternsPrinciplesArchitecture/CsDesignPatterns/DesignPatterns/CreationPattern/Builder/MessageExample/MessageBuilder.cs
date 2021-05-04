using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Builder.MessageExample
{
  public  abstract class MessageBuilder
    {

        protected Message _message=new Message();

        public Message Message => _message;

       // public abstract void SendMessage();

        public abstract  void SetTo(string To);

        public abstract void SetFrom(string From);



    }
}
