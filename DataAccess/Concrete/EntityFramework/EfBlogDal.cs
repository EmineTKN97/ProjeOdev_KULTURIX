using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, ProjeOdevContext>, IBlogDal
    {
        private readonly ProjeOdevContext _context;

        public EfBlogDal(ProjeOdevContext context)
        {
            _context = context;
        }

        public void Add(BlogDTO blogdto)
        {
            using (var context = _context)
            {
                var newBlog = new Blog
                {
                    BlogId = Guid.NewGuid(),
                    Title = blogdto.Title,
                    Content = blogdto.Description,
                    Date = DateTime.Now
                };

                context.Blogs.Add(newBlog);
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            var blogToDelete = _context.Blogs.FirstOrDefault(b => b.BlogId == id);

            if (blogToDelete != null)
            {
                blogToDelete.Status = true;
                _context.Blogs.Update(blogToDelete);
                _context.SaveChanges();
            }

        }
        public List<BlogDetailsDTO> GetAllBlogDetails()
        {
            using (var context = new ProjeOdevContext())
            {
                var result = from b in context.Blogs
                             join bc in context.BlogComments
                             on b.BlogId equals bc.BlogId
                             where b.Status == false

                             select new BlogDetailsDTO
                             {
                                 İd = b.BlogId,
                                 BlogTitle = b.Title,
                                 BlogContent = b.Content,
                                 BlogDate = b.Date,
                                 BlogCommentDate = bc.CommentDate,
                                 BlogCommentText = bc.CommentText,
                                 BlogCommentTitle = bc.Title,
                             };

                return result.ToList();
            }
        }

        public List<BlogDTO> GetBlogDetails()
        {
            using (var context = new ProjeOdevContext())
            {
                var result = context.Blogs
                    .Where(b => b.Status == false)
                    .Select(b => new BlogDTO
                    {
                        Id = b.BlogId,
                        Title = b.Title,
                        Description = b.Content,
                        CreateDate = b.Date,
                    })
                    .ToList();

                return result;
            }
        }


        public BlogDTO GetBlogById(Guid id)
        {
            using (var context = _context)
            {
                var blog = context.Blogs
                    .Where(b => b.BlogId == id)
                    .FirstOrDefault();

                if (blog != null)
                {
                    // Blog varsa BlogDTO'ya dönüştür ve geri döndür
                    var blogDto = new BlogDTO
                    {
                        Id = blog.BlogId,
                        Title = blog.Title,
                        Description = blog.Content,
                        CreateDate = blog.Date
                    };

                    return blogDto;
                }
                else
                {
                    // Blog bulunamazsa null döndür
                    return null;
                }
            }
        }

        public void Update(Guid id, BlogDTO updatedBlogDto)
        {
            using (var context = _context)
            {
          
                var blogToUpdate = context.Blogs.FirstOrDefault(b => b.BlogId == id);

                if (blogToUpdate != null)
                {
                    
                    blogToUpdate.Title = updatedBlogDto.Title ?? blogToUpdate.Title;
                    blogToUpdate.Content = updatedBlogDto.Description ?? blogToUpdate.Content;

                    if (updatedBlogDto.CreateDate != null)
                    {
                        blogToUpdate.Date = updatedBlogDto.CreateDate;
                    }
                    else
                    {
                        blogToUpdate.Date = DateTime.Now;
                    }

                    
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




