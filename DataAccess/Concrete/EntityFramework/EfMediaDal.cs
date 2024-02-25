using Autofac.Features.Metadata;
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
                if (string.Equals(existingUser.ImagePath, "user.jpg", StringComparison.OrdinalIgnoreCase))
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
                    userToUpdate.ImagePath ="user.jpg";
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
                var associatedBlog = _context.Blogs.FirstOrDefault(b => b.BlogId == blogId && b.UserId == UserId && b.Status == false);

                if (associatedBlog != null)
                {
                    mediaToDelete.Status = true;
                    _context.Medias.Update(mediaToDelete);
                    _context.SaveChanges();
                    associatedBlog.ImagePath ="default.jpg";
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


        public void Update(string fileName, Guid UserId)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == UserId);

            if (existingUser != null)
            {
                existingUser.ImagePath = fileName;
                _context.SaveChanges();
            }

        }
        public void UpdateBlogMedia(string fileName, Guid blogId, Guid UserId)
        {
            var existingBlog = _context.Blogs.FirstOrDefault(b => b.BlogId == blogId && b.UserId == UserId && b.Status == false);

            if (existingBlog != null)
            {
                var existingMedia = _context.Medias.SingleOrDefault(m => m.BlogId == blogId && m.Status == false);

                if (existingMedia != null)
                {
                    existingMedia.ImagePath = fileName;
                    existingBlog.ImagePath = fileName;
                }
                else
                {
                    var newMedia = new Media
                    {
                        BlogId = blogId,
                        ImagePath = fileName,
                        CreateDate = DateTime.Now,
                    };

                    _context.Medias.Add(newMedia);
                    existingBlog.ImagePath = fileName;
                }
                    existingBlog.ImagePath = fileName;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Belirtilen blog bulunamadı veya medya eklemek için izin yok.");
            }
        }
    }
}
