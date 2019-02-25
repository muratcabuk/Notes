
https://git-scm.com/book/tr/v2/Ba%C5%9Flang%C4%B1%C3%A7-Git%E2%80%99in-Temelleri

https://medium.com/@osmanhomek/git-mi-git-flow-mu-d7573e75269d

https://git-scm.com/book/tr/v1/Git-te-Dallanma-Rebasing-Tekrar-Adresleme
https://aliozgur.gitbooks.io/git101/content/bolum_1_-_baslangic/

https://www.youtube.com/watch?v=LIG-OsGysWM&list=PLPrHLaayVkhnNstGIzQcxxnj6VYvsHBHy&index=15

https://www.youtube.com/watch?v=uncrCoLiq-g&list=PLHN6JcK509bOrevTCFrSMeAfBtuib4Gpg

https://www.youtube.com/watch?v=ciRGHbfKBBo&list=PL_Z0TaFYSF3IqQKPOmbigAOVMMlZ2yU4K


https://fatihhayrioglu.com/git/


https://github.com/vigo/git-puf-noktalari/blob/master/bolum-01/patch-mod-git-add.md

http://marklodato.github.io/visual-git-guide/index-en.html

https://medium.com/data-science-tr/git-ve-github-2ad10716fb83

http://rogerdudler.github.io/git-guide/

https://www.youtube.com/watch?v=TymF3DpidJ8


## Team

https://jameschambers.co/writing/git-team-workflow-cheatsheet/

https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow

https://pewat.blogspot.com/2017/02/git-flow-nedir.html



## Komutlar

1. Workspace de yapılan değişikliği en son committen dönmek için 
- git checkout -- dosyaadi
aslında bu komut son versyonu bir önceki versiyona alıyor.

iki version arasında  geçiş yapmak için aşağıdaki komut kullanılır. Nokta tüm dosyaları o versiyondaki haline gitmesi gerektiğini söyler.

- git checkout versionhashkodu -- . 

2. Son Commiti bir önceki commite dönmek için alttaki komut çalıştırılır.  bu en son yaptığımız commiti master da geri ancak workspace de geri alınacaksa ozaman üstteki kod çalıştırılır.

- git reset HEAD dosyaadi

yada istenilen ir commite tam (kesin) dönmek için --hard eki kullanılır. bu şu anlama gelir. bu committen sonrasını sil.

- git reset commitid --hard 

eğer kesin dönüş yapılmak istenmiyorsa --soft kulanılır.

- git reset commitid --soft

3.Logları tek satır halinde yazdırmak için

- git log --oneline

4. istenilen herhangibir committe yapılıan değişikliği silmek için yani işlemi tamamen geri almak için revert komutu kullanılır

- git revert commitid 

bu komut çalıştırıldığında direkt karşımıza otomatik oluşturulmuş commit mesaj ekranı çıkar. kaydedildiinde işlem geri alınmış olur.

5. hem stage e add yapmak hem de aynı zaman da mesaj eklemek için

- git commit -a -m "message"

6. daha önceki commit e ekleme yapmak için

- git commit -amend

7. branch oluşturmak için

- git branch branchadi

8. 






