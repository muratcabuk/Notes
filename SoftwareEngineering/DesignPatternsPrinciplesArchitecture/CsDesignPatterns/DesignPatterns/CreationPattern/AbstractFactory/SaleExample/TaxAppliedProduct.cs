namespace CreationalPattern.AbstractFactory.SaleExample
{
    class TaxAppliedProduct : ProcessPhases
    {
        public override Process ProductProcess()
        {
           return  new TaxProcess();
        }
    }
}
