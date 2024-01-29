using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
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
    public class EfBlogCommentDal : EfEntityRepositoryBase<BlogComment, ProjeOdevContext>, IBlogCommentDal
    {
        private readonly ProjeOdevContext _context;

        public EfBlogCommentDal(ProjeOdevContext context)
        {
            _context = context;
        }

        public void Add(Guid Blogİd, BlogCommentDTO blogcommentdto)
        {
                var newBlogComment = new BlogComment
                {
                    CommentId = Guid.NewGuid(),
                    Title = blogcommentdto.CommentTitle,
                    CommentText = blogcommentdto.CommentDetail,
                    UserId = blogcommentdto.UserId,
                    CommentDate = DateTime.Now,
                    BlogId = blogcommentdto.BlogId,
                };
                _context.BlogComments.Add(newBlogComment);
                _context.SaveChanges();

            
        }
        public void Delete(Guid id)
        {
            var blogCommentToDelete = _context.BlogComments.FirstOrDefault(c => c.CommentId == id);

            if (blogCommentToDelete != null)
            {
                blogCommentToDelete.Status = true;
                _context.BlogComments.Update(blogCommentToDelete);
                _context.SaveChanges();
            }
        }
        //Blog yorumunu like göre sıralama
        public List<BlogCommentDTO> GetAllCommentDetails()
        {
              var result = (
                    from bc in _context.BlogComments
                    join l in _context.BlogLikes
                    on bc.CommentId equals l.BlogCommentId
                    where bc.Status == false && l.Status == false
                    select new BlogCommentDTO
                    {
                        CommentDate = bc.CommentDate,
                        CommentDetail = bc.CommentText,
                        CommentTitle = bc.Title,
                        Id = bc.CommentId,
                        UserId = bc.UserId,
                        BlogLikeCount = _context.BlogLikes.Count(l => l.BlogCommentId == bc.CommentId)
                    }).OrderByDescending(b => b.BlogLikeCount).ToList();
                return result;
            
        }
        //Blog yorumunu Blogunid'sine göre sıralama
        public List<BlogCommentDTO> GetCommentsByBlogId(Guid BlogId)
        {
                var comments = (from bc in _context.BlogComments
                                join b in _context.Blogs
                                on bc.BlogId equals b.BlogId
                                where bc.BlogId == BlogId && bc.Status == false && b.Status == false
                                select new BlogCommentDTO
                                {
                                    CommentDate = bc.CommentDate,
                                    CommentDetail = bc.CommentText,
                                    CommentTitle = bc.Title,
                                    Id = bc.CommentId,
                                    UserId = bc.UserId,
                                    BlogLikeCount = _context.BlogLikes.Count(l => l.BlogCommentId == bc.CommentId && l.Status == false)
                                }).OrderByDescending(bc => bc.CommentDate).ToList();
                return comments;

            
        }

        public void Update(Guid id, BlogCommentDTO updatedCommentBlogDto)
        {
          
                var blogCommentToUpdate = _context.BlogComments.FirstOrDefault(c => c.CommentId == id);
                if (blogCommentToUpdate != null && blogCommentToUpdate.Status == false)
                {
                    blogCommentToUpdate.Title = updatedCommentBlogDto.CommentTitle;
                    blogCommentToUpdate.CommentText = updatedCommentBlogDto.CommentDetail;
                    blogCommentToUpdate.CommentDate = DateTime.Now;

                     _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Blog Yorum güncellenemedi");
                }
            
        }
    }
}



