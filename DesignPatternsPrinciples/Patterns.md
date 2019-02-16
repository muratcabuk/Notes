# Design Patterns (Tasarım Desenleri)





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

## 2. Structural patterns

### 2.1. Adapter, Wrapper, or Translator

### 2.2. Bridge	

### 2.3. Composite

### 2.4. Decorator

### 2.5. Decorator

### 2.6. Extension object

### 2.7. Facade

### 2.8. Flyweight

### 2.9. Front controller

### 2.10. Marker

### 2.11. Module

### 2.12. Proxy

### 2.12. Twin

## 3. Behavioral patterns

### 3.1. Blackboard

### 3.2. Chain of responsibility

### 3.3. Command

### 3.4. Interpreter

### 3.5. Iterator

### 3.6. Mediator

### 3.7. Memento

### 3.8. Null Object

### 3.9. Observer or Publish/subscribe

### 3.10. Servant

### 3.11. Specification

### 3.12. State

### 3.13. Strategy

### 3.14. Template Method

### 3.15. Visitor

## 4. Concurrency pattern

In software engineering, concurrency patterns are those types of design patterns that deal with the multi-threaded programming paradigm. 

### 4.1. Active Object

### 4.2. Balking pattern

### 4.3. Barrier


### 4.4. Double-checked locking

### 4.5. Guarded suspension


### 4.6. Leaders/followers pattern


### 4.7. Monitor Object


### 4.8. Nuclear reaction

### 4.9. Reactor pattern

### 4.10. Read write lock pattern


### 4.11. Scheduler pattern

### 4.12. Thread pool pattern


### 4.13. Thread-local storage




## References

[Software Design Patterns - Wiki](http://www.wikizero.biz/index.php?q=aHR0cHM6Ly9lbi53aWtpcGVkaWEub3JnL3dpa2kvRGVzaWduX3BhdHRlcm5fKGNvbXB1dGVyX3NjaWVuY2Up)


[Nihat Koçyiğit - Kodcu](https://kodcu.com/2014/08/design-patterns-1-giris-factory-ve-abstract-factory-tasarim-kaliplari-2/
)

[CodeProject - Factory Method vs Abstract Factory](https://www.codeproject.com/Articles/716413/Factory-Method-Pattern-vs-Abstract-Factory-Pattern)


[Vivekcek - Factory Method vs Abstract Factory](https://vivekcek.wordpress.com/2013/03/17/simple-factory-vs-factory-method-vs-abstract-factory-by-example/)