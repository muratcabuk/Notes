### Linux Namespace'lerine Giriş 


![linux-namespace1.png](files/linux-namespace1.png)

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


konuyla ilgili, linux sıkılarştırma eğitimi içinde başlık var bakılmalı
