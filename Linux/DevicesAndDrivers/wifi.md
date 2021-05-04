https://forums.kali.org/showthread.php?45021-rtl8822be-wifi-not-working-after-updated-to-kernel-5-2-0

https://itsfoss.community/t/how-to-install-realtek-wifi-drivers-in-ubuntu-tutorial/2808

https://itectec.com/ubuntu/ubuntu-rtl8822be-wifi-driver-ubuntu-20-04-hp-15-da1009ne/


https://www.onooks.com/rtl8822be-driver-for-ubuntu-18-04-and-20-04/

https://forums.kali.org/showthread.php?45021-rtl8822be-wifi-not-working-after-updated-to-kernel-5-2-0


Code:

```
lspci -nnk|egrep -iA3 "wireless|network"
```
Code:
```
dmesg | egrep -i "rtl8822be|firmware"
```
Wireless network device node present?
Code:
```
ip link
```
If that checks out, move on finding out why you can't get the device associated with the desired network.


https://itsfoss.com/speed-up-slow-wifi-connection-ubuntu/


https://askubuntu.com/questions/1237812/after-updated-ubuntu-20-04-lts-all-browsers-working-slow



https://easylinuxtipsproject.blogspot.com/p/realtek.html#ID8


https://forums.linuxmint.com/viewtopic.php?t=263778

https://forums.linuxmint.com/viewtopic.php?t=304941

https://forums.linuxmint.com/viewtopic.php?t=290987




https://superuser.com/questions/1480697/rtl8822be-wifi-not-working-ubuntu-18-04-bluetooth-works

https://askubuntu.com/questions/1229669/rtl8822be-wifi-driver-ubuntu-20-04-hp-15-da1009ne

https://askubuntu.com/questions/1230041/wifi-problems-with-ubuntu-20-04-focal-fossa


