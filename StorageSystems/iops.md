### IOPS Nedir?

Saniye başına gerçekleşen girdi/çıktı veya kısaca IOPS (input/output operation per second), en temel tanımı ile depolama biriminin hız performans ölçümü için kullanılan bir parametredir.


Burada önemli olan IOPS’ta okunan veya yazılan verinin miktarı değil, bunun için gerçekleşen işlem miktarının hesaplanıyor olmasıdır. Örneğin sunucu üzerindeki bir dosyanın çalıştırılması için bir komut gönderilmesini bir işlem yani 1 IOPS olarak kabul edebilirsiniz. Dosyanın çalıştırılması esnasında ihtiyaç duyduğu bileşenlerin (örneğin dll dosyalarının) her birini çağırması da birer IOPS ve onların çalışırken yaptığı her ek işlem de ek IOPS’lar olarak hesaplanıyor. Yani buna göre bir PC ya da bir sunucudaki basit bir dosyanın çalıştırılması 10 ila 150 IOPS arasında değişen bir değer üretiyor.


Hem HDD, hem de SSD’ler için geçerli olan bu IOPS değeri, cihazın 1 saniyede bu işlemlerden kaç tanesini gerçekleştirebileceğini teorik olarak gösteren bir parametre. Ne kadar güçlü bir CPU ve ne kadar yüksek RAM kullanırsanız kullanın, veriye erişme hızınız depolama biriminin IOPS limitini aşamayacağı için IOPS aslında oldukça önemli bir parametre.


Bu noktada önemli bir detayı da belirtmekte fayda var. SSD, HDD’ye göre yapısal açıdan daha avantajlı olduğu için genellikle çok daha yüksek bir IOPS değerine sahiptir. Aralarındaki benzerlikleri ve farkları incelemek isterseniz “SSD mi, HDD mi?” yazımızı okuyabilirsiniz.

### IOPS, Latency ve Throughput


Yukarıda bahsettiğimiz gibi performans ölçümü açısından IOPS önemli bir parametre olsa da, amaç depolama biriminin performans ölçümü olunca tek başına değerlendirmek çok sağlıklı bir sonuç vermez.


Kullanıcı için önemli olan sadece saniyede kaç girdi/çıktı yapılabileceğinin çok daha ötesinde, veriye ne kadar hızlı erişebileceğidir. Bunun için de IOPS ile birlikte dikkate alınması gereken iki önemli parametre daha var; 

#### latency ve throughput.


Latency bir depolama aygıtının kendisine gelen girdi/çıktı talebine ne kadar hızlı şekilde yanıt verebileceğinin ifadesidir. Milisaniyeler bazında ölçülen latency ne kadar düşükse, depolama birimi gelen işlem talebini o kadar hızlı karşılamaya başlıyor.


Throughput ise 1 saniye içerisinde depolama birimi aracılığı ile ne kadar veri transferi yapılabildiğini ifade eder. IOPS’te her bir girdi/çıktı adedi ölçülürken, throughput ile bu adetlerden bağımsız bir şekilde 1 saniye içerisinde kaç kilobyte veya kaç megabyte veri transferi yapılabildiğini ölçmek mümkün.

### Büyük Resmi Görmek


IOPS, latency ve throughput rakamlarının her birinin büyük resmin birer parçası olduğunu düşünmek yanlış olmaz. Bu anlamda bir depolama biriminin performansını değerlendirirken iyi bir sonuç almak için bu üç değeri bir arada ele almak gerekir. Örneğin 1 saniye içerisinde 50 IOPS gerçekleşiyor ve 10 milisaniyelik bir latency yaşanıyor, her bir IOPS için transfer edilen veri miktarı da 5 megabyte ile sınırlı diyelim, bu örnek rakamlar üzerinden toplam performansı beklenen sonuçla karşılaştırmak mümkün.


Bu şekilde düşünerek üreticilerin açıkladığı IOPS gibi parametrelere göre bir depolama cihazı hakkında öngörüde bulunmak mümkün. Fakat üreticilerin çoğunlukla tüm bu verileri en ideal koşullarda ve kontrollü olarak ölçtüklerini, uzun vadede ortalama olarak elde edeceğiniz performansın bu açıklanan ideal rakamlar kadar iyi olmayabileceğini de göz önünde bulundurmanız gerekir. 
