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

  Başka bir fark, içerik türü başına belirli bir türün yalnızca bir parçasına sahip olmanızdır; bu, "bir" ilişki ışığında anlam ifade ederken, bir bölüm belirli bir türdeki herhangi bir sayıda alana sahip olabilir. Bunu söylemenin başka bir yolu, bir alandaki alanların, alanın türüne ait değerlerin bir dizgisi, içerik türü ise parça türlerinin (isimler olmadan) bir listesi olmasıdır.

  Bu, bölüm ve alan arasında seçim yapmanın başka bir yolunu sunar: İnsanların, içerik türüne göre nesnenizin birden fazla örneğini isteyeceğini düşünüyorsanız, bunun bir alan olması gerekir.

  Another difference is that you have only one part of a given type per content type, which makes sense in light of the "is a" relationship, whereas a part can have any number of fields of a given type. Another way of saying that is that fields on a part are a dictionary of strings to values of the field's type, whereas the content type is a list of part types (without names).

This gives another way of choosing between part and field: if you think people would want more than one instance of your object per content type, it needs to be a field.



       

  - #### Content Field


  - #### [Content Field Template](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/#content-field-templates)

  - #### Content Part

  - #### [Content Part Template](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/#content-part-templates)

  - #### Content Zone

  - #### Widget

  - #### [Widget Template](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/#widget-templates)



  - #### Shape

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
  
  




https://weblogs.asp.net/antoinegriffard
https://twitter.com/Lombiq
https://twitter.com/sebastienros


