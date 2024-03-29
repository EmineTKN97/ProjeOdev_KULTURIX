﻿using Core.DataAccess.EntityFramework;
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
        public async Task Delete(Guid id, Guid userId)
        {
            var blogCommentToDelete = await _context.BlogComments
                .FirstOrDefaultAsync(c => c.CommentId == id && c.UserId == userId && c.Status == false);

            if (blogCommentToDelete != null)
            {
                blogCommentToDelete.Status = true;
                _context.BlogComments.Update(blogCommentToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Yorum silinemedi. Yorum ID: {id}, Kullanıcı ID: {userId}");
            }
        }
        public List<BlogCommentDTO> GetAllCommentDetails()
        {
            var result = (
                from bc in _context.BlogComments
                where bc.Status == false
                orderby bc.CommentDate descending
                select new BlogCommentDTO
                {
                    Email = bc.User.Email,
                    UserName = bc.User.Name,
                    UserSurname = bc.User.SurName,
                    UserİmagePath = bc.User.ImagePath,
                    CommentDate = bc.CommentDate,
                    CommentDetail = bc.CommentText,
                    CommentTitle = bc.Title,
                    CommentId = bc.CommentId,
                    BlogTitle = bc.Blog.Title,
                    BlogId = bc.BlogId,
                    UserId = bc.UserId  
                }).ToList();

            return result;
        }
        public List<BlogCommentDTO> GetByCommentUserId(Guid userId)
        {

            var blogComments = (from bc in _context.BlogComments
                                join u in _context.Users on bc.UserId equals u.Id
                                join b in _context.Blogs on bc.BlogId equals b.BlogId
                                where bc.UserId == userId && bc.Status == false
                                select new BlogCommentDTO
                                {
                                    CommentDate = bc.CommentDate,
                                    CommentDetail = bc.CommentText,
                                    CommentTitle = bc.Title,
                                    BlogTitle = b.Title, 
                                    UserName = b.User.Name,
                                    UserSurname = b.User.SurName,
                                    UserİmagePath= bc.User.ImagePath,
                                    BlogId=b.BlogId,
                                   CommentId= bc.CommentId
                                }).ToList();

            return blogComments;
        }

        public BlogCommentDTO GetById(Guid commentId)
        {
            var blogCommentDetails = (from bc in _context.BlogComments
                               where bc.CommentId == commentId && bc.Status == false
                               select new BlogCommentDTO
                               {
                                   CommentDate = bc.CommentDate,
                                   CommentDetail = bc.CommentText,
                                   CommentTitle = bc.Title,
                                   CommentId = bc.CommentId,
                                   UserName= bc.User.Name,
                                   UserSurname= bc.User.SurName
                               }).FirstOrDefault();

            return blogCommentDetails;
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
                                UserİmagePath= bc.User.ImagePath,
                                UserName = bc.User.Name,
                                UserSurname = bc.User.SurName,
                                CommentDate = bc.CommentDate,
                                CommentDetail = bc.CommentText,
                                CommentTitle = bc.Title,
                            })
                 .OrderByDescending(bc => bc.CommentDate)
                 .ToList();

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



