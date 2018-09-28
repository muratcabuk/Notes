
MAC OS as Guest


Download Mac OS from app store

https://www.youtube.com/watch?v=gM6rQ8GWboQ


ilk kopyalamdan sonra CD yi sil, shel de alttaki komutları çalıştır

FS1: 

cd "macOS Install Data"
cd "Locked Files"
cd "Boot Files"
Now we can run the installer itself with the following command:

boot.efi


vmware unlocker for macos

https://github.com/DrDonk/unlocker


Mac OS 10.14 Mojave

anlatım 1

https://www.sysnettechsolutions.com/en/macos/download-macos-mojave-10-14-iso/

anlatım 2

https://techsviewer.com/install-macos-10-14-mojave-virtualbox-windows/

anlatım 3

https://www.wikigain.com/install-macos-mojave-on-virtualbox-windows/


Dosya Linki 1 : https://drive.google.com/file/d/14wxD0RQswL7BTfgbv-jVMjaWHj3nswNQ/view

Dosya Linki 2 : https://drive.google.com/drive/folders/1uHeGDvXTpnez3wdirq4y4TGGQQyZH2D3

Dosya Linki 3 : https://drive.google.com/file/d/1OJ-Owi_0IkqVhdWJ37GjlVVFa2QulSJe/view

VirtualBox için Code

Code for Virtualbox 5.0.x:

cd "C:\Program Files\Oracle\VirtualBox\"
VBoxManage.exe modifyvm "Your Virtual Machine Name" --cpuidset 00000001 000106e5 00100800 0098e3fd bfebfbff

VBoxManage setextradata "Your Virtual Machine Name" "VBoxInternal/Devices/efi/0/Config/DmiSystemProduct" "iMac11,3"

VBoxManage setextradata "Your Virtual Machine Name" "VBoxInternal/Devices/efi/0/Config/DmiSystemVersion" "1.0"

VBoxManage setextradata "Your Virtual Machine Name" "VBoxInternal/Devices/efi/0/Config/DmiBoardProduct" "Iloveapple"

VBoxManage setextradata "Your Virtual Machine Name" "VBoxInternal/Devices/smc/0/Config/DeviceKey" "ourhardworkbythesewordsguardedpleasedontsteal(c)AppleComputerInc"

VBoxManage setextradata "Your Virtual Machine Name" "VBoxInternal/Devices/smc/0/Config/GetKeyFromRealSMC" 1



Mac OS 10.13.6 

https://astr0baby.wordpress.com/2018/07/15/installing-high-sierra-10-13-6-in-virtualbox-5-2-12-on-linux-x86_64/

You can get the latest 10.13.6 ISO here -> https://drop.me/ByWxnP

şu sayfadan esinlenerek yapılmış 

https://tylermade.net/2017/10/05/how-to-create-a-bootable-iso-image-of-macos-10-13-high-sierra-installer/

klavye ve mouse sorunları için

https://forums.virtualbox.org/viewtopic.php?f=35&t=82639

https://forums.virtualbox.org/viewtopic.php?f=35&t=82639#p390399

https://forums.virtualbox.org/viewtopic.php?f=35&t=82639&p=390399#p390403


eski version

https://www.howtogeek.com/289594/how-to-install-macos-sierra-in-virtualbox-on-windows-10/

https://www.youtube.com/watch?v=8FgreMBnjHs&vl=en


