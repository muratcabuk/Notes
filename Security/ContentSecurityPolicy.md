 Bu response header çeşidi ile sitenizde yer alan kaynaklara erişimi kısıtlayabilirsiniz. Örneğin sadece kendi sitenizde barındırılan style dosyalarını okuyabilir, veya kendi sitenizde yer alan, cloudflare’den ve google’dan gelecek Javascript dosyalarının çalışabilmesini diğer tüm kaynaklardan gelecek script dosyalarını engellemesini sağlayabilirsiniz.

 
 
 
 https://content-security-policy.com/

The new Content-Security-Policy HTTP response header helps you reduce XSS risks on modern browsers by declaring, which dynamic resources are allowed to load.

Content-Security-Policy is the name of a HTTP response header that modern browsers use to enhance the security of the document (or web page). The Content-Security-Policy header allows you to restrict how resources such as JavaScript, CSS, or pretty much anything that the browser loads.





- Blazor için Content Security Policy ile ilgili [sayfa linki](https://docs.microsoft.com/en-us/aspnet/core/blazor/security/content-security-policy?view=aspnetcore-3.1)
- [Implementing Content Security Policy (CSP) in ASP.NET Core](https://anthonychu.ca/post/aspnet-core-csp/)
- [Türkçe Kaynak](https://medium.com/emrekizildas/net-core-mvc-projelerine-content-security-policy-nas%C4%B1l-uygulan%C4%B1r-e3d992c34d4f)
- [Türkçe Detaylı Anlatım](https://www.netsparker.com.tr/blog/web-guvenligi/csp-sakaya-gelmez/)
- [Detaylı Türkçe Anlatım](https://www.mshowto.org/content-security-policy-csp-nedir.html)
- [Türkçe Kaynak](https://www.netsparker.com.tr/blog/web-guvenligi/csp-content-security-policy/)




Jenkins iayağa kaldırırken html reportlara izin verilmesi için bunu aktif etmek gerekiyor. bunun için e java paramettresi olarak  **Dhudson.model.DirectoryBrowserSupport.CSP** geçmek gerekiyor. [Şu sayfaya bakınız](https://www.jenkins.io/doc/book/system-administration/security/configuring-content-security-policy/#ConfiguringContentSecurityPolicy-HTMLPublisherPlugin)

```
java -Dhudson.model.DirectoryBrowserSupport.CSP= -jar jenkins.war 
```



https://www.jenkins.io/doc/book/system-administration/security/configuring-content-security-policy/#ConfiguringContentSecurityPolicy-HTMLPublisherPlugin
