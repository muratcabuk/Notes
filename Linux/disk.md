### Kernel Panic - Not Syncing: VFS: Unable to Mount Root FS on Unknown-Block(0,0) hatası
 

sistem baştab başlatılıp advance modda çalıştırıp eski kernel lardan biriyle açılabilir. 

sitem açıkken halen hangi kernealler yüklü diye bakılmak istenirse 

```
sudo dpkg --get-selections | grep linux  
```

eski kernel ları asla silmeyin.


 
 
1.  https://www.geekswarrior.com/2019/07/solved-how-to-fix-kernel-panic-on-linux.html

2. If this happened during a distribution upgrade of Ubuntu (19.04 to 19.10 in my case), it can be because packages are still left in a half-configured state.

In this case, boot the system in recovery mode using an older kernel. That will work. Then go to the root shell in recovery mode, and execute this to finish the interrupted installation process:

```
sudo aptitude update

dpkg --configure -a
```
 
 
3. son çare  hatalı kernel silinebilir

```
sudo apt remove linux-image-VERSION-generic linux-headers-VERSION-generic linux-modules-VERSION-generic

sudo apt purge  linux-image-VERSION-generic (örn linux-image-5.0.0-36-generic)

```
 
