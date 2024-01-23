using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Migrations;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBlogLikeDal : EfEntityRepositoryBase<BlogLike, ProjeOdevContext>, IBlogLikeDal
    {
        private readonly ProjeOdevContext _context;

        public EfBlogLikeDal(ProjeOdevContext context)
        {
            _context = context;
        }

        public void Add(Guid blogİd, BlogLikeDTO bloglikedto)
        {
            using (var context = _context)
            {
                // Veritabanından belirli bir blog ve kullanıcıya ait like'ı kontrol et
                var existingLike = context.BlogLikes
                    .FirstOrDefault(l => l.Blogid == blogİd);

                // Eğer daha önce like eklenmemişse, yeni bir like oluştur ve ekleyin
                if (existingLike == null)
                {
                    var newBlogLike = new BlogLike
                    {
                        LikeId = Guid.NewGuid(),
                        LikeDate = DateTime.Now,
                        Blogid = bloglikedto.Blogid,
                        BlogCommentId=bloglikedto.BlogCommentid
                    };

                    context.BlogLikes.Add(newBlogLike);
                    context.SaveChanges();
                }
                // Eğer daha önce like eklenmişse, burada gerekirse güncelleme veya hata yönetimi yapabilirsiniz
                // Örneğin: existingLike.Status'u güncelleyerek like'ı tekrar etkin hale getirebilirsiniz.
            }
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<BlogLikeDTO> GetAllLikeDetails()
        {
            throw new NotImplementedException();
        }
    }
}
