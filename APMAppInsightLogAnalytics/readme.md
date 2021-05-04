Öncelikle Audit Log kavramının karşılığını doldurmamız lazım

Temelde detaya girilmezse 3 tip logdan bahsedebiliriz bir yazılım için.

- Event Log: Yazlım olarak bakacak olursak. A fonksiyonu çalıştı gibi bir log olur. Ancak mesela windows event logları daha kapsmlı informative veya error logları şeklinde olabilir. Örneğin A uygulamsında şu hata meydana geldi, yada diskinde yer kalmdı gibi. Ancak yazlımcı dünyaından bakacak olursa yaazılım içindeki komponentlerin belli bir anda yamış oldukları hareketlerin loglanmasıdır.
- Audit Log: A şahsı sisteme giriş veya çıkış yaptı
- Trace Log: Herhnagi bir olaydan sonra ilgi olayın oluşma sürenin de loglanmasıdır. Örneğin Exception
- Transaction Log: Daha çok veri tabı için kullanılır.



#### Log vs Trail

Logs record every action as it happens:
```

[timestamp] User A did action Y
[timestamp] User B did action Z
[timestamp] User C did action Y
...
```

Audit trails go much further into the connections between the actions and what other things happened as a result.
```
[timestamp] User A did action Y
[timestamp] System received Y and did action Z to data store
[timestamp] Data store was updated with data and sent notification back to User A
...
```
Logs tell you what an actor (user or entity) did. This is enough if you want to monitor who did what when.

Audit Trails tell you what sequence of actions occurred in order for a certain state to be created. This is what you want if you need to confirm how and why the system or the data is in a certain state.


### App Insights

ilk bakılacak link
- https://docs.microsoft.com/en-us/azure/azure-monitor/app/api-custom-events-metrics#get-a-telemetryclient-instance

sayfanın sağında metric ve event takibi ile lakalı daha bir çok link var. 

bu sayflardan biri de authenticated user ların loglanması ile ilgili bölüm. Aslında Application Insights a giden standart context i editlmiş oluyoruz. detaylı bilgiler aşağıda. 

sunucu tarafında da takip yapılacaksa hava tarafında kullanıcı athenticate olduğu anda aynen javascrip te olduğu appInsights.setAuthenticatedUserContext(username) fonksiyonu çağrılıyor olacak.bilgiler linkler aşağıda mevcut. java da belki appInsights yerine telemetry kullanılabilir üstte ilk bakılacak başlığında java appInsights instance ı oluşturulurken nasıl olduğuna bakabilirsiniz.


authenticated user

- https://docs.microsoft.com/en-us/azure/azure-monitor/app/api-custom-events-metrics#authenticated-users
- https://docs.microsoft.com/en-us/azure/azure-monitor/faq#what-are-the-user-and-session-counts
- https://github.com/microsoft/ApplicationInsights-JS/blob/master/API-reference.md#setauthenticatedusercontext
- https://github.com/microsoft/ApplicationInsights-JS/blob/master/API-reference.md#setauthenticatedusercontext

tanımlı olayan dependency lerin takibi için (java kodu da var)

https://github.com/MicrosoftDocs/azure-docs/blob/master/articles/azure-monitor/app/api-custom-events-metrics.md#trackdependency
