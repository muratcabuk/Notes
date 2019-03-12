
https://www.youtube.com/watch?v=DidEZ6qbcbI&list=PLh9ECzBB8tJOFZwrh12DAYIhy0oz3FR-s

## SQL Data Access: 

#### Pig, Hive, Impala


Impala Comparing Impala to Hive & Pig

- Similarities:
 -- Queries expressed in high-level languages
 
 -- Alternatives to writting mapreduce code
 
 -- Used to analyze data stored on Hadoop clusters
 
 -- Impala shares the meta store with Hive (Tables created in Hive as visible in Impala (viceversa))

- Contrasting Impala to Hive & Pig

 -- Hive & Pig answers queries by running Mapreduce jobs.Map reduce over heads results in high latency.(even a trivial query takes 10sec or more)
 
 -- Impala does not use mapreduce.It uses a custom execution engine build specifically for Impala.
 
 -- Queries can complete in a fraction of sec.
 
 -- Hive & Pig are best suited long-running batch processes (Data Transformation Tasks).Impala best for interactive/Adhoc queries.
 
 -- Impala can't handle complex data types(Array,Map or Struct)
 
 -- No support for binary data type.
 
 -- If a node fails in Hive or Pig, They answers queries by running mapreduce jobs in other nodes. But,incase of impala if the node fails during a query,the query will fails and it has to be re-run


## Data Storage:

#### Apache Ignite (Database and Caching Platform)
Ignite™ is a memory-centric distributed database, caching, and processing platform for  transactional, analytical, and streaming workloads delivering in-memory speeds at petabyte scale.

Achieve horizontal scalability, strong consistency, and high availability with Ignite™ distributed SQL.


#### HBase (NoSQL Database - Column Base)

Use Apache HBase™ when you need random, realtime read/write access to your Big Data. This project's goal is the hosting of very large tables -- billions of rows X millions of columns -- atop clusters of commodity hardware. Apache HBase is an open-source, distributed, versioned, non-relational database modeled after Google's Bigtable: A Distributed Storage System for Structured Data by Chang et al. Just as Bigtable leverages the distributed data storage provided by the Google File System, Apache HBase provides Bigtable-like capabilities on top of Hadoop and HDFS.

https://www.scnsoft.com/blog/cassandra-vs-hbase

#### Cassandra  (NoSQL Database - Column Base)

Apache Cassandra is a free and open-source, distributed, wide column store, NoSQL database management system designed to handle large amounts of data across many commodity servers, providing high availability with no single point of failure. Cassandra offers robust support for clusters spanning multiple datacenters, with asynchronous masterless replication allowing low latency operations for all clients.

https://www.scnsoft.com/blog/cassandra-vs-hbase


#### HCatalog

HCatalog is a table and storage management layer for Hadoop that enables users with different data processing tools — Pig, MapReduce — to more easily read and write data on the grid.

#### Lucene/Solr

There is but one tool for indexing large blocks of unstructured text, and it’s a natural partner for Hadoop. Written in Java, Lucene integrates easily with Hadoop, creating one big tool for distributed text management. Lucene handles the indexing; Hadoop distributes queries across the cluster.

#### Hama

Apache HamaTM is a framework for Big Data analytics which uses the Bulk Synchronous Parallel (BSP) computing model, which was established in 2012 as a Top-Level Project of The Apache Software Foundation. 

#### Crunch

## Data Serialization - RPC

#### Thrift

The Apache Thrift software framework, for scalable cross-language services development, combines a software stack with a code generation engine to build services that work efficiently and seamlessly between C++, Java, Python, PHP, Ruby, Erlang, Perl, Haskell, C#, Cocoa, JavaScript, Node.js, Smalltalk, OCaml and Delphi and other languages.

#### Avro

Apache Avro™ is a data serialization system.

Avro provides:

- Rich data structures.
- A compact, fast, binary data format.
- A container file, to store persistent data.
- Remote procedure call (RPC).
- Simple integration with dynamic languages. Code generation is not required to read or write data files nor to use or implement RPC protocols. Code generation as an optional optimization, only worth implementing for statically typed languages.

Comparison with other systems

Avro provides functionality similar to systems such as Thrift, Protocol Buffers, etc. Avro differs from these systems in the following fundamental aspects.

- Dynamic typing: Avro does not require that code be generated. Data is always accompanied by a schema that permits full processing of that data without code generation, static datatypes, etc. This facilitates construction of generic data-processing systems and languages.
- Untagged data: Since the schema is present when data is read, considerably less type information need be encoded with data, resulting in smaller serialization size.
- No manually-assigned field IDs: When a schema changes, both the old and new schema are always present when processing data, so differences may be resolved symbolically, using field names.
- Apache Avro, Avro, Apache, and the Avro and Apache logos are trademarks of The Apache Software Foundation.



## Data Intelligence and Analysis

https://dzone.com/articles/big-data-ingestion-flume-kafka-and-nifi

#### Drill

Drill supports a variety of NoSQL databases and file systems, including HBase, MongoDB, MapR-DB, HDFS, MapR-FS, Amazon S3, Azure Blob Storage, Google Cloud Storage, Swift, NAS and local files. A single query can join data from multiple datastores. For example, you can join a user profile collection in MongoDB with a directory of event logs in Hadoop.

Drill's datastore-aware optimizer automatically restructures a query plan to leverage the datastore's internal processing capabilities. In addition, Drill supports data locality, so it's a good idea to co-locate Drill and the datastore on the same nodes.

#### Mohout

Apache Mahout(TM) is a distributed linear algebra framework and mathematically expressive Scala DSL designed to let mathematicians, statisticians, and data scientists quickly implement their own algorithms. Apache Spark is the recommended out-of-the-box distributed back-end, or can be extended to other distributed backends.

- Mathematically Expressive Scala DSL
- Support for Multiple Distributed Backends (including Apache Spark)
- Modular Native Solvers for CPU/GPU/CUDA Acceleration

#### Spark ML

MLlib fits into Spark's APIs and interoperates with NumPy in Python (as of Spark 0.9) and R libraries (as of Spark 1.5). You can use any Hadoop data source (e.g. HDFS, HBase, or local files), making it easy to plug into Hadoop workflows.

## Data Integration: 

#### Sqoop

Apache Sqoop(TM) is a tool designed for efficiently transferring bulk data between Apache Hadoop and structured datastores such as relational databases.

#### Flume (Real Time Data)

Flume is a distributed, reliable, and available service for efficiently collecting, aggregating, and moving large amounts of log data. It has a simple and flexible architecture based on streaming data flows. It is robust and fault tolerant with tunable reliability mechanisms and many failover and recovery mechanisms. It uses a simple extensible data model that allows for online analytic application.

#### Chuwka

Apache Chukwa is an open source data collection system for monitoring large distributed systems. Apache Chukwa is built on top of the Hadoop Distributed File System (HDFS) and Map/Reduce framework and inherits Hadoop’s scalability and robustness. Apache Chukwa also includes a ﬂexible and powerful toolkit for displaying, monitoring and analyzing results to make the best use of the collected data.

Chukwa is a Hadoop subproject that bridges that gap between log handling and MapReduce. It provides a scalable distributed system for monitoring and analysis of log-based data. Some of the durability features include agent-side replying of data to recover from errors. See also Flume.

Large scale log aggregator, and analytics.

#### Kafka: 

Burada dikkat edilmesi gereken önemli noktalardan birisi de Kafka'nın kullanım amacı. Büyük veriyi tutmak için değil bunları toplayıp ilgili sistemelere hatasız ve hızlı biçimde aktarmak için kullanılan bir mesajlaşma hizmeti olarak değerlendirmek daha doğru gibi. Bu sebeple çoğunlukla tek başına ele alınmamakta. Kafka'yı kullanarak verinin ElasticSearch, Hadoop, Spark gibi sistemlere akıtılması söz konusu. Bunun belli başlı motivasyon kaynakları var. Her şeyden önce ilgili verinin aktarılacağı sistemler kapalı olsa bile bir süre Kafka'da tutma imkanı bulunmakta. Bu yetenek uç sistemlerden birinin çökmesi durumunda mesaj kaybını da engellemekte. Diğer bir motivasyon sebebi de verinin büyüklüğü. Büyük veriyi diğer sistemlere taşırken paralel çalışabilen ölçeklenebilir bir dağıtık sistemin arada olması önemlidir.

Kafka vs Flink

The fundamental differences between a Flink and a Streams API program lie in the way these are deployed and managed and how the parallel processing including fault tolerance is coordinated.

Flink is a cluster framework, which means that the framework takes care of deploying the application, either in standalone Flink clusters, or using YARN, Mesos, or containers (Docker, Kubernetes).


#### Nifi
Unlike Flume and Kafka, NiFi. can handle messages with arbitrary sizes. Behind a drag-and-drop Web-based UI, NiFi runs in a cluster and provides real-time control that makes it easy to manage the movement of data between any source and any destination. It supports disparate and distributed sources of differing formats, schema, protocols, speeds, and sizes.


## Management:

#### Cloudera Management

#### Ambari(Portal)

## Monitoring, Orchestration and Scheduler

#### Zookeeper

Orchestration Tool

ZooKeeper is a centralized service for maintaining configuration information, naming, providing distributed synchronization, and providing group services. All of these kinds of services are used in some form or another by distributed applications. Each time they are implemented there is a lot of work that goes into fixing the bugs and race conditions that are inevitable. Because of the difficulty of implementing these kinds of services, applications initially usually skimp on them ,which make them brittle in the presence of change and difficult to manage. Even when done correctly, different implementations of these services lead to management complexity when the applications are deployed.

#### Oozie

Oozie is a workflow scheduler system to manage Apache Hadoop jobs.

Oozie Workflow jobs are Directed Acyclical Graphs (DAGs) of actions.

Oozie Coordinator jobs are recurrent Oozie Workflow jobs triggered by time (frequency) and data availability.

Oozie is integrated with the rest of the Hadoop stack supporting several types of Hadoop jobs out of the box (such as Java map-reduce, Streaming map-reduce, Pig, Hive, Sqoop and Distcp) as well as system specific jobs (such as Java programs and shell scripts).

## security: 

#### Sentry

#### Knox

#### Ranger

## Real Time (Stream Data) Analysis

#### Kudu (NoSQL Database - Column Base)
Kudu is specifically designed for use cases that require fast analytics on fast (rapidly changing) data. Engineered to take advantage of next-generation hardware and in-memory processing, Kudu lowers query latency significantly for Apache Impala (incubating) and Apache Spark (initially, with other execution engines to come).

Kudu kaynakdan kurulum yaparken 

sudo ./kudu-master --fs_data_dirs="/opt/apache-kudu-1.8.0/fs/fsdatadirs/data1" --fs_wal_dir="/opt/apache-kudu-1.8.0/fs/fswaldir"

sudo ./kudu-tserver --fs_data_dirs="/opt/apache-kudu-1.8.0/fstserver/fsdatadirs/data1" --fs_wal_dir="/opt/apache-kudu-1.8.0/fstserver/fswaldir"

#### Flink

Flink is built to be both, a DataStream API for stream analytics and a DataSet API for batch analytics on top of the underlying stream processing engine.

Apache Flink supports programs written in Java or Scala, which get automatically compiled and optimized into data flow programs. Flink does not have its data storage system. The input data can come from a distributed storage system like HDFS or HBase. For data stream processing, Flink can consume data from message queues such as Kafka.

Spark Stream vs Flink

Spark processes data in batch mode while Flink processes streaming data in real time. Spark processes chunks of data, known as RDDs while Flink can process rows after rows of data in real time. So, while a minimum data latency is always there with Spark, it is not so with Flink.

Kafka vs Flink

The fundamental differences between a Flink and a Streams API program lie in the way these are deployed and managed and how the parallel processing including fault tolerance is coordinated.

Flink is a cluster framework, which means that the framework takes care of deploying the application, either in standalone Flink clusters, or using YARN, Mesos, or containers (Docker, Kubernetes).

#### Spark Streaming

Apache Spark, when combined with Apache Kafka, delivers a powerful stream processing environment.

Spark Stream vs Flink

Spark processes data in batch mode while Flink processes streaming data in real time. Spark processes chunks of data, known as RDDs while Flink can process rows after rows of data in real time. So, while a minimum data latency is always there with Spark, it is not so with Flink.

#### Storm 

Apache Storm is a free and open source distributed realtime computation system. Storm makes it easy to reliably process unbounded streams of data, doing for realtime processing what Hadoop did for batch processing. Storm is simple, can be used with any programming language, and is a lot of fun to use!

Storm has many use cases: realtime analytics, online machine learning, continuous computation, distributed RPC, ETL, and more. Storm is fast: a benchmark clocked it at over a million tuples processed per second per node. It is scalable, fault-tolerant, guarantees your data will be processed, and is easy to set up and operate.

Storm integrates with the queueing and database technologies you already use. A Storm topology consumes streams of data and processes those streams in arbitrarily complex ways, repartitioning the streams between each stage of the computation however needed. Read more in the tutorial.

## Real Time (Stream Data) Data Collection And Ontegration

#### Flume (Data Ingestion )

Flume is a distributed, reliable, and available service for efficiently collecting, aggregating, and moving large amounts of log data. It has a simple and flexible architecture based on streaming data flows. It is robust and fault tolerant with tunable reliability mechanisms and many failover and recovery mechanisms. It uses a simple extensible data model that allows for online analytic application.

#### Flink

Flink is built to be both, a DataStream API for stream analytics and a DataSet API for batch analytics on top of the underlying stream processing engine.

Apache Flink supports programs written in Java or Scala, which get automatically compiled and optimized into data flow programs. Flink does not have its data storage system. The input data can come from a distributed storage system like HDFS or HBase. For data stream processing, Flink can consume data from message queues such as Kafka.

#### Nifi
Unlike Flume and Kafka, NiFi. can handle messages with arbitrary sizes. Behind a drag-and-drop Web-based UI, NiFi runs in a cluster and provides real-time control that makes it easy to manage the movement of data between any source and any destination. It supports disparate and distributed sources of differing formats, schema, protocols, speeds, and sizes.


### Links

https://data-flair.training/blogs/hadoop-ecosystem-components/

https://www.edureka.co/blog/hadoop-ecosystem

https://hadoopecosystemtable.github.io/

https://bigdata-madesimple.com/20-essential-hadoop-tools-for-crunching-big-data/

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




## Türkçe Kaynaklar


https://www.b3lab.org/zookeeper-nedir/





http://www.borakasmer.com/net-coreda-elasticsearch/













