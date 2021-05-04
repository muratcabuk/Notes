### Linux File System

### BTRFS
- https://sudo.ubuntu-tr.net/b-tree-dosya-sistemi-btrfs
- https://www.synology.com/tr-tr/dsm/Btrfs
- http://www.kayhankayihan.com/btrfs-dosya-sistemi-hakkinda/


### Storage Pool

#### ZFS


- https://www.technopat.net/2020/10/18/zfs-dosya-sistemine-giris-zfs-nedir/ (çok iyi anlatım)
- https://www.sysnettechsolutions.com/zfs-nedir/
#### LVM

- https://www.koraykey.com/?p=3315
- https://www.cozumpark.com/linux-sistemlerde-disk-yap-land-rma-ve-lvm-yapisi/
- https://bidb.itu.edu.tr/seyir-defteri/blog/2013/09/06/lvm-(logical-volume-management)



#### Resources
- https://hasanyilmaz.net/kati-hal-surucusu-ssd-basarimi-icin-ubuntunun-yapilandirilmasi-5-tmpfs-ve-ramfs-nedir/
- https://www.syslogs.org/linux-sistemlerde-ram-disk-olusturulmasi/


### Linux Storage Structure

#### TMPFS (TEMPORARY FİLE SYSTEM)

- Geçici dosya sistemidir.
- Veriyi diske yazar, takas alanı gibi kullanılır.
- Belirli bir alan ile sınırlanabilir.
- Alan dolduğunda yazmaya devam etmez, hata iletisi verir.
- Geçici depo gibi davranır. Sistem yeniden başladığında ilgili dizindeki veriler silinmiş olur.

#### RAMFS (RANDOM ACCESS MEMORY FİLE SYSTEM)
- Geçici dosya sistemidir.
- Veriyi diske yazmaz, rastgele erişimli belleğe yazar.
- Sınırlanabilir ancak veri yazma işlemi sınıra ulaştıktan sonra da devingen olarak devam eder. Sistem bunu durdurmaz. Bu sınır ne işe yarar o zaman? Sınırlamadıktan sonra fiziksel belleğinizin yarısı kadar sınır standarttır. Eğer sizin fiziksel belleğiniz (+4 GB gibi) iyi durumda ise yarısından fazlasını kullanmak için sınırı yarıdan fazla yapmak iş görür.
- Geçici depo gibi davranır. Bilinen RAM mantığı.
