using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Mediator
{
   public class USAirplane : AirPlane
    {


        public override void SetLandingPermit(bool permit)
        {
            Console.WriteLine("US uçuş no {0} iniş izni istiyor...", FlightNo);

            base.SetLandingPermit(permit);
        }
    }
}
