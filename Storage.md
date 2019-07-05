https://blog.storagecraft.com/object-storage-systems/
https://ubuntu.com/blog/what-are-the-different-types-of-storage-block-object-and-file
https://cloudian.com/blog/object-storage-vs-block-storage/
https://www.druva.com/blog/object-storage-versus-block-storage-understanding-technology-differences/

gluster
ceph
minio




__Ceph: scalable object storage with block and file capabilities__

__Gluster: scalable file storage with object capabilities__

The differences, of course, are more nuanced than this, based on they way each program handles the data it stores.

Ceph uses object storage, which means it stores data in binary objects spread out across lots of computers. It builds a private cloud system with OpenStack technology, and users can mix unstructured and structured data in the same system.

Gluster uses block storage, which stores a set of data in chunks on open space in connected Linux computers. It builds a highly scalable system with access to more traditional storage and file transfer protocols, and can scale quickly and without a single point of failure. That means you can store huge amounts of older data without losing accessibility or security. An April 2014 study by IOP Science showed that Gluster outperformed Ceph, but still showed some instabilities that resulted in partial or total data loss.

![resim](https://www.maketecheasier.com/assets/uploads/2019/03/gluster-vs-ceph-ceph-solution-storage-cluster.png)

![resim2](https://www.maketecheasier.com/assets/uploads/2019/03/glusterfs-gluster-fsintroduction-11-638.jpg)

Ceph is an object-based system, meaning it manages stored data as objects rather than as a file hierarchy, spreading binary data across the cluster. Similar object storage methods are used by Facebook to store images and Dropbox to store client files. In general, object storage supports massive unstructured data, so it’s perfect for large-scale data storage. The system is maintained by a network of daemons in the form of cluster monitors, metadata servers, and journaled storage. These combine to make Ceph capable but more complex than the competition.


GlusterFS, better known as Gluster, is a more traditional file store. It’s easy to set up, and a properly-compiled build can be used on any system that has a folder. The flexibility and ease of use is a major advantage of the system. While it can scale to enormous capacities, performance tends to quickly degrade. It’s best suited for large average file sizes (greater than 4 MB) and sequential access. A cluster can spread across physical, virtual, and cloud servers, allowing for flexible storage virtualization.
