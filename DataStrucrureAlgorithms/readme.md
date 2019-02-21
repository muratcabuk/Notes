# Data Structures And Algorithms





## English 

## Turkçe

[Bilgisayar Kavramları - C ile Video Ders](https://www.youtube.com/watch?v=r3uOBb3BM-0&list=PLh9ECzBB8tJN9bckI6FbWB03HkmogKrFT) 

[Bilgisayar Kavramları - Python ile Video Ders](https://www.youtube.com/playlist?list=PLh9ECzBB8tJOoFYmIIiwFjgXDCD9uiD_i)


[Güzel Kaynak](http://www.mathcs.emory.edu/~cheung/Courses/171/Syllabus/)



#### __Binary Search Tree__

Arama ve bulma aslında aynı kod.

sol küçük rakam, sağ büyük rakam


[Kaynak](http://www.mathcs.emory.edu/~cheung/Courses/171/Syllabus/9-BinTree/BST-delete2.html)



- __tree de dolaşma (traversal) yapılırken kullanılacak yöntemler__

1. Infix : dolaşırken önce sol, sonra düğüm, sonra sağ node ele alınabilir (LNR), veya RNL olabilir. Node un (N) ortada olma durumu. burada örneğin soldan kasıt ilgili nodun solundaki tüm done ları onlarında öncelikle solu olmak koşuluyla bitirmek anlamına geliyor. Root node 56, sol 26 ve sağ 190, soldaki 26 için ikinci levelde sol değer 18, sağ değer 28 , vs.vs.vs

                                    {56}
                                {26}  -  {200}
                           {18},{28}  -  {190},{213}
                      {12},{24}       -
                        


LNR için örneğin tüm node lar dolaşılarak değerler sırayla yazılır.

LNR = 12,18,24,26,27,28,56,190,200,213 (önce soldan başladığımız için küçükten büyüğe sırlama yapmış olduk)

RNL olsaydı ozaman önce büyükler gelecekti.

bunu yamak için recursive fonksiyonlar kullanılır.


2. Prefix : NLR, NRL

3. Postfix : LRN, RLN


Max ve Min değerleri bulmak şu şekilde: hep solda gidersek en küçük, hep sağ nodelara bakarak gidersek max değer bulunmuş olur.


- __silme işlemleri__

1. Silme işlemiinde ise son leaf ler silinirse bir şeyleri değiştirmeye gerek yok
2. aralarda silme yapılırken silinene node a bağlı sadece tek node varsa ozaman o tek node silinen node un yerine taşınır
3. aralarda silme yapılırken eğer silinen node a bağlı 2 çocuk node varsa o zaman 2 yöntemden biri tercih edilir. 
    - silinen node un sağındaki node ların hep solundan gidilerek en küçük rakama sahip node bulunur, veya
    - silinenen node un solundaki node ların hep sağından gidilerek en büyük rakam bulunur ve bulunan node silinen node yerine yazılır.



ancak arada silme yapılacaksa şu şekilde yapılır.

silinen node un solundakilerden en büyüğü veya sağındakilerin en küçüğü silinene node yerine konulursa ağaç bozulmamış olur, yani kuralına ıuygun şekilde çalışıyor olur.

                                    {56}
                                {26}  -  {200}
                           {18},{28}  -  {190},{213}
                      {12},{24}       -


örneğin 56 yı sileceğimizi düşünelim. Bu durumda sağdakilerin en küçüğü 190 olacaktır. yada solundaki node üzerinde hep solda devam ederek solun en büyük rakamı olan 28 bulunur. 28 veya 190 56 rakamı çıktıktan sonra 56 yerine kullanılırsa sistem bozulmamış olur.


#### __B-Tree__

[B-Tree vs Binary Tree](https://techdifferences.com/difference-between-b-tree-and-binary-tree.html) 














