using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMediaDal : EfEntityRepositoryBase<Media, ProjeOdevContext>, IMediaDal
    {
        private readonly ProjeOdevContext _context;

        public EfMediaDal(ProjeOdevContext context)
        {
            _context = context;
        }
        public void AddBlogMedia(string fileName, Guid blogId,Guid UserId)
        {
            var existingBlog = _context.Blogs.FirstOrDefault(b => b.BlogId == blogId && b.UserId == UserId && b.Status == false);

            if (existingBlog != null)
            { 
                var imageEntity = new Media
                {
                    ImagePath = fileName,
                    BlogId = blogId,
                    CreateDate = DateTime.Now,
                };

                _context.Medias.Add(imageEntity);
                _context.SaveChanges();

                // Blogun ImagePath alanını güncelle.
                existingBlog.ImagePath = fileName;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Belirtilen blog bulunamadı veya medya eklemek için izin yok.");
            }
        }

        public void AddUserMedia(string fileName, Guid userId)
        {
            var imageUserEntity = new Media
            {
                ImagePath = fileName,
                UserId = userId,
                CreateDate = DateTime.Now,
            };
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (existingUser != null)
            {
                if (string.Equals(existingUser.ImagePath, "wwwroot\\Uploads\\StaticContent\\default.jpg", StringComparison.OrdinalIgnoreCase))
                {
                    existingUser.ImagePath = fileName;
                    _context.SaveChanges();
                }
            }
            _context.Medias.Add(imageUserEntity);
            _context.SaveChanges();
        }

        public void Delete(Guid id, Guid UserId)
        {
            var mediaToDelete = _context.Medias.FirstOrDefault(m => m.MediaId == id && m.UserId == UserId);

            if (mediaToDelete != null)
            {
                // Medyayı sil
                mediaToDelete.Status = true;
                _context.Medias.Update(mediaToDelete);
                _context.SaveChanges();

                // Medya silindiğinde, kullanıcının resim alanını null yap
                var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == UserId);
                if (userToUpdate != null)
                {
                    userToUpdate.ImagePath ="wwwroot\\Uploads\\StaticContent\\default.jpg";
                    _context.SaveChanges();
                }
            }
            else
            {
                throw new Exception("Belirtilen medya bulunamadı veya silmek için izin yok.");
            }
        }

        public void DeleteBlogMedia(Guid id, Guid blogId, Guid UserId)
        {
            var mediaToDelete = _context.Medias.FirstOrDefault(m => m.MediaId == id && m.BlogId == blogId);

            if (mediaToDelete != null)
            {
                // Medyayı silen kullanıcı, bu medyanın bağlı olduğu blogun sahibi mi kontrol et.
                var associatedBlog = _context.Blogs.FirstOrDefault(b => b.BlogId == blogId && b.UserId == UserId && b.Status == false);

                if (associatedBlog != null)
                {
                    mediaToDelete.Status = true;
                    _context.Medias.Update(mediaToDelete);
                    _context.SaveChanges();

                    // Medya silindiğinde, bağlı olduğu blogun ImagePath alanını null yap.
                    associatedBlog.ImagePath ="wwwroot\\Uploads\\StaticContent\\default.jpg";
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Belirtilen medya bulunamadı veya silmek için izin yok.");
                }
            }
            else
            {
                throw new Exception("Belirtilen medya bulunamadı veya silmek için izin yok.");
            }
        }

        public List<MediaDTO> GetAllMediaDetails()
        {
            var result = _context.Medias
                     .Where(m => m.Status == false)
                      .Select(m => new MediaDTO
                      {
                         Name=m.User.Name,
                         SurName=m.User.SurName,
                         BlogDescription=m.blog.Content,
                         BlogTitle=m.blog.Title,
                         CreateDate=m.CreateDate,
                         ImagePath=m.ImagePath,
                      }).ToList();

            return result;
        }

        public void Update(string fileName, Guid mediaId, Guid UserId)
        {
            var existingMedia = _context.Medias.SingleOrDefault(m => m.MediaId == mediaId && m.UserId == UserId);

            if (existingMedia != null && existingMedia.Status == false)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Id == UserId);

                // Eğer güncellenen media, kullanıcının profil resmi ise, User tablosundaki ImagePath'i güncelle
                if (existingUser != null && existingUser.ImagePath == existingMedia.ImagePath)
                {
                    existingUser.ImagePath = fileName;
                }

                existingMedia.ImagePath = fileName;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Belirtilen medya bulunamadı veya güncellemek için izin yok.");
            }
        }
        public void UpdateBlogMedia(string fileName, Guid mediaId, Guid blogId, Guid UserId)
            {
            // Bloğu yazan kullanıcıyı kontrol et.
            var existingBlog = _context.Blogs.FirstOrDefault(b => b.BlogId == blogId && b.UserId == UserId && b.Status == false);

            if (existingBlog != null)
            {
                // Bloğu yazan kullanıcı, bloğun yazarı ve bloğun durumu false ise bu bloğa gir.
                var existingMedia = _context.Medias.SingleOrDefault(m => m.MediaId == mediaId && m.BlogId == blogId && m.Status == false);

                if (existingMedia != null)
                {
                    // existingMedia null değilse ve durumu false ise bu bloğa gir.
                    existingMedia.ImagePath = fileName;

                    // Blogun ImagePath alanını güncelle.
                    existingBlog.ImagePath = fileName;

                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Belirtilen medya bulunamadı veya güncellemek için izin yok.");
                }
            }
            else
            {
                throw new Exception("Belirtilen blog bulunamadı veya medya eklemek için izin yok.");
            }
        }
    }
}
