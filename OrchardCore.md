## Orchard Core 

- ### Tasarım Terminolojisi

  - #### [Template](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/#available-templates)

  - #### [Theme](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Themes/README/)
  
  Orchard CMS deki anlatım: [adres](http://docs.orchardproject.net/en/latest/Documentation/How-Orchard-works/#themes)
  
  Orchard CMS de Theme nasıl yapılır sayfası: [adres](http://docs.orchardproject.net/en/latest/Documentation/Writing-a-new-theme)

  - #### Content Type

  Orchars CMS deki anlatım : [adres](http://docs.orchardproject.net/en/latest/Documentation/Content-types/#content-type)
  
  Content Type content in kategorisi olarak görülebilir. content in ne sunduğunun tanımıdır. örneğin bir blog sitesindeki   bir post veya fotoğraf gibi.
  
  [anatomy of content type](http://docs.orchardproject.net/en/latest/Documentation/How-Orchard-works/#content-type-system)
  

  - #### [Content](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Contents/README/)

  Orchard CMS deki anlatım : [adres](http://docs.orchardproject.net/en/latest/Documentation/Basic-Orchard-Concepts/#content)
  Kısaca içinde bilgi bulunan ve kullanıcıya sunulan hertürlü içerik. 


  - #### [Content Template](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/#content-templates)


  - #### [Types, Parts, and Fields](http://docs.orchardproject.net/en/latest/Documentation/How-Orchard-works/#content-type-system)
  
  Örneğin, bir blog yayını, bir ürün ve bir video klibin hepsinin yönlendirilebilir bir adresi, yorumları ve etiketleri olabilir. Bu nedenle yönlendirilebilir adres, yorumlar ve etiketlerin her biri Orchard'da ayrı bir içerik parçası (content part) olarak ele alınır. Bu şekilde, yorum yönetimi modülünün yalnızca bir kez geliştirilmesine ihtiyaç vardır ve yorumlama modülünün yazarının bilmediği içerikler de dahil olmak üzere keyfi içerik türlerine (content type) uygulanabilir.
  
  Alanlar (fields), parçalardan daha fine grain bir yapıdadır ([fine grain vs coarse grain](https://stackoverflow.com/questions/3766845/coarse-grained-vs-fine-grained), [diğer kaynak](https://www.quora.com/What-is-the-difference-between-coarse-grained-and-fine-grained)). Örneğin, bir alan türü (field type) bir telefon numarasını veya bir koordinatı açıklayabilir, oysa bir bölüm (part) genellikle yorum yapma veya etiketleme gibi bir endişeyi açıklar.
  
  Parçaların (parts) kendileri özellik ve içerik alanlarına sahip olabilir. İçerik alanları da (content field), parçaların (part) kullanıldığı gibi tekrar tekrar kullanılabilir. Belirli bir alan türü (field type) çeşitli parça (part) ve içerik türleri (content type) tarafından kullanılabilir. Parçalar (part) ve alanlar (field) arasındaki fark, çalıştıkları ölçekte ve semantiklerinde (anlamsallıklarında) bulunur. Fakat buradaki önemli fark, semantiktir (anlamsaldır): Eğer bir ilişkiyi uygularsa bir parça yazmak istersiniz ve eğer bir ilişkiyi kurarsa bir alan yazarsınız. 
  
  Örneğin, bir gömlek bir üründür ve bir SKU'su ve bir fiyatı vardır. Ancak bir tişörtün bir ürünü olduğunu veya bizzat bir gömleğin fiyat veya SKU oldunu söyleyemeyiz. Bundan dolayı Gömlek içerik türünün (content type) bir Ürün parçasından (part) yapılacağını ve bu Ürün parçasının (part) "fiyat" adlı bir Para alanından (field) ve SKU adlı bir String alanından (field) oluşturulacağını tahmin edebiliriz.
  
  Diğer bir fark ise, içerik türü (content type) başına belirli bir türün (type) yalnızça bir parçasına (part) sahip olabilmemizdir. Ancak bir parça (part) belirli bir tür (type) için birçok alana (field) sahip olabilir. Bunu anlatmanın bir diğer yolu ise şudur: parça (part) üzerindeki alanlar (field), alanın türüne (field's type) ait değerlerin string dictionary si iken, içerik türü (content type) ise parça türlerinin (part type) bir listesi (isimler olmaksızın) olmasıdır.
      
[content type anatomisi (okumalısın)](http://docs.orchardproject.net/en/latest/Documentation/How-Orchard-works/#content-type-system)


  - #### [Event Bus](http://docs.orchardproject.net/en/latest/Documentation/How-Orchard-works/#event-bus)

  - #### [Content Field](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.ContentFields/README/)

İçerik alanları (content field), bir içerik türüne (content type) eklenebilecek bilgi parçalarıdır. İçerik alanlarının (content field) bir adı ve türü vardır ve bir içerik türüne özgüdür. Herhangi bir içerik türünde (content type) her alan (field)  türünden birkaç tane olabilir. Örneğin, bir Ürün içerik türü, SKU'sunu temsil eden bir metin alanına, fiyatını temsil eden bir sayısal alana ve ağırlığını temsil eden başka bir sayısal alana sahip olabilir.

  [Field lar nasıl kullanılır](http://docs.orchardproject.net/en/latest/Documentation/Getting-Started-with-Modules-Part-3/#using-fields)

  - #### [Content Field Template](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/#content-field-templates)

Orchard CMS deki anlatım :

  - #### [Content Filed Differentiator](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/#content-field-differentiator)
  
  Differentiator Orchard CMS de yok gibi görünüyor. yada başka türlü çalışıyor


  - #### Content Part 
  
  Orchard CMS deki anlatım: [adres](http://docs.orchardproject.net/en/latest/Documentation/Content-types/#content-part), [adres](http://docs.orchardproject.net/en/latest/Documentation/Basic-Orchard-Concepts/#content-part), [adres](http://docs.orchardproject.net/en/latest/Documentation/Understanding-placement-info/#contentpart)  
  

  - #### [Content Part Template](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/#content-part-templates)

  - #### Content Zone
  
  [Liquid and zone](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Liquid/README/#zone)
  
  Orchard CMS deki linkler: [Zone](http://docs.orchardproject.net/en/latest/Documentation/Basic-Orchard-Concepts/#zone), [local-zone-placement](http://docs.orchardproject.net/en/latest/Documentation/Understanding-placement-info/#local-zone-placement)
  
   
  
  [Content Zone and Diffrentiator](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Themes/README/#content-zones-differentiators), 
  
  Orchard CMS deki anlatım : [adres](http://docs.orchardproject.net/en/latest/Documentation/Basic-Orchard-Concepts/#zone)
  

  - #### [Widget](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Widgets/README/)
  
  Widged oluşturmak için : [core adres](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Widgets/README/), [creating cusotm widged](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Widgets/README/#creating-custom-widgets)
  
  Orchard CMS deki anlatım : [adres](http://docs.orchardproject.net/en/latest/Documentation/How-Orchard-works/#widgets), 
  [adres](http://docs.orchardproject.net/en/latest/Documentation/Definitions/#widget), [adres](http://docs.orchardproject.net/en/latest/Documentation/Basic-Orchard-Concepts/#widget), 
  

  - #### [Widget Template](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/#widget-templates)
  
  - #### [Layer, Zone and Widged](http://docs.orchardproject.net/en/latest/Documentation/Managing-widgets/#layers-zones-and-widgets)
  

  - #### Shape
  
  Orchard Core şu video ya link vermiş shape i an latmak için [adres](https://www.youtube.com/watch?v=gKLjtCIs4GU&feature=youtu.be)
  
  Orchard CMS deki anlatım : [adres](http://docs.orchardproject.net/en/latest/Documentation/Basic-Orchard-Concepts/#shape), [adres](http://docs.orchardproject.net/en/latest/Documentation/Builtin-Features/#shapes), [shape and template](http://docs.orchardproject.net/en/latest/Documentation/Content-types/#shapes-and-templates), 
  

  - #### [Shape Differentiator](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/#shape-differentiators)

  - [Placement.info](https://orchardcore.readthedocs.io/en/latest/OrchardCore/OrchardCore.DisplayManagement/README/)
  
    Orchard CMS deki anlatım : [adres](http://docs.orchardproject.net/en/latest/Documentation/Understanding-placement-info/)
    
  - [Menu Alternate](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Menu/README/#menu-alternates)
    
  - #### [Alternate](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Themes/README/#alternates)
    Orchard CMS deki anlatım : [adres](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Themes/README/#alternates)
    
   
  - #### Display Driver

  - #### Display Type

  - #### Permalink (Permanent Link)

- ### [Manifest Dosyası](http://docs.orchardproject.net/en/latest/Documentation/Manifest-files/)

  Theme Manifest
  
  Module Manifest
  
- ### [YESQL](https://github.com/krisajenkins/yesql)

  Yesql ORM değildir yazarın tabiriyle DRN ()
  
  bütün veriler tek bir tablonun tek bir sütununda JSON olarak tutulur. Sorgu işlemleri için ise verideki önemli kısımlar ayrı ayrı tablolarda index ve view create edilerek yapılır.
  
  index leme yapıldıktan sonra iki türlü map leme yapılır: one-to-one ya da one-to-many. (map/reduce).
  
  verileri JSON olarak store edilirken indexleme yapılan database den farklı yerler kullanılabilir. dosya yada farklı bir database.
  
  Session kavramı aslında EF' deki Context yada Nhibernate deki Session kavramı ile aynıdır.
  
  Migration için bir kez initialize fonksiyonu çağrılır.
  
  
  
  
  
  
  


- ### Routing

- ### Localization

Localization hakkında Orchard Core daki Localization Module sayfası: [adres](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Localization/README/)

Orchard CMS deki linkler: [adres](http://docs.orchardproject.net/en/latest/Documentation/How-Orchard-works/#localization)

Orchard CMS deki Laclization nasıl yapılır sayfası: [adres](http://docs.orchardproject.net/en/latest/Documentation/Creating-global-ready-applications/#localizing-the-orchard-application-and-orchard-modules)




- ### Nasıl Çalışır

  Orchard CMS deki anlatım : [adres](http://docs.orchardproject.net/en/latest/Documentation/How-Orchard-works/)
  
  


- ### Links
  - #### Definitions
  bu artık eskimiş bi tanımlama sayfası ama mantığı anlatması açısından iyi sayılır
  http://docs.orchardproject.net/en/latest/Documentation/Definitions/
  
  Orchard CMS Builtin Features and Modules
  http://docs.orchardproject.net/en/latest/Documentation/Builtin-Features/
  
  Orchard ın Youtube sayfası
  https://www.youtube.com/channel/UCcEaR8HfGpPwt-GqJr_h5UQ
  

  https://weblogs.asp.net/antoinegriffard
  https://twitter.com/Lombiq
  https://twitter.com/sebastienros


