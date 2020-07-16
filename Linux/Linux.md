### Repositories

flatpak

snapcraft

AppImage

https://www.devpy.me/snapcraft-appimage-flatpak/


### Programs

- [Krita](https://krita.org/en/download/krita-desktop/) vector

- [digiKam](https://www.digikam.org/download/) photoshop

- [Kdenlive](https://kdenlive.org/en/) video editing

- pidgin

pidgin installation for office 365 skype for business


    1. Add the following PPA: https://launchpad.net/~sipe-collab/+archive/ubuntu/ppa (not needed for Ubuntu 18.04)
    2. Install/Update pidgin and pidgin-sipe packages
    3. Create a new account with type “Office Communicator”
    4. User name should be user@domain.org
    5. Leave the “login” empty
    6. In the Advanced Tab, under server, enter sipdir.online.lync.com:443
    7. Connection Type and Authentication Scheme should be set to Auto
    8. Use the following as the User Agent: UCCAPI/15.0.4420.1017 OC/15.0.4420.1017
    Enjoy!!

### Ulimit

http://www.belgeler.org/bashref/bashref_bash.builtins-ulimit.html

http://www.belgeler.org/bashref/bashref_bash.builtins-ulimit.html



### Useful Commands

check home directory : grep hadoopuser /etc/passwd | cut -d ":" -f6

create symblink : ln -fs target-path source-path-and-filename

get all symb links : find ./ -type l

get real path symb link : readlink -f [sybmlynk name]

see all users : nano /etc/users

see all groups: nano /etc/groups

see diectory permission: ls -ld /foldername

see user detail : id username

run program on terminal without log (e.g vs code) : code &

run program on terminal without log (e.g vs code) if we already open termianal, just change the session : setsid program-name &>/dev/null


### SSH

ssh-add id_rsa

Error : Could not open a connection to your authentication agent.

Resolution : eval ssh-agent -s


### bin, sbin, usr/bin , usr/sbin split

http://lists.busybox.net/pipermail/busybox/2010-December/074114.html


- /bin : For binaries usable before the /usr partition is mounted. This is used for trivial binaries used in the very early boot stage or ones that you need to have available in booting single-user mode. Think of binaries like cat, ls, etc.

- /sbin : Same, but for binaries with superuser (root) privileges required.

- /usr/bin : Same as first, but for general system-wide binaries.

- /usr/sbin : Same as above, but for binaries with superuser (root) privileges required.


### network

- [WiFi](https://www.linux.com/learn/how-configure-wireless-any-linux-desktop)

- [Add Network Interface](https://www.digitalocean.com/docs/networking/private-networking/how-to/enable/)

```
lshw -class network
```
ekrana kullancağımız mac address gelecek

```
/etc/netplan/50-cloud-init.yaml
```
alttaki satıraklar eth1 ile yukarıdan eth0 kopyala yapıştır yapılır
```
eth1:
    addresses:
    - 198.51.100.0/16
    match:
        macaddress: ex:am:pl:e3:65:13
    set-name: eth1
```
debug yapmak için

```
sudo netplan apply --debug
```
daha sonra

```
sudo ifconfig
```













 
### Driver and Firmware

[kernel firmware list](http://mirrors.kernel.org/ubuntu/pool/main/l/linux-firmware)
[mainborad linux component](https://github.com/armbian)

### Partitions

/ :	The slash / alone stands for the root of the filesystem tree.

/bin : 	This stands for binaries and contains the fundamental utilities that are needed by all users.

/boot :	This contains all the files needed for the booting process.

/dev :	This stands for devices, which contains files for peripheral devices and pseudo devices.

/etc :	This contains configuration files for the system and system databases.

/home :	This holds all the home directories for the users.

/lib :	This is the system libraries and has files like the kernel modules and device drivers.

/lib64 : 	This is the system libraries and has files like the kernel modules and device drivers for 64bit systems.

/media :	This is default mount point for removable devices like USB drives and media players, etc.

/mnt :	This stands for mount, and contains filesystem mount points. Used for multiple hard drives, multiple partitions, network filesystems and CD ROMs and such.

/opt :	Contains add-on software, larger programs may install here rather than in /usr.

/proc :	This contains virtual filesystems describing the processes information as files.

/sbin :	This stands for System Binaries, and contains the fundamental utilities needed to start, maintain and recover the system.

/root :	This is the home location for the system administrator root. This accounts home directory is usually the root of the first partition.

/srv :	This one is server data which is data for services provided by the system.

/sys :	This contains a sysfs virtual filesystem which holds information related to the hardware operating system.

/tmp :	This is a place for temporary files. tmpfs mounted on it or scripts on start up usually clear this at boot.

/usr :	This holds the executables and shared resources that are not system critical.

/opt : is reserved for the installation of add-on application software packages. we can aşso use the /usr/local folder for this purpose.

/var :	This stands for variable and is a place for files that are in a changeable state. Such as size going up and down.

/swap :	The swap partition is where you extend the system memory by dedicating part of the hard drive to it.


### Disk

bir path a bir diski veya basşka bir path i mount ettikten sonra aynı yere başka bir folder ı veya disk mount edersek önceki mount ettiğimiz yer ne olur? 

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
