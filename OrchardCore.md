## Orchard Core 

- ### Tasarım Terminolojisi

    - CMS Types
      1. Standart CMS : Sunucu taraflı ve istemci taraflı tüm işlerim tek altyapıyla sağlandığı CMS ler. örneğin orchard core theme giydirme işlerinin yapıldığı ve sayfanın HTML render işlemlerinin de bu theme in kullanılarak server tarafından yapılarak çalıştırılan CMS buna örnektir.
      2. Decoupled CMS : render işlemlerinin serverda yapıldığı ancak altyapının theme ve html generate etme özelliklerinin kullanımadığı CMS türüdür.
      3. Headless CMS: server tarafından istemciye sadece datanın sunulduğu, tüm tasarım ve render işlemlerinin istemci tarafında yapıldığı şekildir. 


    - #### [Template](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/#available-templates)

    - #### [Theme](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Themes/README/)
        
    [video1](https://www.youtube.com/watch?v=wtAIgn4gYXc&index=7&list=PLuskKJW0FhJfOAN3dL0Y0KBMdG1pKESVn)
    [video2](https://www.youtube.com/watch?v=bt3Stgb_wbI)
  
    Orchard CMS deki anlatım: [adres](http://docs.orchardproject.net/en/latest/Documentation/How-Orchard-works/#themes)
  
    Orchard CMS de Theme nasıl yapılır sayfası: [adres](http://docs.orchardproject.net/en/latest/Documentation/Writing-a-new-theme)
  
  
  Buradaki theme yukarıda bahsi geçen "[Standart CMS](https://github.com/muratcabuk/Notes/blob/master/OrchardCore.md#tasar%C4%B1m-terminolojisi)" 
  
  ##### Adım Adım theme oluşturma
  1. Öncelikle OrchardCore.Themes sanal klasörüne Theme projesi oluşturuyoruz class library olarak. Agency Theme proj dodyasını editkeme modunda açıp içeriğğini yeni oluşturduğumuz TheCreativeTheme projesinin proj doyasına editleme modunda  açıp yapıştırıyoruz. 
  
  projeyi CMS projesine eklemeni iki yolu var: birinci yol CMS projesine referans olark eklemek; ikinci yol ise OrchardCore.Application.Cms.Targets.proj dosyasına  en alta alttaki satırı eklemektir. biz bu yöntemi tercih ettik.
  
  <ProjectReference Include="..\..\OrchardCore.Themes\TheCreativeTheme\TheCreativeTheme.csproj" PrivateAssets="none" />
  
  
  
  kopyalama yaptığımız proj dosyası içindeki embeddedresources itemgroup nodu silinmeli
  
  2. Manifest dosyasını theagenttheme den kopyalarıp değştiriyoruz.
  
  3. Bootstrap sayfasından indridiğimiz [Creative Theme](https://startbootstrap.com/template-overviews/creative/) dosyalarını wwwroot klasörüne yapıştırıyoruz. gulp.js ve package.json dahil
  
  4.  daha sonra ilk olarak Layout u oluşturmaya başlayacağız.
        - bunun için wwwroot altına koyaladığımız index.html adını Layout.liquıd olarak değiştirip Views klasörü altına koyaplıyoruz. Zone olarak ayarlanacak yerleri daha sonra yarlayacağız. Daha sonra TheAgentTheme deki Layout.liquid dosyaından gerekli yerleri kopyala yapıştır yapacağız.
        - Layout.liquid içindeki bütün statik (css, js, image ... vs) dosyalarınınbaşına template in adını yazıyoruz. bizim durumumuzda TheCreativeTemplate ekliyoruz.
        - Head tagı içine alttaki satırları ekliyoruz. render_section alanı razor engine deki section lar gibi. partial view leri yüklemek için kullanılır. burada çalışma zamanında eklemek istediğimiz meta datalar, js ve css ler için kullanıyoruz.
        
          İkinci page_title liquid tag ıdır. page_title title a özel bir section tanımlamasıdır.
          
          OrchardCore.Settings projesi siteye ait settingsleri farklı akaynaklardan toplar.
          
          OrchardCore.DisplayManagement.Title projesi ise Title partnın kullanacağı html title ı oluşturur. Sayfanın herhangi bir yerinde title ı çağırıp html olarak eklran abasmak için lazım. Aynı zamanda HTML içindeki title tag ının (segmentinin) oluşturlmasını nı sağlar (GenerateTitle() fonksiyonu).
          
          {% render_section "HeadMeta", required: false %}
          
          <title>{% page_title Site.SiteName %}</title>
          
          ayrıca body tag ı içine 
          
          dir="{{ Culture.Dir }}"
          
          satırını ekşiyoruz. bu culture koduna gore sağdan solamı soldan sağa mı yazılacağını belirtir.
          
          en alta body tag ını kapatmadan hemen öncesine alttaki satırı ekliyoruz.Resource a eklenen footer için scriptleri ekliyor. [Resources](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Resources/README/)
          
          {% resources type: "FootScript" %}
          
          alttaki satırları da head tagını kapatmadan hemen öcesine ekliyoruz.
          
          {% resources type: "Meta" %}
          {% resources type: "HeadLink" %}
          {% resources type: "Stylesheet" %}
          {% resources type: "HeadScript" %}
          
          body içindeki script taglarının hemen üstüne alttaki satırı ekliyoruz
          
          {% render_section "Footer", required: false %}      
      
        - Navigasyon için gereklei alattaki işlemleri yapıyoruz.
        nav tagları arasında yer alan ultagınıda içine alan div i siliyoruz. tüm menu itemleri veritabanından gelecek.
       bu alanı sildikten sontra alttaki bölümü silinen yere kopyalıyoruz.
       
          {% shape "menu", alias: "alias:main-menu", cache_id: "main-menu", cache_tag: "alias:main-menu" %}
          
          menu : hem content_type hem de shape ı belirtir. shape menu template inin kullanılacağını belirtir.
          cache id = menuyu caclemek için kullanıyoruz
          alias = content item adı
          cache_tag: "alias:main-menu" ise cache in değişip değişmediğini kontrol eden property
          
          
          şuan sitede bu template i anble yapıp default template yaparsak üst taraf alttaki gibi görünecektir. menu css i düzgün görünmüyor. Bu alana menu module ü menuyü basıyor ancak css inin düzenlenmesi gerekiyor. bunun için ilgili view in (template in) değiştirilmesi gerekiyor. 
          
          ![resim](https://github.com/muratcabuk/Notes/blob/master/orchardtheme1.png)
          
          Tam bu noktada Orchard Core Shape mantığını b,raz anlamamız gerekiyor. Menu content-type ından oluşturulan main menu contentine nebulermizi ekledik. menu modulu içinde theme e eklediğimiz menu shape ine menumuz menu.cshtml yardımıyla ekleniyor. Bunun için 
          
          Menu.Cshtml
          
          ![resim](https://github.com/muratcabuk/Notes/blob/master/orchardthememenu1.png)
          
          MenuItem.Cshtml
          
          ![resim](https://github.com/muratcabuk/Notes/blob/master/orchardthememenu2.png)
          
          MenuItemLink.Cshtml
          
          ![resim](https://github.com/muratcabuk/Notes/blob/master/orchardthememenu3.png)
          
          MenuItemLink-LinkMenuItem.Cshtml
          
          ![resim](https://github.com/muratcabuk/Notes/blob/master/orchardthememenu4.png)
       
          

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

   - #### [Content Field](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.ContentFields/README/)

İçerik alanları (content field), bir içerik türüne (content type) eklenebilecek bilgi parçalarıdır. İçerik alanlarının (content field) bir adı ve türü vardır ve bir içerik türüne özgüdür. Herhangi bir içerik türünde (content type) her alan (field)  türünden birkaç tane olabilir. Örneğin, bir Ürün içerik türü, SKU'sunu temsil eden bir metin alanına, fiyatını temsil eden bir sayısal alana ve ağırlığını temsil eden başka bir sayısal alana sahip olabilir.

  [Field lar nasıl kullanılır](http://docs.orchardproject.net/en/latest/Documentation/Getting-Started-with-Modules-Part-3/#using-fields)

   - #### [Content Field Template](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/#content-field-templates)

Orchard CMS deki anlatım :

   - #### [Content Filed Differentiator](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/#content-field-differentiator)
  
  Differentiator Orchard CMS de yok gibi görünüyor. yada başka türlü çalışıyor

   - #### Content Part 
  
  Orchard CMS deki anlatım: [adres](http://docs.orchardproject.net/en/latest/Documentation/Content-types/#content-part), [adres](http://docs.orchardproject.net/en/latest/Documentation/Basic-Orchard-Concepts/#content-part), [adres](http://docs.orchardproject.net/en/latest/Documentation/Understanding-placement-info/#contentpart)  
  
  Ayrıca bu dökümanda (Type, Part and Field) bölmünde detaylı anlatılmaktadır. [adres](https://github.com/muratcabuk/Notes/blob/master/OrchardCore.md#types-parts-and-fields)
  
   - #### [Content Part Template](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/#content-part-templates)

   - #### Content Zone
  
   Zone lar layout içinde yer alan, içine widged konulabilen ve customize edilebilen özel partlardır. bazıları collepse yapılabilir.
    
   [Liquid and zone](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Liquid/README/#zone)
  
  Orchard CMS deki linkler: [Zone](http://docs.orchardproject.net/en/latest/Documentation/Basic-Orchard-Concepts/#zone), [local-zone-placement](http://docs.orchardproject.net/en/latest/Documentation/Understanding-placement-info/#local-zone-placement)
     
  
  [Content Zone and Diffrentiator](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Themes/README/#content-zones-differentiators), 
  
  Orchard CMS deki anlatım : [adres](http://docs.orchardproject.net/en/latest/Documentation/Basic-Orchard-Concepts/#zone)
  
   - #### [Widget](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Widgets/README/)
  
  Widged lar safanınn belirlenen yerlerine render edilebilen spesifik kategorideki (stereotype) conten itemler dır. Widged modulu widged stereotype ını ve render edilebilir bir template i sunar.  
  
  Widget lar sayfaya Layer lar yardımıyla eklenir. layerlar widged ların bir listesidir.
  
  Widged oluşturmak için : [core adres](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Widgets/README/), [creating cusotm widged](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Widgets/README/#creating-custom-widgets)
  
  Orchard CMS deki anlatım : [adres](http://docs.orchardproject.net/en/latest/Documentation/How-Orchard-works/#widgets), 
  [adres](http://docs.orchardproject.net/en/latest/Documentation/Definitions/#widget), [adres](http://docs.orchardproject.net/en/latest/Documentation/Basic-Orchard-Concepts/#widget), 
  
   - #### [Widget Template](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/#widget-templates)
  
   - #### [Layer, Zone and Widged](http://docs.orchardproject.net/en/latest/Documentation/Managing-widgets/#layers-zones-and-widgets)
   
   A layer is a group of widgets (with their specific configuration, which includes their positioning -zone name and ordering-) that is activated by a specific rule.
   
   Layer widgetlar hakkındaki bilgilerin de bulunduğu (pozisyonları, zone isimleri ve sıları gibi) bir listedir. Layer lar widget ları belirli kurallar dahilinde ekrana basar. örneğin layer widget ı sadece belirli userlar login olduğunda gösterebilir.
   
   Zone widget ın sayfa üzerindeki pozisyonu için yardımcı olur.

  
   - #### Shape
   
   Dinamik data modeldir. yani çalışma zamanında  (runtime) update edilebilir. Statik olan view modelin yerini alır. File template razor files ı kullanır yani cshtml (shape template olarak adlandırılır.). Shape classın dan inherit edilerek yazılır ve Shape attribute olarak methodlarda kullanılır. Dinamik olduğu için strong typing ile yazılmaz. 
   
   Örneğin OrchardCore.Html partına bakılırsa HtmlBodyPart.cshtml dosyaındaki model içinde (HtmlBodyPartViewModel) içinde HtmlBodyPart property si tipi string olan bir html adında bir property bulunur. dinamik olarak bu property update edilebilir.
   
   Shape oluşturmak için aşağıdaki yöntemler kullanılabilir.
   -- IShapeFactory (IShape Create (string shapeType))
   -- DefaultShapeFactory
   -- New adında ki fonksiyonu Orchard layout.cshtml içinde çağırarak
   
   Content Shape Oluşturmak
   
   ![Creating Content Shape](https://github.com/muratcabuk/Notes/blob/master/CreatingContentShape.png)
   
   Content Shape Events
   ![Content Shape Event](https://github.com/muratcabuk/Notes/blob/master/ShapeEvents.png)
   
   
     
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
  
  Bütün veriler tek bir tablonun tek bir sütununda JSON olarak tutulur. Sorgu işlemleri için ise verideki önemli kısımlar ayrı ayrı tablolarda index ve view create edilerek yapılır.
  
  Index leme yapıldıktan sonra iki türlü map leme yapılır: one-to-one (map index) ya da one-to-many (map/reduce indexing). (map/reduce).
  
  Verileri JSON olarak store edilirken indexleme yapılan database den farklı yerler kullanılabilir. dosya yada farklı bir database.
  
  Session kavramı aslında EF' deki Context yada Nhibernate deki Session kavramı ile aynıdır.
  
  Migration için bir kez initialize fonksiyonu çağrılır.
  
  IndexProvider ile bitenler IIndexProvider interface ini implement eden class lar. UB objeler (orneğin PersonByNameIndexProvier) index in bizzat kendisinitemsil eder (aynı zamanda DB deki tablonun adını). Bu Inbdex içindeki property lerde tablodaki sütunları temsil eder.
  
  [YESSQL Doc](https://github.com/sebastienros/yessql/wiki)
  
  [YESSQL Example](https://github.com/sebastienros/yessql/tree/master/samples)
   
- ### Routing

- ### Localization

Localization hakkında Orchard Core daki Localization Module sayfası: [adres](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Localization/README/)

Orchard CMS deki linkler: [adres](http://docs.orchardproject.net/en/latest/Documentation/How-Orchard-works/#localization)

Orchard CMS deki Laclization nasıl yapılır sayfası: [adres](http://docs.orchardproject.net/en/latest/Documentation/Creating-global-ready-applications/#localizing-the-orchard-application-and-orchard-modules)

- ### Module

[Video1](https://www.youtube.com/watch?v=LoPlECp31Oo)


- ### Multitanent Website

[Nasıl Yapılır Video](https://www.youtube.com/watch?v=yWpz8p-oaKg)

[Saas Framework Video](https://www.youtube.com/watch?v=Bqgnd2mfRQY)





- ### Nasıl Çalışır

  Orchard CMS deki anlatım : [adres](http://docs.orchardproject.net/en/latest/Documentation/How-Orchard-works/)
  
  [video1](https://www.youtube.com/watch?v=2XP_klGjg40)
  
  Capabilities
  [video2](https://www.youtube.com/watch?v=6ZaqWmq8Pog)
  
  
- ### [Workflows](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Workflows/README/)  
  


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


