using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Mediator
{
  public  class THYAirplane : AirPlane
    {

        public override void SetLandingPermit(bool permit)
        {
            Console.WriteLine("THY uçuş no {0} iniş izni istiyor...", FlightNo);

            base.SetLandingPermit(permit);
        }
    }
}
