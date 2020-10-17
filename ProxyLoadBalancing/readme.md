### Teknikler 

#### Proxy

Proxy'de sunucular client'ı bilmezler. Revers Proxy de ise Client'lar sunucu bilmezler. 
Şu [video]((https://youtu.be/ozhe__GdWC8?t=323)) güzel anlatmış.

proxy de biraz amaç client ı gizlemktir. Reverse Proxy de ama sunucuları gizlemektir. (gizlemek perspektifinden bakıldığında)




#### Reverse Proxy

Proxy'de sunucular client'ı bilmezler. Revers Proxy de ise Client'lar sunucu bilmezler. 
Şu [video]((https://youtu.be/ozhe__GdWC8?t=323)) güzel anlatmış.

proxy de biraz amaç client ı gizlemktir. Reverse Proxy de ama sunucuları gizlemektir. (gizlemek perspektifinden bakıldığında)



#### Load Balancer



#### Failover Clustering


#### Heartbeat vs Keepalived


- a __cluster-oriented product__ such as __heartbeat__ will ensure that a shared resource will be present at at most one place. This is very important for shared filesystems, disks, etc... It is designed to take a service down on one node and up on another one during a switchover. That way, the shared resource may never be concurrently accessed. This is a very hard task to accomplish and it does it well.


"Heartbeat" refers more specifically to a communication protocol, where to or more members of a high-availability setup periodically send "Yes, I'm still alive!" messages. Their peers then take action if they don't see a "Yes, I'm alive" message before a set time (i.e. the other host has gone down). This is a bit like feeling for a pulse, hence the name.



- a __network-oriented product__ such as __keepalived__ will ensure that a shared IP address will be present at at least one place. Please note that I'm not talking about a service or resource anymore, it just plays with IP addresses. It will not try to down or up any service, it will just consider a certain number of criteria to decide which node is the most suited to offer the service. But the service must already be up on both nodes. As such, it is very well suited for redundant routers, firewalls and proxies, but not at all for disk arrays nor filesystems.

"Keepalive" refers more generally to a system which keeps a service highly available.

Keepalived is much simpler, and is usually used for hot-standby usage (i.e. To keep a service up in a redundant fashion.)

A good usage example with keepalived that I have had success with is for redundant Nginx load balancers. In that situation, if a node fails, the "floating ip" moves over to the backup node.

Keepalived is simple, but it allows you to create your own check scripts (that would trigger a failover, etc.) Some info: https://tobrunet.ch/2013/07/keepalived-check-and-notify-scripts/

Which is best for you depends on your situation: keepalived is a good fit for router failover.





### Araçlar

#### Keepalived

#### Pacemaker

#### Heartbeat

#### Nginx

#### HaProxy


