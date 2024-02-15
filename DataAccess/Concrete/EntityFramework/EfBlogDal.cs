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

        public void Add(BlogDTO blogdto, Guid userId)
        {
            var newBlog = new Blog
            {
                BlogId = Guid.NewGuid(),
                Title = blogdto.Title,
                Content = blogdto.Content,
                Date = DateTime.Now,
                ImagePath = "default.jpg",
                UserId = userId
            };

            _context.Blogs.Add(newBlog);
            _context.SaveChanges();
        }

        public void Delete(Guid id, Guid userId)
        {
            var blogToDelete = _context.Blogs.FirstOrDefault(b => b.BlogId == id && b.UserId ==userId);

            if (blogToDelete != null)
            {
                blogToDelete.Status = true;
                _context.Blogs.Update(blogToDelete);
                _context.SaveChanges();
            }
            else 
            {
                throw new Exception("Blog bulunamadı veya silinemedi.");
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
                                    && (bc.Status == false)
                                    && (m.Status == false)
                               group new { b, m } by b.BlogId into groupedBlogs
                               select new BlogDetailsDTO
                               {
                                   İd= groupedBlogs.First().b.BlogId,
                                   Title = groupedBlogs.First().b.Title,
                                   Content = groupedBlogs.First().b.Content,
                                   BlogDate = groupedBlogs.First().b.Date,
                                   İmagePath = groupedBlogs.First().m.ImagePath,
                                   Name = groupedBlogs.First().b.User.Name,
                                   SurName = groupedBlogs.First().b.User.SurName,
                                   BlogCommentCount = _context.BlogComments.Count(c => c.BlogId == groupedBlogs.Key),
                                   BlogLikeCount = _context.BlogLikes.Count(l => l.BlogId == groupedBlogs.Key)
                               })
           .OrderByDescending(b => b.BlogLikeCount)
           .ThenByDescending(b => b.BlogCommentCount)
           .ToList();
           foreach(var blogDetail in blogDetails)
{
                if (blogDetail.BlogCommentCount == 0 || blogDetail.BlogLikeCount == 0)
                {
                  
                     blogDetail.BlogLikeCount = 0;
                    blogDetail.BlogCommentCount = 0;
                }
            }

            return blogDetails;
        }
         
        public void Update(Guid id, BlogDTO updatedBlogDto, Guid UserId)
        {
            var blogToUpdate = _context.Blogs.FirstOrDefault(b => b.BlogId == id && b.UserId == UserId);

            if (blogToUpdate != null && blogToUpdate.Status == false)
            {
                blogToUpdate.Title = updatedBlogDto.Title;
                blogToUpdate.Content = updatedBlogDto.Content;
                blogToUpdate.Date = DateTime.Now;
                _context.Entry(blogToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Blog bulunamadı veya güncellenemedi.");
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

        public BlogDetailsDTO GetById(Guid BlogId)
        {
            var blogDetails = (from blog in _context.Blogs
                               where blog.BlogId == BlogId && blog.Status == false
                               select new BlogDetailsDTO
                               {
                                   İd = blog.BlogId,
                                   Title=blog.Title,
                                   Content = blog.Content,
                                   Name = blog.User.Name,
                                   SurName = blog.User.SurName,
                                   İmagePath = blog.ImagePath,
                                   BlogDate = blog.Date,
                                   BlogCommentCount = _context.BlogComments.Count(c => c.BlogId == BlogId),
                                   BlogLikeCount = _context.BlogLikes.Count(l => l.BlogId == BlogId)
                               }).FirstOrDefault();

            return blogDetails;
        }

        public List<BlogDTO> GetLatestBlog()
        {
            var blogDTOs = _context.Blogs
                       .OrderByDescending(b => b.Date)
                       .Where(b =>b.Status == false)
                       .Take(3)
                       .Select(b => new BlogDTO
                       {
                          İd = b.BlogId,
                          Title=b.Title,   
                          Content=b.Content,
                          İmagePath=b.ImagePath,
                       }).ToList();

            return blogDTOs;
        }
    }
    
}







