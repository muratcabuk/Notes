### Linux Namespace'lerine Giriş 


Containerlar aslında birbirinden iyi isole edilmiş processlerdir diyebiliriz. Ortal kernek kullanmalarına rağmen birbirlierini (!) görmezler, hatta kendilerini çalışan yegane işletim ssitemi olarka görürler. 

peki bunu nasıl yaparlar? yani aslında Linux'da container diye bir kavram bulunmamasın arağmen bu izolasyon aynı kernel kullarnılarak nasıl sağlanabilmektedir?

Konu ileride daha da detaylanacak ancak containmer özelinde inceleyecek olursak Containerları mümkün kılan 2 yapıdan söz etmek mümkündür.

1. Namespacing: Containerların gördüklerini kısıtlamak. yani örneğin container sadece kendi içinde çalışan proccessleri, network yapılarını, kullanıcıları, vb şeyleri görebilmesini sağlamak.
 - chroot (çroot diye okunur): container a bir folder veriyor ve senin root un burasıdır diyor. yani bu klasörün dışına üstüne çıkamazsın diyor.
 

**root and chroot**

In a Unix-like OS, root directory(/) is the top directory. root file system sits on the same disk partition where root directory is located. And it is on top of this root file system that all other file systems are mounted. All file system entries branch out of this root. This is the system’s actual root. 
 
 
 - unshare: normalde linux'da (yada diğer işletim sistemlerinde de) çalışan processler birbirini görebilir. Bu teknoloji sayesinde container'ın processlerini unshare yapabilmek mümkün oluyor. Bu sadece processlerle alakalı değil tabiiki, network, cpu, file system vb kaynkları soyutlamak mümkün hale geliyor. bir program unshre olarak çalıştırıldığında çevrsinde çalışanları göremiyor. 
 
 Mesela mount, PID, network, cgroup, user,  gibi namespace ler mevcut.
 
 
2. Resource Control: Normal şartlarda linux'da çalışan proccessler'in ne kadar kaynak (örneğin CPU, memory, devices, pids (bir process kaç alt proccess ayağa kaldırabilir.)) tüketeceğine kara veremezdik. 
 - cgroups (control group): Ancak bu teknoloji le artık bu mümkün hale geliyor. Kernel üzerinde proccesslerin kaynkalrını sınırlandırabiliyoruz.

Aşağıda bu iki başlıkta yer alan konular hakkında uygulamalr yer alacaktır.

### Namespaces

- Mount (mnt)
- Process ID (pid)
- Network (net)
- Interprocess Communication (ipc)
- UTS
- User ID (user)
- Control group (cgroup) Namespace
- Time Namespace
- Proposed namespaces
  - syslog namespace



 
### Network Namespace kullanımı

**network dosyaları**

- /etc/sysconfig/network dosyası
- /etc/sysconfig/network-scripts dizini
- /etc/hosts
- /etc/resolv.conf
- /etc/nsswitch.conf
- /etc/services


**kaynaklar**

- https://enveraltin.com/blog/iptables.html

- https://www.youtube.com/watch?v=_WgUwUf1d34&t=398s

- https://www.computerhope.com/unix/ip.htm
- https://developers.redhat.com/blog/2018/10/22/introduction-to-linux-interfaces-for-virtual-networking/
- https://blog.scottlowe.org/2013/09/04/introducing-linux-network-namespaces/
- https://itnext.io/create-your-own-network-namespace-90aaebc745d
- https://blogs.igalia.com/dpino/2016/04/10/network-namespaces/
- https://diego.assencio.com/?index=d71346b8737ee449bb09496784c9b344
- https://unix.stackexchange.com/questions/546235/i-can-ping-across-namespaces-but-not-connect-with-tcp
- https://www.cyberciti.biz/faq/ip-route-add-network-command-for-linux-explained/
- https://www.cyberciti.biz/faq/linux-ip-command-examples-usage-syntax/


_ip link_ komutunu çalıştıracak olursak root namespace üzerinde işlem yapıyor oluruz. Aynı şekilde _ip a_ dediğimizde de root namespace üzerindeki device ları görüyor oluruz. 




Networkname space oluşturmak için alttaki mıtı kullanıyoruz.

```
sudo ip netns add mynetwork

```

oluşturduğumuz namespace ler /var/run/netns path i altında oluşur.

namespace ı kontrol ediyoruz

```
ls /var/run/netns 
```
oluşturduğumuz namespace altındaki interface leri kontrol edelim

```
sudo ip netns exec mynetwork ip a

# Sonuç

1: lo: <LOOPBACK> mtu 65536 qdisc noop state DOWN group default qlen 1000
    link/loopback 00:00:00:00:00:00 brd 00:00:00:00:00:00

```
görüldüğü üzere sadece bir interface var ve o da loopback. 

bunu UP yapmak için alttaki komutu kullanıyoruz.

```
sudo ip netns exec mynetwork ip link set lo up

# Sonuç

1: lo: <LOOPBACK,UP,LOWER_UP> mtu 65536 qdisc noqueue state UNKNOWN group default qlen 1000
    link/loopback 00:00:00:00:00:00 brd 00:00:00:00:00:00
    inet 127.0.0.1/8 scope host lo
       valid_lft forever preferred_lft forever
    inet6 ::1/128 scope host 
       valid_lft forever preferred_lft forever

```
artık UP durumuna geçmiş oldu.


Şimdi iki virtual ethernet çifti ceate ediyoruz. 
```
sudo ip link add inside-mynetns type veth peer name outside-mynetns
```
bu komut ile iki eth kartı tanımlamış olduk.

```
ip a

# sonuç

3: outside-mynetns@inside-mynetns: <BROADCAST,MULTICAST,M-DOWN> mtu 1500 qdisc noop state DOWN group default qlen 1000
    link/ether 2e:da:88:06:34:71 brd ff:ff:ff:ff:ff:ff
4: inside-mynetns@outside-mynetns: <BROADCAST,MULTICAST,M-DOWN> mtu 1500 qdisc noop state DOWN group default qlen 1000
    link/ether 7a:ac:b6:6c:91:8c brd ff:ff:ff:ff:ff:ff

```

şimdi oluşturduğumuz outside_mynetns kartını meynetwork namespace ine taşıyoruz.



```
sudo ip link set inside-mynetns netns mynetwork
```


mynetwork ns i altındaki device ları listeleyelim

```
sudo ip netns exec mynetwork ip link list

# sonuç

1: lo: <LOOPBACK,UP,LOWER_UP> mtu 65536 qdisc noqueue state UNKNOWN mode DEFAULT group default qlen 1000
    link/loopback 00:00:00:00:00:00 brd 00:00:00:00:00:00
4: inside-mynetns@if3: <BROADCAST,MULTICAST> mtu 1500 qdisc noop state DOWN mode DEFAULT group default qlen 1000
    link/ether 7a:ac:b6:6c:91:8c brd ff:ff:ff:ff:ff:ff link-netnsid 0

```

iki kartımıza da ip ataması yapıyoruz.

```

sudo ip addr add 10.10.10.1/24 dev outside-mynetns

sudo ip netns exec mynetwork ip addr add 10.20.10.1/24 dev inside-mynetns

```

şimdi iki eth kartımızı da UP durumuna getiriyoruz.

```
sudo ip link set outside-mynetns up
sudo ip netns exec mynetwork ip link set inside-mynetns up
```

şimdi namespace altındaki device ın internete erişip erişemediğini kontrol edelim.

```
sudo ip netns exec mynetwork ping 8.8.8.8
```
internete çıkamadığını görebiliriz.

çünki internete çıkabilcek bir yee bağlı değil şuanda.







### PID Namespace'i




### Mount Namespace'i
### UTS namespace'i
### User Namespace'i
### CGroup - Kontrol Grupları 
