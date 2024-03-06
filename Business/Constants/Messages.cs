using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        public static string BlogLikeNotDeleted = "Beğeni işlemi geri alınamadı";
        public static string BlogAdded = "Blog başarı ile eklenmiştir.";
        public static string BlogNotAdded = "Blog ekleme işlemi başarısız.";
        public static string BlogListed = "Bloglar başarı ile listelendi.";
        public static string BlogNotListed = "Blog listeleme işlemi başarısız.";
        public static string BlogUpdated = "Blog başarı ile güncellendi.";
        public static string BlogDeleted = "Blog başarı ile silindi.";
        public static string BlogNotUpdated = "Blog güncelleme işlemi başarısız.";
        public static string BlogNotDeleted = "Blog silme işlemi başarısız.";

        public static string BlogCommentNotListed = "Blog yorum listeleme işlemi başarısız.";
        public static string BlogCommentAdded = "Yorum başarı ile eklendi.";
        public static string BlogCommentDeleted = "Yorum başarı ile silindi";
        public static string BlogCommentUpdated = "Yorum başarı ile güncellendi";
        public static string BlogCommentNotAdded = "Yorum ekleme işlemi başarısız";
        public static string BlogCommentNotDeleted = "Yorum silme işlemi başarısız";
        public static string BlogCommentNotUpdated = "Yorum güncelleme işlemi başarısız";

        public static string BlogLikeAdded = "Beğeni işlemi başarılı";
        public static string BlogLikeDeleted = "Beğeni işlemi geri alındı";
        public static string BlogLikedListed = "Beğeniler listelendi";
        public static string BlogLikeNotAdded = "Beğeni işlemi başarısız";
        public static string BlogLikedNotListed = "Beğeni listeleme işlemi başarısız";
        public static string BlogCommentListed = "Yorumlar listelendi";

        public static string AddBlogİmage = "Blog için resim başarı ile eklendi";
        public static string AddUserİmage = "Profil resiminiz başarı bir şekilde yüklendi";
        public static string MediaNotAdded = "Bir tane resim ekleyebilirsiniz";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserNotAdded = "Kullanıcı eklenemedi";
        public static string MediaNotListed = "Resimler listelenemedi";
        public static string MediaDeleted = "Resim silme işleminiz başarılı";
        public static string MediaListed = "Resimler listelendi";
        public static string UpdateMedia = "Resim güncellendi";
        public static string UserMediaListed = "Profil fotoğrafları listelendi";
        public static string BlogMediaListed = "Blog resimleri listelendi";
        public static string MediaNotDeleted = "Resim silinemedi";
        public static string MediaNotUpdated = "Resim güncellenemedi";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt işlemi başarılı , Hoşgeldiniz";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre  hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı , Hoşgeldiniz";
        public static string ErrorLogin = "Giriş işlemi başarısız";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string UserRegistrationFailed = "Kayıt işlemi başarısız";
        public static string AdminRegistered = "Kayıt olundu";
        public static string AdminRegistrationFailed = "Kayıt işlemi başarısız";
        public static string AdminNotFound = "Yönetici bulunamadı";
        public static string AdminAlreadyExists = "Bu yönetici mevcut";

        public static string AnnouncementAdded = "Duyuru Eklendi";
        public static string AnnouncementDeleted = "Duyuru silindi";
        public static string AnnouncementListed = "Duyurular Listelendi";
        public static string AnnouncementUpdated = "Duyuru güncellendi";
        public static string AnnouncementNotUpdated = "Duyuru Güncellenemedi";
        public static string AnnouncementNotListed = "Duyurular Listelenemedi";
        public static string AnnouncementNotAdded = "Duyuru eklenemedi";
        public static string AnnouncementNotDeleted = "Duyuru silinemedi";

        public static string UserNotDeleted = "Kullanıcı Silinemedi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserListed = "Kullanıcılar listelendi";
        public static string UserUpdated = "Bilgileriniz Güncellendi";
        public static string UserNotUpdated = "Bilgileriniz Güncellenemedi";
        public static string ChangePassword = "Şifre değiştirme işleminiz başarılı bir şekilde gerçekleştirildi";
        public static string ChangeNotPassword = "Şifre değiştirme işleminiz başarısız";

        public static string AdminNotDeleted = "Sistemde sadece bir admin hesabı var, bu hesabı silemezsiniz.";
        public static string ChangeAdminPassword = "Şifre Güncellendi";
        public static string AdminDeleted = "Yönetici silindi";
        public static string AdminListed = "Yönetici Listelendi";
        public static string AdminUpdated = "Bilgiler Güncellendi";
        public static string AdminNotUpdated = "Bilgiler Güncellenemedi";
        public static string UserNotActive = "Böyle bir kullanıcı bulunamadı";
        public static string AdminNotActive = "Böyle bir yönetici bulunamadı";
        public static string AdminAdded = "Yönetici eklendi";
        public static string UserNotListed = "Kullanıcı bilgileri getirilemedi";

        public static string TicketAdded = "Biletiniz oluşturuldu";
        public static string TicketDeleted = "Bilet bilgileriniz silindi";
        public static string TicketListed = "Biletleriniz Listelendi";
        public static string TicketUpdated = "Biletiniz Güncellendi";
        public static string TicketNotUpdated = "Biletiniz Güncellenemedi";
        public static string TicketNotDeleted = "Bilet silinemedi";
        public static string TicketNotAdded = "Bilet oluşturulamadı";
        public static string TicketNotListed = "Bilet Listelenemdi";

       public static string TicketPriceUpdated="Fiyat Güncellendi";
       public static string TicketPriceNotUpdated="Fiyat Güncellenemedi";
       public static string AddTicketPrice = "Fiyat oluşturuldu";
        public static string  NotAddTicketPrice="Fiyat oluşturulamadı";
    };
}
