using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public void AddBlogCommentLike(Guid blogCommentİd, BlogLikeDTO bloglikedto)
        {
            var existingLike = _context.BlogLikes
             .FirstOrDefault(l => l.BlogCommentId == blogCommentİd);

            if (existingLike == null)
            {
                var newBlogCommentLike = new BlogLike
                {
                    LikeId = Guid.NewGuid(),
                    LikeDate = DateTime.Now,
                    BlogCommentId =bloglikedto.BlogCommentid,
                    UserId = bloglikedto.Userid
                };

                _context.BlogLikes.Add(newBlogCommentLike);
                _context.SaveChanges();
            }
        }

        public void AddBlogLike(Guid blogİd, BlogLikeDTO bloglikedto)
        {
               var existingLike = _context.BlogLikes
                    .FirstOrDefault(l => l.BlogId == blogİd);

                if (existingLike == null)
                {
                    var newBlogLike = new BlogLike
                    {
                        LikeId = Guid.NewGuid(),
                        LikeDate = DateTime.Now,
                        BlogId = bloglikedto.Blogid,
                        UserId = bloglikedto.Userid 
                    };

                    _context.BlogLikes.Add(newBlogLike);
                    _context.SaveChanges();
                }
            

        }

        public void Delete(Guid id)
        {
            var blogLikeToDelete = _context.BlogLikes.FirstOrDefault(l => l.LikeId == id);

            if (blogLikeToDelete != null)
            {
                blogLikeToDelete.Status = true;
                _context.BlogLikes.Update(blogLikeToDelete);
                _context.SaveChanges();
            }
        }

        public List<BlogLikeDTO> GetAllLikeDetails()
        {
              var result = _context.BlogLikes
                    .Where(l => l.Status == false)
                     .Select(l => new BlogLikeDTO
                     {
                         Likeİd = l.LikeId,
                         Blogid = l.BlogId.HasValue ? l.BlogId.Value : Guid.Empty,
                         BlogCommentid = l.BlogCommentId.HasValue ? l.BlogCommentId.Value : Guid.Empty,
                         LikeDate = l.LikeDate,
                         Userid = l.UserId,
                     }).ToList();

                return result;
            
        }

        public List<BlogLikeDTO> GetLikesByBlogId(Guid BlogId)
        {
            
                var likes = (from l in _context.BlogLikes
                             join b in _context.Blogs on l.BlogId equals b.BlogId
                             where l.BlogId == BlogId && l.Status == false && b.Status == false
                             select new BlogLikeDTO
                             {
                                 LikeDate = l.LikeDate,
                                 Userid = l.UserId,
                                 Likeİd = l.LikeId,
                                 Blogid = b.BlogId  
                             })
                            .OrderByDescending(l => l.LikeDate)
                            .ToList();
                return likes;
        }
    }
}
