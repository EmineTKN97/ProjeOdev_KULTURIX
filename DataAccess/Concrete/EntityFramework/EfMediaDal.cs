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
        public void AddBlogMedia(string fileName, Guid blogId)
        {
                var imageEntity = new Media
                {
                    ImagePath = fileName,
                    BlogId = blogId,
                    CreateDate = DateTime.Now,
                };
                _context.Medias.Add(imageEntity);
                _context.SaveChanges();
        }

        public void AddUserMedia(string fileName, Guid userId)
        {

            var imageUserEntity = new Media
            {
                ImagePath = fileName,
                UserId = userId,
                CreateDate = DateTime.Now,
            };
            _context.Medias.Add(imageUserEntity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var mediaToDelete = _context.Medias.FirstOrDefault(m => m.MediaId == id);

            if (mediaToDelete != null)
            {
                mediaToDelete.Status = true;
                _context.Medias.Update(mediaToDelete);
                _context.SaveChanges();
            }
        }

        public List<MediaDTO> GetAllMediaDetails()
        {
            var result = _context.Medias
                     .Where(m => m.Status == false)
                      .Select(m => new MediaDTO
                      {
                          MediaId = m.MediaId,
                          BlogId=m.BlogId.HasValue ? m.BlogId.Value : Guid.Empty,
                          UserId=m.UserId.HasValue ? m.UserId.Value : Guid.Empty,
                          CreateDate=m.CreateDate,
                          ImagePath=m.ImagePath,
                      }).ToList();

            return result;
        }

        public void Update(string fileName, Guid mediaId)
        {
            
            var existingMedia = _context.Medias.SingleOrDefault(m => m.MediaId == mediaId);

            if (existingMedia != null && existingMedia.Status == false)
            {
                existingMedia.ImagePath = fileName;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Belirtilen Id'ye sahip bir Media bulunamadı.");
            }

        }
    }
}
