- Declarative pipeline kod çalıştırlmadan önce valide edilir böylece gereksiz yere kod çalışmamış olur.
- Declarative pipeline'da herhangi bir stage bütün pipiline çalıştırıldıktan sonra tekrar çalıştırılabilir.
- Declarative pipeline da option'lar stage ler içinde ayrı ayrı tanımlanabilir. Ayrıca global olarak olarka kullanılcaklar işçin global option'lar tanımlanabilir. Ancek inperative pipeline'de bunlar nested yazılırlar buda aslında tam beklene sonucu vermez.
- Declarative pipeline'da conditional stage çalıştırıldığında jenkins atlanan stage i ekranda gösterbilirken imperative'de gösteremez.
- Declarative pipeline okuma ve öğrenme adına daha kolaydır. Adı üstünde declarative yani DSL language.
- Imperative pipeline'da genellikle daha az kod yazılır.
- 

### Best Practices

- Gereksiz yere groovy script çalıştırma ve ya karmaşık script çalıştırma. çünki, bu kodlar agent lar da çalışmaz direk olarak jenkins sunucusunda çalışır. bu nedenle agent larda çalışacak shell scriptler evya python veya powershell scriptleri tercih etmek lazım. 
- Groovy scriptleri groovy CPS modda çalıştığı için standart groovy gibi çalışmaz ikisi farklıdır bunedenle buraa yapılabileek halar için şu linkje https://www.jenkins.io/doc/book/pipeline/cps-method-mismatches/ bakınız.
- stage lerde timeout kullanılmalıdır. en kötü global option olarak timeout kullanıabilir
- pipeline ı durduracak approval yada kullanıcı girişleri kullanılmamalı. yani örneğin kullanıcıya build stage i sonrası test stage inde bir soru sorup ona göre devam edeceğiz diyeli. bu durumda build stagei aslında bitti yai oradaki kaynağı aslında boş bırakabilirdik ancak aynı node u kullanark bütün pipeline devam ettirdiğğimiz için sadece bir soru için ilgili node da kki executer ı doldurmuş oluyoruz. bunun için global tarafta node atamasını yparken none olarka belirleyip her stage için ayrı ayrı node lar belirlemek mantıklı olabilir. tabi burada da kurgudan koparmadan ilgili stage i kaldığı yerden devem ettirmek lazı bunun için ilgili srackoverflow sayfası : https://stackoverflow.com/questions/42561241/how-to-wait-for-user-input-in-a-declarative-pipeline-without-blocking-a-heavywei
- parallel stpleri kullan
- 


- https://www.jenkins.io/doc/book/pipeline/pipeline-best-practices/
- https://www.jenkins.io/doc/book/pipeline/
- https://www.cloudbees.com/blog/top-10-best-practices-jenkins-pipeline-plugin



### Resources

- https://www.youtube.com/watch?v=Ei_Nk14vruE (çok iyi video)
- https://www.youtube.com/playlist?list=PLKaiHc24qCTSnXaus2t4b71ihq9k649XS (seri video çok iyi)
- https://www.youtube.com/watch?v=7KCS70sCoK0 (baştan sona declarative örnek)