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

        public void AddBlogCommentLike(Guid blogCommentİd, BlogLikeDTO bloglikedto,Guid UserId)
        {
            if (!_context.BlogLikes.Any(l => l.BlogCommentId == blogCommentİd && l.UserId == UserId))
            {
                var newBlogCommentLike = new BlogLike
                {
                    LikeId = Guid.NewGuid(),
                    LikeDate = DateTime.Now,
                    BlogCommentId = blogCommentİd,
                    UserId = UserId
                };

                _context.BlogLikes.Add(newBlogCommentLike);
                _context.SaveChanges();
            }
        }

        public void AddBlogLike(Guid blogİd, BlogLikeDTO bloglikedto, Guid UserId)
        {
            if (!_context.BlogLikes.Any(l => l.BlogId == blogİd && l.UserId == UserId))
            {
                var newBlogLike = new BlogLike
                {
                    LikeId = Guid.NewGuid(),
                    LikeDate = DateTime.Now,
                };
                _context.BlogLikes.Add(newBlogLike);
                _context.SaveChanges();
            }
        }

        public void Delete(Guid id, Guid UserId)
        {
            var blogLikeToDelete = _context.BlogLikes.FirstOrDefault(l => l.LikeId == id && l.UserId ==UserId) ;

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
                          LikeDate = l.LikeDate,
                        }).ToList();

            return result;
        }   
        public List<BlogLikeDTO> GetLikesByBlogId(Guid BlogId)
        {

            var likes = _context.BlogLikes
                     .Where(l => l.BlogId == BlogId && l.Status == false)
                     .Select(l => new BlogLikeDTO
                     {
                         LikeDate = l.LikeDate,
                     })
                     .OrderByDescending(l => l.LikeDate)
                     .ToList();
            return likes;
        }
    }
}
