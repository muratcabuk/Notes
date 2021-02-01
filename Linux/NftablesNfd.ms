- https://developers.redhat.com/blog/2016/10/28/what-comes-after-iptables-its-successor-of-course-nftables/
- https://www.funtoo.org/Package:Nftables (çok iyi anlatım)
- https://codilime.com/how-to-drop-a-packet-in-linux-in-more-ways-than-one/ (keinlikl eoknmalı)

- keubernetes henuz iptables-nft le uyumlu değil : https://github.com/kubernetes/kubernetes/issues/71305

eğer detafault olark iptables iptables-nft ye linklenmişse düzeltmek için iptables
```
update-alternatives --set iptables /usr/sbin/iptables-legacy
```
