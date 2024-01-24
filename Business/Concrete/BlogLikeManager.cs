using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogLikeManager : IBlogLikeService
    {
        private readonly IBlogLikeDal _bloglikeDal;

        public BlogLikeManager(IBlogLikeDal bloglikeDal)
        {
            _bloglikeDal = bloglikeDal;
        }

        public void AddBlogCommentLike(Guid BlogCommentİd, BlogLikeDTO bloglikedto)
        {
            _bloglikeDal.AddBlogCommentLike(BlogCommentİd, bloglikedto);
        }

        public void AddBlogLike(Guid Blogİd, BlogLikeDTO bloglikedto)
        {
            _bloglikeDal.AddBlogLike(Blogİd, bloglikedto);
        }

        public void Delete(Guid İd)
        {
            _bloglikeDal.Delete(İd);
        }

        public List<BlogLikeDTO> GetAllLikeDetails()
        {
            return _bloglikeDal.GetAllLikeDetails();
        }

        public List<BlogLikeDTO> GetLikesByBlogId(Guid BlogId)
        {
            return _bloglikeDal.GetLikesByBlogId(BlogId);
        }
    }
}
