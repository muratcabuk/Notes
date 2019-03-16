using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.AbstractFactory
{
    public class SmallBoxColorSettings : ColorSettings
    {
        public override void SetColor(Colors colors)
        {
            Console.WriteLine("Kucuk kutu renk ayarlandı");
        }
    }
}
