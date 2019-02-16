# Tasarım Prensipleri

En çok kullanılan prensip SOLID olmasına rağmen daha bir çok prensip bulunmaktadır.


1. Single Responsibility Principle (SOLID)
2. High Cohesion (GRASP)
3. Low Coupling (GRASP)
4. Open Closed Principle (SOLID)
5. Liskov Substitution principle (SOLID)
6. Interface Segregation Principle (SOLID)
7. Dependency Inversion Principle (SOLID)
8. Program to an Interface, Not to an Implementation
9. Hollywood Principle
10. Polymorphism (GRASP)
11. Information Expert (GRASP)
12. Creator (GRASP)
13. Pure Fabrication (GRASP)
14. Controller (GRASP)
15. Favor Composition Over Inheritance
16. Indirection (GRASP)
17. Don't Repeat Yourself

[Lisdeteki presipler için](https://www.codeproject.com/Articles/1166136/S-O-L-I-D-GRASP-And-Other-Basic-Principles-of-Obje)




## SOLID



1. Single Responsibility Prensibi

Bir sınıf tek bir sorumluluğa sahip olmalıdır. Sınıflar birden fazla sorumluluğa sahip oldukça bağımlılık artar. Bağımlılığı artması yeniden kullanılabilirliliği ve test edilebilirliliği azaltır.


Yapışkanlık (Cohesion): Sınıflar arası ilişkinin gevşek bağlı olması istenirken, sınıflar içersindeki yordamların ve veri alanlarının yapışkan/bağlantılı olması istenir. Bir sınıf Single responsibility principle çerçevesinde yalnızca tek bir görevi gerçekleştirmelidir. Eğer bir sınıf içerisinde birden fazla değişik iş yapan yordamlar ya da bağımsız veri alanları bulunuyorsa, bu iş grupları farklı sınıflar halinde ayrıştırılmalıdır. Bir sınıf içerisindeki yordamlar ortak veri alanlarını kullanmıyorlarsa  ya da yaptıkları iş bakımından tamamen ayrık iseler, onları aynı kümenin içinde barındırmanın bir anlamı da bulunmamakta. Yapışkanlık derecesi düşük sınıflar modülerliği ve yazılım bakımını tehdit eden bir unsurdur.

2. Open Closed Pensibi

Geliştirilen uygulama veya kütüphane gelişime ve büyümeye açık ancak değiştirilmeye kapalı olmalıdır. 
Sistem içindeki kodların değişime kapalı tutulması aşağıdaki faydaları sağlar.
  
    - Yazılımcılar eski kodları anlamya vekit kaybetmemiş olacak ve yeni yapılar kurabilecekler
    - Eski kodlar değiştirilmediği için test kodları değişmemeiş olacak
    - Riskler azaltılmış olacak
 
3. Liskov Substitution Pensibi

İlkenin açıklaması Alt sınıflar üst sınıfların yerini sorunsuz bir şekilde alabilmelidir.
- Alt sınıflardan oluşturulan nesneler üst sınıfların nesneleriyle tamamen yer değiştirebilmeli
ve yer değiştirdiklerinde aynı davranışı göstermelidir.
- Üst sınıftan oluşturulmuş bir nesneyi kullanan bir fonksiyon, üst sınıf yerine
bu üst sınıftan türemiş bir alt sınıftan oluşturulmuş bir nesneyi de aynı yerde kullanabilmelidir.
- Üst sınıf ve Alt sınıf arasında farklılık yoktur.
Üst sınıf ile alt sınıf nesne örnekleri yer değiştirdiklerinde, üst sınıf kullanıcısı alt sınıfın operasyonlarına erişmeye devam edebilmelidir.

Liskov'un kitabından tanım 

> “T cinsinden parametre alan tüm programlar (fonksiyonlar) P olacak şekilde, S tipinde o1 nesnesi ve T tipinde o2 nesnesi olsun. Eğer o1 ile o2 nesneleri yer değiştirdiğinde P’nin davranışı değişmiyorsa S tipi T tipinin alt tipidir!”

matematiksel açıklama

> “q(x) fonksiyonu T tipindeki x nesnesi için kanıtlanabilirdir. O halde T tipinin alt tipi olan S tipindeki y nesnesi için de q(y) fonksiyonu kanıtlanabilir olmalıdır.”

Programcı Açıklaması 
> “Temel (base) sınıfın işaretçisini (pointer) ya da referansını kullanan fonksiyonlar, bu sınıftan türemiş olan (derived) sınıfları da ekstra bilgiye ihtiyaç duymaksızın kullanabilmelidir.”


Üst Sınıfı : Base Class

Alt Sınıf : Sub Class

Örnekler

[Örnek 1](https://www.gencayyildiz.com/blog/liskovun-yerine-gecme-prensibiliskov-substitution-principle-lsp/)

[Örnek 2](http://tarikkaygusuz.com/post/solid-prensipleri)

[Örnek 3](https://buraksenyurt.com/post/Tasarim-Prensipleri-Liskov-Substitution)


- Interface Segregation Prensibi


Bir interface tasarlarken interface’in içereceği tüm elemanları bir interface içerisinde toplamak
yerine bunları işlevlerine göre guruplandırmak ve farklı interface’ler içerisine dağıtmak
olarak tanımlanabilir. Pek çok elemanı olan büyük interface’ler yerine, işlevsel ayrım yapılarak
guruplanan birden fazla interface kullanmak ilkenin savunduğu düşüncedir.
Sınıflar şablon olarak kullandıkları Interface’in tüm özelliklerini uygulamak zorundadır.
Fakat kimi zaman interface üzerinde tanımlı yapıların tümüne ihtiyaç duymamakta kullanmamaktadır.


- Dependency Inversion Prensibi

Öncelikle Loose Coupling ve Tight Coupling nedir ona bakmak lazım

Loose Coupling ilkesi nesneler arasında ki bağın zayıf olması gerektiği ilkesidir. Böylece yapının genişletilebilir olması sağlanır. 


Yapışkanlık (Cohesion): Sınıflar arası ilişkinin gevşek bağlı olması istenirken, sınıflar içersindeki yordamların ve veri alanlarının yapışkan/bağlantılı olması istenir. Bir sınıf Single responsibility principle çerçevesinde yalnızca tek bir görevi gerçekleştirmelidir. Eğer bir sınıf içerisinde birden fazla değişik iş yapan yordamlar ya da bağımsız veri alanları bulunuyorsa, bu iş grupları farklı sınıflar halinde ayrıştırılmalıdır. Bir sınıf içerisindeki yordamlar ortak veri alanlarını kullanmıyorlarsa  ya da yaptıkları iş bakımından tamamen ayrık iseler, onları aynı kümenin içinde barındırmanın bir anlamı da bulunmamakta. Yapışkanlık derecesi düşük sınıflar modülerliği ve yazılım bakımını tehdit eden bir unsurdur.

[örnek 1](https://buraksenyurt.com/post/Tasarim-Prensipleri-Loose-Coupling)


[örnek 2](https://www.turkayurkmez.com/loose-coupling-gevsek-baglanti-ilkesi/)


Tight Coupling : Loose Coupling durumunun tam tersidir yani nesneler arasındaki bağın kuvvetli olmasıdır.

Object Oriented dillerde bu bağı tamamen kaldırmak imkansızdır. bu  nedenle loosly coupled bağlar kurulmaya çalışılır.

Bir neste başka bşr nesne içinde create edilirken interface üzerinden create edilir.




## Hollywood Principle
This principle is similar to the dependency inversion principle. This principle says:

Quote:
>Don’t call us, we will call you

This means a high-level component can dictate low-level components (or call them) in a manner that they are not dependent on each other.

This principle defends against dependency rot. Dependency rot happens when each component depends upon every other component. In other words, dependency rot is when dependency happens in each direction (Up, sideways, downward). Hollywood Principle restricts us to make dependency in only one direction.

The difference with dependency inversion principle is that DIP gives us a general guideline “Both higher level and lower component should depend upon abstractions and not on concrete classes”. On the other hand, Hollywood Principle specifies how higher level component and lower level component interact without creating dependencies.


## Bilginin Uzmanı (Information expert)
Sınıflara sorumluluk atamanın temel prensibi nedir?

Bir sorumluluğu bilginin uzmanına, yani onu yerine getirecek veriye sahip olan sınıfa atayın.
Sale > Sales Lıne Item (bu bilgiler sale’da var)
##  Yaratıcı (Creator)
Bir sınıftan nesne yaratma sorumluluğu kime aittir?

- B, A nesnelerini içeriyorsa
- B, A nesnelerinin kaydını tutuyorsa
- B, A nesnelerini yoğun olarak kullanıyorsa
- A’nın yaratılması aşamasındaki başlangıç verilerine B sahipse

Bu koşulları sağlayan birden fazla nesne varsa, sorumluluk nesneyi içeren sınıfa verilmelidir

Register > Sale (sale register’ın üyesi)
## Az Bağımlılık (Low Coupling)
Diğer sınıfların değişimlerinden etkilenmeme, tekrar kullanılabilirlik nasıl sağlanır?

Sorumlulukları, sınıflar arası bağımlılıklar daha az olacak şekilde sorumlulukları atayın.

Register > Sale > Payment (bağımlılık daha az)
## Denetçi (Controller)
Sistem olaylarını arayüz katmanından alıp ilgili nesnelere yönlendirmekle kim sorumludur?

Görüntü veya senaryo (oturum) denetçileri kullanılır.

SaleJFrame -- Register – Sale (register denetçisi)
## İyi Uyum  (High cohesion)
Karmaşıklık nasıl idare edilebilir?

Sorumlulukları sınıf içinde iyi bir uyum olacak şekilde atayın.

Register > Sale > Payment (kim oluştursun)

## Çok Şekillilik (Polymorphism)
Tiplere bağlı alternatifler nasıl ele alınmalı? Sisteme kolay monte edilebilen yazılım parçaları nasıl gerçeklenir?

Birbirleriyle ilgili alternatif davranışlar, tiplere bağlı olarak değişiklik gösteriyorsa bu
davranışları çok şekilli metodlar kullanarak gerçekleyiniz. Koşullu deyimler kullanmak iyi bir yöntem değildir.

ItaxCalculatorAdaptor (farklı adaptörler aynı başlıkta toplanmış)

GenericShape (Line, Rectangle, Circle, ...)

## Dolaylılık (Indirection)

Özellikle kolay değişebilen iki birim arasındaki bağımlılığı azaltmak için sorumluluklar nasıl atanmalıdır?

İki birim arasındaki bağımlılıkları azaltmak için sorumlulukları bir ara nesneye atayın.

Sale > TaxMasterAdapter > TCP Socket Connection

## Pure Fabricatilon

Uzman kalıbının önerdiği çözüm, iyi uyum ve az bağımlılık kavramları ile çelişiyorsa
sorumlulukları hangi sınıfa atamak gerekir?

Eğer sınıflararası bağımlılıkları azaltıyorsa ve yazılımın tekrar kullanabilirliğini arttırıyorsa, birbirleriyle uyumlu sorumlulukları gerçek dünyada var olmayan yapay bir sınıfa
atayabilirisiniz.

PersistantStorage, Connection, ...


#### Kısaca GRASP

- Controller: Sistem sorumluluğunu üzerine alacak sınıfı belirleyin.
- Creator: Gerekli koşullarda Asınıfına başka sınıf yaratma yetkisi verin.
- Low coupling: Sınıflar arasında ki bağı azaltıcı tasarımlar yapın.
- Information expert: Bir sorumluluğu onu yerine getirecek özelliğe sahip olan sınıfa verin.
- Indirection: Bağımlılığı azaltması için araya nesneler atayın. 
- High cohesion: Sorumlulukları sınıf içinde bir uyum olacak şekilde verin.
- Polymorphism: Benzer davranışları tiplere bağlı olarak farklı gösteriyorsa çok şekilli metodlar yapın.
- Protected variations: Sistemde kararsız noktaları kararlı arayüzlerle gerçekleştirin.
- Pure fabrication: Sınıflar arası bağımlılığı azaltıyorsa yapay sınıflar gerçekleştirin.



#### Referanslar

- Mehmet Taşköprü Yazılım Tasaım Presipleri Notları
- [Faruk Aydemir Notları](https://medium.com/pirilab/soli%CC%87d-prensipleri-2-ec74fdf46964) 
- [Gençay Yıldız Liskov Notları](https://www.gencayyildiz.com/blog/liskovun-yerine-gecme-prensibiliskov-substitution-principle-lsp/)
- [Burak Selim Şenyurt] (https://buraksenyurt.com/post/Tasarim-Prensipleri-Liskov-Substitution)
- [Beycan Kahraman GRASP](http://www.beycan.net/eklenen/GoF_ve_GRASP.pdf)







