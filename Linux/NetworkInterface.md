### Ubuntuda yeni interface/device tanımlama veya değiştirme

- [Kaynak 1](https://vitux.com/ubuntu-network-configuration/?__cf_chl_jschl_tk__=ab2d271528f9597f8acbca778eb5c13aa219deb6-1588001835-0-AQ129IaZUde0CuugHTXMcXRkVI4oiA4sPsB8I0ljmUGPPVQJ6dMdyYUelJGmlD17fK3J1D_posoUateu2orDvrFtDQHAscFrX7_zj0uwNUHr-8su0366Kl5DE_IUJj_eSpSUKSQs1gCfCcpZK-iQJPPKxOIlhVUVXss4K8xCgrzSbB8mRnE-nIZ4lm8o_Ywk5m9J-kBgEEnr8NihmG-yEO753vCqUJgHym9q6MP6PeinEMNKpgq9n2qrSnyVziRtVx6lEbO9q7d6QOH1bUa5mhjMfPatXEFewjA-RLpbwWDquhoGLqDbsZpMg1aNRPIZROo6vD-1UPVHewn3VmV4OTn97LRsYmHLgc8Qg18aBKaEUzZZYsCnyF6ET0eHxkPyEg)

- [Kaynak 2](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/5/html/installation_guide/s1-s390info-addnetdevice)

  
Network Address Translation (NAT) converts local ip to global ip. Routing is the process to route the data packet from one network to the other.

### Network Konfigürasyonu 

- [kaynak](https://vitux.com/ubuntu-network-configuration/?__cf_chl_jschl_tk__=ab2d271528f9597f8acbca778eb5c13aa219deb6-1588001835-0-AQ129IaZUde0CuugHTXMcXRkVI4oiA4sPsB8I0ljmUGPPVQJ6dMdyYUelJGmlD17fK3J1D_posoUateu2orDvrFtDQHAscFrX7_zj0uwNUHr-8su0366Kl5DE_IUJj_eSpSUKSQs1gCfCcpZK-iQJPPKxOIlhVUVXss4K8xCgrzSbB8mRnE-nIZ4lm8o_Ywk5m9J-kBgEEnr8NihmG-yEO753vCqUJgHym9q6MP6PeinEMNKpgq9n2qrSnyVziRtVx6lEbO9q7d6QOH1bUa5mhjMfPatXEFewjA-RLpbwWDquhoGLqDbsZpMg1aNRPIZROo6vD-1UPVHewn3VmV4OTn97LRsYmHLgc8Qg18aBKaEUzZZYsCnyF6ET0eHxkPyEg)

bu yolda 

```
sudo nano /etc/network/interfaces
```


komutu ile 

örneğin alttaki satırları ekleyerek yeni bir ethernet tanımlanabilir

```
auto eth1
  iface eth1 inet static
  address 192.168.72.8
  netmask 255.255.255.0
  gateway 192.168.72.1
  dns-nameservers 8.8.8.8 4.4.2.2
```
ubuntu 18.04 ile birlikte Ubuntu Netplan a geçiş yaptı burada artık netwotk özelliklerini conf (yaml) dosyası ile configure edebiliyoruz.

bu şekilde configurasyon yapmak için öcelikle mac adresine ihtiyacımız olacak.

```
$ lshw -class network

. . .
*-network:1
    description: Ethernet controller
    . . .
    *-virtio1 DISABLED
        description: Ethernet interface
        physical id: 0
        bus info: virtio@1
        logical name: ens4
        serial: ex:am:pl:e3:65:13
. . .

```

seria yazan yer mac adresimiz.

daha sonra /etc/netplan/50-cloud-init.yaml dosyasını editleyerek alttaki satıalrı ekliyoruz.

```
eth1:
    addresses:
    - 198.51.100.0/16
    match:
        macaddress: ex:am:pl:e3:65:13
    set-name: eth1
```
daha sonra alttaki komutla appliy ediyoruz

```
sudo netplan apply --debug
```



şu sayfaya kesin bak

https://netplan.io/examples









### identify physical network device by interface name in linux

I have multiple USB to ethernet devices which are plugged to the same pc.

Is there a way to identify which one is mapped to which eth* network interface via usb port/etc ?

I have tried looking in lsusb and /proc, but haven't found anything useful.

```
$ ls -la /sys/class/net
```
veya

```
grep -i eth /var/log/udev
```

- https://jvns.ca/blog/2017/09/03/network-interfaces/


Çok detaylı bir blok

- https://developers.redhat.com/blog/2018/10/22/introduction-to-linux-interfaces-for-virtual-networking/

- https://vincent.bernat.ch/en/blog/2017-vxlan-linux
- https://vincent.bernat.ch/en/blog/2012-multicast-vxlan


bütün bu alttaki network tiplerini IP komutu ile yapmak mümkün. ancak örneğin bridge için brctl komutuda var. bu komutun detaylı kulanımı için alttaki linke de bakılabilir

http://www.debian.org.tr/Bridge-Utilities

https://www.thegeekstuff.com/2017/06/brctl-bridge/

  - Bridge
  - Bonded interface
  - Team device
  - VLAN (Virtual LAN) 
  - VXLAN (Virtual eXtensible Local Area Network) (overlay network)
  - MACVLAN
  - IPVLAN
  - MACVTAP/IPVTAP
  - MACsec (Media Access Control Security)
  - VETH (Virtual Ethernet)
  - VCAN (Virtual CAN)
  - VXCAN (Virtual CAN tunnel)
  - IPOIB (IP-over-InfiniBand)
  - NLMON (NetLink MONitor)
  - Dummy interface
  - IFB (Intermediate Functional Block)
  - netdevsim


iki subnet ibirbiriyle habrleştirmek için routing yapılır.


farklı routin teknikleri
```
ip route add {NETWORK/MASK} via {GATEWAYIP}
ip route add {NETWORK/MASK} dev {DEVICE}
ip route add default {NETWORK/MASK} dev {DEVICE}
ip route add default {NETWORK/MASK} via {GATEWAYIP}
```


- https://www.oreilly.com/library/view/linux-network-administrators/1565924002/ch02s04.html
- https://www.cyberciti.biz/faq/ip-route-add-network-command-for-linux-explained/
- https://www.cyberciti.biz/faq/linux-route-add/
- https://unix.stackexchange.com/questions/311752/routing-between-multiple-subnets
- https://superuser.com/questions/1230318/routing-network-traffic-between-2-subnets-using-a-raspberry-pi
- https://superuser.com/questions/1007200/connect-two-subnets-on-linux
- https://serverfault.com/questions/593448/routing-between-two-subnets-using-a-linux-box-with-two-nics
- https://askubuntu.com/questions/726664/connect-two-subnets-so-that-they-can-see-each-other
- https://www.linux.com/training-tutorials/linux-routing-subnets-tips-and-tricks/
- https://opensource.com/business/16/8/introduction-linux-network-routing
- 


Network Address Translation (NAT) converts local ip to global ip. Routing is the process to route the data packet from one network to the other.