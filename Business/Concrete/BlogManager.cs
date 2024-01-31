﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
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
            try
            {
                _blogDal.Update(id, updatedBlogDto);
                return new Result(true, Messages.BlogUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.BlogNotUpdated);
            }
        }
        // [ValidationAspect(typeof(BlogValidator))
        [SecuredOperation("USER")]
        public async Task<IResult> Add(BlogDTO blogdto)
        {
        
            _blogDal.Add(blogdto);
            return new SuccessResult(Messages.BlogAdded);
        }

  
      public async  Task<IDataResult<List<Blog>>> GetByUserId(Guid UserId)
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetByUserId(UserId), Messages.BlogListed);
        }

        
    }
}
