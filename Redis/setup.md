
redis 6379
sentinel 26379 

portunda  çalışır.

HAPROXY de 6379 posrtu üzerinden tcp ile komut göndererek master nodu kontrol eecek. hangisi ayaktaysa ona gönderecek


HaProxy makinası ipaddress_haproxy

sentinel 1 ipaddress_sentinel1 (sadece sentinel çalışacak redis çalışmayacak)
redis master - sentinel 2 ipaddress_sentinel2_redismster
redis slave -sentinel 3 ipaddress_sentinel2_redisslave








REDIS KURULUM - REDIS MAKINALARINDA YAPILACAK (ipaddress_haproxy,sentinel1_ipaddress,sentinel2_redismaster_ipaddress,sentinel3_redisslave_ipaddress)
----------------------------------------------------------------------------


sudo apt update
sudo apt install build-essential tcl


Redis’in en son stabil sürümünü sunuculara indiriyoruz. 



İndirdiğimiz dosyayı açıyoruz.

cd /tmp
curl -O http://download.redis.io/redis-stable.tar.gz
tar xzvf redis-stable.tar.gz
cd redis-stable


Redis Kurulumu için aşağıdaki komutu çalıştırmamız yeterli;


make
make test
cd src/
make test
make install



sudo nano /etc/sysctl.conf

dosyasını açarak en alt satına aşağıdaki kısmı ekleyebiliriz.

vm.overcommit_memory=1
net.core.somaxconn=65535



sudo nano /etc/rc.local

dosyasını açarak en alt kısmına aşağıdaki kodu ekliyoruz.

if test -f /sys/kernel/mm/transparent_hugepage/enabled; then
  echo never > /sys/kernel/mm/transparent_hugepage/enabled
fi
sysctl -w net.core.somaxconn=65535

exit 0



sudo adduser --system --group --no-create-home redisusr


sudo mkdir -p /etc/redis
sudo cp /home/administrator/redis/redis-stable/redis.conf /etc/redis/redis.conf
sudo cp /home/administrator/redis/redis-stable/sentinel.conf /etc/redis/sentinel.conf

sudo mkdir /var/lib/redis
sudo chown redisusr:redisusr /var/lib/redis
sudo chmod 770 /var/lib/redis



sudo nano /etc/systemd/system/redis-server.service


[Unit]
Description=Redis In-Memory Data Store
After=network.target
[Service]
User=redisusr
Group=redisusr
ExecStart=/usr/local/bin/redis-server /etc/redis/redis.conf
ExecStop=/usr/local/bin/redis-cli shutdown
Restart=always
[Install]
WantedBy=multi-user.target


sudo systemctl start redis-server

sudo systemctl status redis-server



sudo systemctl enable redis-server



redis-cli
set baskent ankara
get baskent



redis 5.0.5




SENTINEL KURULUM  - REDIS MAKINALARINDA YAPILACAK (ipaddress_haproxy,201,202,203)
-----------------------------------------------------------------------------



redis-sentinel


Sentinel için gerekli olan klasör ve yetkileri tanımlıyoruz.

sudo mkdir /var/lib/redis-sentinel
sudo chown redisusr:redisusr /var/lib/redis-sentinel
sudo chmod 770 /var/lib/redis-sentinel
sudo chown redisusr:redisusr /etc/redis/sentinel.conf


Servis olarak çalışması için öncelikle redis-sentinel.service isimli bir servis oluşturarak

sudo nano /etc/systemd/system/redis-sentinel.service

içeriği ekleyelim

[Unit]
Description=Sentinel for Redis
After=network.target
[Service]
User=redisusr
Group=redisusr
ExecStart=/usr/local/bin/redis-sentinel /etc/redis/sentinel.conf
[Install]
WantedBy=multi-user.target


Yukarıdaki şekilde servis dosyasını oluşturup kayıt ettikten sonra aşağıdaki komut ile servisi çalıştırabiliriz.

sudo systemctl start redis-sentinel

Herhangi bir hata ile kaşılaşmadıysak servisin durumunu kontrol edebiliriz.

sudo systemctl status redis-sentinel

Servisin başlangıçta sorunsuz bir şekilde başlaması için servisi etkinleştiriyoruz;

sudo systemctl enable redis-sentinel


MASTER REDIS KONFIGURASYON (ipaddress_sentinel2_redismster) redis 5.0.5
-------------------------------------------------------------------


log dosyasını değiştirmek istiyorsanız öncelikle bir log dosyası oluşturarak gerekli izinleri vermelisiniz.

sudo mkdir -p /var/log/redis/
sudo touch /var/log/redis/redis.log
sudo chown redisusr:redisusr /var/log/redis/redis.log



sudo nano /etc/redis/redis.conf

# Orjinal Hali
bind 127.0.0.1 (10.131.62.82) ==============> BURAYA MAKİNANIN NETWORK IP SI YAZILMALI bizde ipaddress_sentinel2_redismster
# Orjinal Hali
dir /var/lib/redis
# Orjinal Hali
supervised systemd
# Orjinal Hali
logfile /var/log/redis/redis.log

masterauth masterpassword

requirepass masterpassword





MASTER SENTINEL KONFIGURASYONU  (ipaddress_sentinel2_redismster) redis 5.0.5
-------------------------------------------------------------------------

Sentinel ayarları sırasında Cluster yapımıza bir isim vermemiz gerekiyor. Ben burada cluster için REDISCLUSTER ismini kullanacağım



sudo mkdir -p /var/log/redis-sentinel/
sudo touch /var/log/redis-sentinel/redis-sentinel.log
sudo chown redisusr:redisusr /var/log/redis-sentinel/redis-sentinel.log


sudo nano /etc/redis/sentinel.conf

# Orjinal Hali
dir /var/lib/redis-sentinel

# Orjinal Hali
sentinel monitor REDISCLUSTER (10.131.62.82 YANI MASTER REDIS IN IP SI bizde ipaddress_sentinel2_redismster) 6379 2

# Orjinal Hali
dir /var/lib/redis-sentinel

# Orjinal Hali
sentinel down-after-milliseconds REDISCLUSTER 10000

# Orjinal Hali
sentinel parallel-syncs REDISCLUSTER 1

# Orjinal Hali
sentinel failover-timeout REDISCLUSTER 20000

# Orjinal Hali
sentinel leader-epoch REDISCLUSTER 0

# Orjinal Hali
sentinel config-epoch REDISCLUSTER 0


sentinel auth-pass REDISCLUSTER masterpassword


logfile  "/var/log/redis-sentinel/redis-sentinel.log"   ==========> izinleri vermeyi unutma (yukarıda verdin zaten)








Önemli bir not sentinel.conf dosyasının ile satırına sunucun ip adresini yazmamız gerekiyor.
bind 10.131.62.82  =========> bizde ipaddress_sentinel2_redismster

Son olarak seninel.conf a gerekli izinleri veriyoruz ve sentinel i yeniden başlatıyoruz.

sudo chown redisusr:redisusr /etc/redis/sentinel.conf

sudo systemctl restart redis-sentinel




REDIS SLAVE 01 KONFIGURASYONU  (ipaddress_sentinel2_redisslave) redis 5.0.5
-------------------------------------------------------------------------
 
sudo mkdir -p /var/log/redis/
sudo touch /var/log/redis/redis.log
sudo chown redisusr:redisusr /var/log/redis/redis.log

sudo nano /etc/redis/redis.conf
# Orjinal Hali
bind 127.0.0.1 (10.131.44.177) =======================bizde ipaddress_sentinel2_redisslave

# Orjinal Hali
dir /var/lib/redis

# Orjinal Hali
supervised systemd

# Orjinal Hali
slaveof 10.131.62.82 6379 #master redis ip adresi ==============> bizde ipaddress_sentinel2_redismster

# yeni versyonda burası replicaof

masterauth masterpassword


# Orjinal Hali
slave-priority 150

# Orjinal Hali
logfile /var/log/redis/redis.log



REDIS SLAVE 01 SENTINEL KONFIGURASYIONU  (ipaddress_sentinel2_redisslave) redis 5.0.5
---------------------------------------------------------------------

sudo mkdir -p /var/log/redis-sentinel/
sudo touch /var/log/redis-sentinel/redis-sentinel.log
sudo chown redisusr:redisusr /var/log/redis-sentinel/redis-sentinel.log

sudo nano /etc/redis/sentinel.conf


# Orjinal Hali
dir /var/lib/redis-sentinel

# Orjinal Hali
sentinel monitor REDISCLUSTER 10.131.62.82 6379 2  =============> bizde ipaddress_sentinel2_redismster

# Orjinal Hali
dir /var/lib/redis-sentinel

# Orjinal Hali
sentinel down-after-milliseconds REDISCLUSTER 10000

# Orjinal Hali
sentinel parallel-syncs REDISCLUSTER 1

# Orjinal Hali
sentinel failover-timeout REDISCLUSTER 20000

# Orjinal Hali
sentinel leader-epoch REDISCLUSTER 0

# Orjinal Hali
sentinel config-epoch REDISCLUSTER 0


sentinel auth-pass REDISCLUSTER masterpassword


logfile  "/var/log/redis-sentinel/redis-sentinel.log"


Önemli bir not sentinel.conf dosyasının ile satırına sunucun ip adresini yazmamız gerekiyor.
bind 10.131.44.177     ===========================> bu bizde ipaddress_sentinel2_redisslave

Son olarak seninel.conf a gerekli izinleri veriyoruz ve sentinel i yeniden başlatıyoruz.

sudo chown redisusr:redisusr /etc/redis/sentinel.conf
sudo systemctl restart redis-sentinel




SENTINEL 1 MAKINASI IÇIN SENTINEL KONFIGURASYONU (ipaddress_sentinel1) redis 5.0.5
--------------------------------------------------
bu makinadaki redis slave olarak tanımlanmadı. 
yani buradaki sentinel sadece geriye kan 2 makinadaki sentinellerle haberleşmekk için ayağa kaldırılmış olacak.




sudo mkdir -p /var/log/redis-sentinel/
sudo touch /var/log/redis-sentinel/redis-sentinel.log
sudo chown redisusr:redisusr /var/log/redis-sentinel/redis-sentinel.log

sudo nano /etc/redis/sentinel.conf


# Orjinal Hali
dir /var/lib/redis-sentinel

# Orjinal Hali
sentinel monitor REDISCLUSTER 10.131.62.82 6379 2  =============> bizde ipaddress_sentinel2_redismster
# Orjinal Hali
dir /var/lib/redis-sentinel

# Orjinal Hali
sentinel down-after-milliseconds REDISCLUSTER 10000

# Orjinal Hali
sentinel parallel-syncs REDISCLUSTER 1

# Orjinal Hali
sentinel failover-timeout REDISCLUSTER 20000

# Orjinal Hali
sentinel leader-epoch REDISCLUSTER 0

# Orjinal Hali
sentinel config-epoch REDISCLUSTER 0


sentinel auth-pass REDISCLUSTER masterpassword


logfile  "/var/log/redis-sentinel/redis-sentinel.log"


Önemli bir not sentinel.conf dosyasının ile satırına sunucun ip adresini yazmamız gerekiyor.
bind 10.131.44.177     ===========================> bu bizde ipaddress_sentinel1

Son olarak seninel.conf a gerekli izinleri veriyoruz ve sentinel i yeniden başlatıyoruz.

sudo chown redisusr:redisusr /etc/redis/sentinel.conf
sudo systemctl restart redis-sentinel








TUM SUNUCLARDA KONTROL AMAÇLI
=================================
ps -ef | grep redis

iki tane servis çaışıyor olması lazım

sonuç

redisusr 19454     1  0 13:46 ?        00:00:02 /usr/local/bin/redis-server 127.0.0.1:6379
redisusr 19461     1  0 13:46 ?        00:00:03 /usr/local/bin/redis-sentinel 127.0.0.1:26379 [sentinel]
adminis+ 19501  3728  0 14:22 pts/0    00:00:00 grep --color=auto redis





REDIS CLI redis 5.0.5
===================================

redis-cli -p 6379 -h ip-address -a masterpassword 

>MONITOR (sistemi monitor etmeye başlar)
>MEMORY STATS command returns an Array reply about the memory usage of the server.

>client list






SENTINEL CLI 
===================================
redis-cli -p 26739
redis-cli -p 26739 -h ip-address


info                                                # full info


# bizim cluster id miz REDISCLUSTER 

sentinel masters                                    # to get all masters (or if you don't know the cluster name)
sentinel master <your cluster id>                   # get current sentinel master
sentinel get-master-addr-by-name <your cluster id>  # get current sentinel master IP


sentinel slaves <your cluster id>

sentinel failover <your cluster id>


sentinel master REDISCLUSTER  (bütün sentinel makinlarda bu kos çalıştırıldığında master bilgisi dönmeli) 




KAYNAKLAR

https://medium.com/@amila922/redis-sentinel-high-availability-everything-you-need-to-know-from-dev-to-prod-complete-guide-deb198e70ea6

https://medium.com/@bozyol/redis-replication-sentinel-haproxy-kurulum-b%C3%B6l%C3%BCm-1-384a0bcd71e7
https://medium.com/@bozyol/redis-replication-sentinel-haproxy-konfig%C3%BCrasyonlar-b%C3%B6l%C3%BCm-2-5f7ad92a6627
https://medium.com/@bozyol/redis-replication-sentinel-haproxy-kurulum-b%C3%B6l%C3%BCm-3-7abf5cbdc83c

https://jameshfisher.com/2019/01/08/how-to-run-redis-sentinel/

https://www.mustafaaltinkaynak.com/haproxy-kurulumu-ve-yapilandirma.html

https://github.com/falsecz/haredis



HAPROXY KURULUMU ipaddress_haproxy
=========================================

apt update
apt install haproxy

varsion : 1.8.8

nano /etc/haproxy/haproxy.cfg



Aşağıdaki gibi olacak





global
        log /dev/log    local0
        log /dev/log    local1 notice
        chroot /var/lib/haproxy
        stats socket /run/haproxy/admin.sock mode 660 level admin expose-fd listeners
        stats timeout 30s
        user haproxy
        group haproxy
        daemon

        # Default SSL material locations
        ca-base /etc/ssl/certs
        crt-base /etc/ssl/private

        # Default ciphers to use on SSL-enabled listening sockets.
        # For more information, see ciphers(1SSL). This list is from:
        #  https://hynek.me/articles/hardening-your-web-servers-ssl-ciphers/
        # An alternative list with additional directives can be obtained from
        #  https://mozilla.github.io/server-side-tls/ssl-config-generator/?server=haproxy
        ssl-default-bind-ciphers ECDH+AESGCM:DH+AESGCM:ECDH+AES256:DH+AES256:ECDH+AES128:DH+AES:RSA+AESGCM:RSA+AES:!aNULL:!MD5:!DSS
        ssl-default-bind-options no-sslv3

defaults REDISCLUSTER
        log     global
        mode    tcp
        timeout connect 5000
        timeout client  50000
        timeout server  50000

frontend frontend_redis
        bind *:6379 name redis
        default_backend backend_redis
backend backend_redis
            option tcp-check
            tcp-check send AUTH\ masterpassword\r\n
            tcp-check expect string +OK
            tcp-check send info\ replication\r\n
            tcp-check expect string role:master
            tcp-check send QUIT\r\n
            tcp-check expect string +OK
        server R1 ipaddress_sentinel2_redismster:6379 check inter 1s
        server R2 ipaddress_sentinel2_redisslave:6379 check inter 1s

