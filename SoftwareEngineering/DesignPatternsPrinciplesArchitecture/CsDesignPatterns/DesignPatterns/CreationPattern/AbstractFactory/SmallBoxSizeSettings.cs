using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.AbstractFactory
{
    public class SmallBoxSizeSettings : SizeSettings
    {
        public override void Depth(int iDepth)
        {
            Console.WriteLine("Kucuk kutu derinlik ayarlandı");
        }

        public override void Height(int iHeight)
        {
            Console.WriteLine("Kucuk kutu yükseklik ayarlandı");
        }

        public override void Width(int iWidth)
        {
            Console.WriteLine("Kucuk kutu genişlik ayarlandı");
        }
    }
}
