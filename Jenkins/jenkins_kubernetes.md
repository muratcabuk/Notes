
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

