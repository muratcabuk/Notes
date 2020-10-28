1. MQ(Messaging Queue) bir ESB(Enterprise Service Bus) değldir. biri mesajı iletir. 

Enterprise Service Bus (ESB) için genel olarak transport işlemleri için bir gateway’dir diyebiliriz. ESB’nin görevi aslında high level olarak özünde, transport işlemlerini higher abstraction seviyesinde client api için halletmektedir.


2. api gateway normal de proxy veya load balancer gibi çalışabilcen bir siştemdir. yani transformasyon yapmazlar. ayrıca cross cutting concern problemlerini de çözer. ancak artık api gateway lerde ESB lerin yaptığı bazı bir çok işi yapabilir durumdadır.

3. servi e mesh ise: load baalancing,esb, security, dns ve benzeri bir çok işi beraber yapabilken teknojidir.



**dotnet service bus, queue, distrbuted transaction kütüphaneler

- MassTransit: Distributed Application Framework for .NET. SAGAS yı destekler


- CAP : Distributed transaction solution in micro-service base on eventually consistency, also an eventbus with Outbox pattern.

CAP is a library based on .Net standard, which is a solution to deal with distributed transactions, has the function of EventBus, it is lightweight, easy to use, and efficient.

direkt olarak ACID desteklemez (bu durumda SAGA veya 2PC yoktur) bunun yerine Eventual consistency (diğer adı optimistic replication) destekler. Burada amaç yapılcak iş locak db ye yazılarak diğer servislerde ki şşler bittiğinde locak db den bu işi silmeye dayanır. (https://cap.dotnetcore.xyz/user-guide/en/cap/transactions/). burada amaç ileride bir zamanda sistemin tutarlı ve beklenen noktaya ulaşmasını sağlamaktır.

kubernetes de örneğin bu şekilde çalışmaktadır.

queue yapısında in-memory desteği de vardır.



https://www.baeldung.com/transactions-across-microservices


- NServiceBus: The most developer-friendly service bus for .NET (paralı)

- rebus: Simple and lean service bus implementation for .NET 



 
