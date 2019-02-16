## Principles and Patterns

- [Design Principles - Türkçe](Principles.md)
- [Design patterns - Türkçe](Patterns.md)


### Summary of Principles


#### Difference between Design Principle and Design Pattern
In the software engineering, design principle and design pattern are not the same.

#### Design Principles
It provides high level guide lines to design better software applications. Design principles do not provide implementation and not bound to any programming language. E.g. SOLID (SRP, OCP, LSP, ISP, DIP) principles.

For example, Single Responsibility Principle (SRP) suggests that a class should have only one and one reason to change. This is high level statement which we can keep in mind while designing or creating classes for our application. SRP does not provide specific implementation steps but it's on you how you implement SRP in your application.

1. GRASP = General Responsibility Assignment Software Patterns (or Principles) , abbreviated GRASP, consist of guidelines for assigning responsibility to classes and objects in object-oriented design. 

- Controller
The controller pattern assigns the responsibility of dealing with system events to a non-UI class that represents the overall system or a use case scenario. A controller object is a non-user interface object responsible for receiving or handling a system event.

A use case controller should be used to deal with all system events of a use case, and may be used for more than one use case. For instance, for the use cases Create User and Delete User, one can have a single class called UserController, instead of two separate use case controllers.

The controller is defined as the first object beyond the UI layer that receives and coordinates ("controls") a system operation. The controller should delegate the work that needs to be done to other objects; it coordinates or controls the activity. It should not do much work itself. The GRASP Controller can be thought of as being a part of the application/service layer  (assuming that the application has made an explicit distinction between the application/service layer and the domain layer) in an object-oriented system with common layers in an information system logical architecture.

- Creator (Factory pattern)

Creation of objects is one of the most common activities in an object-oriented system. Which class is responsible for creating objects is a fundamental property of the relationship between objects of particular classes.

In general, a class B should be responsible for creating instances of class A.

- High cohesion

High cohesion is an evaluative pattern that attempts to keep objects appropriately focused, manageable and understandable. High cohesion is generally used in support of low coupling. High cohesion means that the responsibilities of a given element are strongly related and highly focused. Breaking programs into classes and subsystems is an example of activities that increase the cohesive properties of a system. Alternatively, low cohesion is a situation in which a given element has too many unrelated responsibilities. Elements with low cohesion often suffer from being hard to comprehend, hard to reuse, hard to maintain and averse to change.

- Information expert
Information expert (also expert or the expert principle) is a principle used to determine where to delegate responsibilities. These responsibilities include methods, computed fields, and so on.

Using the principle of information expert, a general approach to assigning responsibilities is to look at a given responsibility, determine the information needed to fulfill it, and then determine where that information is stored.

Information expert will lead to placing the responsibility on the class with the most information required to fulfill it


Türkçesi 

Nesnelere sorumluluk atarken; bir işi , o işin uzmanı olan nesneye atamak gerekir. Yani bir sorumluluğu yerine getirmek için gerekli bilgiye sahip olan nesneye o sorumluluğun atanması gerektiğini söyler.


- Low coupling (Loose Coupling)

Coupling is a measure of how strongly one element is connected to, has knowledge of, or relies on other elements. Low coupling is an evaluative pattern that dictates how to assign responsibilities to support

lower dependency between the classes,
change in one class having lower impact on other classes,
higher reuse potential.

Türkçesi 

Bir nesnenin yaptığı iş itibari ile diğer nesnelere en az bağımlı olması gerektiğini söyler.



- Polymorphism

According to polymorphism principle, responsibility of defining the variation of behaviors based on type is assigned to the type for which this variation happens. This is achieved using polymorphic operations. The user of the type should use polymorphic operations instead of explicit branching based on type.

Türkçesi

Bir nesnenin ortak özelliklerinin, çok çeşitli olarak kullanılabilecek şekilde tasarlanması gerektiğini söyler.(Örnek: Tekerlek<Araba tekerleği, bisiklet tekerleği ,... gibi>)


- Protected variations

The protected variations pattern protects elements from the variations on other elements (objects, systems, subsystems) by wrapping the focus of instability with an interface and using polymorphism to create various implementations of this interface.


Türkçesi

Nesneleri ,birliktelik oluşturacak şekilde(‘yabancılarla konuşmayan’ gibi), olabildiğince kullanıma açık, değiştirilebilmeye kapalı olarak tasarlamanın gerektiğini söyler.(Örnek : Open-Closed prensibi)

- Pure fabrication

A pure fabrication is a class that does not represent a concept in the problem domain, specially made up to achieve low coupling, high cohesion, and the reuse potential thereof derived (when a solution presented by the information expert pattern does not). This kind of class is called a "service" in domain-driven design.

Türkçesi 

Nesnelerin uzmanlık alanlarının belirlenmesinde, nesne bağımlılığı(object coupling) ve method alakası(method cohesion) ile ilgili problem olduğu düşünülüyor ise; uzmanlık konusu ile alakası olmayan yeni bir suni sınıf/katman oluşturulması gerektiğini söyler. (Örnek : Service<Systems Architecture> )


- Indirection


The indirection pattern supports low coupling and reuse potential between two elements by assigning the responsibility of mediation between them to an intermediate object. An example of this is the introduction of a controller component for mediation between data(model) and its representation(view) in the model-view control pattern.This ensures that coupling between them remains low.


Nesne gruplarının kendine has yaptığı işlerde diğer nesnelere bağımlılığının(object coupling) azaltıması gerektiğini söyler.(Low Coupling in genelleştirilmiş bakış açısı denilebilir.Örn. Delegation pattern, Model View Controller pattern gibi)

Özellikle kolay değişebilen iki birim arasındaki bağımlılığı azaltmak için sorumluluklar nasıl atanmalıdır?
İki birim arasındaki bağımlılıkları azaltmak için sorumlulukları bir ara nesneye atayın.
Sale > TaxMasterAdapter > TCP Socket Connection



2.  Kısaca GRASP

- Controller: Sistem sorumluluğunu üzerine alacak sınıfı belirleyin.
- Creator: Gerekli koşullarda Asınıfına başka sınıf yaratma yetkisi verin.
- Low coupling: Sınıflar arasında ki bağı azaltıcı tasarımlar yapın.
- Information expert: Bir sorumluluğu onu yerine getirecek özelliğe sahip olan sınıfa verin.
- Indirection: Bağımlılığı azaltması için araya nesneler atayın. 
- High cohesion: Sorumlulukları sınıf içinde bir uyum olacak şekilde verin.
- Polymorphism: Benzer davranışları tiplere bağlı olarak farklı gösteriyorsa çok şekilli metodlar yapın.
- Protected variations: Sistemde kararsız noktaları kararlı arayüzlerle gerçekleştirin.
- Pure fabrication: Sınıflar arası bağımlılığı azaltıyorsa yapay sınıflar gerçekleştirin.




3. SOLID = Abbreviation (Acronym)

- Single responsibility principle
a class should have only a single responsibility (i.e. only changes to one part of the software's specification should be able to affect the specification of the class).
- Open/closed principle
"software entities … should be open for extension, but closed for modification."
- Liskov substitution principle
"objects in a program should be replaceable with instances of their subtypes without altering the correctness of that program." See also design by contract.
- Interface segregation principle
"many client-specific interfaces are better than one general-purpose interface."
- Dependency inversion principle
one should "depend upon abstractions, [not] concretions."





[GRASP Document](https://www.cs.colorado.edu/~kena/classes/5448/f12/presentation-materials/duncan.pdf)

[SOLID wiki](http://www.wikizero.biz/index.php?q=aHR0cHM6Ly9lbi53aWtpcGVkaWEub3JnL3dpa2kvU09MSURfKG9iamVjdC1vcmllbnRlZF9kZXNpZ24p)

[GRASP wiki](http://www.wikizero.biz/index.php?q=aHR0cHM6Ly9lbi53aWtpcGVkaWEub3JnL3dpa2kvR1JBU1BfKG9iamVjdC1vcmllbnRlZF9kZXNpZ24p)




### Design Pattern
It provides low level solution (implementation) for the commonly occurring object oriented problem. In another word, design pattern suggest specific implementation for the specific object oriented programming problem. For example, if you want create a class that can only have one object at a time then you can use Singleton design pattern which suggests the best way to create a class that can only have one object.

Design patterns are tested by others and safe to follow. E.g. Gang of Four patterns: Abstract Factory, Factory, Singleton, Command etc.






### References

- [Arif Erol - Yazılım Tsarım Teknikleri](http://yazilimgelistirmeyontemleri.blogspot.com/2015/02/yazlm-tasarm-teknikleri-grasp.html)

- [Beycan Kahraman GRASP](http://www.beycan.net/eklenen/GoF_ve_GRASP.pdf)



### Summary Of Patterns

