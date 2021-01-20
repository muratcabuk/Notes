 
The command dd was modeled after the command DDR (Disk Dump and Restore) from IBM mainframes from the 1960s and is mainly intended to convert and reblock block oriented I/O from/to block oriented disks.

Bu komut "data definition" kelimelerinin kısalmasıdır.


 
 
1. Örnek 1: Bir sabit diski başka bir sabit diske kopyalayın. Bu, aynı yapılandırmaya sahip birçok makine inşa ettiğimizde yararlıdır. Tüm makinelere işletim sistemi kurmaya gerek yok. Sadece makineye işletim sistemini ve gerekli yazılımı yükleyin, ardından aşağıdaki örnekle kopyalayın.

```	
dd if=/dev/sda of=/dev/sdb
```

2. Örnek 2: Disk bozulmasına karşın parçalı veya tam HDD’nin yedeğini alabiliriz.

```
dd if =/dev/sda2 of=~/hdadisk.img
```

Aldığımız yedeği geri yükleme.
```
dd if=~/hdadisk.img of=/dev/sdb3
```

3. Örnek 3: image alırken sıkıştırmak için.

```
dd if =/dev/sda2 | bzip2 hdadisk.img.bz2
```

4. Örnek 4: cp komutu yerine kullanabiliriz.

```
dd if=/home/imran/abc.txt of=/mnt/abc.txt
```
5. Örnek 5: Bir diskin içeriğini siler, böylece birisinin kullanması için boş olacak.

```
dd if=/dev/zero of=/dev/sdb
```
/dev/null ve /dev/zero benzer işlemleri yapar.


6. Örnek 6: Kişisel verilerinizi silebiliriz. Bir çok insan rm -rf / verilerinizi yapıp yapmadığımızı düşünür. Ancak bu silme işlemini Photorec veya bazı adli tıp araçları gibi disk kurtarma araçlarını kullanarak kurtarabiliriz. Ancak, verilerinizi kurtarmamayı istemiyorsanız, verilerin bulunduğu bölümünüze rastgele veri yazmanız gerekir.

```
dd if=/dev/random of=/dev/sdb
```
Verileri kurtarmayı dahada zorlaştırmak için, birden çok kez komut verebiliriz.
```
for i in {1..10};do dd if=/dev/random of=/dev/sdb;done
```

7. Örnek 7: swap olarak kullanılabilecek dd komutuyla sanal dosya sistemi oluşturabiliriz.

```
dd if=/dev/zero of=/swapfile bs=1024 count=200000
```
bs : block boyutudur. Blok boyutunu belirtmezseniz, dd varsayılan bir blok boyutunu 512 bayt kullanır. Aşağıdaki kurallar blok boyutları için çalışacaktır. kB(1000 byte), K(1024 byte), Mb(1000*1000 byte), MB(1024*1024 byte), Gb, GB, T, P ,E ,Z, Y opsiyonları kullanılabilir.

count : bs ile boyutları belirtilen bloklardan kaç adet kopyalanacağı


8. Örnek 8: dd komutunu kullanarak bir CD-ROM veya DVD-ROM’dan ISO dosyaları bile oluşturabiliriz.

```
dd if=/dev/dvd of=/opt/my_linux_image.iso
```

veya

```
dd if=/dev/sr0 of=/home/$user/mycd_image.iso bs=2048 conv=sync
```

9. Örnek 9: dd komutunu kullanarak önyüklenebilir USB bile oluşturabiliriz.

```
dd if=/home/$user/bootimage.img of=/dev/sdc
```

10. Örnek 10: Disk yazma hızını ölçmek için;

```
dd if=/dev/zero of=tempfile bs=1M count=1024
```

11. Örnek 11: Disk buffer okuma ölçmek için;

```
dd if=tempfile of=/dev/null bs=1M count=1024

```

12. Örnek 12: Disk gerçek okuma hızını ölçmek için;

```/sbin/sysctl -w vm.drop_caches=3
dd if=tempfile of=/dev/null bs=1M count=1024
```

### Resources

- https://linuxcorbasi.blogspot.com/2017/09/dd-komutu.html
- http://www.mustafabektastepe.com/2017/01/15/dd-komutu/

 
