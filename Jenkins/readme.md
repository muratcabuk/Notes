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


**yöntem2**

1. dfd
2. dfdf
3. sdfdsf
4. sdfsdfds



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

### kubernets

https://www.jenkins.io/doc/pipeline/steps/kubernetes/

https://github.com/jenkinsci/kubernetes-plugin



kubernettes için jankins makinasında alttaki işlemler yapılmalı







**Kısıtlı yetkili kullanıcı oluşturma**

jenkins agent kurulu makinamızda jenkins kullanıcısı ile kubernetes e işlemler yapabilmek amacıyla user, role ve rolebinding oluştturuyoru.


amacımız jenkinsin listedeğki objeleri  yöntebilceği bir kullanıcı oluşturmak.

- Pod
- Service
- Volume
- Deployment
- DaemonSet
- StatefulSet
- ReplicaSet
- Job


oluşturağımız kullanıcı sadece default ve testnamespace inde yettki olacak.

 Daha sonra bu kullanıcıyı agent makinasına kuracağımız kubectl ile ve jenkins kullanıcının home klasörüne oluşturacağımz .kube klasörü altındaki config doyasınuı kullanrak yetkilendireceğiz.


 çalışmada listeki libkler kullanıldı
 - https://kubernetes.io/docs/reference/access-authn-authz/authentication/

- https://docs.bitnami.com/tutorials/configure-rbac-in-your-kubernetes-cluster/


1. **testnamespace ini oluşturuyoruz**

```
$ kubectl create namespace testnamespace
```

2. **kullanıcı hesabı oluşturuyoruz**

jenkins kullanıcısı için  private key oluşturuyoruz

```
$ sudo -u jenkins openssl genrsa -out jenkins.key 2048
```

daha sonra key i kullanarak certificate sign request oluştturuyoruz.

```
$ sudo -u jenkins openssl req -new -key jenkins.key -out jenkins.csr -subj "/CN=jenkins"
```

son olarak crt uzantılı sertifikamızı oluşturuyoruz. Ancak tam bu noktoda Ca.crt ve Ca.key dosyalrına ihtiyacımız olacak. bu dosyaların altt6aki komutun çalıştırıldığı klasörde olduğunu varsayıyoruz.

```
$ sudo -u jenkins openssl x509 -req -in jenkins.csr -CA ca.crt -CAkey ca.key -CAcreateserial -out jenkins.crt -days 3600
```

son olarak bu sertifikarı config dosylarımıza cedential ve context set ederek tanımlıyoruz.ancak şuna dikkat edilmeli bu iki crt ve key uzantılı dosya jenkins home klasöründe olmalı ve jenkins jkullanıcısı yetkili olmalı ayrıca eğer bu işlemler jenkins kullanıcısı dışında bir kullanısıyla yapılıyorsa "sudo " prefix kullanılarak komutlar yazılmalı.

eğer jenkins dışında bir kullanıcı ile yapıyorsak

```
$ sudo kubectl config set-credentials jenkins --client-certificate=jenkins.crt  --client-key=jenkins.key --kubeconfig=.kube/config --user=jenkins

$ sudo kubectl config set-context jenkins-context --cluster=cluster.local --user=jenkins --kubeconfig=.kube/config
```

olurda hata yapılırsa user ve context silmek için

```
$ sudo kubectl config unset users.jenkins --client-certificate=jenkins.crt  --client-key=jenkins.key --kubeconfig=.kube/config --user=jenkins
$ sudo kubectl config unset contexts.jenkins-context --cluster=cluster.local --user=jenkins --kubeconfig=.kube/config
```



test etmek için 
```
$ sudo kubectl get pod --client-certificate=jenkins.crt  --client-key=jenkins.key --kubeconfig=.kube/config --user=jenkins --context=jenkins-context
```

testt sonucu beklenildiği gibi 

```
Error from server (Forbidden): pods "jenkins" is forbidden: User "jenkins" cannot get resource "pods" in API group "" in the namespace "default"

```


çünki bu kullanıcı için bir yetki ttanımlaması yapmamıştık.


3. **role oluşturuyoruz**

files klasöründeki yaml dosyası role-deployment-manager-testnamespace.yaml 


burada görüldüğü üzere role üzerinde namespace kısıttlamaı yapılmış. eğer burada değilde aşağıda role-binding üzerinde bu kısıtlama yapılıp birden fazla role de bu rolebinding kullanılarak namespave kısıtlaması da yapılabilir. örnek kullanım için [link](https://kubernetes.io/docs/reference/access-authn-authz/rbac/#rolebinding-example).

birde şuna dikkat emek lazım bu bir role, clusterRole değil. eğer öyle olsaydı namespacve kısıtlaması zaten garip olurdu. zaten yapılamıyorda.

- https://unofficial-kubernetes.readthedocs.io/en/latest/admin/authorization/rbac/
- https://docs.bitnami.com/tutorials/configure-rbac-in-your-kubernetes-cluster/
- https://medium.com/faun/kubernetes-rbac-use-one-role-in-multiple-namespaces-d1d08bb08286 (use one Role in multiple namespaces)

ayrıca bu sadece testnamespace için bir role birde default için lazım. oda failes klasörü altında

```yaml
kind: Role
apiVersion: rbac.authorization.k8s.io/v1beta1
metadata:
  namespace: testnamespace
  name: deployment-manager-testnamespace
rules:
- apiGroups: ["", "extensions", "apps"]
  resources: ["deployments", "replicasets", "pods","services","volumes","replicasets","jobs"]
  verbs: ["get", "list", "watch", "create", "update", "patch", "delete"] # You can also use ["*"]

```

bu iki role ude deploy ediyoruz.

```
$ kubectl create -f role-deployment-manager-testnamespace.yaml
$ kubectl create -f role-deployment-manager-default.yaml


```

4. **RoleBinding create ediyoruz**

roleRef tanımı array tipinde olmadığı için API dökünalarından kontrol edilebilir. mecburen 2 tane rolebinding oluşturduk. aslında burada namespace tanıumına gerek yok çünki role tanımında zaten vardı. tek doya içine iki tanım yaptık.

```
kind: RoleBinding
apiVersion: rbac.authorization.k8s.io/v1beta1
metadata:
  name: deployment-manager-testnamespace-binding
  namespace: testtnamespace
subjects:
- kind: User
  name: jenkins
  apiGroup: ""
roleRef:
  kind: Role
  name: deployment-manager-testnamespace
  apiGroup: ""
---
kind: RoleBinding
apiVersion: rbac.authorization.k8s.io/v1beta1
metadata:
  name: deployment-manager-default-binding
  namespace: default
subjects:
- kind: User
  name: jenkins
  apiGroup: ""
roleRef:
  kind: Role
  name: deployment-manager-default
  apiGroup: ""
```

yaml dosyasını çalıştırıyorus


```
$ kubectl create -f rolebinding-deployment-manager.yaml
```

şimdi tekrar ttest tediyoruz. jenkins makinamızda


namespace pelirttmediğimiz için default da yapmş olacak.

```
$ sudo kubectl get pod --client-certificate=jenkins.crt  --client-key=jenkins.key --kubeconfig=.kube/config --user=jenkins --context=jenkins-context
```


sonuç oılarak pod lar listelenmiş olacak.












