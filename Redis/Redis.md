https://redislabs.com/ebook/appendix-a/a-3-installing-on-windows/a-3-2-installing-redis-on-window/

https://stackoverflow.com/questions/2139443/redis-replication-and-redis-sharding-cluster-difference

https://docs.aws.amazon.com/en_us/AmazonElastiCache/latest/red-ug/WhatIs.html

https://www.javacodegeeks.com/2015/09/redis-sharding.html

https://www.alibabacloud.com/blog/understanding-the-failover-mechanism-of-redis-cluster_594707

https://redis.io/topics/sentinel

https://stackoverflow.com/questions/49461494/how-does-redis-sharding-work-when-cluster-mode-is-enabled

https://dev.to/scalegrid/intro-to-redis-cluster-sharding--advantages-limitations-deploying--client-connections-5g82

http://qnimate.com/overview-of-redis-architecture/

https://alex.dzyoba.com/blog/redis-ha/

https://alex.dzyoba.com/blog/redis-cluster/

In simple words, the fundamental difference between the two concepts is that Sharding is used to scale Writes while Replication is used to scale Reads. As Alex already mentioned, Replication is also one of the solutions to achieve HA.

Suppose you have the following tuples: [1:Apple], [2:Banana], [3:Cherry], [4:Durian] and we have two machines A and B. With Sharding, we might store keys 2,4 on machine A; and keys 1,3 on machine B. With Replication, we store keys 1,2,3,4 on machine A and 1,2,3,4 on machine B.




