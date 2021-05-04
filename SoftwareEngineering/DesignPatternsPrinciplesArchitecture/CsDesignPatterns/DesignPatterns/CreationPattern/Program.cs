using System;
using System.Collections.Generic;
using CreationalPattern.Builder.MessageExample;
using CreationalPattern.Factory.Roles;
using CreationalPattern.Prototype;
using CreationalPattern.Singleton;

namespace CreationalPattern
{





    class Program
    {

       static void createAbstractFactory()
        {

            //AbstractFactory.AbstractFactory _abstractFactory = new AbstractFactory.AbstractFactory();
            //var box =   _abstractFactory.ProductSmallBox();
            //Console.WriteLine(  "depth = " + box.Depth);



            CreationalPattern.AbstractFactory.Bank.AbstractFactory _abstractFactoryBank = new CreationalPattern.AbstractFactory.Bank.AbstractFactory();

            _abstractFactoryBank.MakeDeposite();

        }


        static void createBuilder()
        {

            //var order = new Order();

            //order.PrepareOrder(new Menu1());

            //Console.WriteLine(order.ToString());


            var MessageManager = new MessageManager(new FeastMessage());


        }


        static void createFactory()
        {

            var  factory = new Factory.Factory();


        }

        static void createRoles()
        {

            var userFactoery = new UserFactory();


        }



        static void createPrototype()
        {

            var client = new Client();

        }


        static void createProtoTypeRoles()
        {

         




            var pt1 = "Prototype Başla:" + DateTime.Now;

            var userFactoery = new FactoryPrototype.UserFactory();

            var pt2 = "Prototype Başla:" + DateTime.Now;

            Console.WriteLine(pt1);
            Console.WriteLine(pt2);

            Console.WriteLine("-------------------------------------");


            List<string> users = new List<string>();

            var t1 = "Başla:" + DateTime.Now;

            string a = string.Empty;

            for (int i = 0; i < 50000; i++)
            {
                a += Guid.NewGuid().ToString();
            }

            foreach (var u in users)
            {
                Console.WriteLine(u);
            }


            var t2 = "Bitir:" + DateTime.Now;


            Console.WriteLine(t1);
            Console.WriteLine(t2);

        }


        static void createSingleton()
        {


            var plugCreator = new PlugCreator();







        }



        static void Main(string[] args)
        {

            createSingleton();


        }
    }
}
