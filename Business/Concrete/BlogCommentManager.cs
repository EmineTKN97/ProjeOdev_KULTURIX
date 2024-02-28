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
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogCommentManager : IBlogCommentService
    {
        private readonly IBlogCommentDal _blogcommentDal;
        public BlogCommentManager(IBlogCommentDal blogcommentDal)
        {
            _blogcommentDal = blogcommentDal;
        }
        [SecuredOperation("USER")]
        [ValidationAspect(typeof(BlogCommentValidator))]
        [CacheRemoveAspect("IBlogCommentService.Get")]
        public async Task<IResult> Add(Guid Blogİd, BlogCommentDTO blogcommentdto, Guid userId)
        {
           _blogcommentDal.Add(Blogİd, blogcommentdto, userId);
            return new SuccessResult(Messages.BlogCommentAdded);
        }
        [SecuredOperation("USER")]
       [CacheRemoveAspect("IBlogCommentService.Get")]
        public async Task<IResult> Delete(Guid İd, Guid userId)
        {
            _blogcommentDal.Delete(İd,userId);
            return new Result(true, Messages.BlogCommentDeleted);
        }
        [SecuredOperation("USER")]
        [ValidationAspect(typeof(BlogCommentValidator))]
       [CacheRemoveAspect("IBlogCommentService.Get")]
        public async Task<IResult> Update(Guid id, BlogCommentDTO updatedCommentBlogDto, Guid userId)
        {
            try
            {

               _blogcommentDal.Update(id, updatedCommentBlogDto,userId);
                return new Result(true, Messages.BlogCommentUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.BlogCommentNotUpdated);
            }
        }
        [CacheAspect]
        public async Task<IDataResult<List<BlogCommentDTO>>> GetAllCommentsDetails()
        {
            return new SuccessDataResult<List<BlogCommentDTO>>(_blogcommentDal.GetAllCommentDetails());
        }
        [CacheAspect]
        public async Task<IDataResult<List<BlogCommentDTO>>> GetCommentsByBlogId(Guid BlogId)
        {
            return new SuccessDataResult<List<BlogCommentDTO>>(_blogcommentDal.GetCommentsByBlogId(BlogId), Messages.BlogCommentListed);
        }

        public async Task<IDataResult<List<BlogCommentDTO>>> GetByCommentUserId(Guid UserId)
        {
            return new SuccessDataResult<List<BlogCommentDTO>>(_blogcommentDal.GetByCommentUserId(UserId), Messages.BlogCommentListed);
        }

        public async Task<IDataResult<BlogCommentDTO>> GetById(Guid CommentId)
        {
            return new SuccessDataResult<BlogCommentDTO>(_blogcommentDal.GetById(CommentId), Messages.BlogCommentListed);
        }
    }
}
