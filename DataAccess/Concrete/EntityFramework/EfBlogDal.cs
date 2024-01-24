using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Migrations;
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
        //bloğu yorum sayısı ve like sayısına göre sıralama
        public List<BlogDetailsDTO> GetBlogsByCommentAndLikeCount()
        {
            using (var context = new ProjeOdevContext())
            {
                var blogDetails = (from b in context.Blogs
                                   join l in context.BlogLikes on b.BlogId equals l.Blogid
                                   join bc in context.BlogComments on b.BlogId equals bc.BlogId
                                   where b.Status == false && l.Status == false && bc.Status == false
                                   group b by b.BlogId into groupedBlogs
                                   select new BlogDetailsDTO
                                   {
                                       İd = groupedBlogs.Key,
                                       BlogTitle = groupedBlogs.First().Title,
                                       BlogContent = groupedBlogs.First().Content,
                                       BlogDate = groupedBlogs.First().Date,
                                       BlogCommentCount = context.BlogComments.Count(c => c.BlogId == groupedBlogs.Key),
                                       BlogLikeCount = context.BlogLikes.Count(l => l.Blogid == groupedBlogs.Key)
                                   }).OrderByDescending(b => b.BlogLikeCount)
                                    .ThenByDescending(b => b.BlogCommentCount)
                                    .ToList();

                return blogDetails;
            }

        }
        //bloğun id'sine göre sıralama
        public BlogDTO GetBlogById(Guid id)
        {
            using (var context = _context)
            {
                var blog = context.Blogs
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
        }
        public void Update(Guid id, BlogDTO updatedBlogDto)
        {
            using (var context = _context)
            {
                var blogToUpdate = context.Blogs.FirstOrDefault(b => b.BlogId == id &&  b.Status == false);
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
            }
        }


    }
}




