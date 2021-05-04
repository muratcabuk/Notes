DOcker kurarken muklaka kullanıcılar docker grubuna dahil edilmeli ve docker root olmadan çalıştıurılmalı 


örnek sayfa


https://docs.docker.com/engine/install/linux-postinstall/

ve docker üzerinde işlme yapacak tüm kullanıcılar docker grubuna dahil edilmeli


docker ve jenkins üzerine 8 derslik blog. resimli anlatım

https://technology.riotgames.com/news/thinking-inside-container




### Kurulum

kurulum yaparken kesinlikle jankins kullanıcısı kullanılmalı.

docker kurlumunda da zaten host üzerine persitanat volume mount edilirken jenkins kullanıcısı veya (uid) si kullanılmalı. yoksa persisttant volume yazılamıyor. docker container içinde de jenkins kullanıcısı olduğu içi çakuşma yaparsa uid kullanılmalı zaten.



credetials kaydederken username password tipinde olamayan credetials lar combobox larda listelenmez. bunu sağlamak için

- https://blog.plee.me/2019/06/missing-credentials-in-dropdown-for-jenkins-build-configuration/#:~:text=In%20it%2C%20the%20following%20solution,was%20the%20case%20for%20me)

- https://github.com/jenkinsci/ghprb-plugin/issues/534#issuecomment-409347028

**yöntem 1**

1. Navigate to "Jenkins" (main menu) => "Manage Jenkins" => "Configure Global Security"
2. Go to the "Access Controls for Builds" section
3. Under "Project default Build Authorization" check if the "Strategy" is set to "Run as anonymous" (which was the case for me)
4. If yes, try changing it to "Run as User who Triggered Build" (it might also work with another setting if that suits you better)
5. Save and reload the build configuration settings


jenkinsi safe restart etmek için (jenkins_url)/safeRestart adresi çağırmak yeterli


### Jenkins kurulumu

docker hub da dikkat edilmeli yanlışlıkla sadece jenkins yazan image ları yükleme. Onlar deprecated artık yeni imaje larda jenkins/jenkins yazıyor. 

birde jebkins in yeni nesil UI i ve pipeline işlettme şekli olan blue ocean versiyonu var. onun registery adrsi farklı ve clasiğe göre bazı farklılıkları olduğı için niz clasik olan versiyonu yüklüyoruz.


jenkins makinasına aynı zamanda docker kurmuş olmalıyız zaen nexus u kurarken kullandığımız versionu jenkins makinaısnada kurduğumuz varsayıyoruz

```
$ adduser jenkins
$ cat /etc/passwd | grep jenkins

# sonuç

jenkins:x:1001:1001::/home/jenkins:/bin/bash

```
daha sonra bu id yi altta kullanacağız

birde var altıda jenkins_home diye bir klasör açıyoruz.




daha sonra log kısmını ayarlıyoruz

```
$ sudo -u jenkins cat > /var/jenkins_home/log.properties <<EOF
handlers=java.util.logging.ConsoleHandler
jenkins.level=FINEST
java.util.logging.ConsoleHandler.level=FINEST
EOF

```
klasöürn içindekilerle birlikte sahibini jenkins kullanıcısı yapıyoruz

```
$ sudo chown -R 1001:1001 /var/jenkins_home
```





```
$ sudo docker run --name myjenkins --restart unless-stopped -d -u 1001 -p 8080:8080 -p 50000:50000 --env JAVA_OPTS="-Djava.util.logging.config.file=/var/jenkins_home/log.properties" -v /var/jenkins_home:/var/jenkins_home jenkins/jenkins:2.249.1-lts-centos7
```

-d detach mode demektir, --rm stop olan container ı siler

eğer restart sttrategy belirlemediysek daha sonra bütün containerlarıda elle stop edilcene kadar restart etmesini sağlaycak kod

```
$  sudo docker update --restart unless-stopped $(sudo docker ps -q)

```



password için artık host makinasında alttaki komutu çalıştırabiliriz.

```
$ sudo cat /var/jenkins_home/secrets/initialAdminPassword
```


### service olarka çalışitırmak için

 /etc/systemd/system/jenkins-agent.service

```
[Unit]
Description=Jenkins Agent Service
After=network.target
After=systemd-user-sessions.service
After=network-online.target

[Service]
User=jenkins
# Type=simple
# PIDFile=/run/my-service.pid
ExecStart=/usr/bin/java -jar /home/jenkins-agent/agent.jar -jnlpUrl http://10.0.1.9:8080/computer/dockerhost/slave-agent.jnlp -s$
# ExecReload=/home/transang/startup.sh reload
# ExecStop=/home/transang/startup.sh stop
# TimeoutSec=30
Restart=always
RestartSec=30
StartLimitInterval=0
# StartLimitBurst=10

[Install]
WantedBy=multi-user.target
```


### grekli pluginlrt

- **github pull requestler için plugin**

https://plugins.jenkins.io/ghprb/

http://blog.pontificae.com/2018/10/23/ghprb-setup/

- GitHub Pull Request Builder


**kullanırken aşağıdaki gibi yapılmalı**

- Under Advanced, set Name to origin 
- branch seçimi için : ${sha1}
- refspec için : +refs/pull/*:refs/remotes/origin/pr/*
- build trigger da GitHub Pull Request Builder seç ve admin listesine github dan kullanıcı ekle




### Docker komutları build ve register için

docker kurulu olan agent da nexuss 3 private registery ye login olunduktan sonra home altında ki admin kullanıcısının alıdna yer alan .docker klasöründeki config.json dosyasını /home/jenkins alrıdna açılacak olan .docker klasörüne koyapalanmalı.


Build alırken tag atmak

privatereg.com:5000 daha önce docker tarafında  login olunmuş private registery adresi

version kısmı parametre olarak alınıp jenkinde rapametre olarka da docker komutuna eklenebilir.


```
$ docker build -t privatereg.com:5000/kubernetes:v1.0.0

```

Örnek parametrik taglemek. Dockerfile klasörünün olduğu yerde olmalıyız tabii ki.

```
$ docker build -t privatereg.com:5000/kubernetes:${version}

```

path belirterek docker build

```
docker build "${WORKSPACE}/samples/aspnetapp" -t privatereg.com:5000/kubernetes:${Versiyon}
```


birden  fazla tag atmak için

```
$ docker build -t whenry/fedora-jboss:latest -t whenry/fedora-jboss:v2.1

```


build alınmış bir docker image ı taglemek

```
$ docker tag aspnetapp:latest privatereg.com:5000/aspnetapp:v1.0.0

```
image ı deploy etmek

```
$ docker push privatereg.com:5000/aspnetapp:1.0.0
```
