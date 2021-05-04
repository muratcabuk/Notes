### INTRO

jenkins i kurmadan önce jenkins adında bir kullanıcıyı host da açıp docker grubuna dail etmek gerekiyor.

kurulumm için yapılması gereken öz hazırlıklar için alttaki linke bakınız. amacımız full yetkşi vermeden jenkins i docker oarka kurmak
* https://github.com/muratcabuk/DockerTutorial/tree/master/RegisteryRepository#jenkins-kurulumu

- jenkins version : Jenkins 2.235.3

- jenkins_home

alttaki linkteki nginx için default.conf dosyası oluşturuldu. Ancak bu conf dosyasını kullanmadık. dah sade olanı nginx docker-compose dosyasında mevcut.

https://www.jenkins.io/doc/book/system-administration/reverse-proxy-configuration-nginx/