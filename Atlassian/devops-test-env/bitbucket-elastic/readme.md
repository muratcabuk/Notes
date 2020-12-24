### INTRO

Öncelikle alttaki komutla max_map_count değeri arttırılmalı. bu değer config dosyasın ayzılmadığı için host restart olduğunda değer kaybolcaktır bu nedenle /etc/sysctl.conf dosyasına da yazılmalıdır. 

```
sudo sysctl -w vm.max_map_count=262144
```

- https://www.elastic.co/guide/en/elasticsearch/reference/current/vm-max-map-count.html


Elasticsearch uses a mmapfs directory by default to store its indices. The default operating system limits on mmap counts is likely to be too low, which may result in out of memory exceptions.

**mmapfs:** The MMap FS type stores the shard index on the file system (maps to Lucene MMapDirectory) by mapping a file into memory (mmap). Memory mapping uses up a portion of the virtual memory address space in your process equal to the size of the file being mapped. Before using this class, be sure you have allowed plenty of virtual address space. 
https://www.elastic.co/guide/en/elasticsearch/reference/current/index-modules-store.html#mmapfs





