using Business.Abstract;
using Business.Constants;
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
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        [ValidationAspect(typeof(BlogValidator))]
        public IResult Add(BlogDTO blogdto)
        {
                _blogDal.Add(blogdto);
                return new Result(true, Messages.BlogAdded);
        }

       public  IResult Delete(Guid İd)
        {
            _blogDal.Delete(İd);
            return new Result(true, Messages.BlogDeleted);
        }

       public IDataResult<List<BlogDetailsDTO>> GetBlogsByCommentAndLikeCount()
        {
            return new SuccessDataResult<List<BlogDetailsDTO>>(_blogDal.GetBlogsByCommentAndLikeCount(),Messages.BlogListed); 
        }

        public IDataResult<Blog> GetById(Guid id)
        {
            return new SuccessDataResult<Blog>(_blogDal.Get(blog => blog.BlogId == id), Messages.BlogListed);
        }

       public  IResult Update(Guid id, BlogDTO updatedBlogDto)
        {
            _blogDal.Update(id, updatedBlogDto);
            return new Result(true,Messages.BlogUpdated);
        }
    }
}
