using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
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

        public void Add(Guid Blogİd,BlogCommentDTO blogcommentdto)
        {
            using (var context = _context)
            {
                
                    var newBlogComment = new BlogComment
                    {
                        CommentId = Guid.NewGuid(),
                        Title = blogcommentdto.CommentTitle,
                        CommentText = blogcommentdto.CommentDetail,
                        UserId = blogcommentdto.UserId,
                        CommentDate= DateTime.Now,
                        BlogId = blogcommentdto.BlogId,
  
                    };
                // BlogComments tablosuna yeni yorumu ekle
        
                  context.BlogComments.Add(newBlogComment);//blogid sıfırlanıyor
                context.SaveChanges();

            }
        }


        public void Delete(Guid id)
        {
            var blogCommentToDelete = _context.BlogComments.FirstOrDefault(c =>c.CommentId  == id);

            if (blogCommentToDelete != null)
            {
                blogCommentToDelete.Status = true;
                _context.BlogComments.Update(blogCommentToDelete);
                _context.SaveChanges();
            }
        }

        public List<BlogCommentDTO> GetAllCommentDetails()
        {
            using (var context = new ProjeOdevContext())
            {
                var result = context.BlogComments
                    .Where(bc =>bc.Status== false)
                     .Select(bc => new BlogCommentDTO
                             {
                                CommentDate = bc.CommentDate,
                                CommentDetail= bc.CommentText,
                                CommentTitle =bc.Title,
                                Id=bc.CommentId,
                                UserId=bc.UserId,
                        
                                
                             }).ToList();

                return result;
            }
        }

     
        public void Update(Guid id, BlogCommentDTO updatedCommentBlogDto)
        {
            using (var context = _context)
            {
                var blogToUpdate = context.BlogComments.FirstOrDefault(c => c.CommentId == id);

                if (blogToUpdate != null)
                {
                    // Güncelleme işlemleri
                    blogToUpdate.Title = updatedCommentBlogDto.CommentTitle ?? blogToUpdate.Title;
                    blogToUpdate.CommentText = updatedCommentBlogDto.CommentDetail ?? blogToUpdate.CommentText;

                    if (updatedCommentBlogDto.CommentDate != null)
                    {
                        blogToUpdate.CommentDate = updatedCommentBlogDto.CommentDate;
                    }
                    else
                    {
                        blogToUpdate.CommentDate = DateTime.Now;
                    }
                    // Eğer CreateDate değeri atanmamışsa, varsayılan değer olarak DateTime.Now kullanılır.

                    // Değişiklikleri kaydet
                    context.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("Güncellenmek istenen blog bulunamadı.");
                }
            }
        }
    }
}
