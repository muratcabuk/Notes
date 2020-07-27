
AOP aşağıda anlatılıyor

__Similarities and Differences between DI and AOP__

There are some similarities in the objectives of DI and AOP:

- Both achieve a loosely coupled architecture.
- Both achieve a better separation of concerns.
- Both offload some concerns from the base code.

However, DI and AOP differ significantly in situations where they are found to be useful:

- DI is good when you have a dependency on a component, you just don’t know to which implementation.
- AOP is good when you need to apply a common behavior to a large number of elements of code. The target code is not necessarily dependent on this behavior to be applied.

__Dynamic Proxy__

It’s simply that the DI pattern makes it easy to add behaviors to components. Here’s how: when you ask a dependency from the container, you expect to receive an implementation of an interface. You can probably guess which implementation you will receive, but since you play the game, you just program to the interface. And you’re right. If you ask the container to add a behavior (for instance tracing) to the component, you will not receive the component itself; instead, you will receive a dynamic proxy. 


__AOP__

ÇOk iyi bir kaynak. Kesinlikle okunmalı. Aşağıda yazılanlar bu makaleden alınmıştır. 

https://denizirgin.com/aspect-oriented-programming-kavram%C4%B1-2a3a31ab020f


__Concern__

Yazıyı buraya kadar okuduysanız Concern deyince artık aklınıza Logging, Exception Handling, Caching, Security gibi kavramların geldiğini düşünüyorum. Bu saydıklarımın hepsi Aspect-Oriented açısından baktığımız zaman concern’dür.

__Join Point__

Join Point deyince aklınıza gelmesi gereken, programızın akışı esnasında aspect kodlarınızın ne zaman execute edilmesi gerektiğinin belirtilmesidir. Yani aslında burada bir precondition(ön koşul) dan da bahsediyoruz

__Pointcut__

Pointcut için Join Point kümesi diyebiliriz. Program execution aşamasında ne zaman Pointcut içinde belirtilmiş olan Join Point’lerden birine gelirse, pointcut ile ilişkilendirilmiş olan code parçacığı (mesela bir concern olarak Logging mekanizmamızın log metodu) execute edilir. Yani bir araya girme bir interception (buna dikkat) söz konusu.

Yani ;

__Join Point = Ne zaman ?__

__Pointcut = Hangi ?__

Peki __aspect__ dediğimizde aklımıza ne gelmeli. Logging örneği üzerinden gidersek ;

Uygulama kodunda belirli bir yerde execute edilecek olan Loglama mekanizmasının (concern) loglama metodunun (pointcut) hangi şartlar altında ne zaman (join point) execute edileceği olgusuna aspect denir.
İşin özü, bir aspect’den bahsediyorsak elimizde concern, pointcut, join point veya join point’ler olmalı.

__Yine AOP açısından ele aldığımız zaman concern kavramsal olarak ikiye ayrılıyor ;__

__Side-Effect Concern’ler__

Şimdi pointcut’ların kendisiyle ilişkilendirilmiş olan bir kod parçacı olduğundan, intercept ettiğinden yani araya girdiğinden bahsettik. Bu araya girme işlemi kodun akışında davranışsal (behavior) olarak bir değişikliğe sebep olmuyorsa bu bir side-effect concern’dür. Logging bu açıdan baktığımızda iyi bir örnek. Yukarıda bankacılık örneğini ele alalım. BankOperations sınıfının Transfer metodu execute edilirken devreye girecek olan loglama metodu, Transfer metodunun davranışını etkilemez, sadece ona extra bir davranış kazandırır.

__Advice Concern’ler__

Advice aslında programlama dünyasında yeni bir kavram değil, oldukçada geniş bir konu. Basitçe AOP ve functional programming’de (prosedürel programlama) execute edildiğinde join point olarak yer aldığı fonksiyonun veya metotdun davranışını değiştiren fonksiyon veya metotlara denir. Caching bu açıdan baktığımızda oldukça iyi bir örnek. Örnek vermek gerekirse bir Business sınıfından metotdu çağırdığımız esnada devreye girecek olan cachleme methodu, business metodunun davranışını değiştirir. Çünkü metodun ikinci çağrımında veri artık cache’lenmiş olacağından business metodu çağrılmaz, direkt cachelediğimiz veriyi alırız. Yani araya giren cache’leme aspect’imiz kendisinden sonra çağrılacak olan Business metodunun çağrımını engeller.

Bu noktadan sonra artık AOP kavramının kafanızda oturduğunu düşünüyorum. Sürekli kodumuzun execution’ı esnasında araya girmeden, interception’dan bahsettik. Peki bu kavramın pratikte uygulanması nasıl oluyor? İşte bu aşamda hayatımıza Weaving kavramı giriyor.

## Aspect-Oriented Weaver Kavramı ##

Weaving bir kod parçasının çalıştırılması (executing) esnasında bir aspect’in araya nasıl gireceği yöntemiyle alakalı. Yani interception model’i. Bu aşamadan sonra konuyu .Net Platformu açısından ele almak istiyorum. .Net Platformu AOP’u direkt olarak desteklemiyor. Ama bir kaç belirgin yöntem var. Aslında burada sorulması gereken konu, yazdığımız kodu ne seviye intercept etmek istiyoruz. Çünkü kullandığımız yönteme göre teorik olarak satır bazında bile yapabiliriz. Tabi yine burada karşımıza taş, kurbağa denklemi çıkıyor.
Attığımız taş, ürküttüğümüz kurbağaya değecek mi? Eh aslında bu bir developer olarak atacağımız her adımda kendimize sorduğumuz bir soru sanırım.
İki belirgin yöntem var, ikisininde kendilerine has avantajları ve dezavantajları mevcut.

Compile-Time Weaving ve Run-Time Weaving. Aslında şu an daha kabul görmüş ve sık kullanılanı ve de uygulanması daha az maliyetli olanı Run-Time Weaving. Ama teorik bilgi açısından ikisinide anlatacağım. Bunları söylememin sebebi, compile-time weaving mevzusunu okuduktan sonra “bu iş bukadar zor mu yav” diyerek AOP’dan soğumamanız :D
AOP günümüzde oldukça kolay uygulanan bir yöntem. Detaylı olarak anlatacağım.

#### 1. Compile-Time Weaving ####

Bu yöntem de kendi arasında 3'e ayrılıyor. Aslında hepsi temelde derleme zamanında(compile time) koda müdehale ediyor.
Bu aşamada source kodun başka bir formata nasıl dönüştüğünü anlatmakta yarar görüyorum. Çok detaylı bir konu o yüzden kısaca üzerinden geçeceğim. Genelde 3 aşamada gerçekleşir.

__Lexing :__ Bir karakter dizisinin bir token dizisine çevrilmesidir. Kabaca ;

```
int x = 0;
while (x < 10)
{    
   printf(x);
   x = x + 1;
}
```
gibi bir kodun

[INT; String("x"); EQ; Int(0); NEWLINE; WHILE; String("x"); LT; VAL(10); vs.... ]

gibi bir ifadeye, token dizisine çevrilmesi.

__Parsing :__ Lexing esnasında oluşan token dizisinin abstract syntax tree (AST)’ye çevrilmesi. (soyut sözdizimi ağacı). AST mevzusu da çok detaylı bir konu, C#’daki expression tree’ye konspet olarak biraz benziyor.
AST olayın kalbi, elinizde AST olduktan sonra ister compile edersiniz, ister interpret edersiniz (javascript), ister Visual Studio’nun kod editörünün yaptığı gibi syntax highlighter yaparsınız. Hatta karşılığı olan başka bir dile bile çevirebilirsiniz.

__Compiling :__ AST’yi alıp executable ifadeler serisine çevirir. Yani native code, byte code (JAVA), MSIL (.Net) gibi.
Source-Level Weaving

Bu yöntemle koda parse aşamasında müdehale ediyoruz. Yani aspect uygulamak için kod içerisinde standart dışı kendimize ait ifadele yer verip, parsing esnasında bu ifadelerin compiler’ın anlayacağı standart AST’ye çevrilmesi işini bizim yapmamız. Dezavantajı tahmin edeceğiniz üzere böyle birşey yapmak oldukça zor, programlama dilleri üzerinde çok bilgili olmanız lazım. Lexing, parsing, semantic gibi konularda bilgi sahibi olmanız gerekiyor. Avantajı ise böyle birşeyi yapabilecek kadar yetkiliğiniz varsa hemen hemen dibine kadar aspect uygulayabilirsiniz. Bkz : Taş-Kurbağa denklemi.

#### 2. Kendi compiler’ınızı yazmak ####

En baştan kendi compiler’ınızı yazmak ve ya open-source compiler’lardan birini alıp istediğiniz değişiklikleri yapmak. Dezavantajlarından bahsetmeme gerek yok heralde. Avantajı ise teorik olarak aspect istediğiniz seviyede uygulama imkanına sahip olmanız. Şiddetli Bkz : Taş-Kurbağa denklemi. Bu yöntemle ilgili Iowa Universitesini bir çalışması var. EOS

#### 3. Byte-Code, MSIL üzerinde değişiklik yapmak ####

Compile-Time Weaving’ler arasında en popüler olanı bu. Compiler işini yapsın, biz de çıkan byte-code, MSIL üzerinde değişikliklerimizi, eklemelerimizi yapalım.
Bu işi hali hazırda yapan paralı bir ürün var. PostSharp. Yeri gelmişken biraz PostSharp’dan bahsetmek istiyorum. PostSharp’ı yıllar öncesinden daha bedava ve beta halindeyken kullanmıştım. Temel mantık, yukarıda yaptığım Örnek B gibi kodunuzu yazmanız, aspect’lerinizi ise C# Attribute’lerine taşımanız üzerine. PostSharp size kendi Attribute’ünüzü türetmeniz için bir Base Attribute veriyor. Siz bu Attribute içerisindeki çeşitli method’ları override ediyorsunuz. Yukarıdaki Bankacılık örneği üzerinden gidelim ;

Aspect’lerimizi Attribute olarak hazırladıktan sonra Örnek B’deki metotdumuz şu hale geliyor

```

[ExceptionHandlingAspect]
[LoggingAspect]
public void Transfer(string fromAccountNumber, string toAccountNumber, decimal ammount)
{
    // Hesapta para var mı vs. diğer kontroller
    _accountOperations.Withdraw(fromAccountNumber, ammount);
    _accountOperations.Deposit(toAccountNumber, ammount);
}

```

Kod compile edildiğinde PostSharp ortaya çıkmış olan MSIL kodunun içerisine attribute’lerin içerisindeki kodları inject ediyor.
Oldukça basit değil mi :)

Bu şekilde mimarinizi oldukça temiz ve anlaşılır tutabilirsiniz ve AOP’un asıl hedeflediği Separation of Cross-Cutting Concerns prensibini gerçekleştirebilirsiniz.
PostSharp’ın parasız alternatifleride var. __KingAop__ gibi.

Bu yöntemde dikkat etmeniz gereken birkaç şey var. PostSharp’ı yüklediğiniz zaman PostSharp Visual Studio’nun compile aşamalarına müdehale ediyor. Eğer birden fazla developer’ın çalıştığı bir projede kullanıyorsanız, PostSharp’ın bütün developer’ların makinalarında yüklü olduğundan emin olmanız lazım. Aksi durumda compile edilen kodlar istenilen davranışları göstermez. Ve bu açıdan baktığınızda sizi biraz kısıtlayan bir araç. Open-Source bir projede kullanmanız söz konusu bile değil. Ve ya müşterilerinize özel bir proje geliştiriyorsanız ve bu kodları müşterinize de veriyorsanız bir takım sıkıntılar yaşayabilirsiniz. Bu konuları göz önünde bulundurmanızda fayda var.
Not : Örnekler elbetteki konseptsel olarak yazıldı. Gerçek hayat dikkate alınmadı. Mesela LogginAspect içerisinde method argumanlarının tipleri kontrol edilmeli vs…
Şimdi gelelim diğer Weaving yöntemimiz olan Run-Time Weaving’e.

#### 4. Run-Time Weaving ####

Bu yöntem .Net dünyasında AOP uygulanırken en sık kullanılan yöntem. Bunun sebeplerinden biri de son yıllarda gittikçe popülerleşen IOC Container’larla (bkz: Dependency Inversion Principle) kolay entegre olmaları. Bir sürü open-source library var, hepsinin performans vs. açısından dez avantajları ve avantajları var. Aspect’lerimizi run-time’da uyguladığımızdan dolayı, run-time’da aspect’lerimizi değiştirme gibi imkanlarımız oluyor bu açıdan bir takım avantajları var fakat nesnelerimizi bir proxy ile sarmaladığımızdan dolayı Compile-Time Weaving’e göre daha az performanslı. Ayrıca join point’lerimiz en çok method seviyesine inebiliyorlar gerçi yukarıda da bahsettiğim gibi kendi parser veya compiler’ınızı yazmadığınız sürece daha alt seviyelere inmek pek mümkün değil ki buna da zaten genelde ihtiyaç olmuyor, o yüzden bir dezavantaj olduğunu düşünmüyorum. Zaten kendim de yıllardır katıldığım projelerde ve kendi open-source projelerimde bu şekilde AOP uygulmaktayım ve method seviyesinde join point kullanımının bana bir kısıtlama yarattığına şahit olmadım.
Run-Time Weaving’in uygulanmasında da birkaç yöntem var bunlardan belirgin olanlarını burada yazacağım.

- __ContextBoundObject ve MarshalByRefObject Yöntemi__

.Net dünyasında nispeten eski yöntemlerden birisi. Remoting ile uğraşmış ve ya en basidinden web service, wcf gibi kavramlara aşina kişilerin kafalarında proxy diyince eminim birşeyler canlanıyordur. Buradaki mantık da aynı. Client bir remote nesneyi kullanır ki aslında o bir proxydir yani bütün aspect’lerimiz gerçek nesneyi sarmalamış olan proxy sınıflarımız tarafından uygulanır.

Bilgiledirme olarak hem MarshalByRefObject hem de ContextBoundObject’den biraz bahsedilim ama bu anlattıklarımın AOP ile direkt alakası yok o yüzden direkt alttaki başlığa da geçebilirsiniz.

Öncelikle bilmeniz gereken ContextBoundObject nesnesi MarshalByRefObject nesnesinden türemiştir. Neden böyle birşeye ihtiyaç duyulmuş sorusuna cevap vermek için 

MarshalByRefObject nedir sorusuna cevap vermek gerekiyor ki cevabı çok zor olan bir soru :)

MarshalByRefObject için büyülü bir nesne denilebilir. CLR bir takım gizemli işlemlerle bu nesnenin çalışmasını sağlıyor :)

.Net Remoting ile uğraştıysanız MarshalByRefObject’in Serializable Attribute’ünün alternatifi olduğunu bilirsiniz. Alternatifinden kastım şu aslında ;

Serializable nesneler byte stream’lerine dönüştürülürler ve ayrı bir yerde yeniden Deserialize edilerek orjinal nesnenin kopyası olurlar ki bu da orjinal nesnenin birden fazla instace’si de olabilir demek.

MarshalByRefObject’den türeyen nesneler ise büyülü nesnelere dönüşürler :D Bu büyülü nesneler de byte’lara dönüşürler fakat bu byte’lar yeniden birleştiklerinde ortaya çıkan orjinal MarshalByRefObject’den türemiş nesnenizle haberleşmenizi sağlayan proxy (transparent proxy) nesnelerdir. Ve orjinal nesnenizin instance’si yine birtanedir.

Bunun avantajı ; dcom gibi teknolojilerde nesne remote sisteme kopyalanarak çalışır.

MarshalByRefObject kullanarak ise farklı bir application domain’de bulunan bir nesneyi kullanıyorsunuz, bu nesnenin metodları, size serialize edilmiş objeler dönebiliyor bu sayede kendinizi farklı bir makinadaki çalışan, canlı bir nesneye pointer ile ulaşıyormuş gibi hissediyorsunuz (bkz : Marshalling). Dediğim gibi bunu nasıl yaptığı ise biraz gizemli :)

ContextBoundObject ise MarshalByRefObject’in yaptığı herşeyi yapmanızı sağlamasının yanında nesne ve proxy yaratılması ve de marshalling konularını daha detaylı ele almanızı sağlıyor. Yani customization’a daha açık daha özelleştirilmiş bir nesne.

Şimdi MarshalByRefObject kullanırken mevzu şu şekilde ilerliyor ; elimizde orjinal nesnemizmiş gibi davranan bize o ilizyonu sağlayan transparent proxy’ler var aslında transparent proxy’nin yaptığı yapılan çağrımları remoting alt yapısını kullanarak orjinal nesneye forward etmek (ayrıca bkz : RealProxy). Bu durumda aslında biz hiç bir zaman orjinal MarshalByRefObject nesnemizi kullanmıyoruz, transparent proxy’leri kullanıyoruz.

ContextBoundObject ise transparent proxy’lerin yapılan çağrıları orjinal nesneye forward etme aşamasında bize araya girme, intercept etme şansı veriyor. (aynı şeyi direkt MarshalByRefObject kullanarak da biraz daha kasarak yapabilirsiniz bkz : RealProxy)

Yukarıda anlattığım konular oldukça detaylı ve geniş konular. Ben biraz özet geçmeye çalıştım. Zaten server-client haberleşmesi konusu WCF çıktığından beridir artık uygulanması çok daha kolay. Artık .Net Remoting’i ölü bir teknoloji sayıyoruz.

AOP Uygulanması

ContextBoundObject’den türemiş bir nesneniz varsa, bu nesnenin instance’sini aynı App Domain içerisindeki farklı bir Context’de yaratabilirsiniz, bu sayede nesneleriniz .Net Remoting’in proxy sistemi sayesinde otomatik olarak haberleşebilirler bu da size custom sink’ler (bkz: IMessageSink) ile araya girme, intercept etme imkanı verir. Bu yöntemle AOP’u uygulayabilirsiniz.

[örnek](https://www.codeproject.com/Articles/8414/The-Simplest-AOP-Scenario-in-Csharp)

Günümüzde yukarıdaki şekilde AOP uygulamak artık gereksiz. Hem uygulaması zor hem de konuyla alakasız, tamamen başka bir iş için kullanılan .Net Remoting alt yapısını kullanmak durumundayız. Ayrıca MarshalByRefObject nesnesi büyük bir nesne. Her ne kadar büyük olmasının yanında oldukça yetenekli bir nesne olsa da, bu yeteneklerin çoğu konumuzla alakalı değil :) .

__Dynamic Proxy Yöntemi__

Run-time Weaving yöntemleri arasında en popüler olanı. Gönül rahatlığıyla artık günümüzde bu yöntemi kullanıyoruz diyebiliriz. Bu yöntemin öncülerinden biri Castle Projesi.
Castle DynamicProxy run-time esnasında havada hafif proxy’ler oluşturmanıza imkan veriyor. Yazdığınız sınıfların intercept edilebilmesi için bu sınıflarınızı MarshalByRefObject gibi bir nesneden türetmeye gerek yok, dolayısla sınıflarınızda ekstradan herhangi birşeyler yazmanıza, birşeyleri override etmeye gerek yok. Bu açıdan bakıldığı zaman size daha temiz kod yazma imkanı sağlıyor.

Castle’ın DynamicProxy yöntemi bizi MarshalByRefObject’in birçok kısıtından kurtardığı gibi daha farklı şeyler yapmamıza da imkan sağlıyor, oldukça kapsamlı bir library.

Dinamik olmasının sebebi yukarıda bahsettiğim gibi proxy’lerin oluşturulması işleminin run-time’da dinamik olarak oluşturulması. Bu size müthiş bir esneknik sağlıyor, run-time’da pointcut ve join point’lerini dinamik olarak değiştirebilirsiniz veya aynı nesnenin farklı proxy’lerini kullanabiliriz.

Castle DynamicProxy’nin belli kısıtları var. Mesela intercept edeceğiniz metotlar ya virtual olmalı yada interface metotları olmalı. Bu kısıtların sebebi DynamicProxy’nin yapısından kaynaklanıyor.

Oldukça yetenekli bir library nasıl kullanılacağı ile ilgili Castle projesinin geliştiricilerinden olan Krzysztof Koźmic’in güzel bir makale serisi var, mutlaka okumanızı tavsiye ederim.

Ayrıca yine günümüzün en popüler IOC Container’larından biri olan Castle Windsor ile entegre bir şekilde çalışıyor ki çok büyük avantaj.

__donet core System.Runtime.DispatchProxy kütüphnesi ile birlikte geliyor. Bu kütüphane sayesinde proxy objesi oluşturmak mümkün ancak yetenekleri hem az hemde bezı şeyleri yapmak örneğin castle core veya aoutofac kadar kolay değil__

https://www.codeproject.com/Articles/1219720/Aspect-Oriented-Programming-in-Csharp-using-Dispat

https://medium.com/@nik96a/using-di-with-dispatchproxy-based-decorators-in-c-net-core-ac02f02c5fe5

https://developpaper.com/net-core-class-library-system-reflection-dispatchproxy-implementing-simple-aop-method/


https://www.c-sharpcorner.com/article/aspect-oriented-programming-in-c-sharp-using-dispatchproxy/





