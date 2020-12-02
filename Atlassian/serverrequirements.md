## Requirement


### proxy
------------------
2 core 4 ram 50 gb disk


### veritabanı
------------------



### Confluence
-----------------

https://confluence.atlassian.com/doc/server-hardware-requirements-guide-30736403.html

- Accounts: 5,000
- Spaces: 500
- Pages
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


bu durumda tek başına jira için 4 core işlemci ve 8 ram en azından gemektedir. ayrıca tek başına 7200 rpm dik lazım


insigts için 10.000 asset için 4gb ram gerekşiyor ekstradan (100.000 için 8 ram)


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


 
