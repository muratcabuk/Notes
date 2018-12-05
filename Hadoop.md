## Teknolojiler

### Data Access: 

#### Pig, Hive

### Data Storage:

#### HBase, Cassandra

### Interecation, Visualization, Execution, Development : HCatalog, Lucene, Hama, Crunch

### Data Serialization:

#### Avro, Thrift

### Data Intelligence:

#### Drill, Mohout, Spark ML

### Data Integration: 

Sqoop, Flume, Chuwka, Kafka

#### Kafka: Burada dikkat edilmesi gereken önemli noktalardan birisi de Kafka'nın kullanım amacı. Büyük veriyi tutmak için değil bunları toplayıp ilgili sistemelere hatasız ve hızlı biçimde aktarmak için kullanılan bir mesajlaşma hizmeti olarak değerlendirmek daha doğru gibi. Bu sebeple çoğunlukla tek başına ele alınmamakta. Kafka'yı kullanarak verinin ElasticSearch, Hadoop, Spark gibi sistemlere akıtılması söz konusu. Bunun belli başlı motivasyon kaynakları var. Her şeyden önce ilgili verinin aktarılacağı sistemler kapalı olsa bile bir süre Kafka'da tutma imkanı bulunmakta. Bu yetenek uç sistemlerden birinin çökmesi durumunda mesaj kaybını da engellemekte. Diğer bir motivasyon sebebi de verinin büyüklüğü. Büyük veriyi diğer sistemlere taşırken paralel çalışabilen ölçeklenebilir bir dağıtık sistemin arada olması önemlidir.

### Management:

#### Ambari(Portal)

### Monitoring:

#### Zookeeper

### Orchestration:

#### Oozie

### security: 

#### Sentry, Knox, Ranger

### Download 

https://hadoop.apache.org/releases.html

Multi Node Install

https://www.linode.com/docs/databases/hadoop/how-to-install-and-set-up-hadoop-cluster/

https://hadoop.apache.org/docs/r3.0.3/hadoop-project-dist/hadoop-common/ClusterSetup.html

http://gaurav3ansal.blogspot.com/2017/08/installing-hadoop-300-alpha-4-multi.html

https://www.tutorialspoint.com/hadoop/hadoop_multi_node_cluster.htm

https://www.linode.com/docs/databases/hadoop/how-to-install-and-set-up-hadoop-cluster/

https://medium.com/@rubenafo/some-tips-to-run-a-multi-node-hadoop-in-docker-9c7012dd4e26,



Pseudo Cluster

https://blog.usejournal.com/hadoop-3-0-installation-on-ubuntu-18-04-step-by-step-pseudo-distributed-mode-2808f6b8e71f


Kudu

Kudu kaynakdan kurulum yaparken 

sudo ./kudu-master --fs_data_dirs="/opt/apache-kudu-1.8.0/fs/fsdatadirs/data1" --fs_wal_dir="/opt/apache-kudu-1.8.0/fs/fswaldir"

sudo ./kudu-tserver --fs_data_dirs="/opt/apache-kudu-1.8.0/fstserver/fsdatadirs/data1" --fs_wal_dir="/opt/apache-kudu-1.8.0/fstserver/fswaldir"






