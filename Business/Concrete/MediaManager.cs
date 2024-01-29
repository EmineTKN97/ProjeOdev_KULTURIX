using Business.Abstract;
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
        public async Task<IResult> AddBlogMedia(IFormFile file,Guid BlogId)
        {
            string uniqueFileName = Guid.NewGuid().ToString();
            string fileExtension = Path.GetExtension(file.FileName);
            string fileName = uniqueFileName + fileExtension;

            var filePath = Common.GetFilePath(fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            _mediaDal.AddBlogMedia(fileName,BlogId);

            return new SuccessResult(Messages.AddBlogİmage);
        }

        public async Task<IResult> AddUserMedia(IFormFile file,Guid UserId)
        {
            string uniqueFileName = Guid.NewGuid().ToString();
            string fileExtension = Path.GetExtension(file.FileName);
            string fileName = uniqueFileName + fileExtension;

            var filePath = Common.GetFilePath(fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            _mediaDal.AddUserMedia(fileName,UserId);

            return new SuccessResult(Messages.AddUserİmage);
        }

        public async Task<IResult> Delete(Guid İd)
        {
            _mediaDal.Delete(İd);
            return new Result(true, Messages.MediaDeleted);
        }

        public async Task<IDataResult<List<MediaDTO>>> GetAllMediaDetails()
        {
            return new SuccessDataResult<List<MediaDTO>>(_mediaDal.GetAllMediaDetails(), Messages.MediaListed);
        }
        public async Task<IDataResult<Media>> GetMediaByUserId(Guid UserId)
        {
            return new SuccessDataResult<Media>(_mediaDal.Get(m => m.UserId== UserId),Messages.UserMediaListed);
        }

       public async Task<IDataResult<Media>> GetMediaByBlogId(Guid BlogId)
        {
            return new SuccessDataResult<Media>(_mediaDal.Get(m => m.BlogId == BlogId), Messages.BlogMediaListed);
        }
        public async Task<IResult>Update(IFormFile file, Guid MediaId)
        {
            string uniqueFileName = Guid.NewGuid().ToString();
            string fileExtension = Path.GetExtension(file.FileName);
            string fileName = uniqueFileName + fileExtension;

            var filePath = Common.GetFilePath(fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            _mediaDal.Update(fileName,MediaId);

            return new SuccessResult(Messages.UpdateMedia);
        }

       
    }
}
