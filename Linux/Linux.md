### Repositories

flatpak

snapcraft


### Useful Commands

check home directory : grep hadoopuser /etc/passwd | cut -d ":" -f6

create symblink : ln -fs target-path source-path-and-filename

get all symb links : find ./ -type l

get real path symb link : readlink -f [sybmlynk name]




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
