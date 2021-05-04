 
### Diff

farklı versiyonları da vardır.

- wdiff : kelime farklılıkları için
- colordiff : resnklerle farklılıkları gösterir
- vimdiff


**resources**
- https://veriteknik.gitbook.io/linux-yonetimi/gelismis-terminal-komutlari/patch-ve-diff
- https://en.wikipedia.org/wiki/Diff#Unified_format
- http://manpages.ubuntu.com/manpages/trusty/tr/man1/diff.1.html
- https://nenedirnasilyapilir.com/linux-terminalinde-iki-metin-dosyasini-karsilastirma/
- https://git-scm.com/docs/git-diff
- https://git-scm.com/docs/git-diff#_combined_diff_format
- https://www.atlassian.com/git/tutorials/saving-changes/git-diff


Diff'in çalışması, en uzun ortak alt dizi problemini (solving the longest common subsequence problem) çözmeye dayanır. 

iki dizi düşünelim

```
a b c d   f g h j q       z
a b c d e f g i j k r x y z
```
mantık olarak şöyle işlemektedir. Her iki orijinal dizide aynı sırada bulunan en uzun öğe dizisini bulmak istiyoruz. Yani, bazı öğeleri silerek ilk orijinal sekanstan ve diğer öğeleri silerek ikinci orijinal sekanstan elde edilebilecek yeni bir sekans bulmak istiyoruz. Ayrıca bu dizinin mümkün olduğu kadar uzun olmasını istiyoruz.

```
a b c d  f  g  j  z
```

eğer bir öğe alt dizide yoksa ancak ilk orijinal dizide mevcutsa, silinmiş olmalıdır (aşağıdaki '-' işaretleriyle gösterildiği gibi) ). Alt dizide yoksa ancak ikinci orijinal dizide mevcutsa, eklenmiş olmalıdır ('+' işaretleriyle belirtildiği gibi).

yani ilk dizide hangi değişiklikleri yparsak ikinci diziye ulaşırız.

```
e h i q k r x y

+ - + - + + + +
```

bu tamımlamda sonra diff komutunu linux üzerinde biraz inceleyelim.

elimizde 2 adet dosya olsun a ve b

```
a.txt   b.txt
1.  z     z
2.  a     c
3.  g     b
4. 
5.  a     a
6.  b     c
7.  b     c
8. 
9.  2
10. 2
11. 
```
alttaki komutla somnuçları inceleyelim. her bir bloğa chunk veya hunk da denir.

```
diff  a.txt b.txt

# sonuç
2,3c2,3
< a
< g
---
> c
> b
6,7c6,9
< b
< b
---
> c
> c
> 
> 
9,10d10
< 2
< 2

```

2,3c2,3 - 6,7c6,9 - 9,10d10 ifadeleri a dosyasında ne yapılmalıki b dosyasına erişilebildin gibi bir durumu ifade eder. yani değişiklikleri ifade eder. sırasıyla inceleyecek olursak

- 2,3c2,3 : a dosyasında 2. ve 3. satırları silip b deki 2. ve 3. satırları yaz
- 6,7c6,9 : a dosyasındaki 6. ve 7. satırları silip yerine b deki 6.,7.,8. ve 9. satırları yaz
- 9,10d10 : a daki 9. ve 10 satırları sil

arada yer alan harfler şu anlma geliyor.

- c : İlk dosyadaki satırın ikinci dosyadaki satırla eşleşmesi için değiştirilmesi gerekiyor.
- d : İlk dosyadaki satır, ikinci dosya ile eşleşecek şekilde silinmelidir.
- a : İkinci dosyaya uyması için ilk dosyaya ekstra içerik eklenmelidir.

diff komutundan farklı çıktılar almak mümkündür.

- ed script : diff komutuna -e opsiyonu ekleyerek ed komutu için script oluşturulur. böylece bu script kullanılarak ilk dosya (a.txt) üzerinde yapılacak değişiklikler scripten okunarak ikinci dosyaya (b.txt) ulaşılabilir (ed -s original < mydiff)
- Context format : diff komutuna -c eklenerek elde edilir (diff -c original new). Bir "!" iki dosyaya karşılık gelen satırlar arasındaki değişikliği temsil eder. Bir "+", bir satırın eklenmesini temsil ederken, bir boşluk değişmemiş bir satırı temsil eder. 
- Unified format: git diff komutunda da default olrak kullanılan çıktıdır. Orijinal dosyanın (a.txt) aralığının önünde bir eksi simgesi bulunur ve yeni dosyanın (b.txt) aralığının önünde bir artı simgesi bulunur. Her hunk aralığı l, s biçimindedir, burada l başlangıç ​​satırı numarasıdır ve s, her bir ilgili dosya için değişiklik hunk'ın uyguladığı satır sayısıdır. GNU diff'in birçok sürümünde, her aralık virgül ve sondaki s değerlerini çıkarabilir, bu durumda s varsayılan olarak 1'dir. Gerçekten ilginç olan tek değerin ilk aralığın l satır numarası olduğuna dikkat edin; diğer tüm değerler farktan hesaplanabilir.
- patch : patch çıktısı almak için örnek komut diff -u a.txt b.txt > test1-2.patch. bu komuttaki patch dosyasını patch komutuna a.txt ile girdi olarka verirsek b.txt dosyaına erişebiliriz (patch < test1-2.patch).


unified format git de de kullanıldığı için biraz daha inceleyelim.

```
diff -u a.txt b.txt

# sonuç

--- a.txt       2021-04-26 17:14:33.686848800 +0300
+++ b.txt       2021-04-26 17:13:19.924242300 +0300
@@ -1,10 +1,10 @@
 z
-a
-g
+c
+b
 
 a
-b
-b
+c
+c
+
+
 
-2
-2
```


örnek bir git diff dosyası


**örneğin alttaki ilk chunk/hunk da -34,6 +34,8 soldaki dosyadan 34. satırdan itibaren 6 satırın yerine sağdaki dosyanın 34. satırından itibaren 8 satırı kopyla demektir**

![example-diff.jpg](files/example-diff.jpg)







