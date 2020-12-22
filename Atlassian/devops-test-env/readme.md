### INTRO

bütün sisitem için öncelikle bir bridge metwork oluşturulmalı.

```
$ docker network create \
  --driver=bridge \
  --subnet=10.200.0.0/16 \
  devopsbridge
```
