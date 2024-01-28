using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        //[ValidationAspect(typeof(BlogLikeValidator))]
        public async Task<IResult> AddBlogLike(Guid Blogİd, BlogLikeDTO bloglikedto)
        {
            _bloglikeDal.AddBlogLike(Blogİd, bloglikedto);
            return new Result(true, Messages.BlogLikeAdded);
        }
        //[ValidationAspect(typeof(BlogLikeValidator))]
        public async Task<IResult> AddBlogCommentLike(Guid BlogCommentİd, BlogLikeDTO bloglikedto)
        {
            _bloglikeDal.AddBlogCommentLike(BlogCommentİd, bloglikedto);
            return new Result(true, Messages.BlogLikeAdded);
        }

        public  async Task<IResult> Delete(Guid İd)
        {
            _bloglikeDal.Delete(İd);
            return new Result(true, Messages.BlogLikeDeleted);
        }

        public async Task<IDataResult<List<BlogLikeDTO>>> GetAllLikeDetails()
        {
            return new SuccessDataResult<List<BlogLikeDTO>>(_bloglikeDal.GetAllLikeDetails(), Messages.BlogLikedListed);
        }

        public async Task<IDataResult<List<BlogLikeDTO>>>GetLikesByBlogId(Guid BlogId)
        {
            return new SuccessDataResult<List<BlogLikeDTO>>(_bloglikeDal.GetLikesByBlogId(BlogId), Messages.BlogLikedListed);
        }
    }
}
