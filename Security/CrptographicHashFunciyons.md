Burada amaç bilgiyi kaybederek güvenli hakle getirmek.

__en çok bilinenler__

- MD5
- SHA1
- SHA256
- SHA512

ilk ikisi zaten artık kırıldı.

burada aslında datanın integrity sini sağlamış oluyoruz. 

__Itegrity:__ iki nokta arasında gönderilen mesajın değişmeden olduğu gibi karşıya erişmesi anlamına geliyor. Bunu için integriry check kullanılır.


örneğin A noktasından B noktasına gönderilen verinin hash ini alıp yanna koyarsak ve karşı taraf ilgili bilgi,yi aldığında o da hash ini aldığında aynı veriye ulaşıyorsa demekki bilgi değiştirilmeiş demektir. bu üretilen checksum ya da digest deniliyor.

alınan hash ler aslında binary formatta oluyor ama bunların her bir byte ı (genelede) hexadesimal karakter çevrildiği için daha okunaklı görünüyor sonuç. tabi burada amaç binarty formatı text e dökmek. bir başkası örneğin base64 ü de kullanabilir. bu dene cheksum yaplacaksa neye çevrildiği bilinip ona göre checkedilmelidir.

diğer bir örnek database de verşiyi cleartext olarak tutmak istemiyoruz diyelim. hash leyip tutabiliriz. bu durumda asında authenticity yapmış oluruz.

__Authenticity:__ iki nokta birbiriyle haberleşirken hakikaten karşıdaki kişinin konuştuğu kişi olup olmadığından emin olunması. yani hakikaten ABC banksaının sitesindemiyim yoksa araya biri girip ABC bankası gibi mi davranıyor.

mesela authenticity ye diğe bir örnek git deki commit ler. her bir commitin unique liğini sağlamk için aslında hash ialınır. hatta galiba sha-1 i alınıyor.

__Hashed Message Authenticaiton Code (HMAC)__ mesajı göndeririken birşey daha göndermek istiyoruzki mesajın bizden geldiği belli olsun. burada aslolan mesajın açık yada gizli olması değil, önemli olan mesajın doğru kişien gelip gelmediğini berlirlemek (authenticity).

önceki örnekte authenticity örneğinde mesajın yanna hash alıp göndermiştik. ancak bir başkasıda araya girip mesajı ve has ini değiştirip  gönderebilir. budurumda karşı taraf doğru kişiden aldığını neren bilcek.
bu durumda hash alırken sadece bilginin değil birde iki tarafın bildiği bir metni koyarak hash alıyorum araya giren biri saati değiştirip has i alsa bile ilgili ikinci metni bilemdiği için hash aslında yanlış oluşmuş olacak. bu ekstra eklenen hash e HMAC key deniliyor.

### key ler nasıl store edilecek

yani örneğin password ler nasıl databse de saklanacak.

- plaintext
- hashed (ama bunun için de internette rainbow table lar var)
- password e bir başka key eklenip (buna salt deniliyor) hash lenebilir ama burada eninde sonunda salt olsa dahi GPU lar ile brute force ile bununları bulmak yine de mümkün olabiliyor. özellikle veritabnında aynı passwordden şanseseri varsa daha da kolaylaşıyor.


__PBKDF2 yani Password based Key Derivation Functions__

buradada password salt le hash leniyor ve üretilen yeni hash tekrar passworde salt olarakveriliyor ve bu işlem belki 1000 kez tekrarlanıyor.