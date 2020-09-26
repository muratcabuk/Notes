 
Microsoft'da Storage adına ne varsa bulabilceğiniz web sayfası

https://docs.microsoft.com/en-us/windows-server/storage/storage


**Storage Space kavramı**

Storage Spaces is a technology in Windows and Windows Server that can help protect your data from drive failures. It is conceptually similar to RAID, implemented in software. You can use Storage Spaces to group three or more drives together into a storage pool and then use capacity from that pool to create Storage Spaces. These typically store extra copies of your data so if one of your drives fails, you still have an intact copy of your data. If you run low on capacity, just add more drives to the storage pool.

https://docs.microsoft.com/en-us/windows-server/storage/storage-spaces/overview
 
 
 
 **Storage Replicaiton vs DFS**
 
DFS de aslında failover yok sadece replication var. uygulama sunucusunun diskine yazılan dosya diğer uygulama sunucusunun diskine replica olur.



https://docs.microsoft.com/en-us/windows-server/storage/storage-replica/storage-replica-overview#why-use-storage-replica

Storage Replica may allow you to decommission existing file replication systems such as DFS Replication that were pressed into duty as low-end disaster recovery solutions. While DFS Replication works well over extremely low bandwidth networks, its latency is very high - often measured in hours or days. This is caused by its requirement for files to close and its artificial throttles meant to prevent network congestion. With those design characteristics, the newest and hottest files in a DFS Replication replica are the least likely to replicate. Storage Replica operates below the file level and has none of these restrictions.

Storage Replica also supports asynchronous replication for longer ranges and higher latency networks. Because it is not checkpoint-based, and instead continuously replicates, the delta of changes tends to be far lower than snapshot-based products. Furthermore, Storage Replica operates at the partition layer and therefore replicates all VSS snapshots created by Windows Server or backup software; this allows use of application-consistent data snapshots for point in time recovery, especially unstructured user data replicated asynchronously.
 
 
 
- **Windows Server 2019 File Server Failover Cluster Kurulumu**

    - https://www.bakicubuk.com/windows-server-2019-file-server-failover-cluster-kurulumu/

    - https://www.mshowto.org/windows-server-2019-file-server-failover-cluster-kurulumu-ve-ayarlari.html



- **Windows Server 2019 Hyper-V Failover Cluster Kurulumu**

    - https://www.bakicubuk.com/windows-server-2019-hyper-v-failover-cluster-kurulumu/
    
- **Windows server 2019 DFS kurulumu**
IIS sunucularında içerik senkronizasyonu için sıklıkla kullanılan bu yöntem ile iki web sunucusu arasında dosyalarınızı sync duruma getirebilirsiniz.

    - https://www.emreozanmemis.com/windows-server-2019-dfs-kurulumu-ve-yapilandirmasi/
    - https://cankarapinar.wordpress.com/2019/05/15/windows-server-2019-ile-dfsdistributed-file-system-kurulumu-ve-yapilandirma/
    - https://social.technet.microsoft.com/wiki/contents/articles/53051.windows-server-2019-dfs-kurulumu-ve-yapilandirmasi-tr-tr.aspx
 
 
- Storage Replication için genel bilgilendirme döküman linki

https://docs.microsoft.com/en-us/windows-server/storage/storage-replica/storage-replica-overview

- Aynı data center da iki makinanın storage larının replikasyonu için ilgili dökümanın linki (sync replication)

https://docs.microsoft.com/en-us/windows-server/storage/storage-replica/server-to-server-storage-replication


- Iki farklı lokasyondaki iki cluster ın replikasyonu için Ilgili dökümanın linki (async replication)

https://docs.microsoft.com/en-us/windows-server/storage/storage-replica/cluster-to-cluster-storage-replication


- Ayrıca aynı makina üzerinde raid benzeri bir storage sistemi kurdulamak ve disklerin hata durumunda ayakta kalmasını garantilemek amacıyla kullanılabilecek storage space döküman linki

https://docs.microsoft.com/en-us/windows-server/storage/storage-spaces/overview


- iki makina içinde aynı storage I kullanrak cluster shared volume kullanrak tek disk üzerinden cluster kurmak için ilgili döküman linki

https://docs.microsoft.com/en-us/windows-server/failover-clustering/failover-cluster-csvs
