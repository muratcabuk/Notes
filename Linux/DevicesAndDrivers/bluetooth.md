adapter çalışmadığında

http://www.thinkwiki.org/wiki/How_to_setup_Bluetooth
http://www.thinkwiki.org/wiki/How_to_setup_Bluetooth
https://forum.manjaro.org/t/solved-bluetooth-dont-discovers-device-bluetoothctl-no-default-controller/90699

https://www.linux-magazine.com/Issues/2017/197/Command-Line-bluetoothctl

```
sudo systemctl enable bluetooth
```

After that run this
```
sudo systemctl restart bluetooth
```
for checking status of your, Bluetooth run this
```
systemctl status bluetooth
```


verify the radio status with the rfkill command:

Code:

```
rfkill
```

... if your bluetooth adapter appears it should not have a status "BLOCKED".

If the bluetooth adapter isn't listed with the rfkill command, I would then check to see if the bluetooth driver module and dependencies are loaded. Please report back the output of the following command :

Code:
```
lsmod | grep bt
```
... if several lines appear, including references to module btusb, your system should be able to start the systemd bluetooth service. If nothing appears, try loading the module with the following command :

Code:
```
sudo modprobe btusb
```
.. and then try the previous lsmod command again. If loaded modules now appear, you could try restarting your systemd bluetooth service with the first command and reporting the output of the status command again. If it then appears as loaded and started, you should be able to see your bluetooth device in whatever gui app you are using. 


thinkpad e480 için

after 5-10 bios resets to re-enable bluetooth during the last two years I decided to investigate this issue again. looks like there is a bluetooth switch emulation in the thinkpad_acpi module. turn this on via module options et voila -> working bluetooth!

echo options thinkpad_acpi dbg_bluetoothemul=1 bluetooth_state=1 | sudo tee -a /etc/modprobe.d/thinkpad_acpi.conf

reboot && block/unblock bluetooth as needed:

rfkill unblock all

Ayrıca Ubuntunun kullandığı blutooth yönetim aracını kaldırıp blueman/blue manager ı yüklemek mantıklı gibi

birde alttaki komutlar denenebilir

```
sudo rmmod btusb

sudo modprobe btusb

```







