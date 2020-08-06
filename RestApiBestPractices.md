[Selçuk Ermaya - İstanbul Coders 2017 sunumundan](https://www.youtube.com/watch?v=nVhUyQqvv4s)

- Anlaşılır isimlendirme (semantic naming)
- İlişki API uçları (relational endpoint) - örneğin ziyaretçinin mesajları
- Ortak cevap modeli (Common Model)
- Ortak güvenlik katmanı (common security model)
- Önbellekleme (caching)

- Ayrıştırılmış istek ve data modeli  (seperated request / DTO model)
- Versiyonlama (Versioning)
- Basitlik (Simplicity)
- Az Bağımlılık (Less Dependence)
- Doğrulam (Validation)


örnekler 

|endpoint|method|desc|
|--------|------|----|
|/users|get|tüm kullanıcıların listesi|
|/users|post|yeni kullanıcıekler|
|/users/5|put|idsi 5 olan kullanıcıyı günceller|
|/me|get|oturumu verilen kullanıcının bilgilerini getirir|
|/me/followers|get|oturumu verilen kullanıcının takipçilerini getirir|
|/me/followers/5/block|post|oturumu verilen kullanıcının 5 idli follower ını engeller|



