## Requirement


### proxy
------------------
https://www.haproxy.com/documentation/hapee/latest/installation/getting-started/os-hardware/


4 core 4 ram 50 gb disk >>>>> ssl offloding yacak birde 


### veritabanı
------------------

her bir uygulama üzerinden






### Confluence
-----------------

https://confluence.atlassian.com/doc/server-hardware-requirements-guide-30736403.html

- Accounts: 5,000
- Spaces: 500
- CPUs : 4 
- CPU (GHz): 3
- RAM (MB): 8 GB



Total pages is not a major consideration for performance. For example, instances hosting 80K of pages can consume under 512MB of memory


performance tuning: https://confluence.atlassian.com/doc/performance-tuning-130289.html



4 core 8 ram 100 gb disk



### Jira
------------------

- https://confluence.atlassian.com/adminjiraserver/jira-applications-installation-requirements-938846826.html (Server-side requirements for production bölümüne bakınız)

- https://confluence.atlassian.com/adminjiraserver/jira-data-center-monitoring-976770793.html (monitoring)

For a small number of projects (less or equal to 100) with 1,000 to 5,000 issues in total and about 100-200 users, a recent server (multicore CPU) with 8GB of available RAM and a reasonably fast hard drive (7200 rpm or faster) should cater for your needs. However, if you're using a 32-bit operating system, you shouldn't allocate more than 1GB of RAM to Jira. If you’re manually installing/upgrading Jira on a 32-bit system by using the archive, you need to decrease the maximum heap size available to Jira. See the upgrade notes for more information.


For 100 projects or more you should monitor Jira memory usage and allocate more memory if required. This is because each created project can create new workflows, new custom fields, new permissions schemes, new screens, etc.
	


diğer bir kaynak: https://subscription.packtpub.com/book/application_development/9781789802818/1/ch01lvl1sec12/system-requirements


It can be difficult at times to estimate these figures. As a reference, a server running with over 2.0 quad core CPU and 4 GB of RAM will be sufficient for most instances with around 200 active users. If you start to get into thousands of active users, you will need to have at least 8 GB of RAM allocated to Jira (JVM). Once you have gone beyond a million of issues and thousands of active users for a single Jira instance, simply adding raw system resources (vertical scaling) will start yield diminishing returns. In such cases, it is often better to consider using the data center edition of Jira, which offers better scalability by allowing you to have multiple instances clustered together (horizontal scaling), with the added benefit of providing high availability.


Officially, Jira only supports x86 hardware and 64-bit derivatives of it. When running Jira on a 64-bit system, you will be able to allocate more than 4 GB of memory to Jira, which is the limit if you are using a 32-bit system. If you are planning to deploy a large instance, it is recommended that you use a 64-bit system.


**insights plugin**
- https://documentation.mindville.com/display/INSSERV/Installation+Guide
- https://documentation.mindville.com/insight/latest/system-requirements-33466680.html
- https://wiki.softwareplant.com/display/DOCUMENTATION/BigPicture+Sizing+Guide


bu durumda tek başına jira için 4 core işlemci ve 8 ram en azından gemektedir. ayrıca tek başına 7200 rpm dik lazım


insigts için 10.000 asset için 2 core 4gb ram gerekşiyor ekstradan (100.000 için 8 ram)
big picture için fazaladan 2 core 4 ram gerekmektedir. 


4 core 8 ram 100 gb disk


### Bitbucket
--------------------

- https://confluence.atlassian.com/bitbucketserver/supported-platforms-776640981.html
- https://confluence.atlassian.com/bitbucketserver/scaling-bitbucket-server-776640073.html

databasse için

A very rough guideline is: 100 + ((total number of commits across all repositories) / 2500) MB.

So, for example, for 20 repositories with an average of 25,000 commits each, the database would need 100 + (20 * 25,000 / 2500) = 300MB.


- https://confluence.atlassian.com/bitbucketserver/install-bitbucket-data-center-872139817.html
- https://confluence.atlassian.com/bitbucketserver/supported-platforms-776640981.html


min için : Production: 2+ cores, You'll need at least 3GB available memory. We recommend 1GB for Bitbucket Server and an additional 2GB to support Git operations. 

peki üstünü nasıl belirleyeceğiz. : https://confluence.atlassian.com/bitbucketserver/scaling-bitbucket-server-776640073.html

- Add one CPU for every 2 concurrent clone operations. 
- allocate 1.5 x number of concurrent clone operations x min(repository size, 700MB) of memory.
- repositorylerin 1.5 kat ı kadar disk alanı



4 core 8 ram 100 gb disk


elasticsearch : https://www.elastic.co/guide/en/elasticsearch/reference/current/docker.html#docker-cli-run-prod-mode


### Crucible
---------------
artık yavaş yavaş marketten çekşiliyor

https://community.atlassian.com/t5/Fisheye-Crucible-questions/Recommended-hardware-for-big-Crucible-Fisheye-installation/qaq-p/209474
https://confluence.atlassian.com/crucible/fisheye-and-crucible-are-in-basic-maintenance-mode-987143986.html





### Bamboo
----------------

https://confluence.atlassian.com/bamboo/bamboo-best-practice-system-requirements-388401170.html


Multiple small teams/


Large team

- 20 - 100s plans
- Plan branches
- High concurrency
- Medium server use
- 8 core, 16 GB RAM, more remote agents


bu rakamlara bakıldığında aslında agent lara yüklenmek daha mantıklı görünüyor.


bamboo nu kendisine 4 core 8 ram verip. agent lara yüklenmelek örneğin 1 windows agent 8 core 16 ram, 1 linux agent 4 core 8 ram şeklinde.


yani toplamda 3 makin aolacak


- bamboo : 4 core 8 ram 100 gb disk
- 1 win agent : 8 core 16 ram
- 1 linux agent: 4 core 8 ram


### jenkins
-------------

burada da bamboo yu baz alıyoruz yani 4 core 8 ram 100 gb disk


### sonarqube
-------------

- https://docs.sonarqube.org/latest/requirements/hardware-recommendations/
- https://docs.sonarqube.org/latest/requirements/requirements/



sonarqube elastic search ile birlikte çalışıyor. 

bitbucket da aynı şekilde. bu nedenle bu ikisi için tek bir elasticsearch kurulup 150-200 gb lık bir disk takılsa yeterli olur.


Enterprise Hardware Recommendations


For large teams or Enterprise-scale installations of SonarQube, additional hardware is required. At the Enterprise level, monitoring your SonarQube instance is essential and should guide further hardware upgrades as your instance grows. 


A starting configuration should include at least:

- 8 cores, to allow the main SonarQube platform to run with multiple Compute Engine workers
- 16GB of RAM For additional requirements and recommendations relating to database and ElasticSearch, see Hardware Recommendations.


- buraya göre 8 core 16 ram demiş. 100 gb da disk olabilir. zaten elasticsearch u tek başına bitbucket ve burası için tek kurabiliriz. yinede dökümanlarına bakılabilir.
- dökümana göre sonarqube kendi container ı içinde elasitcsearch ı kuruyor : https://docs.sonarqube.org/latest/setup/install-server/
- bu durumda bitbucket için bir easltik ayrıca kurulacak

- elasticsearch : https://www.elastic.co/guide/en/elasticsearch/reference/current/docker.html#docker-cli-run-prod-mode


### Nexus3
-----------

https://help.sonatype.com/repomanager3/installation/system-requirements


8 Core 16 ram 16 Ram  750 gb


### Son Durumda

Proxy      : 4 core 4 ram 50 gb Disk >>>>> ssl offloading yapacak birde
Confluence : 4 Core 8 Ram 100 gb Disk >>>>>
Jira       : 4 Core 8 Ram 100 gb Disk / Insight için de extra 2 core 4 ram ve big picture için 2 core 4 ram bu durumda toplam 8 core 16 ram >>>>
Bitbucket  : 4 core 8 Ram 100 gb Disk >>>>
Bamboo     : 4 Core 8 Ram 100 gb Disk  >>>>>
Jenkins    : 4 Core 8 Ram 100 gb Disk  >>>>>
Win Agent  : 8 Core 16 Ram 500 gb Disk >>>>>
Lin Agent  : 4 Core 8 Ram 250 gb Disk >>>>>>
Sonarqube  : 8 Core 16 Ram 250 gb Disk (kendi içinde elasticsearch var)
Nexus 3    : 8 Core 16 Ram 750 gb Disk >>>>>

Veritabanı : 8 core, 24 ram 200 gb disk
Sentry     : 8 core 16 Ram 500 gb disk

Crucible   : bunun yerine ilerde araç bakılacak iki tanesi göze çarpıyor (Review Board, Gerrit)
Crowd      : bunun yerine de gerekirse ileride KeyCloak mantıklı görünüyor



Toplam     :72 Core 148 ram 2.800 TB



Makina isimlerinde devops benzeri bir kelime geçirilirse iyi olur


Database
- 1. Makina  : Postgres Veritabanı : 8 core, 24 ram 200 gb disk

Agents

- 2. makina  : Linux Agent:4 Core 8 Ram 250 gb Disk
- 3. Makina  : Win Agent: 8 Core 16 Ram 500 gb Disk

apps / her bir uygulamaya özel docker compose yazılabilir ve compose üzerinden updateleri de yapılabilir. Swarm yada Kubernetes kurulmayacak ileride gerekirse bu makinalar kullanılarak kurulabilir. 
Datacenter versiyonları da yine makina sayısı arttırılarak yada bu makinların kaynakları arttırılarak yapılabilir.

- 4. Makina  : Proxy: 4 core 4 ram 50 gb Disk
- 5. Makina  : Nexus3 - Jenkins - Bamboo 16 Core 32 Ram 1 TB Disk
- 6. Makina  : Confluence - Jira - Bitbucket 16 Core 32  Ram 500 GB Disk
- 7. Makina  : Sentry taşınacak 8 core 16 ram 500 gb disk   (4 core 8 ram 200 gb disk var ancak bu yetersiz yukarıda bahsedildiği gibi 8 core 16 ram 500 Disk Konulmalı - üzerinde sentry worker api, sentry ui app ve postgre vertabanı çalışıyor yani 3 uygulama ve exception loglama yapıyor.)



Test Makinası için

- Tek Makina : 32 core 64 ram 500 gb disk

Bütün DevOps uygulamlarının test ve UAT sunucuları burada olacak ayrıca Docker çalışmalarının da ArGe ve test işlemlerini bu sunucuda yönetiyor olacağız. 
Daha önceleri bu ortamlar vardı ancak hepsini geçen sürede kullanmak zorunda kaldık. Tek makina ile bütün test işlerini çözelim dedim yoksa onlarca makina açıp birçok firewall/VPN kural yazıyor olacağız. 

bu sunucu üzerinde en az 2 veritabanı, 10 üzeri sanal makina/container, 10 dan fazla uygulama kurulacak. bazen upgrade testleri yapılacak.






3 ve 4 nolu makinaları swarm yapıp alttaki konfigürasyonla sadece belli makinlarda çalışması sağlanabilir.

noda label ata:  https://docs.docker.com/engine/swarm/manage-nodes/

docker node update --label-add foo --label-add bar=baz node-1




sonrada noda servisi atıyoruz. (https://docs.docker.com/engine/swarm/services/)

 docker service create \
  --name my-nginx \
  --mode global \
  --constraint node.labels.region==east \
  --constraint node.labels.type!=devel \
  nginx




==============================================================================================================


### Tavsiye edilen donanımlar

Dökümanlara bakıldığında uygulamaların tek tek system gereksinimleri

1.  Proxy      : 4 core 4 ram 50 gb Disk
2.  Confluence : 4 Core 8 Ram 100 gb Disk
3.  Jira       : 8 Core 16 Ram 100 gb Disk / Insight için de extra 2 core 4 ram ve big picture için 2 core 4 ram bu durumda toplam 8 core 16 ram >>>>
4.  Bitbucket  : 4 core 8 Ram 100 gb Disk
5.  Git Elastic: 2 core 4 Ram 100 gb Disk
6.  Bamboo     : 4 Core 8 Ram 100 gb Disk
7.  Jenkins    : 4 Core 8 Ram 100 gb Disk
8.  Win Agent  : 8 Core 16 Ram 500 gb Disk
9.  Lnx Agent  : 4 Core 8 Ram 250 gb Disk
10. Sonarqube  : 8 Core 16 Ram 250 gb Disk (kendi içinde elasticsearch var)
12. Nexus 3    : 8 Core 16 Ram 750 gb Disk

12. Veritabanı : 4 Core 16 Ram 200 Gb Disk => ileride 8 core, 24 ram 200 gb disk
13. Sentry     : 8 core 16 Ram 500 gb disk (2 uygulama ve 1 vertabanından oluşuyor)

14. Crucible   : 4 Core 8 Ram 250 Gb Disk - bunun yerine ilerde araç bakılacak iki tanesi göze çarpıyor (Review Board, Gerrit)
15. Crowd      : 4 Core 8 Ram 100 Gb Disk 


Toplam         : 78 Core 160 ram 3450 TB


### Şöyle bir kurgu yapılabilir


Uyugulamalar için sunucu gereksinimleri aşağıdaki gibi belirlenmiştir.

Database için 

- 1. Makina  : Postgres Veritabanı=                     4 core 16 ram 200 gb disk (ileride arttırılabilir)

Agentlar için

- 2. Makina  : Linux Agent=                             4 Core 8 Ram 250 gb Disk
- 3. Makina  : Win Agent=                               8 Core 16 Ram 500 gb Disk

Uygulamalar için


- 4. Makina  : Sentry taşınacak =                       8 core 16 ram 500 gb disk   (4 core 8 ram 200 gb disk var ancak bu yetersiz yukarıda bahsedildiği gibi 8 core 16 ram 500 Disk Konulmalı - üzerinde sentry worker api, sentry ui app ve postgre veritabanı çalışıyor yani 3 uygulama ve exception loglama yapıyor.)

- 5. Makina  : Sonarqube =                              8 Core 16 Ram 250 gb Disk (kendi içinde elasticsearch var)

- 6. Makina  : Nexus3=                                  8 Core 16 Ram 500 Gb Disk ===> ileride arttırılabilir


- 7. Makina  : Proxy=                                   4 core 4 ram 50 gb Disk
- 8. Makina  : Bitbucket - Elastic - Jenkins Bamboo=    14 Core 28 Ram  400 Gb Disk
- 9. Makina  : Confluence - Jira=                       12 Core 24  Ram 200 GB Disk


Talep  Edilen Toplam:                                   70 Core 144 Ram 2 Tb 850 GB Disk



### Uygulama sistem gereksinimleri hakkında dökümanlar
------

Uygulamaların Requirement'ları hakkında dökümanlar.

- 1. HaProxy:              https://www.haproxy.com/documentation/hapee/latest/installation/getting-started/os-hardware/

- 2. Confluence (Wiki):    https://confluence.atlassian.com/doc/server-hardware-requirements-guide-30736403.html

- 3. Bitbucket (Git):      https://confluence.atlassian.com/bitbucketserver/supported-platforms-776640981.html
                           https://confluence.atlassian.com/bitbucketserver/scaling-bitbucket-server-776640073.html
                           
- 4. Bitbucket Elastic     (Üstteki Bitbucket Linklerine bakılabilir)

- 5. Bamboo:               https://confluence.atlassian.com/bamboo/bamboo-best-practice-system-requirements-388401170.html

- 6. Jenkins:              (Üstteki Bamboo dökümanına bakılabilir.)

- 7. Jira:                 https://confluence.atlassian.com/adminjiraserver/jira-applications-installation-requirements-938846826.html (Server-side requirements for production bölümüne bakınız)
                           https://confluence.atlassian.com/adminjiraserver/jira-data-center-monitoring-976770793.html (monitoring)
                           
- 8. Crowd:                https://community.atlassian.com/t5/Crowd-questions/Crowd-Hardware-Requirements/qaq-p/5396
                           https://community.atlassian.com/t5/Crowd-questions/Server-Capacity-required-for-Crowd-installation-on-separate/qaq-p/675079 (kendi dökünlarında yetyerli bilgi yok soru cevaplardan bilgilere ulaştım. Ancak çok kaynak yemediği söyleniyor)

- 9. Crucible:             https://community.atlassian.com/t5/Fisheye-Crucible-questions/Recommended-hardware-for-big-Crucible-Fisheye-installation/qaq-p/209474 (2014 yılı dökümanı, resmi dökümanında yeterli bilgi yok. soru cevaplardan bulabildim.

- 10.Sonarqube:            https://docs.sonarqube.org/latest/requirements/hardware-recommendations/
                           https://docs.sonarqube.org/latest/requirements/requirements/

- 11.Senty:                (dökümanları system gereksinimleri konusunda güncelleyecklerini söylemişler geçen eylülde ancak hiç bit yok şuan. kendi kullanımımıza göre karar verilecek)

- 12.Database:             Bütün uygulamaların minimum requirement'larına bakılabilir. Onların Toplamı olacak

- 13.Windows Agent:        (Kullanıma göre karar veriliyor)

- 14.Linux Agent:          Windows Agent ile aynı durumda sadece burada yük yarı yarıya daha düşük şuan için.

- 15.Nexus3:               https://help.sonatype.com/repomanager3/installation/system-requirements

















