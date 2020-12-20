### Desteklenen Donanımlar ve Kurulum
 
- Acer Switch Alpha 12 Laptop
- Intel NUC
- Google Pixelbook (Chromebook değil)

ayrıca USB ile normal PC lerde de test edilebilceğinden bahsedilmiş. Ancak dökümantasyonu çok zayıf. Bir çok sayfası halen yapım aşamasında. 

test etmek için biraz daha gelişmesi lazım gibi görünüyor. Başka kaynaklarda da (wiki, youtube, stackoverflow..vb) yeterli bilgi yok.

şaun için YouTube' da çalıştığını gösterir video linkleri

- Google servisleri yok, boş hali, PC kurulumunda görülecek olan bu: https://www.youtube.com/watch?v=r6f70xV_rc0&feature=emb_logo
- Pixelbook versiyonu : https://www.youtube.com/watch?v=FhX6cANaJ6o&t=11s

 
Youtube görülen videoların büyük çoğunluğu Pixelbook üzerinde çekilmiş.

Pixelbook üerinde ekran görüntüleriyle ne detaylı anlatım : https://arstechnica.com/gadgets/2018/01/googles-fuchsia-os-on-the-pixelbook-it-works-it-actually-works/


Kurulum yapabilmek için Build işlemini yapmak gerekişyor. Şuan için hazır bir image yok. Yani ilgili cihaza özel build alınması gerkiyor. Bu durumda da yukarıda bahsedildği gibi içi boş sadee terminal den çalışan bir sistem ayağa kalkmış oluyor.

bütün kurulum tekniklerinin yer aldığı sayfa linkleri

- Network üzerinden build alıp diğer cihaz akurmak için: https://fuchsia.dev/fuchsia-src/development/hardware/paving
- Bootable USB oluşturmak için: https://fuchsia.dev/fuchsia-src/development/hardware/usb_setup

 
 
**Kaynak**
- https://fuchsia.googlesource.com/docs/+/refs/changes/56/101356/4/fuchsia_paver.md
- https://fuchsia.dev/fuchsia-src/development/hardware/paving
 
### Kötü Tarafı
 
Google servislerine yani Google Clud a çok bağımlı. Bu sevisler olmadan sadece IoT cihazlarında veya embedded cihazlarda kullanılabilir görünüyor.
 
### Development

- **ffx:** Future Fuchsia experience (FFX), kullanıcıların bir veya daha fazla Fuchsia cihazını yöntebilcekleri aynı zamanda birçok ortak geliştirme ve entegrasyon iş akışı işlemini gerçekleştirmelerini sağlayan servis tabanlı arayürdür. Bir CLI'ı vardır. Komut satırı yardımıyla cihazlar/simülasyonlar uzaktan yönteilebilir, deploymen yapılabilir, testler yapılabilir...vb


Hem bir hizmet çalışma zamanı hem de bir yardımcı programlar koleksiyonudur ve hem kullanıcılar hem de altyapı entegratörleri için tasarlanmıştır.


- **FIDL:**  FIDL (Fuchsia Interface Definition Language), Fuchsia için bir IPC sistemidir. FIDL yardımıyla diğer dillerin Fuchsia OS' a uyumlu hale gelemsi de sağlanabilmektedir. FIDL derleyicisi ile derleme yapılması gerekmektedir. 


Fuchsia IDK, Fuchsia projesinin Fuchsia geliştiricilerine sağladığı bir kütüphane ve araç koleksiyonudur. Fuchsia IDK, diğer şeylerin yanı sıra, Fuchsia Sistem Arayüzünün bir tanımını ve bir dizi istemci kütüphanesini içerir. IDK, tam bir SDK oluşturmak için derleme ortamına özgü ortama özel araçlar ekleyen geliştirme ortamı entegratörlerini hedeflemektedir.


- **FIDK:** Fuchsia Fuchsia Integrator Development Kit (IDK),

- **DDK:** The Driver Development Kit, Driver geliştricileri için kütüphaneler barındırı. Zirkon Kernel için driver geliştirmeye yardımcı API ve paylaştırılmış kütüphane ve kodlar bulunmaktadır.

- **Banjo ile Driver Geliştirmek:** Banjo, sürücüler arasında iletişim kurmak için kullanılan protokolleri tanımlamak için kullanılan bir dildir. FIDL'den farklıdır, çünkü sürücülerin IPC protokolü yerine birbirlerini aramak için kullanmaları için bir ABI belirtir.

**ilgili kaynaklar:**

- https://fuchsia.dev/fuchsia-src/development/drivers/banjo-tutorial
- https://fuchsia.googlesource.com/fuchsia/+/refs/heads/origin/sandbox/venkateshs/kpti/zircon/docs/ddk/overview.md
- https://fuchsia.googlesource.com/fuchsia/+/refs/heads/origin/sandbox/venkateshs/kpti/zircon/docs/ddk/driver-development.md


**Fuchsia Os'un desteklediği Programlama dilleri**

Şuan tam anlamıyla desteklene diller C, C++, Dart'dır. Biline diğer diller ya bazı özelliklşeir desteklediği yada hiç deteklenmediğini gösterin link aşağıdadır.

- https://fuchsia.dev/fuchsia-src/contribute/governance/policy/programming_languages


Bu yazının yazıldığı tarihlerde bilinenin aksine GO dili tam olarka desteklenmemektedir. Ancak ilgili problemin yakın zamanlarda giderileceğini söylemeye gerek yok herhalde. 
Go'nun tam olarak desteklendiğini gösteirri metin : https://fuchsia.dev/fuchsia-src/contribute/governance/policy/programming_languages#decision_5

```
    Go is not approved, with the following exceptions:
        netstack. Migrating netstack to another language would require a significant investment. In the fullness of time, we should migrate netstack to an approved language.
    All other uses of Go in the Fuchsia Platform Source Tree for production software on the target device must be migrated to an approved language.


```




- https://fuchsia.dev/fuchsia-src/contribute/governance/policy/programming_languages
- https://fuchsia.dev/fuchsia-src/development/languages


### Diğer kaynaklarda

- Fuchsia Os Sözlüğü: https://fuchsia.googlesource.com/fuchsia/+/master/docs/glossary.md
- Fuchsia Os Konsepti, Fuchsia OS' mimari yapısı, device ve driver yönetimi ile detaylı anlamk için: https://fuchsia.dev/fuchsia-src/concepts



**Notlar**

- **IPC:** Bilgisayar bilimlerinde süreçler arası iletişim (Inter Process Communication) veya işlemler arası iletişim (IPC), bir işletim sistemde işlemlerin birbiri ile haberleşmesi ve paylaşılan verilerin yönetilmesine izin verildiği teknolojiyi tanımlamaktadır.
- **API:** Application Program Interface, daha çok developerlar içindir. Public objeler yardımıyla programcı ilgili programla iletişime geçebilcek kodlar yazabilir. Bir nevi bir yazılımın kapalı alanlarının belli kod bloklarıyla dışarı açılmasıdır. Buradakitanımı web teknolojilerinde sıklıkla kullşanılan web API'ler ile karıştırmayınız. Örnmek olarak C/C++ daki header dosyları bu kullanıma örnek gösterilebilir.
- **ABI:** Daha çok uygulamarın birbirini anlamsı içindir. Mesela bir compiler'ın derleyecceği kodu binary seviyede tanıması gerekmektedir. Yada örneğin bir driver kernel ile nasıl iletişime geçecek bunun için çok alt seviyede bir tanımlama gerekmektedir. Yada Fuchsia OS özeli,nde konuşacaklsak mesela modüller birbiriyle nasıl konuşacağını binary seviyede bilmelidir. Banjo tam bu işi yapmaktdır.  






