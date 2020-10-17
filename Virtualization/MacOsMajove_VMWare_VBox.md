# VMWARE - MacOs Mojave as Guest

vmware latest version direct link : https://www.vmware.com/go/getworkstation-linux


https://www.wikigain.com/fix-macos-mojave-imessage-icloud-app-store-vmware/


### 1. if you have a MacOS Download Mac OS from app store

https://www.youtube.com/watch?v=gM6rQ8GWboQ

after download the mojave app file, we need to create bootable iso file

- hdiutil create -o ~/Desktop/Mojave.cdr -size 6g -layout SPUD -fs HFS+J
- hdiutil attach ~/Desktop/Mojave.cdr.dmg -noverify -mountpoint /Volumes/install_build
- sudo [installation path] Mojave.app/Contents/Resources/createinstallmedia --volume /Volumes/install_build --nointeraction
- hdiutil detach "/Volumes/Install macOS Mojave"
- hdiutil convert ~/Desktop/Mojave.cdr.dmg -format UDTO -o ~/Desktop/Mojave.iso
- mv ~/Desktop/Mojave.iso.cdr ~/Desktop/Mojave.iso

or download beta bootable iso version

- File URL 1 : https://drive.google.com/file/d/14wxD0RQswL7BTfgbv-jVMjaWHj3nswNQ/view
- File URL 2 : https://drive.google.com/drive/folders/1uHeGDvXTpnez3wdirq4y4TGGQQyZH2D3
- File URL 3 : https://drive.google.com/file/d/1OJ-Owi_0IkqVhdWJ37GjlVVFa2QulSJe/view

### 2. vmware links

http://download3.vmware.com/software/wkst/file/VMware-Workstation-Full-14.1.3-9474260.x86_64.bundle

https://my.vmware.com/en/web/vmware/info/slug/desktop_end_user_computing/vmware_workstation_pro/15_0

### 3. Unlock wmware for macos

remember to stop all vmware services

- sudo /etc/init.d/vmware stop
- sudo /etc/init.d/vmware-workstation-server stop
- sudo /etc/init.d/vmware-USBArbitrator stop

download unlocker

https://github.com/DrDonk/unlocker

for linux user : give execute permission to files that are begun with lnx-
and run the lnx-install.sh

start all services

- sudo /etc/init.d/vmware start
- sudo /etc/init.d/vmware-workstation-server start
- sudo /etc/init.d/vmware-USBArbitrator start


### 4. Folow the the video instructions

https://www.youtube.com/watch?v=50dXwQTY-zk

### 5. Troubleshooting

for screen resolution install darwin.iso and restart. use wmvare full screen option from view menuj


# VIRTUALBOX - MacOs Mojave as Guest

### 1. Download Mac OS from app store or beta version

https://www.youtube.com/watch?v=gM6rQ8GWboQ

after download the mojave app file, we need to create bootable iso file

- hdiutil create -o ~/Desktop/Mojave.cdr -size 6g -layout SPUD -fs HFS+J
- hdiutil attach ~/Desktop/Mojave.cdr.dmg -noverify -mountpoint /Volumes/install_build
- sudo [installation path] Mojave.app/Contents/Resources/createinstallmedia --volume /Volumes/install_build --nointeraction
- hdiutil detach "/Volumes/Install macOS Mojave"
- hdiutil convert ~/Desktop/Mojave.cdr.dmg -format UDTO -o ~/Desktop/Mojave.iso
- mv ~/Desktop/Mojave.iso.cdr ~/Desktop/Mojave.iso

or download beta bootable iso version

- File URL 1 : https://drive.google.com/file/d/14wxD0RQswL7BTfgbv-jVMjaWHj3nswNQ/view
- File URL 2 : https://drive.google.com/drive/folders/1uHeGDvXTpnez3wdirq4y4TGGQQyZH2D3
- File URL 3 : https://drive.google.com/file/d/1OJ-Owi_0IkqVhdWJ37GjlVVFa2QulSJe/view

### 2. Before start the intallation run the following commands in linux

- vboxmanage modifyvm "Your Virtual Machine Name" --cpuidset 00000001 000106e5 00100800 0098e3fd bfebfbff
- vboxmanage setextradata "Your Virtual Machine Name" "VBoxInternal/Devices/efi/0/Config/DmiSystemProduct" "iMac11,3"
- vboxmanage setextradata "Your Virtual Machine Name" "VBoxInternal/Devices/efi/0/Config/DmiSystemVersion" "1.0"
- vboxmanage setextradata "Your Virtual Machine Name" "VBoxInternal/Devices/efi/0/Config/DmiBoardProduct" "Iloveapple"
- vboxmanage setextradata "Your Virtual Machine Name" "VBoxInternal/Devices/smc/0/Config/DeviceKey" "ourhardworkbythesewordsguardedpleasedontsteal(c)AppleComputerInc"
- vboxmanage setextradata "Your Virtual Machine Name" "VBoxInternal/Devices/smc/0/Config/GetKeyFromRealSMC" 1

### 3. After copy the setup files shutdown because MacOs will not see the OS disk and run following command 

- FS1: 
- cd "macOS Install Data"
- cd "Locked Files"
- cd "Boot Files"

Now we can run the installer itself with the following command:

boot.efi

### 4. Some link for virtual box instructions

- https://www.sysnettechsolutions.com/en/macos/download-macos-mojave-10-14-iso/
- https://techsviewer.com/install-macos-10-14-mojave-virtualbox-windows/
- https://www.wikigain.com/install-macos-mojave-on-virtualbox-windows/


### 5. Troubleshooting

- https://forums.virtualbox.org/viewtopic.php?f=35&t=82639
- https://forums.virtualbox.org/viewtopic.php?f=35&t=82639#p390399
- https://forums.virtualbox.org/viewtopic.php?f=35&t=82639&p=390399#p390403

