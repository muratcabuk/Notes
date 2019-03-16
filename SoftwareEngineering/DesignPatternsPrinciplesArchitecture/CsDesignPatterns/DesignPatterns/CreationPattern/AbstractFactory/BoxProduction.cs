using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.AbstractFactory
{
  public  class BoxProduction
    {

        private ProductionProcess _productionProcess;
        private SizeSettings _sizeSetttings;
        private ColorSettings _colorSettings;
        private OtherSettings _otherSettings;


        public BoxProduction(ProductionProcess productionProcess)
        {

            _productionProcess = productionProcess;

            _sizeSetttings = productionProcess.SetSizeSettings();
            _colorSettings = productionProcess.SetColorSettings();
            _otherSettings = productionProcess.SetOtherSettings();

        }



        public Box ProductBox(int width, int height, int depth, Colors color, OtherSettings otherSettings)
        {

            // alında buradaki processler sadece moduller. yani bir kutu üretilirken geçeceği process leri belirtiyoruz.
            // her kutu farklı processler den geçilebilir.

            _sizeSetttings.Depth(depth);
            _sizeSetttings.Width(width);
            _sizeSetttings.Height(height);
            _colorSettings.SetColor(color);


            _otherSettings.property1 = otherSettings.property1;
            _otherSettings.property2 = otherSettings.property2;
            _otherSettings.property3 = otherSettings.property3;


            Console.WriteLine("Küçük kutu üretildi");


            //tabi bu anlamsız oldu size ve color dışında başka processleri aslında process olarak yazmak lazım. 
            // Bu sadece bir örnek olduğu için 

            Box box = new Box();

            box.Colors = color;
            box.Depth = depth;
            box.Height = height;
            box.Width = width;


            return box;



        }


    }
}
