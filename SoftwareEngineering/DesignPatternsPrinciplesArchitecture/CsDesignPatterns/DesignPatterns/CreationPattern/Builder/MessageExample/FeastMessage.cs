using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Builder.MessageExample
{
   public class FeastMessage : MessageBuilder
    {

        public FeastMessage()
        {
            _message.Body = "";
            _message.Title = "";
        }

        //public override void SendMessage()
        //{
        //    Console.WriteLine(String.Format("From: {0}, To: {1}", _message.From, _message.To));
        //}
        public override void SetTo(string To)
        {
            _message.To = To;
            
        }

        public override void SetFrom(string From)
        {
            _message.From = From;
        }
    }
}
