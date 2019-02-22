# Data Structures And Algorithms Analysis





## English 


- __Typical steps in the development of algorithms:__

1. Problem definition
2. Development of a model
3. Specification of the algorithm
4. Designing an algorithm
5. Checking the correctness of the algorithm
6. Analysis of algorithm
7. Implementation of algorithm
8. Program testing
9. Documentation preparation



- __Algoritmaların Sınıflandırılması__

 By Implementation

 1. Recursion
 2. Logical (Mantıksal)
 3. Serial, Parallel or Distributed
 4. Deterministic (parametreleri iyi bilinen, belli ibr gidişle aynı sonucu veren ve içinde olasılık barındırmayan modeller, stokastik modeller tam tersidir.) or Non-Determininistic
 5. Exact or Approximate



By Design Paradigm

1. Brute-force or Exhaustive (Kapsamlı) Search
2. Divide and Conquer (Bil ve Fethet) : Merge Sorting, Quicksort
3. Search and Enumeration
4. Randomized Algorithm
5. Reduction of Complexity : This technique involves solving a difficult problem by transforming it into a better-known problem for which we have (hopefully) asymptotically optimal algorithms. 
6. Back Tracking


By Field of Study

Every field of science has its own problems and needs efficient algorithms. Related problems in one field are often studied together. Some example classes are 

1. search algorithms, 
2. sorting algorithms, 
3. merge algorithms, 
4. numerical algorithms, 
5. graph algorithms, 
6. string algorithms, 
7. computational geometric algorithms, 
8. combinatorial algorithms, 
9. medical algorithms, 
10. machine learning, 
11. cryptography, 
12. data compression algorithms and parsing techniques.

Fields tend to overlap with each other, and algorithm advances in one field may improve those of other, sometimes completely unrelated, fields. For example, dynamic programming was invented for optimization of resource consumption in industry but is now used in solving a broad range of problems in many fields.


Optimization Problems

- Linear Programming
- Dynamic Programming: When a problem shows optimal substructures—meaning the optimal solution to a problem can be constructed from optimal solutions to subproblems—and overlapping subproblems, meaning the same subproblems are used to solve many different problem instances, a quicker approach called dynamic programming avoids recomputing solutions that have already been computed. For example, Floyd–Warshall algorithm, the shortest path to a goal from a vertex in a weighted graph can be found by using the shortest path to the goal from all adjacent vertices. Dynamic programming and memoization go together. The main difference between dynamic programming and divide and conquer is that subproblems are more or less independent in divide and conquer, whereas subproblems overlap in dynamic programming. 
- The Greedy Algorithm: The most popular use of greedy algorithms is for finding the minimal spanning tree where finding the optimal solution is possible with this method. Huffman Tree, Kruskal, Prim, Sollin are greedy algorithms that can solve this optimization problem.
- The Heuristic Algorithm : In optimization problems, heuristic algorithms can be used to find a solution close to the optimal solution in cases where finding the optimal solution is impractical. 







## Turkçe


### __Veri Yapıları__


[link](http://hanmurat.com/blog/algoritma-analizi-ders-notlari/)

[veri yapıları](http://hanmurat.com/blog/veri-yapilari-ders-notlari/)


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



### __Algoritmalar__

1. [Sıralama Algoritmaları - Sorting Algorithms](SortingAlgorithms.md)
2. [Arama Algoritmaları - Search algorithms](SearchAlgorithms.md) 
3. merge algorithms, 
4. numerical algorithms, 
5. graph algorithms, 
6. string algorithms, 
7. computational geometric algorithms, 
8. combinatorial algorithms, 
9. medical algorithms, 
10. machine learning, 
11. cryptography, 
12. data compression algorithms and parsing techniques.











