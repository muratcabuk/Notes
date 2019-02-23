# Data Structures And Algorithms Analysis


## English 

- __Memory : Stack vs Heap__

[Source](https://www.gribblelab.org/CBootCamp/)

[Good Explanation Video -  C# - Java](https://www.youtube.com/watch?v=clOUdVDDzIM&spfreload=5)

__The Stack__

What is the stack? It's a special region of your computer's memory that stores temporary variables created by each function (including the main() function). The stack is a "LIFO" (last in, first out) data structure, that is managed and optimized by the CPU quite closely. Every time a function declares a new variable, it is "pushed" onto the stack. Then every time a function exits, all of the variables pushed onto the stack by that function, are freed (that is to say, they are deleted). Once a stack variable is freed, that region of memory becomes available for other stack variables.

The advantage of using the stack to store variables, is that memory is managed for you. You don't have to allocate memory by hand, or free it once you don't need it any more. What's more, because the CPU organizes stack memory so efficiently, reading from and writing to stack variables is very fast.

A key to understanding the stack is the notion that when a function exits, all of its variables are popped off of the stack (and hence lost forever). Thus stack variables are local in nature. This is related to a concept we saw earlier known as variable scope, or local vs global variables. A common bug in C programming is attempting to access a variable that was created on the stack inside some function, from a place in your program outside of that function (i.e. after that function has exited).

Another feature of the stack to keep in mind, is that there is a limit (varies with OS) on the size of variables that can be stored on the stack. This is not the case for variables allocated on the heap.

To summarize the stack:

the stack grows and shrinks as functions push and pop local variables
there is no need to manage the memory yourself, variables are allocated and freed automatically
the stack has size limits
stack variables only exist while the function that created them, is running

![Stack and Heap](files/StackAndHeap.png)


__The Heap__

The heap is a region of your computer's memory that is not managed automatically for you, and is not as tightly managed by the CPU. It is a more free-floating region of memory (and is larger). To allocate memory on the heap, you must use malloc() or calloc(), which are built-in C functions. Once you have allocated memory on the heap, you are responsible for using free() to deallocate that memory once you don't need it any more. If you fail to do this, your program will have what is known as a memory leak. That is, memory on the heap will still be set aside (and won't be available to other processes). As we will see in the debugging section, there is a tool called valgrind that can help you detect memory leaks.

Unlike the stack, the heap does not have size restrictions on variable size (apart from the obvious physical limitations of your computer). Heap memory is slightly slower to be read from and written to, because one has to use pointers to access memory on the heap. We will talk about pointers shortly.

Unlike the stack, variables created on the heap are accessible by any function, anywhere in your program. Heap variables are essentially global in scope.

__Stack vs Heap Pros and Cons__

Stack:

- Stored in computer RAM just like the heap.
- Variables created on the stack will go out of scope and are automatically deallocated.
- Much faster to allocate in comparison to variables on the heap.
- Implemented with an actual stack data structure.
- Stores local data, return addresses, used for parameter passing.
- Can have a stack overflow when too much of the stack is used (mostly from infinite or too deep recursion, very large allocations).
- Data created on the stack can be used without pointers.
- You would use the stack if you know exactly how much data you need to allocate before compile time and it is not too big.
- Usually has a maximum size already determined when your program starts.


Heap:

- Stored in computer RAM just like the stack.
- In C++, variables on the heap must be destroyed manually and never fall out of scope. The data is freed with delete, delete[], or free.
- Slower to allocate in comparison to variables on the stack.
- Used on demand to allocate a block of data for use by the program.
- Can have fragmentation when there are a lot of allocations and deallocations.
- In C++ or C, data created on the heap will be pointed to by pointers and allocated with new or malloc respectively.
- Can have allocation failures if too big of a buffer is requested to be allocated.
- You would use the heap if you don't know exactly how much data you will need at run time or if you need to allocate a lot of data.
Responsible for memory leaks.


__Typical steps in the development of algorithms:__

1. Problem definition
2. Development of a model
3. Specification of the algorithm
4. Designing an algorithm
5. Checking the correctness of the algorithm
6. Analysis of algorithm
7. Implementation of algorithm
8. Program testing
9. Documentation preparation


__Hash Table And Hash Functions__

TODO: I will add some content

__Boxing and Unboxing__



TODO: I will add some content



### __Classifying Algorithms__

 __By Implementation__

 1. Recursion
 2. Logical (Mantıksal)
 3. Serial, Parallel or Distributed
 4. Deterministic (parametreleri iyi bilinen, belli ibr gidişle aynı sonucu veren ve içinde olasılık barındırmayan modeller, stokastik modeller tam tersidir.) or Non-Determininistic
 5. Exact or Approximate



__By Design Paradigm__

1. Brute-force or Exhaustive (Kapsamlı) Search
2. Divide and Conquer (Bil ve Fethet) : Merge Sorting, Quicksort
3. Search and Enumeration
4. Randomized Algorithm
5. Reduction of Complexity : This technique involves solving a difficult problem by transforming it into a better-known problem for which we have (hopefully) asymptotically optimal algorithms. 
6. Back Tracking


__By Field of Study__

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


__Optimization Problems__

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




- __Memory : Stack vs Heap__

[Source](https://www.gribblelab.org/CBootCamp/)

[Good Explanation Video -  C# - Java](https://www.youtube.com/watch?v=clOUdVDDzIM&spfreload=5)


- __Hash Table ve Hash Fonksiyonu__


[Algoritma Uzmanı Anlatım](https://www.algoritmauzmani.com/veri-yapilari/hashing-nedir-veri-yapilari/)

[Bilgisayar Kavramları - Hashtable ve Hash Fonksiyonu](https://www.youtube.com/watch?v=_TCkO3DnVs4)

[Hashtable Youtube Video](https://www.youtube.com/watch?v=0fGeIVgyAgY)

[C# koleksiyonlar hakkında](https://www.srdrylmz.com/c-koleksiyonlar/)

C# daki Dictionary ler aslında bir hashtable dır.
Veriyi Dictionary e atarken sistemin bizden aldığı key i nereye yzacağı ve biz ararken nasıl bulunacağı kısmını C# halletmektedir. Ancak bunu bşr kendimiz yapmak isteseydik sadece array kullanarak bunu yapmak ve arrayda aranılan değeri daha hızlı bulmak için bir hash leme algoritması kullanmamız ve bunu bir fonksiyonla çağırmamız gerekecekti. bu fonksiyona hash fonksiyonu denmektedir.

aslında amaç array ler de hzılı veri bulmak için uygun anahtarları oluşturmak ve kaynakları en verimli şekilde kullanmaya çalışmaktır.
arrayın hangi index inde hangi verinin olduğunu bulmak için bir yöntem geliştirmektir.

oluşturulan hash değeri tek yönlüdür yani hash den veri elde edilemez. sadece değerden hash a erişim vardır.

oluşturulan 2 hash değeri aynı olursa ozaman çakışma olur buna da collision denir.



Bilinen hash fonksiyonları.

- MD5 (Message Digest 5) [link](http://bilgisayarkavramlari.sadievrenseker.com/2008/04/30/md5-message-digest-mesaj-ozet/)
- SHA-1 (Secure Hashing Algorithm) [Link] (http://bilgisayarkavramlari.sadievrenseker.com/2009/11/02/secure-hasing-algorithm-sha/)






__Boxing ve Unboxing Kavramları__



TODO: I will add some content




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
