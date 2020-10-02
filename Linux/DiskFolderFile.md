### Disk

**bir path a bir diski veya basşka bir path i mount ettikten sonra aynı yere başka bir folder ı veya disk mount edersek önceki mount ettiğimiz yer ne olur?** 

cevap: sadece görünmez olur aynı alanı tekrar MOUNT DEĞİL BIND ederek tekrar görebiliriz.

https://unix.stackexchange.com/questions/198542/what-happens-when-you-mount-over-an-existing-folder-with-contents


diyelimki /tmp alanına bir disk i mount ettik eki eski tmp kalsörüne oldu


What happens to the actual content of /tmp when my hard drive is mounted?

Pretty much nothing. They're just hidden from view, not reachable via normal filesystem traversal.

Is it possible to perform r/w operations on the actual content of /tmp while the hard drive is mounted?

Yes. Processes that had open file handles inside your "original" /tmp will continue to be able to use them. You can also make the "reappear" somewhere else by bind-mounting / elsewhere.

```
# mount -o bind / /somewhere/else
# ls /somewhere/else/tmp  
```



**bulunduğunuz klasördeki herşeyin (klasör ve dosya) boyutunu veren kod**

h human readable demek
s standart formatta gb, mb vb formatta boyut veririr


```
$ sudo du -sh *
```

c parametresi toplamı da veririr en alttaki
```
$ du -c ~/go
```

yukarıdan aşağı sıralama

```
du ~/go | sort -n -r | less
```

en büyük folder ı bulmak için a parametresi akelnir böylece sadece doyalar değil klasör toplamları da ekrana gelir.
```
du -a / | sort -n -r | head -n 10
```

Diskte bulunan dizindeki kalsörlerin boyutlarını veren kod

https://www.tecmint.com/find-top-large-directories-and-files-sizes-in-linux/

bir rakamı kaç level alta gidileğini söylüyor
```
sudo du -h -d 1 --exclude=/proc --exclude=/run /
```
buda aynı işi yapıyor 
```
 sudo du -hs * | sort -rh | head -5
 ```

 **Disk/mount boyutları**
 
 ```
 df -H /dev/sda1
 ```
 
 daha detaylı bilgi almak için
 
- source — the file system source
- size — total number of blocks
- used — spaced used on a drive
- avail — space available on a drive
- pcent — percent of used space, divided by total size
- target — mount point of a drive

Let’s display the output of all our drives, showing only the size, used, and avail (or availability) fields. The command for this would be:
 
  
 ```
 df -H --output=size,used,avail
 ```
