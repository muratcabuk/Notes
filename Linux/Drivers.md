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








