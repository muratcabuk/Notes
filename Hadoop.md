
## SQL Data Access: 

#### Pig, Hive, Impala

## Data Storage:

#### HBase, Cassandra

## Interecation, Visualization, Execution, Development

#### HCatalog

#### Lucene

#### Hama

#### Crunch

## Data Serialization:

#### Avro, Thrift

## Data Intelligence:

#### Drill, Mohout, Spark ML

## Data Integration: 

#### Sqoop

#### Flume

#### Chuwka

#### Kafka: 

Burada dikkat edilmesi gereken önemli noktalardan birisi de Kafka'nın kullanım amacı. Büyük veriyi tutmak için değil bunları toplayıp ilgili sistemelere hatasız ve hızlı biçimde aktarmak için kullanılan bir mesajlaşma hizmeti olarak değerlendirmek daha doğru gibi. Bu sebeple çoğunlukla tek başına ele alınmamakta. Kafka'yı kullanarak verinin ElasticSearch, Hadoop, Spark gibi sistemlere akıtılması söz konusu. Bunun belli başlı motivasyon kaynakları var. Her şeyden önce ilgili verinin aktarılacağı sistemler kapalı olsa bile bir süre Kafka'da tutma imkanı bulunmakta. Bu yetenek uç sistemlerden birinin çökmesi durumunda mesaj kaybını da engellemekte. Diğer bir motivasyon sebebi de verinin büyüklüğü. Büyük veriyi diğer sistemlere taşırken paralel çalışabilen ölçeklenebilir bir dağıtık sistemin arada olması önemlidir.

## Management:

#### Ambari(Portal)

## Monitoring:

#### Zookeeper

## Orchestration:

#### Oozie

## security: 

#### Sentry

#### Knox

#### Ranger

## Real Time (Stream Data) Analysis

#### Kudu
Kudu is specifically designed for use cases that require fast analytics on fast (rapidly changing) data. Engineered to take advantage of next-generation hardware and in-memory processing, Kudu lowers query latency significantly for Apache Impala (incubating) and Apache Spark (initially, with other execution engines to come).

Kudu kaynakdan kurulum yaparken 

sudo ./kudu-master --fs_data_dirs="/opt/apache-kudu-1.8.0/fs/fsdatadirs/data1" --fs_wal_dir="/opt/apache-kudu-1.8.0/fs/fswaldir"

sudo ./kudu-tserver --fs_data_dirs="/opt/apache-kudu-1.8.0/fstserver/fsdatadirs/data1" --fs_wal_dir="/opt/apache-kudu-1.8.0/fstserver/fswaldir"

#### Flink

Flink is built to be both, a DataStream API for stream analytics and a DataSet API for batch analytics on top of the underlying stream processing engine.

Apache Flink supports programs written in Java or Scala, which get automatically compiled and optimized into data flow programs. Flink does not have its data storage system. The input data can come from a distributed storage system like HDFS or HBase. For data stream processing, Flink can consume data from message queues such as Kafka.

Spark processes data in batch mode while Flink processes streaming data in real time. Spark processes chunks of data, known as RDDs while Flink can process rows after rows of data in real time. So, while a minimum data latency is always there with Spark, it is not so with Flink.

#### Spark Streaming

Apache Spark, when combined with Apache Kafka, delivers a powerful stream processing environment.

#### Storm 

Apache Storm is a free and open source distributed realtime computation system. Storm makes it easy to reliably process unbounded streams of data, doing for realtime processing what Hadoop did for batch processing. Storm is simple, can be used with any programming language, and is a lot of fun to use!

Storm has many use cases: realtime analytics, online machine learning, continuous computation, distributed RPC, ETL, and more. Storm is fast: a benchmark clocked it at over a million tuples processed per second per node. It is scalable, fault-tolerant, guarantees your data will be processed, and is easy to set up and operate.

Storm integrates with the queueing and database technologies you already use. A Storm topology consumes streams of data and processes those streams in arbitrarily complex ways, repartitioning the streams between each stage of the computation however needed. Read more in the tutorial.

## Real Time (Stream Data) Data Collection And Ontegration

#### Flume

Flume is a distributed, reliable, and available service for efficiently collecting, aggregating, and moving large amounts of log data. It has a simple and flexible architecture based on streaming data flows. It is robust and fault tolerant with tunable reliability mechanisms and many failover and recovery mechanisms. It uses a simple extensible data model that allows for online analytic application.

#### Flink

Flink is built to be both, a DataStream API for stream analytics and a DataSet API for batch analytics on top of the underlying stream processing engine.

Apache Flink supports programs written in Java or Scala, which get automatically compiled and optimized into data flow programs. Flink does not have its data storage system. The input data can come from a distributed storage system like HDFS or HBase. For data stream processing, Flink can consume data from message queues such as Kafka.

## Download 

https://hadoop.apache.org/releases.html

## Multi Node Install

https://www.linode.com/docs/databases/hadoop/how-to-install-and-set-up-hadoop-cluster/

https://hadoop.apache.org/docs/r3.0.3/hadoop-project-dist/hadoop-common/ClusterSetup.html

http://gaurav3ansal.blogspot.com/2017/08/installing-hadoop-300-alpha-4-multi.html

https://www.tutorialspoint.com/hadoop/hadoop_multi_node_cluster.htm

https://www.linode.com/docs/databases/hadoop/how-to-install-and-set-up-hadoop-cluster/

https://medium.com/@rubenafo/some-tips-to-run-a-multi-node-hadoop-in-docker-9c7012dd4e26,

## Pseudo Cluster

https://blog.usejournal.com/hadoop-3-0-installation-on-ubuntu-18-04-step-by-step-pseudo-distributed-mode-2808f6b8e71f








