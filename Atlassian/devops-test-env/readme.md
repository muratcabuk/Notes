### INTRO

bütün sisitem için öncelikle bir bridge metwork oluşturulmalı.

```
$ docker network create \
  --driver=bridge \
  --subnet=192.168.0.0/16 \
  devopsbridge
```
