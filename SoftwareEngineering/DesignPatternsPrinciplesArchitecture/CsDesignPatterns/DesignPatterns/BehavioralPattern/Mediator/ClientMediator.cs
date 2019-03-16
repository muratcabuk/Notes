using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Mediator
{
   public class ClientMediator
    {

        public ClientMediator ()
        {

            ITower esenbogaTower = new EsenbogaTower();


            AirPlane ThyTK001 = new THYAirplane {FlightNo = "ThyTK001" };
            AirPlane ThyTK002 = new THYAirplane {FlightNo = "ThyTK002" };
            AirPlane ThyTK003 = new THYAirplane {FlightNo = "ThyTK003" };

            esenbogaTower.RegisterAirPlane(ThyTK001);
            esenbogaTower.RegisterAirPlane(ThyTK002);
            esenbogaTower.RegisterAirPlane(ThyTK003);

            ThyTK001.RequestLandingPermit();
            ThyTK002.RequestLandingPermit();

            //bir sonraki işleme geçebilirsin
            ThyTK001.LandingPermit = false;

            ThyTK001.RequestLandingPermit();


        }
    }
}
