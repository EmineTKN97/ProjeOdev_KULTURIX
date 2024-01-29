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
            var newBlog = new Blog
            {
                BlogId = Guid.NewGuid(),
                Title = blogdto.Title,
                Content = blogdto.Description,
                Date = DateTime.Now,
                UserId = blogdto.UserId,
                ImagePath =  "wwwroot\\Uploads\\StaticContent\\default.jpg"
            };
            _context.Blogs.Add(newBlog);
            _context.SaveChanges();
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
        //bloğu yorum sayısı ve like sayısına göre sıralama
        public List<BlogDetailsDTO> GetBlogsByCommentAndLikeCount()
        {
            var blogDetails = (from b in _context.Blogs
                               join l in _context.BlogLikes on b.BlogId equals l.BlogId
                               join bc in _context.BlogComments on b.BlogId equals bc.BlogId
                               join m in _context.Medias on b.BlogId equals m.BlogId
                             where (b.Status == false) 
                                  && (l.Status == false)
                                  && (bc.Status == false )
                                  && (m.Status == false )
                               group new { b, m } by b.BlogId into groupedBlogs
                               select new BlogDetailsDTO
                               {
                                   İd = groupedBlogs.Key,
                                   BlogTitle = groupedBlogs.First().b.Title,
                                   BlogContent = groupedBlogs.First().b.Content,
                                   BlogDate = groupedBlogs.First().b.Date,
                                   İmagePath = groupedBlogs.First().m.ImagePath,
                                   BlogCommentCount = _context.BlogComments.Count(c => c.BlogId == groupedBlogs.Key),
                                   BlogLikeCount = _context.BlogLikes.Count(l => l.BlogId == groupedBlogs.Key)
                               })
                   .OrderByDescending(b => b.BlogLikeCount)
                   .ThenByDescending(b => b.BlogCommentCount)
                   .ToList();
            return blogDetails;


        }
        //bloğun id'sine göre sıralama
        public BlogDTO GetBlogById(Guid id)
        {
            var blog = _context.Blogs
                .Where(b => b.BlogId == id)
                .FirstOrDefault();

            if (blog != null)
            {
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
                return null;
            }

        }
        public void Update(Guid id, BlogDTO updatedBlogDto)
        {

            var blogToUpdate = _context.Blogs.FirstOrDefault(b => b.BlogId == id);
            if (blogToUpdate != null && blogToUpdate.Status == false)
            {
                blogToUpdate.Title = blogToUpdate.Title;
                blogToUpdate.Content = blogToUpdate.Content;
                blogToUpdate.UserId = updatedBlogDto.UserId;
                blogToUpdate.Date = DateTime.Now;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Blog güncellenemedi");
            }
        }
        //userın bloglarını eklenme tarihine göre sıralama
        public List<Blog> GetByUserId(Guid userId)
        {

            var blogs = (from b in _context.Blogs
                          join u in _context.Users on b.UserId equals u.Id
                          where b.UserId == userId
                          orderby b.Date descending
                          select new Blog
                          {
                              BlogId = b.BlogId,
                              Title = b.Title,
                              Content = b.Content,
                              ImagePath = b.ImagePath,    
                          }).ToList();

            return blogs;
        }
    }
}







