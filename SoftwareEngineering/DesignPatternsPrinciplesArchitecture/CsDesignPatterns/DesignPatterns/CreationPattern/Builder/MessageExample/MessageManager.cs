using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Builder.MessageExample
{
   public class MessageManager
    {






        public  MessageManager( MessageBuilder messageBuilder)
        {

            messageBuilder.SetFrom("murat");
            messageBuilder.SetTo("mehmet");


            Console.WriteLine(String.Format("From: {0}, To: {1}", messageBuilder.Message.From, messageBuilder.Message.To));



        }
    }
}
