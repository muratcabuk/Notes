namespace CreationalPattern.AbstractFactory.SaleExample
{
  public  class DiscountedProduct : ProcessPhases
    {
        public override Process ProductProcess()
        {
            return new DiscountProcess();
        }
    }
}
