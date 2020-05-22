SS de ilk haberleşme de ve key değişiminde aymetic key kulanıldığında bahsetmişti. Ancak il haberleşmeden sonta işlemlerin daha hılzı olması için simetrik keye geçiş yapılır. burada da diffie-hellman algoritmesında bahsetmiştik,

- Asimetrik için : RSA, DSA
- Simetrik için: AES, DES



#### 1. Yol

öncelike kendi özel anahtarımı oluşturmalıyız.

```
openssl genrsa -out private_key.pem 2048
```
oluşturulan key ascii formatındadır yanmi okunabilir.

daha sonra CSR (Certificate Signing Request) oluşturuyoruz.

bunu normalde CA ile yapıyor olsaydık CA nin imzalaması gerekcekti ancak burada kendimiz imzalayacağız.

bunun için sertifika üzerine x.509 alanlarının tanımlanması gerekecek.

Common Name alanına korumayı istediğimiz alan adını full qualified domain name olarka yazmamız gerekecek.

```
openssl req -new -key private_key.pem -out my_server.csr
```

bu komut ile birlikte aşağıdaki bilgeri doldurmamız gerekecek

```
Country Name (2 letter code) [GB]:TR
State or Province Name (full name) [Berkshire]:Cankaya
Locality Name (eg, city) [Newbury]:Ankara
Organization Name (eg, company) [My Company Ltd]: murat cabuk
Organizational Unit Name (eg, section) []: murat cabuk
Common Name (eg, your name or your server’s hostname) []:muratcabuk.com
Email Address []:muratcabuk@muratcabuk.com
Please enter the following ‘extra’ attributes
to be sent with your certificate request
A challenge password []:
An optional company name []:
```
oluştururacağımız sertifikayı kendimiz imzalayacağımız için oluşturduğumuz CSR dosyasını imzalamamız gerekiyor.

```
openssl x509 -req -days 365 -in my_server.csr -signkey private_key.pem -out my_server.crt
```

oluşturduğumuz sertifikada parola varsa sunucuda kullanırken problem olabilir. çünki her restart da password soracaktır bunu kaldırmak için aşağıdkai komutu kullanıyoruz.

```
openssl rsa -in server.key.org -out server.key
```


#### 2.Yol

```
mkdir /etc/nginx/ssl


openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout /etc/nginx/ssl/muratcabuk.com.key -out /etc/nginx/ssl/muratcabuk.com.crt

şu bilgileri dolduruyoruz

Country Name (2 letter code) [AU]:TR
State or Province Name (full name) [Some-State]:Ankara
Locality Name (eg, city) []:Ankara
Organization Name (eg, company) [Internet Widgits Pty Ltd]:Murat Cabuk
Organizational Unit Name (eg, section) []: Murat Cabuk
Common Name (e.g. server FQDN or YOUR name) []:muratcabuk.com
Email Address []:info@muratcabuk.com

```

2 dosya oluştu key ve crt

bize pem dosyası alım forward secrecy (iletme gizlilii) için. burada Diffie-Hellman için gerkli bir adım. 

alıntı 

"İletme gizliliği(Forward Secrecy) kavramı basittir: Sunucudan RSA özel istemci ve sunucu arasında bir Diffie-Hellman anahtar değişimini imzalamak için kullanılır. El sıkışma ile elde edilen pre-master anahtar, şifreleme için kullanılır. Ana anahtar bir istemci ve sunucu arasında geçen bir bağlantıya özgüdür ve yalnızca sınırlı bir süre için kullanılır, ömrü kısadır daha sonrasında kullanılmaz.

İletme Gizliliği ile, bir saldırgan sunucunun özel anahtarını eline geçirirse, geçmiş iletişim şifresini çözmek saldırgan için mümkün olmayacaktır. Özel anahtar sadece pre-master anahtarı ortaya koymuyor, ki DH yi, imzalamak için kullanıyor. Pre-master anahtarlar hiçbir zaman istemci ve sunucu arasında bir saldırgan tarafından yapılan ve tespit edilemeyen MITM’leri engeller."

```
cd /etc/nginx/ssl/
openssl dhparam -out dhparam.pem 4096
```
daha sonta nginx e ekliyoruz

```

server {
    listen 80 default_server;
    listen [::]:80 default_server;
    server_name git.mertcangokgoz.com;
    return 301 https://$host$request_uri;
}

server {
    listen 443 ssl;
    listen [::]:443 ssl;
    server_name git.mertcangokgoz.com;
    # certs sent to the client in SERVER HELLO are concatenated in ssl_certificate
    ssl_certificate /etc/nginx/ssl/mertcangokgoz.com.crt;
    ssl_certificate_key /etc/nginx/ssl/mertcangokgoz.com.key;
    ssl_session_timeout 1d;
    ssl_session_cache shared:SSL:50m;
    ssl_session_tickets off;

    # Diffie-Hellman parameter for DHE ciphersuites, recommended 4096 bits
    ssl_dhparam /etc/nginx/ssl/dhparam.pem;

    # modern configuration. tweak to your needs.
    ssl_protocols TLSv1.2;
    ssl_ciphers 'ECDHE-ECDSA-AES256-GCM-SHA384:ECDHE-RSA-AES256-GCM-SHA384:ECDHE-ECDSA-CHACHA20-POLY1305:ECDHE-RSA-CHACHA20-POLY1305:ECDHE-ECDSA-AES128-GCM-SHA256:ECDHE-RSA-AES128-GCM-SHA256:ECDHE-ECDSA-AES256-SHA384:ECDHE-RSA-AES256-SHA384:ECDHE-ECDSA-AES128-SHA256:ECDHE-RSA-AES128-SHA256';
    ssl_prefer_server_ciphers on;

    # HSTS (ngx_http_headers_module is required) (15768000 seconds = 6 months)
    add_header Strict-Transport-Security max-age=15768000;

    location / {
	    try_files $uri $uri/ =404;
    }
}
```








### Kaynaklar

- http://www.fatlan.com/tag/openssl/
- https://mertcangokgoz.com/nginx-icin-self-signed-ssl-sertifikasi-olusturma/
- https://mertcangokgoz.com/nginx-icin-self-signed-ssl-sertifikasi-olusturma/