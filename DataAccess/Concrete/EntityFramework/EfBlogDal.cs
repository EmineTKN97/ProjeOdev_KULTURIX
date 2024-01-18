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
                // Şimdi _context üzerinden veritabanı işlemlerinizi gerçekleştirebilirsiniz.
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
                _context.Blogs.Remove(blogToDelete);
                _context.SaveChanges();
            }
            
        }
        public List<BlogDetailsDTO> GetAllBlogDetails()
        {
                using (var context = new ProjeOdevContext())
                {
                    var result = from b in context.Blogs
                                 select new BlogDetailsDTO
                                 {
                                     İd = b.BlogId,
                                     BlogTitle= b.Title,
                                     BlogContent = b.Content,
                                     BlogDate=b.Date,
                                 };

                    return result.ToList();
                }
        }

        public List<BlogDTO> GetBlogDetails()
        {
            using (var context = new ProjeOdevContext())
            {
                    var result = from b in context.Blogs
                             select new BlogDTO
                             {
                              İd= b.BlogId, 
                              Title= b.Title,
                              Description=b.Content,
                              CreateDate=b.Date,    
                             };

                return result.ToList();
            }
        }

        public void Update(Guid id, BlogDTO updatedBlogDto)
        {
            using (var context = _context)
            {
                var blogToUpdate = context.Blogs.FirstOrDefault(b => b.BlogId == id);

                if (blogToUpdate != null)
                {
                    // Güncelleme işlemleri
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
 }   }

 

