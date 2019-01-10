### Issue One: Device not detected

1. If the wireless device is not detected by Ubuntu (or any distro for that matter), 
then you will need to access the Terminal and type the following command:

``` shell
sudo lsusb
```

2. if you use a plug in USB wireless card/dongle, and

``` shell
sudo lspci
```
3. if you have an internal wireless card.

If the response from these commands comes back with an output similar to the screenshot below, 
then you are in luck: Ubuntu can find the card. It is usually identified by “Network Controller” or “Ethernet Controller.”

4.  Additional Commands

You can also use the following command to test if the machine can see the wireless device; users may need to install lshw on their machine first.

``` shell
lshw -C network
```

### Issue Two: Driver module missing
Following on from the successful lsusb and lspci commands, providing Ubuntu can see the wireless card, you can assume that the firmware is working, just that the system has no idea what to do with the card. This is where drivers or modules are needed.

Go back to the terminal and type the following command:

``` shell
sudo lsmod
``` 

You see a list of modules that are used. In order to activate your module, type the following command where “modulename” is the name of your chipset.

``` shell
sudo modprobe modulename
```

For example, if your wireless chipset is “RT2870,” it would be as follows:

``` shell
sudo modprobe rt2800usb
```

### Load module automatically at boot
It is a rare occasion, but sometimes the module will not persist from boot. In this case you can force it to load permanently. Enter the command below into the Terminal:

``` shell
sudo nano /etc/modules
```
The nano text editor will open up. Add your module name at the bottom and save the file. You will need to reboot and check to see if the wireless card can now see networks to enable you to connect as normal.

If you get stuck, then repeat the process. Thankfully, Ubuntu has some useful help pages in their online documentation that you can also read through. Additionally, you can use the built-in help within the terminal by entering:

``` shell
man lsusb
man lspci
```

### Issue Three: DNS

It is rare that the DNS will be an issue; however, it is worth investigating should you still have connection issues. From the Terminal, type the following command to assess where the DNS is coming from:

``` shell
nmcli device show wlan1 | grep IP4.DNS
```

This will show you the LAN address of the router. If it doesn’t work, you may have to change “wlan1” to whatever your wireless uses. The following command can also be used to grab the designation:
``` shell
ip address
```
Once you have this information, your next method is to ping your router’s LAN address. If this works, try to ping Google’s DNS servers:
``` shell
ping 8.8.8.8
```
With these results you can establish where the DNS issue is. If all devices within your home or office are giving page load errors, then change the router DNS to Google or Open DNS servers. You’ll have to consult your router manufacturer for how to do this, but it is generally done within the admin pages, most commonly by logging onto 192.168.0.1 or similar.

``` shell
sudo service network-manager restart

```
### Issue Four: No Network Manager
Let’s say you have removed the Network Manager or uninstalled it by accident. This is a really troublesome situation: you have no Internet and no Network Manager, but there are things you can do.

Assuming the apt package is still within your cache, then you can go to the Terminal and enter:
``` shell
sudo apt-get install network-manager
```

If you have removed this cache, then you can use an Ethernet cable to connect by plugging this into your Ethernet port and running the above command again.

As a final step, if none of the above works, you will need to edit your configuration file. I selected gedit as the text editor, but you can use your preferred choice and amend the command.

``` shell
sudo gedit /etc/network/interfaces
```
Amend it to read as follows:
``` shell
auto lo
iface lo inet loopback
 
auto wlan0
iface wlan0 inet dhcp
wpa-essid myssid
wpa-psk mypasscode
```

Then you can restart the interface by entering the below code:
``` shell
sudo ifdown wlan0 && sudo ifup -v wlan0
```








