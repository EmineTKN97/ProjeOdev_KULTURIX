# KÜLTÜRİX (BLOG-HABER-BİLET) SİTESİ

Bu proje benim ilk proje deneyimim oldu.Projede ulaşılmak istenen amaç  müze bileti satın alabileceğimiz müzelerle ilgili blogların ve duyuruların olduğu,bloglara yorum ve beğeni yapılabilen,user ve admin olarak iki yetkilendirmenin bulunduğu dinamik bir backend geliştirmektir.
Teknoloji olarak Asp.Net core Entity Framework Web API  kullanarak geliştirmeye çalışıyorum.
## Kurulum
Projenin yerel olarak nasıl kurulacağına dair adımlar:

1. Proje kurulumu yaptıktan sonra ![Image of Yaktocat](https://octodex.github.com/images/yaktocat.png)
2. EF code first yaklaşımı ile tablolarımı oluşturduğum için Package Manager Console'den update-database yapmanız yeterlidir.
3. İkinci adım...

## Kullandığım Teknolojiler

Projenin geliştirilmesinde çeşitli teknolojiler kullanılmıştır. İşte projede kullanılan temel teknolojiler:

- **Fluent Validation**: Form ve model doğrulaması için kullanılmıştır. Kullanıcı girişlerini kontrol etmek ve geçersiz veri girişlerini engellemek için kullanılır.
- **Code First**: Entity Framework Code First yaklaşımı kullanılarak veritabanı modeli oluşturulmuştur. Bu şekilde kod tarafında yapılan değişiklikler otomatik olarak veritabanına yansıtılmaktadır.
- **Web API**: RESTful API'lerin oluşturulması ve yönetilmesi için ASP.NET Core Web API kullanılmıştır. API'ler aracılığıyla kullanıcılar, etkinlikler, sanatçılar ve diğer kaynaklarla iletişim kurabilir.
- **Müze API Entegrasyonu**: Kültürel etkinliklerin yanı sıra müzelerle ilgili bilgileri de sunabilmek için özel bir Müze API'si entegre edilmiştir.
- **Autofac**: Proje içerisinde bağımlılık enjeksiyonu ve servisleri yönetmek için Autofac kullanılmıştır. Bu sayede kodun daha modüler ve yönetilebilir olması sağlanmıştır.
- **MERNİS Servisi**: Kullanıcıların kimlik doğrulaması ve bilgilerinin doğruluğunu kontrol etmek için Türkiye Cumhuriyeti Nüfus ve Vatandaşlık İşleri Genel Müdürlüğü'nün (MERNİS) servisinden yararlanılmıştır.

Bu teknolojilerin bir araya gelmesiyle proje geliştirme süreci daha verimli ve etkili hale getirilmiştir. Detaylı bilgi için lütfen proje klasöründe yer alan belgelere ve kodlara göz atabilirsiniz.
