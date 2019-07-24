## KURULUM

### 1. java Kurulur

ubuntu için

sudo apt install openjdk-8-jdk

daha sonra .bashrc ye JAVA_HOME eklenir

sudo nano ~/.bashrc


export JAVA_HOME=/usr/lib/jvm/java-8-openjdk-amd64/
export PATH=$JAVA_HOME/bin:$PATH

### 2. IGNITE KURULUR

https://ignite.apache.org/download.cgi

bu linkte bütün versiyonlar var. biz ubuntu için deb paketini indiriyoruz.,

'''
sudo bash -c 'cat <<EOF > /etc/apt/sources.list.d/ignite.list
deb http://apache.org/dist/ignite/deb/ apache-ignite main
EOF'
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 379CE192D401AB61
sudo apt update

'''
