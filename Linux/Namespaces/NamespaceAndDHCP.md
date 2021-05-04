
http://blog.asiantuntijakaveri.fi/2015/07/dhcp-tricks-with-linux-network-namespace.html

```

DHCP tricks with Linux network namespace
Some notes from my experiments with fetching more than one IP address from DHCP for same physical ethernet adapter. Nothing too difficult and you don't even need netns for this, few policy route settings would be enough if dhclient (and especially dhclient-script) wouldn't be so broken. For example dhclient has nasty habit of hijacking udp/68 on all network interfaces rather than only those it controls. There's also issues in some cases due routing when DHCP server is not on local LAN but behind WAN like it's in corporate and ISP networks.

# Create new network namespace
ip netns add nns_pink

# Traffic between "main" and "pink" is routed via veth
# Create veth pipe between vem_pink and ves_pink
ip link add vem_pink type veth peer name ves_pink
# Move ves_pink veth to nns_pink namespace
ip link set ves_pink netns nns_pink

# Configure internal network running over veth
ip addr add 10.251.251.1/24 dev vem_pink
ip link set up dev vem_pink
# And nns_pink side
ip netns exec nns_pink ip addr add 10.251.251.2/24 dev ves_pink
ip netns exec nns_pink ip link set up dev ves_pink

# Allow "main" to talk with outside world via "pink" by masquerading
ip netns exec nns_pink iptables -t nat -A POSTROUTING -s 10.251.251.1 -j MASQUERADE 
# Routing must also be enabled
ip netns exec nns_pink sysctl net.ipv4.ip_forward=1
ip netns exec nns_pink sysctl net.ipv4.conf.ves_pink.forwarding=1

# Traffic between Internet (eth0) and "pink" is bridged over macvlan
# Create new macvlan alias called mvl_pink
ip link add link eth0 dev mvl_pink type macvlan
# Use fixed mac address instead of auto generated random mac
ip link set dev mvl_pink address 00:60:2f:00:00:00
# Move mvl_pink macvlan to nns_pink namespace
ip link set mvl_pink netns nns_pink

# Setup loopback on nns_pink namespace
ip netns exec nns_pink ip addr add 127.0.0.1/8 dev lo
ip netns exec nns_pink ip link set up dev lo

# Fetch DHCP allocated Internet IP for pink
ip netns exec nns_pink dhclient -nw -v \
      -pf /run/dhclient.mvl_pink.pid \
      -lf /var/lib/dhcp/dhclient.mvl_pink.leases mvl_pink

# Confirm that dhclient is binded only on nns_pink
netstat -nlp|grep ":68 "
ip netns exec nns_pink netstat -nlp|grep ":68 "

# Check our public IP using OpenDNS "myip.opendns.com" trick
dig +short myip.opendns.com @208.67.222.222
# And it should be different in nns_pink netns
ip netns exec nns_pink dig +short myip.opendns.com @208.67.222.222

# Route traffic to OpenDNS resolver via pink
ip route add 208.67.222.222 via 10.251.251.2 dev vem_pink
# Recheck our IP, it should now show IP of pink due routing + masquerading
dig +short myip.opendns.com @208.67.222.222

# Release DHCP lease and stop dhclient
ip netns exec nns_pink dhclient -r -v \
      -pf /run/dhclient.mvl_pink.pid \
      -lf /var/lib/dhcp/dhclient.mvl_pink.leases mvl_pink

# Remove nns_pink network namespace
ip netns del nns_pink

```
