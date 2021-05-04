using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Builder.MessageExample
{
  public  class Message
    {

        public  string To { get; set; }
        public string From { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }


        public override string ToString()
        {
            return String.Format("From: {0}, To: {1}", From, To);
        }
    }
}
