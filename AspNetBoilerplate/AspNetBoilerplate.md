## Asp.Net Boilerplate

- ### Başlamadan Önce

    - Öğrenilmesi gereken tasarım desenleri

        - Creatinal Design Patterns
    
            Builder Design Pattern 
      
            Abstract Factory Design Pattern
      
            Factory Design Pattern
      
        - Behavioral design Patterns
      
            Observer Design Pattern 
            
            Command design Pattern
      
      
        - Structural Design Patterns
      
            Decorator Design Patterns

        - Domain Driven Design : Bu proje geliştirme mantığını, projenin yapsının domain tabanlı design edilmesini ifade eden bir geliştirme kültürüdür. bu konuyu Boilerplate ile yazılım geliştirmeen önce iyi öğrenmek lazım. altta bazı kaynaklar mevcut.İş kurallarının sık olarak değiştiği ve taleplerin sürekli artacağı öngörülen yazılım sistemleri için yazılımın geleceğine aydınlık bir altyapı tasarlamak amacıyla uygulanabilir. Örneğin kanun ve yönetmeliklerin çok sık değiştiği  kurumlarda geliştirilen yazılımları gibi. Ancak karmaşık iş kuralları olmayan basit sistemler için DDD uygulamak uygun olmaz. 
        
          [link](http://www.hakanalevok.com/2017/04/domain-driven-design/) - [link1](https://medium.com/@avniozunlu/domain-driven-design-ddd-151c90472914) - [link2](https://apiumhub.com/tech-blog-barcelona/introduction-domain-driven-design/) - [link3](https://msdn.microsoft.com/en-us/magazine/dn342868.aspx?f=255&MSPPError=-2147217396) - [link4](https://github.com/zkavtaskin/Domain-Driven-Design-Example)
          
          internette örnek sayfa çok bu yazılım geliştirme şekli çok iyi öğrenilmeli.
      
      
      Options pattern - [link](https://weblog.west-wind.com/posts/2016/May/23/Strongly-Typed-Configuration-Settings-in-ASPNET-Core#Using-String-Configuration-Values) - [link](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-2.1)
      
      
    - Öğrenilmesi gereken bası ileri konular konular
    
        [Thread Safety - Multi Thread Locking](https://www.c-sharpcorner.com/UploadFile/de41d6/monitor-and-lock-in-C-Sharp/)
      
        [Thread Safety - Multi Thread Locking](http://www.albahari.com/threading/part2.aspx)
      
        [Application Startup](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup?view=aspnetcore-2.1)
      
        [external assembly in ASP.NET Core with IHostingStartup](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/platform-specific-configuration?view=aspnetcore-2.1&tabs=linux)
      
        [Configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.1)
      
        [Options](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-2.1)
      
        [WebHost](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/web-host?view=aspnetcore-2.1)
      
        [Background tasks with hosted services](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-2.1)
      
        [Change Tokens](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/change-tokens?view=aspnetcore-2.1)
      
        [Factoty Based Middleware](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/extensibility?view=aspnetcore-2.1)
      
        [ASP.Net Core Fundamentals sayfası](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/?view=aspnetcore-2.1) detaylı şekilde alt linklerle birlikte hazmedilmeli
      
        [Asp.net Core Application Model](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/application-model?view=aspnetcore-2.1)
      
        [Asp.net Core Application Part](https://docs.microsoft.com/en-us/aspnet/core/mvc/advanced/app-parts?view=aspnetcore-2.1)
      
        Extension Methods,Delegastes ve Events, Lambda Expression 
      
        [link1](https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/Topics/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md) - [link2](https://www.dotnetperls.com/delegate) - [link3](https://www.oreilly.com/library/view/c-70-in/9781491987643/ch04.html) - [link4](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods) - [link5](https://stackoverflow.com/questions/852916/how-to-create-extension-methods-with-lambda-expressions) - [link6](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions) - [link7](https://www.c-sharpcorner.com/uploadfile/ashish_2008/introduction-to-linq-extension-methods-and-lambda-expressions/)

- ### Tasarım Terminolojisi

    - CMS Types
      1. Standart CMS : Sunucu taraflı ve istemci taraflı tüm işlerim tek altyapıyla sağlandığı CMS ler. örneğin orchard core theme giydirme işlerinin yapıldığı ve sayfanın HTML render işlemlerinin de bu theme in kullanılarak server tarafından yapılarak çalıştırılan CMS buna örnektir.
      2. Decoupled CMS : render işlemlerinin serverda yapıldığı ancak altyapının theme ve html generate etme özelliklerinin kullanımadığı CMS türüdür.
      3. Headless CMS: server tarafından istemciye sadece datanın sunulduğu, tüm tasarım ve render işlemlerinin istemci tarafında yapıldığı şekildir. 
      
     - Adım Adım Template Giydirme
     
