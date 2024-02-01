using Business.Abstract;
using Business.BusinessAspect.Autofac;
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
        [ValidationAspect(typeof(BlogLikeValidator))]
        [SecuredOperation("USER")]
        public async Task<IResult> AddBlogLike(Guid Blogİd, BlogLikeDTO bloglikedto, Guid UserId)
        {
            _bloglikeDal.AddBlogLike(Blogİd, bloglikedto,UserId);
            return new Result(true, Messages.BlogLikeAdded);
        }
        [ValidationAspect(typeof(BlogLikeValidator))]
        [SecuredOperation("USER")]
        public async Task<IResult> AddBlogCommentLike(Guid BlogCommentİd, BlogLikeDTO bloglikedto, Guid UserId)
        {
            _bloglikeDal.AddBlogCommentLike(BlogCommentİd, bloglikedto,UserId);
            return new Result(true, Messages.BlogLikeAdded);
        }
        [SecuredOperation("USER")]
        public  async Task<IResult> Delete(Guid İd, Guid UserId)
        {
            _bloglikeDal.Delete(İd,UserId);
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
