using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Migrations;
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
            using (var context = _context)
            {
                var existingLike = context.BlogLikes
                    .FirstOrDefault(l => l.BlogCommentId == blogCommentİd);

                if (existingLike == null)
                {
                    var newBlogLike = new BlogLike
                    {
                        LikeId = Guid.NewGuid(),
                        LikeDate = DateTime.Now,
                        BlogCommentId = bloglikedto.BlogCommentid
                    };

                    context.BlogLikes.Add(newBlogLike);
                    context.SaveChanges();
                }
            }
        }

        public void AddBlogLike(Guid blogİd, BlogLikeDTO bloglikedto)
        {
            using (var context = _context)
            {
                var existingLike = context.BlogLikes
                    .FirstOrDefault(l => l.Blogid == blogİd);

                if (existingLike == null)
                {
                    var newBlogLike = new BlogLike
                    {
                        LikeId = Guid.NewGuid(),
                        LikeDate = DateTime.Now,
                        Blogid = bloglikedto.Blogid,
                    };

                    context.BlogLikes.Add(newBlogLike);
                    context.SaveChanges();
                }
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
            using (var context = new ProjeOdevContext())
            {
                var result = context.BlogLikes
                    .Where(l => l.Status == false)
                     .Select(l => new BlogLikeDTO
                     {
                         Likeİd = l.LikeId,
                         Blogid = l.Blogid.HasValue ? l.Blogid.Value : Guid.Empty,
                         BlogCommentid = l.BlogCommentId.HasValue ? l.BlogCommentId.Value : Guid.Empty,
                         LikeDate = l.LikeDate,
                         Userid = l.Userid,
                     }).ToList();

                return result;
            }
        }

        public List<BlogLikeDTO> GetLikesByBlogId(Guid BlogId)
        {
            using (var context = new ProjeOdevContext())
            {
                var likes = (from l in context.BlogLikes
                             join b in context.Blogs on l.Blogid equals b.BlogId
                             where l.Blogid == BlogId && l.Status == false && b.Status == false
                             select new BlogLikeDTO
                             {
                                 LikeDate = l.LikeDate,
                                 Userid = l.Userid,
                                 Likeİd = l.LikeId,
                                 Blogid = b.BlogId  
                             })
                            .OrderByDescending(l => l.LikeDate)
                            .ToList();
                return likes;
            }
        }
    }
}
