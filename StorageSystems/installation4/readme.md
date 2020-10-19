### stable-5.0 Supports Ceph version octopus. This branch requires Ansible version 2.9.


https://docs.ceph.com/projects/ceph-ansible/en/latest/#installation


### Ceph Cluster Componenets

Components of Ceph storage cluster

The basic components of a Ceph storage cluster

- Monitors: A Ceph Monitor (ceph-mon) maintains maps of the cluster state, including the monitor map, manager map, the OSD map, and the CRUSH map
- Ceph OSDs: A Ceph OSD (object storage daemon, ceph-osd) stores data, handles data replication, recovery, rebalancing, and provides some monitoring information to Ceph Monitors and Managers by checking other Ceph OSD Daemons for a heartbeat. At least 3 Ceph OSDs are normally required for redundancy and high availability.
- MDSs: A Ceph Metadata Server (MDS, ceph-mds) stores metadata on behalf of the Ceph Filesystem (i.e., Ceph Block Devices and Ceph Object Storage do not use MDS). Ceph Metadata Servers allow POSIX file system users to execute basic commands (like,ls, find etc.) without placing an enormous burden on the Ceph Storage Cluster.\
- Managers: A Ceph Manager daemon (ceph-mgr) is responsible for keeping track of runtime metrics and the current state of the Ceph cluster, including storage utilization, current performance metrics, and system load.


### Başlamadan Önce


eğer azure da ortamı kurmak isterseniz azure-ansible klasöründeki ansible playbook larını çalıştırabilirsiniz.

bu sistem 3 ceph makinası, 1 load balancer ve tet edebilmek için ayrıca 2 windows makimnası ayağa kalddıracaktır.

- bütün makinalara ssh ile bağlanabilişyor olmak lazım. Cluster için kullanılacak 3 makinada extradan takılmış 3 adet disk olması lazım. 

- Azure sitemde biz 3 adet klasik disk takmış olacağız.


**Ubuntu Andisible 2.9 kurulumu**

```
$ sudo apt update
$ sudo add-apt-repository ppa:ansible/ansible-2.9
$ sudo apt install ansible
```

yada 

```
$ sudo apt-get install python3-pip python3-dev
$ sudo -H pip3 install ansible==2.9
``` 




### Kurulum

1. Clone the repository:

```
$ git clone https://github.com/ceph/ceph-ansible.git
```


2. Next, you must decide which branch of ceph-ansible you wish to use. There are stable branches to choose from or you could use the master branch:


biz burada stable-5.0  kullanacağzı çünki octobus u bu sürüm deteklemeye başladı

```
$ git checkout $branch (stable-5.0 )
```

3. Next, use pip and the provided requirements.txt to install Ansible and other needed Python libraries:

,,,
$ pip install -r requirements.txt
,,,















**Recommendations**

- https://docs.ceph.com/en/latest/start/hardware-recommendations/ (hardware recommendations)
- https://access.redhat.com/documentation/en-us/red_hat_ceph_storage/3/html/red_hat_ceph_storage_hardware_selection_guide/recommended-minimum-hardware-requirements-for-the-red-hat-ceph-storage-dashboard-hardware 

--------------------

- örnek kurlum (ceph-ansible ile): https://computingforgeeks.com/install-and-configure-ceph-storage-cluster-on-centos-linux/
- örnek kurlum (cephadm ansible yedirilmiş): https://computingforgeeks.com/install-ceph-storage-cluster-on-ubuntu-linux-servers/

- resmi dokuman: https://docs.ceph.com/projects/ceph-ansible/en/stable-5.0/

- video: https://www.youtube.com/watch?v=RiLvPL7Dh3k
---
- https://huseyincotuk.com/2017/06/12/ceph-tasariminda-dikkat-edilmesi-gereken-hususlar/(metin metin olarak güzel hazırlanmış)
- http://bulutwiki.ulakbim.gov.tr/index.php/CEPH_Kurulumu (özellikle parametereler içişn okunmalıdır)
- https://huseyincotuk.com/2018/12/02/ceph-bluestore/ (bluestore nedir)
- https://huseyincotuk.com/2017/12/03/ceph-turkiye-4-meetup-istanbul-ceph-kurulumu/ 
- https://huseyincotuk.com/2017/11/27/ceph-turkiye-3-meetup-ankara-ceph-tasariminda-dikkat-edilecek-hususlar/
- https://huseyincotuk.com/2017/10/15/ceph-turkiye-2-meetup-istanbul-ceph-yapitaslari-ceph-mimarisi-openstack-entegrasyonu/
- https://ceph.io/geen-categorie/crushmap-example-of-a-hierarchical-cluster-map/ (crush map le alakalı güzel bi yazı)
- https://sohilladhani.wordpress.com/2016/03/29/how-i-managed-to-deploy-a-2-node-ceph-cluster/ (2 node cluster naıl kurulur, ancak quarom için tavsiye edilmiyor.)
- https://www.rajtechtips.com/2014/06/create-2-node-ceph-storage-cluster/ (2 node cluster - ayarlartı öğrenmek için güzel örnek)
- https://medium.com/@balderscape/setting-up-a-virtual-single-node-ceph-storage-cluster-d86d6a6c658e (tek makina  üzerine cluster kurulumu. ceph 15 octobus ile)
- https://medium.com/@balderscape/how-to-set-up-samba-to-share-a-ceph-filesystem-with-active-directory-access-control-ee96e172b67b (active disrectoey control ile ceph storage ı samba ile paylaşmak)

- https://ichi.pro/tr/ceph-deneyimimizden-3-vaka-215980997403943

**iki bölümlük yazoı dizisi**
- https://www.linkedin.com/pulse/red-hat-ceph-storage-asiye-yigit/
- https://www.linkedin.com/pulse/ceph-storage-b%C3%B6l%C3%BCm-2-asiye-yigit/

**oracle ceph sayfası - çok iyi anlatılmış**
- https://docs.oracle.com/en/operating-systems/oracle-linux/ceph-storage/toc.htm





### Faydalı Linkler
- https://vmknowledge.wordpress.com/2016/01/14/ceph-komutlar-1/
- https://vmknowledge.wordpress.com/category/storage/ceph/
- https://www.youtube.com/watch?v=OFBGeP4WVLw
- https://www.youtube.com/watch?v=2uPhxGXe9gQ
- https://www.youtube.com/watch?v=3cLgCTHLFWc
- https://youtu.be/61b12Y8cMSg?t=1379 (yaşanan zorlukjlara değinmiş)
