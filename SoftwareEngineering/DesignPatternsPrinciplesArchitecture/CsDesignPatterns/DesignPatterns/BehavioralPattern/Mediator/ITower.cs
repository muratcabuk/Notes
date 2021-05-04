using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Mediator
{
  public interface ITower
    {
        void RegisterAirPlane(AirPlane airplane);
        void RequestLandingPermit(string flightNo);


    }
}
