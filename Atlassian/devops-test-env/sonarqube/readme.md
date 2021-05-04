### INTRO

host da sudo ile lattki komut çalıştırıolmalı elastic search için gerekli

```
sudo sysctl -w vm.max_map_count=262144


```


sonarqube un tam olarar 8.0 versiyonunu kullanıyoruz.

https://docs.sonarqube.org/latest/setup/install-server/

3 tane volume istiyor

```
$> docker volume create --name sonarqube_data
$> docker volume create --name sonarqube_logs
$> docker volume create --name sonarqube_extensions
```

