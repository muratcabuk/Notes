using System;

namespace CreationalPattern.AbstractFactory.Bank
{
  public  class WithdrawProcess : Process
    {
        public override void Apply()
        {
            Console.WriteLine("Para çekildi");
        }
    }
}
