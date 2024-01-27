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
        [ValidationAspect(typeof(BlogCommentValidator))]
        public IResult Add(Guid Blogİd, BlogCommentDTO blogcommentdto)
        { 
            _blogcommentDal.Add(Blogİd,blogcommentdto);
            return new Result(true, Messages.BlogCommentAdded);
        }

        public IResult Delete(Guid İd)
        {
            _blogcommentDal.Delete(İd);
            return new Result(true, Messages.BlogCommentDeleted);
        }

        public IResult Update(Guid id, BlogCommentDTO updatedCommentBlogDto)
        {
            _blogcommentDal.Update(id, updatedCommentBlogDto);
            return new Result(true, Messages.BlogCommentUpdated);
        }

        public IDataResult<List<BlogCommentDTO>> GetAllCommentsDetails()
        {
            return new SuccessDataResult<List<BlogCommentDTO>>(_blogcommentDal.GetAllCommentDetails(),Messages.BlogCommentListed);
        }

       public  IDataResult<List<BlogCommentDTO>>GetCommentsByBlogId(Guid BlogId)
        {
            return new SuccessDataResult<List<BlogCommentDTO>>(_blogcommentDal.GetCommentsByBlogId(BlogId),Messages.BlogCommentListed);

        }
    }
}
