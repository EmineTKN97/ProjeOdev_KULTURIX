﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.Helper;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
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
using System.Security.Claims;
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
        [SecuredOperation("USER")]
        [CacheRemoveAspect("IBlogService.Get")]
        public async Task<IResult> Delete(Guid İd, Guid UserId)
        {
            _blogDal.Delete(İd, UserId);
            return new Result(true, Messages.BlogDeleted);
        }
        public async Task<IDataResult<List<BlogDetailsDTO>>> GetBlogsByCommentAndLikeCount()
        {
            return new SuccessDataResult<List<BlogDetailsDTO>>(_blogDal.GetBlogsByCommentAndLikeCount(), Messages.BlogListed);
        }
        [CacheAspect(duration: 10)]
        public async Task<IDataResult<BlogDetailsDTO>> GetById(Guid BlogId)
        {
            return new SuccessDataResult<BlogDetailsDTO>(_blogDal.GetById(BlogId), Messages.BlogListed);
        }
        [SecuredOperation("USER")]
        [ValidationAspect(typeof(BlogValidator))]
       [CacheRemoveAspect("IBlogService.Get")]
        public async Task<IResult>Update(Guid id, BlogDTO updatedBlogDto,Guid UserId)
        {  
            try
            {
                _blogDal.Update(id, updatedBlogDto,UserId);
                return new Result(true, Messages.BlogUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.BlogNotUpdated);
            }
        }
        [SecuredOperation("USER")]
        [ValidationAspect(typeof(BlogValidator))]
        [CacheRemoveAspect("IBlogService.Get")]
        public async Task<IResult> Add(BlogDTO blogdto, Guid userId)
        {
            _blogDal.Add(blogdto,userId);
            return new SuccessResult(Messages.BlogAdded);
        }
 
        public async  Task<IDataResult<List<BlogDTO>>> GetByUserId(Guid UserId)
        {
            return new SuccessDataResult<List<BlogDTO>>(_blogDal.GetByUserId(UserId), Messages.BlogListed);
        }

        public async Task<IDataResult<List<BlogDTO>>> GetLatestBlog()
        {
            return new SuccessDataResult<List<BlogDTO>>(_blogDal.GetLatestBlog(), Messages.BlogListed);
        }
  
        public async Task<IDataResult<BlogDTO>> GetLastBlogByUserId(Guid UserId)
        {
            return new SuccessDataResult<BlogDTO>(_blogDal.GetLatestBlogByUserId(UserId), Messages.BlogListed);
        }
  
        public async Task<IDataResult<List<BlogDetailsDTO>>> GetAllBlogsDetails()
        {
            return new SuccessDataResult<List<BlogDetailsDTO>>(_blogDal.GetAllBlogsDetails());
        }
    }
}
