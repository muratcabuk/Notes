### INTRO

bütün sisitem için öncelikle bir bridge metwork oluşturulmalı.

```
$ docker network create \
  --driver=bridge \
  --subnet=10.200.0.0/16 \
  devopsbridge
```

### Azsure Monitor

https://docs.microsoft.com/en-us/azure/azure-monitor/insights/containers

### Atlassian portları

https://confluence.atlassian.com/kb/ports-used-by-atlassian-applications-960136309.html
