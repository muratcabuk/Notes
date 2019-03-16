using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Singleton
{
  public  class PlugCreator
    {

        private Object locker = new object();
        private Plug _plug { get; set; }


        public Plug CreatePlug()
        {
            if (_plug == null)
            {
                lock (locker)
                {
                    if (_plug == null)
                    {
                        _plug = new Plug(Guid.NewGuid());
                    }
                }
            }
            return _plug;
        }

    }
}
