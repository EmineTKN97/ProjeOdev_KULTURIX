using Business.Abstract;
using Business.Constants;
using Business.Helper;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
 IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public async Task<IResult> Delete(Guid İd)
        {
            _blogDal.Delete(İd);
            return new Result(true, Messages.BlogDeleted);
        }

        public async Task<IDataResult<List<BlogDetailsDTO>>> GetBlogsByCommentAndLikeCount()
        {
            return new SuccessDataResult<List<BlogDetailsDTO>>(_blogDal.GetBlogsByCommentAndLikeCount(), Messages.BlogListed);
        }

        public async Task<IDataResult<Blog>> GetById(Guid id)
        {
            return new SuccessDataResult<Blog>(_blogDal.Get(blog => blog.BlogId == id), Messages.BlogListed);
        }
        public async Task<IResult>Update(Guid id, BlogDTO updatedBlogDto)
        {
            _blogDal.Update(id, updatedBlogDto);
            return new Result(true, Messages.BlogUpdated);
        }
        // [ValidationAspect(typeof(BlogValidator))
        public async Task<IResult> Add(IFormFile file,BlogDTO blogdto)
        {
            string uniqueFileName = Guid.NewGuid().ToString();
            string fileExtension = Path.GetExtension(file.FileName);
            string fileName = uniqueFileName + fileExtension;

            var filePath = Common.GetFilePath(fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            _blogDal.AddImage(fileName,blogdto);
            return new SuccessResult(Messages.BlogAdded);
        }
      

    

               
                    




    }
}
