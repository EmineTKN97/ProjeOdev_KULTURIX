using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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


        public IResult AddBlogCommentLike(Guid Blogcommentİd, BlogLikeDTO bloglikedto)
        {
            _bloglikeDal.AddBlogCommentLike(Blogcommentİd, bloglikedto);
            return new Result(true, Messages.BlogLikeAdded);
        }

        public IResult AddBlogLike(Guid Blogİd, BlogLikeDTO bloglikedto)
        {
            _bloglikeDal.AddBlogLike(Blogİd, bloglikedto);
            return new Result(true, Messages.BlogLikeAdded);
        }

        IResult IBlogLikeService.Delete(Guid İd)
        {
            _bloglikeDal.Delete(İd);
            return new Result(true, Messages.BlogLikeDeleted);
        }

        public IDataResult<List<BlogLikeDTO>> GetAllLikeDetails()
        {
            return new SuccessDataResult<List<BlogLikeDTO>>(_bloglikeDal.GetAllLikeDetails(), Messages.BlogLikedListed);
        }

        public IDataResult<List<BlogLikeDTO>> GetLikesByBlogId(Guid BlogId)
        {
            return new SuccessDataResult<List<BlogLikeDTO>>(_bloglikeDal.GetLikesByBlogId(BlogId), Messages.BlogLikedListed);
        }
    }
}
