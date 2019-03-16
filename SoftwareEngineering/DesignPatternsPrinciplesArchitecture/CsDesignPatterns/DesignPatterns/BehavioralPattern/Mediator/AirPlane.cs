using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPattern.Mediator
{
   public abstract class AirPlane
    {
       public ITower RelatedTower { get; set; }

        public string FlightNo { get; set; }

        public bool LandingPermit { get; set; }



        public void RequestLandingPermit()
        {

            RelatedTower.RequestLandingPermit(FlightNo);

        }

        public virtual void SetLandingPermit(bool permit)
        {

            LandingPermit = permit;

            if(LandingPermit)
            {

                Console.WriteLine("izin verildi");
            }
            else
            {

                Console.WriteLine("izin reddedildi");

            }


        }


    }
}
