# KÜLTÜRİX (BLOG-HABER-BİLET) SİTESİ

Bu proje benim ilk proje deneyimim oldu.Projede ulaşılmak istenen amaç  müze bileti satın alabileceğimiz müzelerle ilgili blogların ve duyuruların olduğu,bloglara yorum ve beğeni yapılabilen,user ve admin olarak iki yetkilendirmenin bulunduğu dinamik bir backend geliştirmektir.
Teknoloji olarak Asp.Net core Entity Framework Web API  kullanarak geliştirmeye çalıştım.
## Kurulum
Projenin yerel olarak nasıl kurulacağına dair adımlar:

1. Proje kurulumu yaptıktan sonra ProjeOdevContext.cs'dosyasını bulunuz.
 ![Ekran görüntüsü 2024-03-29 190327](https://github.com/EmineTKN97/ProjeOdev_KULTURIX/assets/156480828/953285b8-8097-44e0-b0e8-eb26ad3e2bc0)
2. Burada bulunan UsesqlServer kısımını kendi veritabanınıza göre düzeltiniz. ![sql](https://github.com/EmineTKN97/ProjeOdev_KULTURIX/assets/156480828/f1b62a72-1727-4f0a-b014-1bbdf71ceb7d)
3.Daha sonra  EF code first yaklaşımı ile tablolarımı oluşturduğum için Package Manager Console'den update-database yapmanız yeterlidir.Oluşturduğunuz veritabanından OperationClaims tablosunu bularak aşağıdaki verileri giriniz.Böylece USER ve ADMİN rolleri tanımlanmış oldu.
![clims](https://github.com/EmineTKN97/ProjeOdev_KULTURIX/assets/156480828/cd746934-c1aa-46e5-b209-7bd8886cf639)

   
## Kullandığım Teknolojiler

Projenin geliştirilmesinde çeşitli teknolojiler kullanılmıştır. İşte projede kullanılan temel teknolojiler:

- **Fluent Validation**: Form ve model doğrulaması için kullanılmıştır. Kullanıcı girişlerini kontrol etmek ve geçersiz veri girişlerini engellemek için kullanılır.
- **Code First**: Entity Framework Code First yaklaşımı kullanılarak veritabanı modeli oluşturulmuştur. Bu şekilde kod tarafında yapılan değişiklikler otomatik olarak veritabanına yansıtılmaktadır.
- **Web API**: RESTful API'lerin oluşturulması ve yönetilmesi için ASP.NET Core Web API kullanılmıştır. API'ler aracılığıyla kullanıcılar, etkinlikler, sanatçılar ve diğer kaynaklarla iletişim kurabilir.
- **Müze API Entegrasyonu**: Kültürel etkinliklerin yanı sıra müzelerle ilgili bilgileri de sunabilmek için özel bir Müze API'si entegre edilmiştir.
- **Autofac**: Proje içerisinde bağımlılık enjeksiyonu ve servisleri yönetmek için Autofac kullanılmıştır. Bu sayede kodun daha modüler ve yönetilebilir olması sağlanmıştır.
- **MERNİS Servisi**: Kullanıcıların kimlik doğrulaması ve bilgilerinin doğruluğunu kontrol etmek için Türkiye Cumhuriyeti Nüfus ve Vatandaşlık İşleri Genel Müdürlüğü'nün (MERNİS) servisinden yararlanılmıştır.
- **JWT**:Kullanıcı giriş yaparak kimlik doğrulamasını gerçekleştirir. Sunucu, geçerli bir kullanıcı kimliği ve parola alır ve bu bilgileri doğrular. Kullanıcı doğrulandıktan sonra sunucu, kullanıcıya bir JWT oluşturur. Kullanıcıya gönderilen JWT, kullanıcının oturumunun süresini belirler ve yetkilendirme bilgilerini içerir.Kullanıcı her istek yaptığında, JWT sunucuya gönderilir ve sunucu bu tokeni doğrular. Bu sayede kullanıcının kimliği ve yetkilendirmesi sağlanmış olur.

  
## Katkıda Bulunma

- Eğer projeye katkıda bulunmak istiyorsanız, öncelikle bir issue açarak konuyu belirtin.
- Fork ederek kendi çalışma alanınıza kopyalayın.
- Yaptığınız değişiklikleri yeni bir branch oluşturarak commit edin.
- Pull request (çekme isteği) gönderin ve değişikliklerinizi tartışın.

Bu teknolojilerin bir araya gelmesiyle proje geliştirme süreci daha verimli ve etkili hale getirilmiştir. Detaylı bilgi için lütfen proje klasöründe yer alan belgelere ve kodlara göz atabilirsiniz.
Proje hakkında herhangi bir sorunuz, geri bildiriminiz veya işbirliği teklifiniz varsa benimle iletişime geçebilirsiniz.

- **E-posta:** [eminetkn.97@gmail.com](eminetkn.97@gmail.com)
- Her türlü geri bildiriminiz benim için değerlidir. Teşekkür ederim!
