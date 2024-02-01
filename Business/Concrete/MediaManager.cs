using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
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
        public async Task<IResult> AddBlogMedia(IFormFile file,Guid BlogId, Guid UserId)
        {
            string fileName = FileHelper.GenerateFileName(file);
            var filePath = Common.GetFilePath(fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            _mediaDal.AddBlogMedia(fileName,BlogId,UserId);

            return new SuccessResult(Messages.AddBlogİmage);
        }
        [SecuredOperation("USER")]
        public async Task<IResult> AddUserMedia(IFormFile file,Guid UserId)
        {
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
        public async Task<IResult> Delete(Guid İd, Guid UserId)
        {
            _mediaDal.Delete(İd,UserId);
            return new Result(true, Messages.MediaDeleted);
        }

        public async Task<IDataResult<List<MediaDTO>>> GetAllMediaDetails()
        {
            return new SuccessDataResult<List<MediaDTO>>(_mediaDal.GetAllMediaDetails(), Messages.MediaListed);
        }
        public async Task<IDataResult<Media>> GetMediaByUserId(Guid UserId)
        {
            return new SuccessDataResult<Media>(_mediaDal.Get(m => m.UserId == UserId && m.Status == false),
    Messages.UserMediaListed);
        }

       public async Task<IDataResult<Media>> GetMediaByBlogId(Guid BlogId)
        {
            return new SuccessDataResult<Media>(_mediaDal.Get(m => m.BlogId == BlogId && m.Status ==false), Messages.BlogMediaListed);
        }
        [SecuredOperation("USER")]
        public async Task<IResult>Update(IFormFile file, Guid MediaId, Guid UserId)
        {
            string fileName = FileHelper.GenerateFileName(file);
            var filePath = Common.GetFilePath(fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            _mediaDal.Update(fileName,MediaId,UserId);

            return new SuccessResult(Messages.UpdateMedia);
        }

        public async Task<IResult> DeleteBlogMedia(Guid İd, Guid BlogId)
        {
            _mediaDal.DeleteBlogMedia(İd,BlogId);
            return new Result(true, Messages.MediaDeleted);
        }
    public async Task<IResult> UpdateBlogMedia(IFormFile file, Guid MediaId, Guid BlogId)
        {
            string fileName = FileHelper.GenerateFileName(file);
            var filePath = Common.GetFilePath(fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            _mediaDal.UpdateBlogMedia(fileName, MediaId,BlogId);

            return new SuccessResult(Messages.UpdateMedia);
        }
    }
}
