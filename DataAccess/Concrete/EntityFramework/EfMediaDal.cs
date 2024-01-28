using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
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
    }
}
