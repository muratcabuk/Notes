## KURULUM

### 1. java Kurulur

ubuntu için

sudo apt install openjdk-8-jdk

daha sonra .bashrc ye JAVA_HOME eklenir

sudo nano ~/.bashrc

```
export JAVA_HOME=/usr/lib/jvm/java-8-openjdk-amd64/
export PATH=$JAVA_HOME/bin:$PATH
```

tekrar yüklemek için

source  ~/.bashrc

### 2. IGNITE KURULUR

https://ignite.apache.org/download.cgi

bu linkte bütün versiyonlar var. biz ubuntu için deb paketini indiriyoruz.,

home kalsörünüzde olduğunuzu varsayarak.
```
mkdir ignite

sudo bash -c 'cat <<EOF > /etc/apt/sources.list.d/ignite.list deb http://apache.org/dist/ignite/deb/ apache-ignite main EOF'
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 379CE192D401AB61
sudo apt update
```
ve kurulum yapılır.

sudo apt install apache-ignite --no-install-recommends

kurulum sonrası oluşan kalsörler hakkında

https://apacheignite.readme.io/docs/rpm-and-deb-setup


|Folder|Mapped To|Description|
|------|---------|-----------|
|/usr/share/apache-ignite| |The root of Apache Ignite's installation|
|/usr/share/apache-ignite/bin||Bin folder (scripts and executables)|
|/etc/apache-ignite|/usr/share/apache-ignite/config|Default configuration files|
|/var/log/apache-ignite|/var/lib/apache-ignite/log|Log directory|
|/usr/lib/apache-ignite|/usr/share/apache-ignite/libs|Core and optional libraries|
|/var/lib/apache-ignite|/usr/share/apache-ignite/work|Ignite work directory|
|/usr/share/doc/apache-ignite| |Documentation|
|/usr/share/license/apache-ignite-<version>| |Licenses|
|/etc/systemd/system| |systemd service configuration|


daha sonra .bashrc ye IGNITE_HOME eklenir


sudo nano ~/.bashrc


```
export IGNITE_HOME=/usr/share/apache-ignite/
export PATH=$JAVA_HOME/bin:$PATH
```

tekrar yüklemek için

source  ~/.bashrc


## 3. Cluster Ayarları Yapılır


https://apacheignite.readme.io/docs/clustering

```
sudo nano  /etc/apache-ignite/default-config.xml

```
cluster ın discovery yapılabilmesi için 2 yöntem var. Zookeeper ve TCPIP, biz TCP yi tercih ediyoruz. İlgili sayfadan static Ip Finder kullanrak ip leri listeliyoruz



https://apacheignite.readme.io/docs/tcpip-discovery

```
<bean class="org.apache.ignite.configuration.IgniteConfiguration">
  ...
  <property name="discoverySpi">
    <bean class="org.apache.ignite.spi.discovery.tcp.TcpDiscoverySpi">
      <property name="ipFinder">
        <bean class="org.apache.ignite.spi.discovery.tcp.ipfinder.vm.TcpDiscoveryVmIpFinder">
          <property name="addresses">
            <list>
              <!-- 
              Explicitly specifying address of a local node to let it start and
              operate normally even if there is no more nodes in the cluster. 
              You can also optionally specify an individual port or port range.
              -->
              <value>1.2.3.4</value>
              
              <!-- 
              IP Address and optional port range of a remote node.
              You can also optionally specify an individual port.
              -->
              <value>1.2.3.5:47500..47509</value>
            </list>
          </property>
        </bean>
      </property>
    </bean>
  </property>
</bean>

```
__Shell ile de aşağıdaki şekile yapılabilir__

```
# The configuration should use TcpDiscoveryVmIpFinder without addresses specified:

IGNITE_TCP_DISCOVERY_ADDRESSES=1.2.3.4,1.2.3.5:47500..47509 bin/ignite.sh -v config/default-config.xml
```





### __Apache Ignite Web Console__

https://apacheignite-tools.readme.io/docs/build-and-deploy

### __Python Örnekleri__

https://github.com/apache/ignite/tree/master/modules/platforms/python/examples










 




