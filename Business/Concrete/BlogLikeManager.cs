using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
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
        [SecuredOperation("USER")]
        [ValidationAspect(typeof(BlogLikeValidator))]
        [CacheRemoveAspect("IBlogLikeService.Get")]
        public async Task<IResult> AddBlogLike(Guid Blogİd, BlogLikeDTO bloglikedto, Guid UserId)
        {
            _bloglikeDal.AddBlogLike(Blogİd, bloglikedto,UserId);
            return new Result(true, Messages.BlogLikeAdded);
        }
        [SecuredOperation("USER")]
        [ValidationAspect(typeof(BlogLikeValidator))]
        [CacheRemoveAspect("IBlogLikeService.Get")]
        public async Task<IResult> AddBlogCommentLike(Guid BlogCommentİd, BlogLikeDTO bloglikedto, Guid UserId)
        {
            _bloglikeDal.AddBlogCommentLike(BlogCommentİd, bloglikedto,UserId);
            return new Result(true, Messages.BlogLikeAdded);
        }
        [SecuredOperation("USER")]
        [CacheRemoveAspect("IBlogLikeService.Get")]
        public  async Task<IResult> Delete(Guid İd, Guid UserId)
        {
            _bloglikeDal.Delete(İd,UserId);
            return new Result(true, Messages.BlogLikeDeleted);
        }
        [CacheAspect]
        public async Task<IDataResult<List<BlogLikeDTO>>> GetAllLikeDetails()
        {
            return new SuccessDataResult<List<BlogLikeDTO>>(_bloglikeDal.GetAllLikeDetails(), Messages.BlogLikedListed);
        }
        [CacheAspect]
        public async Task<IDataResult<List<BlogLikeDTO>>>GetLikesByBlogId(Guid BlogId)
        {
            return new SuccessDataResult<List<BlogLikeDTO>>(_bloglikeDal.GetLikesByBlogId(BlogId), Messages.BlogLikedListed);
        }
    }
}
