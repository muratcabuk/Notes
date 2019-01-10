### Repositories

flatpak

snapcraft

AppImage

https://www.devpy.me/snapcraft-appimage-flatpak/


### Programs

- [Krita](https://krita.org/en/download/krita-desktop/)

- [digiKam](https://www.digikam.org/download/)

- pidgin


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


### bin, sbin, usr/bin , usr/sbin split

http://lists.busybox.net/pipermail/busybox/2010-December/074114.html


- /bin : For binaries usable before the /usr partition is mounted. This is used for trivial binaries used in the very early boot stage or ones that you need to have available in booting single-user mode. Think of binaries like cat, ls, etc.

- /sbin : Same, but for binaries with superuser (root) privileges required.

- /usr/bin : Same as first, but for general system-wide binaries.

- /usr/sbin : Same as above, but for binaries with superuser (root) privileges required.


### network

[WiFi](https://www.linux.com/learn/how-configure-wireless-any-linux-desktop)

### Driver and Firmware

[kernel firmware list](http://mirrors.kernel.org/ubuntu/pool/main/l/linux-firmware)


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
