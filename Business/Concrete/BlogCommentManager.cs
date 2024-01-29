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
        //[ValidationAspect(typeof(BlogCommentValidator))]
        public async Task<IResult> Add(Guid Blogİd, BlogCommentDTO blogcommentdto)
        {
           _blogcommentDal.Add(Blogİd, blogcommentdto);
            return new Result(true, Messages.BlogCommentAdded);
        }

        public async Task<IResult> Delete(Guid İd)
        {
            _blogcommentDal.Delete(İd);
            return new Result(true, Messages.BlogCommentDeleted);
        }

        public async Task<IResult> Update(Guid id, BlogCommentDTO updatedCommentBlogDto)
        {
            try
            {

               _blogcommentDal.Update(id, updatedCommentBlogDto);
                return new Result(true, Messages.BlogCommentUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.BlogCommentNotUpdated);
            }
        }

        public async Task<IDataResult<List<BlogCommentDTO>>> GetAllCommentsDetails()
        {
            return new SuccessDataResult<List<BlogCommentDTO>>(_blogcommentDal.GetAllCommentDetails());
        }

       public async Task<IDataResult<List<BlogCommentDTO>>> GetCommentsByBlogId(Guid BlogId)
        {
            return new SuccessDataResult<List<BlogCommentDTO>>(_blogcommentDal.GetCommentsByBlogId(BlogId), Messages.BlogCommentListed);
        }
    }
}
