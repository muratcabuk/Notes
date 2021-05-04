

![seven-layers-of-OSI-model.png](files/seven-layers-of-OSI-model.png)

EbTables Iptables a göre daha alt seviyede kural yazmamızı sağlar. Örneğin sadece belli bir MAC adresinden gelenlerleri içeride 80 portuna izin ver gibi.

layer 3 ün latında kullar yazmamızı sağlar. Ebtables Layer 2 yani "Data Link" katmanına, Iptables ise layer 3 katmanına kural yazar. Yani temelde böyledir yoksa şuan özellikle firewall lar layer 7 ye kadar kural yazabilir haldedirler.



![osi.gif](files/osi.gif)

### Segment vs Package vs Frame

Trasportdan itibaren artık yazılımdan fiziksel cihazlara doğru geçiş başlar. bu geçişle birlikte

- transport katmanında segmentlerden
- network katmanında paketlerden
- ve data link katmanında frame lerden bahsedilir.

![segment_package_frame.jpg](files/segment_package_frame.jpg)

