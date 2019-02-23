


## 1. Creational patterns

### 1.1. Factory Method vs Abstract Factory


__The Factory Method__ is usually categorised by a switch statement where each case returns a different class, using the same root interface so that the calling code never needs to make decisions about the implementation.



``` C#

public ICardValidator GetCardValidator (string cardType)
{
    switch (cardType.ToLower())
    {
        case "visa":
            return new VisaCardValidator();
        case "mastercard":
        case "ecmc":
            return new MastercardValidator();
        default:
            throw new CreditCardTypeException("Do not recognise this type");
    }
}
```

__The Abstract Factory__ is where you have multiple concrete factory classes (not Factory Methods) derived from one interface which may return many different types from different methods. (Like Strategy Pattern)





- Simple Factory Method


![Simple Factory](https://vivekcek.files.wordpress.com/2013/03/simplefactory.png)


``` C#
class CustomerFactory
{
    public static ICustomer GetCustomer(int i)
    {       
        switch (i)
        {
            case 1:
                GoldCustomer goldCustomer = new GoldCustomer();
                goldCustomer.GoldOperation();
                goldCustomer.AddPoints();
                goldCustomer.AddDiscount();
                return goldCustomer;               
            case 2:
                SilverCustomer silverCustomer = new SilverCustomer();
                silverCustomer.SilverOperation();
                silverCustomer.AddPoints();
                silverCustomer.AddDiscount();
                return silverCustomer;
            default: return null;
        }      
    }
}

//Client Code
ICustomer c = CustomerFactory.GetCustomer(someIntegerValue);

```


- Factory Method Pattern

![Simple Factory](https://vivekcek.files.wordpress.com/2013/03/fmethod.png)



``` C#

public abstract class BaseCustomerFactory
{
    public ICustomer GetCustomer()
    {
        ICustomer myCust = this.CreateCustomer();
        myCust.AddPoints();
        myCust.AddDiscount();
        return myCust;
    }
    public abstract ICustomer CreateCustomer();
}

public class GoldCustomerFactory : BaseCustomerFactory
{
    public override ICustomer CreateCustomer()
    {
        GoldCustomer objCust = new GoldCustomer();
        objCust.GoldOperation();
        return objCust;
    }
}
public class SilverCustomerFactory : BaseCustomerFactory
{
    public override ICustomer CreateCustomer()
    {
        SilverCustomer objCust = new SilverCustomer();
        objCust.SilverOperation();
        return objCust;
    }
}
//Client Code
BaseCustomerFactory c = new GoldCustomerFactory();// Or new SilverCustomerFactory();
ICustomer objCust = c.GetCustomer();


```


- Abstract Factory 

![Abstract Factory](https://vivekcek.files.wordpress.com/2013/03/abstractfactorypg.png)

Product Interfaces

``` C#

public interface IProcessor 
{
    void PerformOperation();
}
public interface IHardDisk { void StoreData(); }
public interface IMonitor { void DisplayPicture();}

public class ExpensiveProcessor : IProcessor
{
    public void PerformOperation()
    {
        Console.WriteLine("Operation will perform quickly");
    }
}
public class CheapProcessor : IProcessor
{
    public void PerformOperation()
    {
        Console.WriteLine("Operation will perform Slowly");
    }
}

public class ExpensiveHDD : IHardDisk
{
    public void StoreData()
    {
        Console.WriteLine("Data will take less time to store");
    }
}
public class CheapHDD : IHardDisk
{
    public void StoreData()
    {
        Console.WriteLine("Data will take more time to store");
    }
}

public class HighResolutionMonitor : IMonitor
{
    public void DisplayPicture()
    {
        Console.WriteLine("Picture quality is Best");
    }
}
public class LowResolutionMonitor : IMonitor
{
    public void DisplayPicture()
    {
        Console.WriteLine("Picture quality is Average");
    }
}

```
Factory Interfaces and Classes

``` C#

public interface IMachineFactory
{
    IProcessor GetRam();
    IHardDisk GetHardDisk();
    IMonitor GetMonitor();
}

public class HighBudgetMachine : IMachineFactory
{
    public IProcessor GetRam() { return new ExpensiveProcessor(); }
    public IHardDisk GetHardDisk() { return new ExpensiveHDD(); }
    public IMonitor GetMonitor() { return new HighResolutionMonitor(); }
}
public class LowBudgetMachine : IMachineFactory
{
    public IProcessor GetRam() { return new CheapProcessor(); }
    public IHardDisk GetHardDisk() { return new CheapHDD(); }
    public IMonitor GetMonitor() { return new LowResolutionMonitor(); }
}
//Let's say in future...Ram in the LowBudgetMachine is decided to upgrade then
//first make GetRam in LowBudgetMachine Virtual and create new class as follows

public class AverageBudgetMachine : LowBudgetMachine
{
    public override IProcessor GetRam()
    {
        return new ExpensiveProcessor();
    }
}

```
Usage

``` C#
public class ComputerShop
{
    IMachineFactory category;
    public ComputerShop(IMachineFactory _category)
    {
        category = _category;
    }
    public void AssembleMachine()
    {
        IProcessor processor = category.GetRam();
        IHardDisk hdd = category.GetHardDisk();
        IMonitor monitor = category.GetMonitor();
        //use all three and create machine

        processor.PerformOperation();
        hdd.StoreData();
        monitor.DisplayPicture();
    }
}

```
Client Code

``` C#
//Client Code
IMachineFactory factory = new HighBudgetMachine();// Or new LowBudgetMachine();
ComputerShop shop = new ComputerShop(factory);
shop.AssembleMachine();   
```



### 1.2. Builder


### 1.3. Prototype

### 1.4. Singleton

### 1.5. Lazy initialization

