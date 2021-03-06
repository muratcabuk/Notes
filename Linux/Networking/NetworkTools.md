### Network Manager

Libudev ve diğer bazı linux kernel interface leri üzerinde çalışan high-level network konfigürasyon aracıdır.

Çoğunlukla Redhat desteği ile devam etmektedir.

Nmcli kullanılarak yönetilebilir.

ayrıca centos/fedora/redhat ve debian tabanlı distrbution ların arkada tarafta kullanıkları persitant network kanfigürasyon aracıdır.


![networkmanager.png](files/networkmanager.png)


- https://wiki.archlinux.org/index.php/NetworkManager
- https://wiki.debian.org/NetworkManager
- https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/7/html/networking_guide/getting_started_with_networkmanager

### /etc/sysconfig/network-scripts/

Redhat ve Centos da network konfigürasyonu için kullanılan sistemdir. Aslında Network Manager kullanılrak yönetilir. Ubuntu tarafındaki netplan a benzer. Bu da arka tarafta network manager kullanmaktadır.


### netplan

Canonical firmasının ubuntu için geliştirdiği 
- **Network Manager** veya networkd kullanarak 
- network configürasyonunu bu araçlardan soyutlayarak 
- yaml tabanlı

bir network konfigürasyon aracısır.


![netplan.png](files/netplan.png)


### brctl

bridge yönetimi için  kullanılır ancak bunun için artık ip komutu kullanılır.

- https://www.thegeekstuff.com/2017/06/brctl-bridge/

### Open VSwitch


- https://medium.com/devopsturkiye/open-vswitch-nedir-nas%C4%B1l-kullan%C4%B1l%C4%B1r-afe00241a56f (docker üzerinden overlay network oluşturma örneği var bakılmalı)


Open vSwitch is a production quality, multilayer virtual switch licensed under the open source Apache 2.0 license.  It is designed to enable massive network automation through programmatic extension, while still supporting standard management interfaces and protocols (e.g. NetFlow, sFlow, IPFIX, RSPAN, CLI, LACP, 802.1ag).  In addition, it is designed to support distribution across multiple physical servers similar to VMware's vNetwork distributed vswitch or Cisco's Nexus 1000V. See full feature list here






- Visibility into inter-VM communication via NetFlow, sFlow(R), IPFIX, SPAN, RSPAN, and GRE-tunneled mirrors
- LACP (IEEE 802.1AX-2008)
- Standard 802.1Q VLAN model with trunking
- Multicast snooping
- IETF Auto-Attach SPBM and rudimentary required LLDP support
- BFD and 802.1ag link monitoring
- STP (IEEE 802.1D-1998) and RSTP (IEEE 802.1D-2004)
- Fine-grained QoS control
- Support for HFSC qdisc
- Per VM interface traffic policing
- NIC bonding with source-MAC load balancing, active backup, and L4 hashing
- OpenFlow protocol support (including many extensions for virtualization)
- IPv6 support
- Multiple tunneling protocols (GRE, VXLAN, STT, and Geneve, with IPsec support)
- Remote configuration protocol with C and Python bindings
- Kernel and user-space forwarding engine options
- Multi-table forwarding pipeline with flow-caching engine
- Forwarding layer abstraction to ease porting to new software and hardware platforms


Q: Why would I use Open vSwitch instead of the Linux bridge?

A: Open vSwitch is specially designed to make it easier to manage VM network configuration and monitor state spread across many physical hosts in dynamic virtualized environments. Refer to Why Open vSwitch? for a more detailed description of how Open vSwitch relates to the Linux Bridge.

In some scenarios when you have to transfer data from one VM to another, Open vSwitch forwards packages in-kernel instead of creating copies of the package that transverse interfaces.

Open vSwitch works with the concept of datapaths. It's basically a rule-based system that creates paths to forward packages, and the tables of those paths are stored in memory to achieve best performance. When a specific packet uses this datapath, it will be processed by the kernel avoiding the overheads of going to a Physical NIC and return to the virtual host. Generally, will be slower if the virtual Switch have to deliver something that is not inside the host.

**şu şekilde düşünenlerde var**


But let’s remember that truism: simple wins over complicated. Having been through the convolutions required by OVS, large scale production environments are now increasingly moving over to Linux Bridge. OVS just comes with too much complexity and renders issues in the network domain a royal pain in the rear to manage. Certainly, there have been changes to Linux Bridge that have also helped close the gap between projects using OVS and Linux Bridge, including the addition of VXLAN support as a tunnel technology. But in the greater scheme, it’s the simplicity of Linux Bridge that wins the day.




https://docs.openvswitch.org/en/latest/faq/general/


### ip / iproute2

- https://codilime.com/how-to-drop-a-packet-in-linux-in-more-ways-than-one/ (keinlikle okunmalı)


Ifcongig yerine artık bu kullanılmaktadır.

iproute2 ile linux e gelen ve ipfilter kernel modülü üzerinebbir interface olarak çalışan araç. aşağıda adı geçen birçok uygulamanın yerine gelmiş bir araç.

araç için de birçok uygulama geliyor. Örneğin ip komutu iproute2 ile gelmektedir.



- https://baturin.org/docs/iproute2/ (çok iyi hazırlanmış bir sayfa)


**Syntax**

- ip OBJECT COMMAND
- ip \[options\] OBJECT COMMAND
- ip OBJECT help

OBJECTS can be any one of the following and may be written in full or abbreviated form:
|Object|Abbreviated form|Purpose|
|------|----------------|-------|
|link|l|Network device.|
|address|a addr|Protocol (IP or IPv6) address on a device.|
|addrlabel|addrl|Label configuration for protocol address selection.|
|neighbour|n neigh|ARP or NDISC cache entry.|
|route|r|Routing table entry.|
|rule|ru|Rule in routing policy database.|
|maddress|m maddr|Multicast address.|
|mroute|mr|Multicast routing cache entry.|
|tunnel|t|Tunnel over IP.|
|xfrm|x|Framework for IPsec protocol.|





### route

Statik route tanımlamak ve routing table ı görüntülemek için kullanılır.

### arp

Arp table görüntüleme ve değiştirme için kullanılr.

### ifconfig

Network interfacelerini konfigüre etme ve  ip ayarlarını değiştirmek için kullanılır.

Ayrıca interfaceleri start stop yapabilir.

### networkd (systemd-networkd)

Systemd-networkd is a system daemon that manages network configurations. It detects and configures network devices as they appear; it can also create virtual network devices. This service can be especially useful to set up complex network configurations for a container managed by systemd-nspawn or for virtual machines. It also works fine on simple connections.

- https://wiki.archlinux.org/index.php/Systemd-networkd

### iptables

iptables sunucuya gelen, sunucudan çıkan ve sunucunun yönlendirdiği paketler için birer zincir tanımlamıştır. Bu zincirler sırasıyla INPUT, OUTPUT ve FORWARD olarak adlandırılır. iptables kullanıcının bu zincirlere kurallar eklemesine ve incelenen paket bu kurallardan birine uyduğunda belirli aksiyonların alınmasına olanak tanır. Paket bir zincirde eşleştiği ilk kural ile o zinciri terkeder. Paket eşleşme olduğunda ya kullanıcı tarafından tanımlanan başka bir zincire atlar ya da DROP veya ACCEPT edilir.

- https://medium.com/@gokhansengun/iptables-nedir-nas%C4%B1l-ve-nerelerde-kullan%C4%B1l%C4%B1r-1-7c081a9512c0
- https://medium.com/@gokhansengun/iptables-nedir-nas%C4%B1l-ve-nerelerde-kullan%C4%B1l%C4%B1r-2-5178c5560bb

- https://blog.muvhost.com/iptables-nedir-nasil-kullanilir/


aslında firewall la aynı işi yapar.

ufw ve iptables ikiside netfilter üzerine kuruludur.


![firewalld-structure.png](files/firewalld-structure.png)



### Tun/Tap

buradaki tap ı fiziksel tap cihazları ile karıştırmamamk lazım.


amac user space de çalışan bir uygulamayı (linux de herşey bir dosyadır prensibinden yola çıkarak) tabiri caizse tab dosyasıyla muhatap etmektir. Böylece o dosyaya azılacak veriyi direk olarak linux kernela'a göndermeyi hedefler. 

![Tun-tap-osilayers-diagram.png](files/Tun-tap-osilayers-diagram.png)


A TUN interface is a virtual IP Point-to-Point interface and a TAP interface is a virtual Ethernet interface. That means the user program can only read/write IP packets from/to a TUN interface and Ethernet frames from/to a TAP interface.


![tun-use-case.png](files/tun-use-case.png)

TUN/TAP provides packet reception and transmission for user space programs. It can be seen as a simple Point-to-Point or Ethernet device, which, instead of receiving packets from physical media, receives them from user space program and instead of sending packets via physical media writes them to the user space program.

- https://www.fir3net.com/Networking/Terms-and-Concepts/tun-tap-and-veth-virtual-networking-devices-explained.html


AP network interfaces are designed for this. They represent virtual Ethernet devices. A TAP network interface is managed by some user process:

- when an Ethernet frame is sent to the network interface, the user process receives this Ethernet frame;
- the user process can send Ethernet frames to this network interface.

This is often used for:

- VPNs (such as OpenVPN): When an Ethernet frame is sent to the TAP network interface, the VPN process receives it and forwards it in a tunnel. Conversely when the user process receives an Ethernet frame from the tunnel it forwards them to the TAP interface;
- vitual machines: When an Ethernet frame is sent to the TAP interface, the hypervisor/emulator receives it and forwards it to the VM. Conversely when the VM sends a packet to its interface, the hypervisor/emulator forwards it to the TAP interface.





### Tcpdump

TCP paketlerini dump alarak analiz ve monitor etme imkanı sağlar. 

### Netstat

TCP paketlerini mnitor etmeye yarar.

### NetCat

https://tr.wikipedia.org/wiki/Netcat

Netcat, ağı okuyan ve TCP veya UDP iletişim kurallarını kullanarak ağ bağlantılarını yazan bir hizmetidir. Netcat, diğer program ve betikler tarafından içtenlikle veya kolayca kullanılabilen güvenilir "arkauç" aygıtı olması için tasarlandı. Aynı zamanda, gelecekte ihtiyaç duyalacak hemen hemen her türlü bağlantıyı üretebilen, birçok niteliğe sahip, ağ hata ayıklama ve araştırma aracıdır. 

port taramsı da yapabilir ancak en iyisi nmap aracıdır.

- https://sibertehdit.com/netcat-kullanimi-ve-uygulamalari/
- https://medium.com/@uurats/bind-shell-nedir-e927e0c0d95e
- https://veriteknik.gitbook.io/linux-yonetimi/gelismis-network-komutlari/netcat
- https://www.kadinyazilimci.com/netcat-i/
- https://www.kadinyazilimci.com/netcat-ii/



**reverse shell vs shell bind** 
- https://www.siberali.com/remote-code-execute-icin-hangi-reverse-shelli-kullanabiliriz/
- https://www.siberportal.org/red-team/penetration-testing/sizma-testlerinde-ters-baglanti-yontemleri/

dosya gönderme işlerimi dahi yapılabilir.

**netcat ile website yayını**
- https://www.digitalocean.com/community/tutorials/how-to-use-netcat-to-establish-and-test-tcp-and-udp-connections-on-a-vps

### nmap

port tarama aracıdır

https://akademikbulten.com/nmap-ile-internetin-ufak-bir-kismini-taramak/

### traceroot


Traceroute programı, TCP/IP ağlarında kaynak bilgisayardan hedef bilgisayara giden paketlerin hangi rotayı takip ettiğinin anlaşılması ve bu rotalardan geçerken meydana gelen gecikmelerin görülebilmesini sağlayan bir ağ aracıdır.


https://visualtraceroute.net/ görsel version

### nslookup - dig

Alan adı ve IP adresi eşleşmesi bulmak veya DNS kayıtlarını sorgulamak/incelemek için kullanılabilen bir komut satırı aracıdır. 

```
nslookup -query=mx google.com

nslookup -query=ns google.com

```

- https://veriteknik.gitbook.io/linux-yonetimi/gelismis-network-komutlari/dig
- https://veriteknik.gitbook.io/linux-yonetimi/gelismis-network-komutlari/nslookup

### ipref - speedtest-cli

network hız testi için kullanılır

https://veriteknik.gitbook.io/linux-yonetimi/gelismis-network-komutlari/bantgenisligi-oelcuemue


### BAzı Faydalı Bilgiler

```
1- Names incorporating Firmware/BIOS provided index numbers for on-board devices (example: eno1)
2- Names incorporating Firmware/BIOS provided PCI Express hotplug slot index numbers (example: ens1)
3- Names incorporating physical/geographical location of the connector of the hardware (example: enp2s0)
4- Names incorporating the interfaces's MAC address (example: enx78e7d1ea46da)
5- Classic, unpredictable kernel-native ethX naming (example: eth0)



enp0s10:
| | |
v | |
en| |   --> ethernet
  v |
  p0|   --> bus number (0)
    v
    s10 --> slot number (10)







```








### Resources

- https://developers.redhat.com/blog/2018/10/22/introduction-to-linux-interfaces-for-virtual-networking/
- https://www.cyberciti.biz/faq/linux-ip-command-examples-usage-syntax/
- https://aboutnetworks.net/linux-networking-part-1/
- https://aboutnetworks.net/linux-networking-part-2/
- https://aboutnetworks.net/linux-networking-part-3
- https://aboutnetworks.net/linux-networking-part-4
- https://www.cemaltaner.com.tr/2019/12/08/spanning-tree-protokolu-nedir-nasil-yapilandirilir/
- https://bidb.itu.edu.tr/seyir-defteri/blog/2013/09/07/spanning-tree-protokol%C3%BC-(stp)
- https://www.tech-worm.com/hub-ile-switch-karsilastirmasi/
- https://medium.com/devopsturkiye/open-vswitch-nedir-nas%C4%B1l-kullan%C4%B1l%C4%B1r-afe00241a56f
- https://www.nakivo.com/blog/virtualbox-network-setting-guide/
- https://azizozbek.ch/blog/2018/01/vmware-network-adaptor-ayarlari-gorseli/


 
