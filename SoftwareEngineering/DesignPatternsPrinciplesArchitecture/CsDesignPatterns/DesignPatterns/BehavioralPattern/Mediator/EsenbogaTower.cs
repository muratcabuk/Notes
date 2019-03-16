using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Mediator
{
    class EsenbogaTower : ITower
    {

        private List<AirPlane> _airPlaneList = new List<AirPlane>();
 
        public void RegisterAirPlane(AirPlane airPlane)
        {

            _airPlaneList.Add(airPlane);

            airPlane.RelatedTower = this;

        }

        public void RequestLandingPermit(string flightNo)
        {
            bool permit = true;

                if (_airPlaneList.Where(a => a.LandingPermit == true).Count() > 0);
                    permit = false;


            _airPlaneList.Where(a => a.FlightNo == flightNo).Single().SetLandingPermit(permit);
        }
    }
}
