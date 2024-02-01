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

        public void Add(Guid Blogİd, BlogCommentDTO blogcommentdto,Guid UserId)
        {
            var existingBlog = _context.Blogs.FirstOrDefault(b => b.BlogId == Blogİd && b.Status == false);
            if (existingBlog == null)
            {
                throw new Exception("Belirtilen blog bulunamadı.");
            }

            if (string.IsNullOrEmpty(blogcommentdto.CommentTitle) || string.IsNullOrEmpty(blogcommentdto.CommentDetail))
            { 
                throw new Exception("Yorum başlık ve detayı boş olamaz.");
            }

            var newBlogComment = new BlogComment
            {
                CommentId = Guid.NewGuid(),
                Title = blogcommentdto.CommentTitle,
                CommentText = blogcommentdto.CommentDetail,
                UserId = UserId,
                CommentDate = DateTime.Now,
                BlogId = Blogİd,
            };

            _context.BlogComments.Add(newBlogComment);
            _context.SaveChanges();


        }
        public void Delete(Guid id,Guid userId)
        {
            var blogCommentToDelete = _context.BlogComments.FirstOrDefault(c => c.CommentId == id && c.UserId == userId && c.Status == false);

            if (blogCommentToDelete != null)
            {
                blogCommentToDelete.Status = true;
                _context.BlogComments.Update(blogCommentToDelete);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Belirtilen yorum bulunamadı veya silme izinleri yok.");
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

        public void Update(Guid id, BlogCommentDTO updatedCommentBlogDto, Guid UserId)
        {
            var blogCommentToUpdate = _context.BlogComments.FirstOrDefault(c => c.CommentId == id && c.UserId == UserId && c.Status == false);

            if (blogCommentToUpdate != null)
            {
                blogCommentToUpdate.Title = updatedCommentBlogDto.CommentTitle;
                blogCommentToUpdate.CommentText = updatedCommentBlogDto.CommentDetail;
                blogCommentToUpdate.CommentDate = DateTime.Now;
                _context.SaveChanges();
            }
            else
            {  
                throw new Exception("Belirtilen blog yorumu bulunamadı veya güncelleme izinleri yok.");
            }

        }
    }
}



