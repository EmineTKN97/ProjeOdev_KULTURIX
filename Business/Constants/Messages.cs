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
        public static string BlogLikeNotDeleted="Beğeni işlemi geri alınamadı";
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
        public static string BlogLikeAdded ="Beğeni işlemi başarılı";
        public static string BlogLikeDeleted="Beğeni işlemi geri alındı";
        public static string BlogLikedListed="Beğeniler listelendi";
        public static string BlogLikeNotAdded="Beğeni işlemi başarısız";
        public static string BlogLikedNotListed="Beğeni listeleme işlemi başarısız";
        public static string BlogCommentListed = "Yorumlar listelendi";
        public static string AddBlogİmage="Blog için resim başarı ile eklendi";
        public static string AddUserİmage = "Profil resiminiz başarı ile yüklendi";
        public static string MediaNotAdded="Resim eklenemedi";
        public static string UserAdded="Kullanıcı eklendi";
        public static string UserNotAdded="Kullanıcı eklenemedi";
        public static string MediaNotListed="Resimler listelenemedi";
        public static string MediaDeleted="Resim silindi";
        public static string MediaListed = "Resimler listelendi";
        public static string UpdateMedia="Resim güncellendi";
        public static string UserMediaListed="Profil fotoğrafları listelendi";
        public static string BlogMediaListed="Blog resimleri listelendi";
        public static string MediaNotDeleted="Resim silinemedi";
        public static string UserDeleted="Kullanıcı silindi";
        public static string UserListed="Kullanıcılar listelendi";
        public static string UserUpdated="Kullanıcılar güncellendi";
        public static string UserNotUpdated="Kullanıcı güncelleme işlemi başarısız";
        public static string UserNotDeleted="Kullanıcı silinemedi";
        public static string UserNotListed="Kullanıcılar listelenemedi";
        public static string MediaNotUpdated="Resim güncellenemdi";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre  hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
        internal static User UserRegistrationFailed;
    }
}
