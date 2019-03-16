using System;

namespace CreationalPattern.AbstractFactory.SaleExample
{
   public class TaxProcess : Process
    {
        public override void Apply()
        {
            Console.WriteLine("Tax uygulandı");
        }
    }
}
