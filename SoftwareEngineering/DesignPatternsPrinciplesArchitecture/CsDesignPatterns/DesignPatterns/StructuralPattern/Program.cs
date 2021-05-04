using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructuralPattern.Adapter;
using StructuralPattern.Bridge;
using StructuralPattern.Adapter.DateTimeExample;
using StructuralPattern.Composite;
using StructuralPattern.Decorator;
using StructuralPattern.Facade;
using StructuralPattern.Flyweight;
using StructuralPattern.Proxy;

namespace StructuralPattern
{
    class Program
    {

        static void createAdapter()
        {

            IDateTimeShow dts = new DateScreen();

            Console.WriteLine(dts.ShowDateTime());


        }


        static void createBridge()
        {

            Report report = new PerformanceReport(new WebFormat());

            report.Display();




        }

        static void createComposite()
        {


            var composite = new CompositeCreator();

        }




        static void createDecorator()
        {


            Imail mail = new Mail();
            Decorator.Decorator encryptMail = new EncryptMail(mail, "1234");
            SignMail signMail = new SignMail(encryptMail);

            signMail.SendMail();





        }



        static void createFacade()
        {

            var t = new Works();

        }


        static void createProxy()
        {

            var t = new ProxyBank("murat", "123");

            t.MakeDeposite(99);

            t.MakeDeposite(101);

            t.MakeDeposite(100);


        }


        static void createFlyweight()
        {
            var image1 = ImageProcessor.AddImage(1);
            var image2 = ImageProcessor.AddImage(2);
            var image3 = ImageProcessor.AddImage(3);
            var image4 = ImageProcessor.AddImage(4);
            var image5 = ImageProcessor.AddImage(5);
            var image6 = ImageProcessor.AddImage(1);
            Console.WriteLine(ImageProcessor.Images.Count);
        }




        static void Main(string[] args)
        {


            createProxy();


        }
    }
}
