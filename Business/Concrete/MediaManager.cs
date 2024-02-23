using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.Helper;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MediaManager : IMediaService
    {
        IMediaDal _mediaDal;

        public MediaManager(IMediaDal mediaDal)
        {
            _mediaDal = mediaDal;
        }
        [SecuredOperation("USER")]
        [ValidationAspect(typeof(MediaValidator))]
        [CacheRemoveAspect("IMediaService.Get")]
        public async Task<IResult> AddBlogMedia(IFormFile file,Guid BlogId, Guid UserId)
        {
            IResult result = BusinessRules.Run(IsBlogWithoutMedia(BlogId));

            if (result != null)
            {
                return new ErrorResult("Blog zaten bir resime sahiptir.");
            }
            string fileName = FileHelper.GenerateFileName(file);
            var filePath = Common.GetFilePath(fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            _mediaDal.AddBlogMedia(fileName, BlogId, UserId);

            return new SuccessResult(Messages.AddBlogİmage);
        }
        [SecuredOperation("USER")]
        [ValidationAspect(typeof(MediaValidator))]
        [CacheRemoveAspect("IMediaService.Get")]
        public async Task<IResult> AddUserMedia(IFormFile file,Guid UserId)
        {
            IResult result = BusinessRules.Run(IsUserWithoutMedia(UserId));

            if (result != null)
            {
                return new ErrorResult("Kullanıcı zaten bir resime sahiptir.");
            }
            string fileName = FileHelper.GenerateFileName(file);
            var filePath = Common.GetFilePath(fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            _mediaDal.AddUserMedia(fileName,UserId);

            return new SuccessResult(Messages.AddUserİmage);
        }
        [SecuredOperation("USER")]
        [CacheRemoveAspect("IMediaService.Get")]
        public async Task<IResult> Delete(Guid İd, Guid UserId)
        {
            _mediaDal.Delete(İd,UserId);
            return new Result(true, Messages.MediaDeleted);
        }
        [CacheAspect]
        public async Task<IDataResult<List<MediaDTO>>> GetAllMediaDetails()
        {
            return new SuccessDataResult<List<MediaDTO>>(_mediaDal.GetAllMediaDetails(), Messages.MediaListed);
        }
        [CacheAspect]
        public async Task<IDataResult<Media>> GetMediaByUserId(Guid UserId)
        {
            return new SuccessDataResult<Media>(_mediaDal.Get(m => m.UserId == UserId && m.Status == false),
    Messages.UserMediaListed);
        }
        [CacheAspect]
        public async Task<IDataResult<Media>> GetMediaByBlogId(Guid BlogId)
        {
            return new SuccessDataResult<Media>(_mediaDal.Get(m => m.BlogId == BlogId && m.Status ==false), Messages.BlogMediaListed);
        }
        [SecuredOperation("USER")]
        [ValidationAspect(typeof(MediaValidator))]
        [CacheRemoveAspect("IMediaService.Get")]
        public async Task<IResult>Update(IFormFile file, Guid UserId)
        {
            string fileName = FileHelper.GenerateFileName(file);
            var filePath = Common.GetFilePath(fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
  
            _mediaDal.Update(fileName,UserId);

            return new SuccessResult(Messages.UpdateMedia);
        }
        [SecuredOperation("USER")]
        [CacheRemoveAspect("IMediaService.Get")]
        public async Task<IResult> DeleteBlogMedia(Guid İd, Guid BlogId, Guid UserId)
        {
            _mediaDal.DeleteBlogMedia(İd,BlogId,UserId);
            return new Result(true, Messages.MediaDeleted);
        }
        [SecuredOperation("USER")]
        [ValidationAspect(typeof(MediaValidator))]
        [CacheRemoveAspect("IMediaService.Get")]
        public async Task<IResult> UpdateBlogMedia(IFormFile file, Guid BlogId, Guid UserId)
        {
            string fileName = FileHelper.GenerateFileName(file);
            var filePath = Common.GetFilePath(fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            _mediaDal.UpdateBlogMedia(fileName,BlogId,UserId);

            return new SuccessResult(Messages.UpdateMedia);
        }
        private IResult IsBlogWithoutMedia(Guid blogId)
        {

            var result = _mediaDal.GetAll(m => m.BlogId == blogId && m.Status == false).Count();
            if (result >0)
            {
                return new ErrorResult("Sadece bir adet resim ekleyebilirsiniz");

            }
            return new SuccessResult();
        
        }
        private IResult IsUserWithoutMedia(Guid userId)
        {

            var result = _mediaDal.GetAll(m => m.UserId == userId && m.Status == false).Count();
            if (result > 0)
            {
                return new ErrorResult("Sadece bir adet resim ekleyebilirsiniz");

            }
            return new SuccessResult();

        }
    }
}
