namespace CreationalPattern.AbstractFactory.Bank
{
   public class AbstractFactory
   {
       Bankamatic bankamatic;
      

        public void MakeDeposite()
        {

            var  deposit = new Deposit();
            bankamatic = new Bankamatic(deposit);
            bankamatic.ProcessResult();
        }



       public void Withdraw()
       {

           var  withdraw = new Withdraw();
           bankamatic = new Bankamatic(withdraw);
           bankamatic.ProcessResult();
       }


    }
}
