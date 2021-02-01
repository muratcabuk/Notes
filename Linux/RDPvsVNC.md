 
Aşağıda VNC ve xrdp kurulumdarı da var. 

 
### Similarities

 
1. **The Goal**

The ultimate goal of both protocols is to provide graphical access to a remote computer, displaying the desktop as well as communicating keystrokes and mouse actions. A user operating the local computer actually triggers all events, launches the applications and observers the results on the remote one.

2. **Peer-to-peer Networking*

Both technologies use direct peer-to-peer communication. It means that the local user computer directly connects to the remote computer. But if a firewall blocks the remote computer’s access, neither technologies would work. In this case, the access could be established by using an intermediary computer (gateway or jump server) that the user can connect to first and then from this computer remote connect to the ultimate destination. This is as oppose to popular screen sharing technologies that require agents on both local and remote computers to connect to the centrally located server.

3. **Client and Server Side Software**

Both RDP and VNC technologies require client side and server side software to support communication protocol. This software comes pre-installed on some platforms which makes it easier to setup. For example, almost all versions of Windows have an RDP server pre-installed, while virtually all modern versions include an RDP client. Also, many versions of Linux have a pre-installed VNC server. Mac OS includes an often overlooked VNC client. In all cases the server parts for both technologies has to be configured to enable access and to set up credentials to login.

### Differences

 
1. **Desktop vs Computer Access**

RDP logs in a remote user to the server computer by effectively creating a real desktop session on the server computer including a user profile. It works in the same way as if the user had logged in to the physical server directly. RDP can support multiple remote users logged in to the same server that completely unaware of each other. It makes RDP a good choice for using the same remote server for multiple users at the same time.


VNC connects a remote user to the computer itself by sharing its screen, keyboard and mouse. Consequently, when several users (including the one operating the real physical monitor and keyboard) connect to the same server they see the same thing and they type on the same keyboard. It makes VNC a good choice for technical support when the remote user can see what the local user does and can take control when needed to help. Popular WEB based screen sharing technologies like WebEx or GotoMeeting provide similar kinds of functionality using cloud based servers to maintain communication. VNC does it using a direct connection.

2. **Multi-platform**

RDP is inherently Windows technology on the server side because of its core principle of creating a unique Windows login session for each user of the system. However, there are RDP clients built for multiple desktop and mobile platforms: Windows, Mac OS, iOS, Linux and Android.


VNC supports multiple platforms on the server side allowing sharing screens and keyboards of both Windows and Linux computers including Linux graphical environments. It might explain the desire to standardize on VNC to keep access similar across the board.


3. **Use by 3rd Parties**

It’s also worth remembering that VNC is an open protocol. There are multiple technologies based on (and sometimes partially compatible with) this technology including  some of the WEB based screen sharing applications. They might claim to have VNC as their primary communication channel, However they might not support complete VNC infrastructure with peer-to-peer connectivity and specific client and server side software.


We, at Xton Technologies, recently added support for VNC protocol. Our Xton Access Manager (XTAM) Privileges Session Management Server requires only a WEB browser for the remote user to log in to the VNC server. It eliminates the need to install VNC clients on multiple desktop or mobile devices.


XTAM can store credentials to the VNC servers. It can optionally login the user to the remote computer without even asking the user for credentials based on the permissions in the XTAM server itself. In addition to that, XTAM can monitor user keystrokes and even record complete session to the remote computer as video for future learning, sharing or auditing purposes. It provides a simple and secure method of granting access to remote computers in a controlled way. We discuss this situation in our article “Five Ways to Open Root Access for a Remote Contractor“


### XRDP kurulumu Kubuntu 20-04 KDE için

```
$ sudo apt update
$ sudo apt upgrade
$ sudo apt install xrdp 
$ sudo systemctl status xrdp


# By default Xrdp uses the /etc/ssl/private/ssl-cert-snakeoil.key file that is readable only by members of the “ssl-cert” group. Run the following command to add the xrdp user to the group :

$ sudo adduser xrdp
$ sudo adduser xrdp ssl-cert  

# Restart the Xrdp service for changes to take effect:

$ sudo systemctl restart xrdp

```

daha sonra alttaki scripti çalıştırıyoruz.

bazı kaynakarda startkde kullanıldığı görülür. Ancak startkde eski kde lerde var artık alttaki gibi kullanılıyor. 

echo "startplasma-x11" > ~/.xsession




```
!/bin/sh -e

# Load Ubuntu config.
echo "startplasma-x11" > ~/.xsession
D=/usr/share/plasma:/usr/local/share:/usr/share:/var/lib/snapd/desktop
C=/etc/xdg/xdg-plasma:/etc/xdg
C=${C}:/usr/share/kubuntu-default-settings/kf5-settings
cat <<EOF > ~/.xsessionrc
export XDG_SESSION_DESKTOP=KDE
export XDG_DATA_DIRS=${D}
export XDG_CONFIG_DIRS=${C}
EOF

# Avoid Authentication Required dialog.
cat <<EOF | \
  sudo tee /etc/polkit-1/localauthority/50-local.d/xrdp-NetworkManager.pkla
[Networkmanager]
Identity=unix-group:sudo
Action=org.freedesktop.NetworkManager.network-control
ResultAny=yes
ResultInactive=yes
ResultActive=yes
EOF
cat <<EOF | \
  sudo tee /etc/polkit-1/localauthority/50-local.d/xrdp-packagekit.pkla
[Networkmanager]
Identity=unix-group:sudo
Action=org.freedesktop.packagekit.system-sources-refresh
ResultAny=yes
ResultInactive=auth_admin
ResultActive=yes
EOF
sudo systemctl restart polkit
```

#### KDE XRDP Troubleshooting

bağlanıldığında beyaz ekran görme yada ikinci kişi girdiğinde problem yaşanıyorsa

öncelikle ltaaki komutla x-session-manager startplasma-X11 seçilir

```
sudo update-alternatives --config x-session-manager
```

ikinici olarak bir
```
/etc/xrdp/startwm.sh and add these lines before the lines that test and execute Xsession. The $HOME/.profile is not part of the solution, but is something that should be run before starting the session anyway.

unset DBUS_SESSION_BUS_ADDRESS  
unset XDG_RUNTIME_DIR

```





### Resource
- https://blog.netop.com/what-is-vnc
- 
