4 makina var 

bir tanesi proxy (haproxy)
üç tanesi de redis cluste riçin

## REDIS KURULUM - REDIS MAKINALARINDA YAPILACAK (3 makinada)

```
sudo apt update
sudo apt install build-essential tcl
```

Redis’in en son stabil sürümünü sunuculara indiriyoruz.

İndirdiğimiz dosyayı açıyoruz.

```
cd /tmp
curl -O http://download.redis.io/redis-stable.tar.gz
tar xzvf redis-stable.tar.gz
cd redis-stable
```

Redis Kurulumu için aşağıdaki komutu çalıştırmamız yeterli;

```
make
make test
cd src/
make test
make install



sudo nano /etc/sysctl.conf

```

dosyasını açarak en alt satına aşağıdaki kısmı ekleyebiliriz.


vm.overcommit_memory=1

net.core.somaxconn=65535



sudo nano /etc/rc.local


dosyasını açarak en alt kısmına aşağıdaki kodu ekliyoruz.

```
if test -f /sys/kernel/mm/transparent_hugepage/enabled; then
echo never > /sys/kernel/mm/transparent_hugepage/enabled
fi
sysctl -w net.core.somaxconn=65535

exit 0
```

redis için kullanıcı ve grup oluşturuyoruz

```
sudo adduser --system --group --no-create-home redisusr


sudo mkdir -p /etc/redis
sudo cp /home/administrator/redis/redis-stable/redis.conf /etc/redis/redis.conf
sudo cp /home/administrator/redis/redis-stable/sentinel.conf /etc/redis/sentinel.conf

sudo mkdir /var/lib/redis
sudo chown redisusr:redisusr /var/lib/redis
sudo chmod 770 /var/lib/redis
```
servisi oluşturmak için dosya create ediyoruz.

```
sudo nano /etc/systemd/system/redis-server.service
```
aşağıdaki satırları ekliyoruz


```
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
```

sudo systemctl start redis-server

sudo systemctl status redis-server

sudo systemctl enable redis-server

redis-cli

set baskent ankara

get baskent


redis 5.0.5







## CLUSTER ILE HIGH AVAILABILITY KURULUM




HAProxy (load balancer)
Redis Master 1
Redis Slave 3
Redis Master 2
Redis Slave 1
Redis Master 3
Redis Slave 2
1
1
1
Client
haproxy_ip
redis1_ip
redis2_ip
redis3_ip



kaynak : http://codeflex.co/configuring-redis-cluster-on-linux/

https://www.javacodegeeks.com/2015/09/redis-clustering.html

https://www.digitalocean.com/community/tutorials/how-to-configure-a-redis-cluster-on-ubuntu-14-04



__Öncelikle her redis makina üzeinde aşağıdaki  configurasyonlar yapılır__



sudo nano /etc/redis/redis.conf

ve aşağıdaki ayarla yapılır.

```
port 7000
bind hangi_makinadyasak_onun_ip_si
 
cluster-enabled yes
cluster-config-file nodes.conf
cluster-node-timeout 5000
cluster-slave-validity-factor 1
 
logfile redis.log
loglevel notice
slowlog-log-slower-than 10000
slowlog-max-len 64
latency-monitor-threshold 100
 
maxmemory 64mb
maxmemory-policy volatile-ttl
slave-read-only yes
 
save 900 1
save 300 10
save 60 10000
stop-writes-on-bgsave-error yes
rdbchecksum yes
dbfilename dump.rdb
 
appendonly yes

masterauth password_gelecek 

```



Buraya kadar yaptıklarımız 3 adet master redis i çalıştırmaktı. Ayrıca bu 3 master için slave tanımlamaları yapmak gerekecek.

aslında yukarıda redis.config içinde yaptıklarımızı ayrı bir redis7001 klasörü tıalayarak içine koyup 7001 portu üzerinden redis i çalıştırmak olacak

en üstte ilk redis-server ı kurumunu yapmıştık aynı mantıkla 7001 için kurulum  yapıyoruz


```
sudo mkdir -p /etc/redis7001
sudo cp  /etc/redis/redis.conf  /etc/redis7001/redis.conf


sudo mkdir /var/lib/redis7001
sudo chown redisusr:redisusr /var/lib/redis7001
sudo chmod 770 /var/lib/redis7001
```


daha sonra log için ayrı bir klasör açılır.


```
sudo mkdir -p /var/log/redis7001/
sudo touch /var/log/redis7001/redis.log
sudo chown redisusr:redisusr /var/log/redis7001/redis.log

```




```
sudo nano /etc/systemd/system/redis7001-server.service

[Unit]

Description=Redis7001 In-Memory Data Store

After=network.target

[Service]

User=redisusr

Group=redisusr

ExecStart=/usr/local/bin/redis-server /etc/redis7001/redis.conf

ExecStop=/usr/local/bin/redis-cli shutdown

Restart=always

[Install]

WantedBy=multi-user.target

```



Daha sonra config  dosyası açılıp aşağıdaki ayarlar değiştirilir



sudo nano /etc/redis7001/redis.conf

```

pidfile /var/run/redis_7001.pid

port değiştirilir 7000, 7001 yapılır

logfile "/var/log/redis7001/redis.log"

dbfilename dump7001.rdb

dir /var/lib/redis7001

appendfilename "appendonly7001.aof"

```






sudo systemctl start redis7001-server

sudo systemctl status redis7001-server

sudo systemctl enable redis7001-server



daha sonra mkinların cluster ı tanımasını sağlıyoruz. herhangi bir redis te olur ama biz 10.0.43.201 ip li makindan çalıştırdık.



```

redis-cli -h redis1_ip -a mymasterpass -p 7000 CLUSTER MEET redis1_ip 7001
redis-cli -h  redis1_ip  -a mymasterpass -p 7000 CLUSTER MEET redis2_ip 7000
redis-cli -h redis1_ip -a mymasterpass -p 7000 CLUSTER MEET redis2_ip 7001
redis-cli -h redis1_ip -a mymasterpass -p 7000 CLUSTER MEET redis3_ip 7000
redis-cli -h redis1_ip -a mymasterpass -p 7000 CLUSTER MEET redis3_ip 7001


```

daha sonra makinalardan herhangi birinde alttaki komutlar çalıştırılır


```
for i in {0..5400}; do redis-cli  -a masterpass_gelecek -h 10.0.43.201 -p 7000 CLUSTER ADDSLOTS $i; done
for i in {5401..10800}; do redis-cli -a masterpass_gelecek -h 10.0.43.202 -p 7000 CLUSTER ADDSLOTS $i; done
for i in {10801..16383}; do redis-cli -a masterpass_gelecek -h 10.0.43.203 -p 7000 CLUSTER ADDSLOTS $i; done
```


daha sonra alttaki komut ile kontrol edilir. her biri için ayrı ayrı çalıştırlır.


redis-cli -a masterpass_gelecek -h 10.0.43.201 -p 7000 CLUSTER NODES



şöyle bir çıktı üretir. cluster kuruldukran sonra burası 6 satır oalcak

```
49537862138131140cd0eb365b8981e38c694581 :7000@17000 myself,master - 0 0 0 connected 0-5400

f7b861f2a50a8ee97521447812f2c5d7068281ee :7000@17000 myself,master - 0 0 0 connected 5401-10800

b11a601befdb4b95f875f6dfebd43905c64ca123 :7000@17000 myself,master - 0 0 0 connected 10801-16383
```








Now when all the 16384 hash slots are allocated and all 6 instances are running we need to tell them to meet each other. Thus every node will “know” everyone.

alttaki komutu 10.0.43.201 ip li sunucuda çalıştırıyoruz.



Now, when all nodes are connected into cluster we need set replications. In other words we need to define what nodes are masters and what nodes are their slaves:





203 ip li makinanın 7001 portu 202 makşnasının slave i olduğuna gore 

redis-cli -a mymasterpass -h 10.0.43.203 -p 7001 CLUSTER REPLICATE f7b861f2a50a8ee97521447812f2c5d7068281ee (buradaki guid aslında 10.0.43.201 nolu makinanın bilgisi)

10.0.43.201 nolu makinanın guiid bilgisini almak için komut

redis-cli -a mymasterpass -h 10.0.43.202 -p 7000 CLUSTER NODES



202 makinasının 7001 portu 201 nakinasının 7000 porunun slave i olduğuna göre

redis-cli -a mymasterpass -h 10.0.43.202 -p 7001 CLUSTER REPLICATE 49537862138131140cd0eb365b8981e38c694581 (buradaki guid aslında 10.0.43.203 nolu makinanın bilgisi)

10.0.43.203 nolu makinanın guiid bilgisini almak için komut

redis-cli -a mymasterpass -h 10.0.43.201 -p 7000 CLUSTER NODES



201 makinasının 7001 portu  203 makinaının 7000 portunun slave i

redis-cli -a mymasterpass -h 10.0.43.201 -p 7001 CLUSTER REPLICATE b11a601befdb4b95f875f6dfebd43905c64ca123 (buradaki guid aslında 10.0.43.202 nolu makinanın bilgisi)

10.0.43.202 nolu makinanın guiid bilgisini almak için komut

redis-cli -a mymasterpass -h 10.0.43.203 -p 7000 CLUSTER NODES



redis-cli -h 10.20.21.44 -p 7000 CLUSTER NODES



sistemi test ekmek amacıyla sona -c parametresi eklenmelidir.

redis-cli -h 10.20.21.44 -p 7000 -a mymasterpass -c



artık tüm tüm port ve ip ler hem yazabilir hem de  okuyabilr.


## HAPROXY



bunun içinaşağıdaki komutları kullanılır

sudo nano /etc/haproxy/haproxy.cfg

akttaki ayarlar dosyada yapılır.

aşağıda da görüleceği üzere haproxy istatisleri de incenebilir.

ileride problem durumunda mail atma ayarları da yapılacak



```

global
log /dev/log local0
log /dev/log local1 notice
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
# https://hynek.me/articles/hardening-your-web-servers-ssl-ciphers/
# An alternative list with additional directives can be obtained from
# https://mozilla.github.io/server-side-tls/ssl-config-generator/?server=haproxy
ssl-default-bind-ciphers ECDH+AESGCM:DH+AESGCM:ECDH+AES256:DH+AES256:ECDH+AES128:DH+AES:RSA+AESGCM:RSA+AES:!aNULL:!MD5:!DSS
ssl-default-bind-options no-sslv3

defaults KIZILAYREDISCLUSTER
log global
mode tcp
timeout connect 5000
timeout client 50000
timeout server 50000

frontend stats
bind *:8404
stats enable
stats uri /stats
stats refresh 10s
stats admin if { src 127.0.0.1 }

frontend frontend_redis
bind *:6379 name redis
default_backend backend_redis
backend backend_redis
option tcp-check
tcp-check send AUTH\ mymasterpass\r\n
tcp-check expect string +OK
tcp-check send PING\r\n
tcp-check expect string +PONG
tcp-check send QUIT\r\n

tcp-check expect string +OK
server R1 10.0.43.201:7000 check inter 1s
server R2 10.0.43.201:7001 check inter 1s
server R3 10.0.43.202:7000 check inter 1s
server R4 10.0.43.202:7001 check inter 1s
server R5 10.0.43.203:7000 check inter 1s
server R6 10.0.43.203:7001 check inter 1s


```



sistemi test ekmek amacıyla sona -c parametresi eklenmelidir.

redis-cli -h redis1_ip (yada en doğrusu proxy ip si) -p 7000 (proxy ise onun portu gelecek) -a sifre -c




