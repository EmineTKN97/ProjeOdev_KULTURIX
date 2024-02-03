using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMediaService
    {
        Task<IResult> AddUserMedia(IFormFile file, Guid UserId );
        Task<IResult> AddBlogMedia(IFormFile file, Guid BlogId,Guid UserId);
        Task<IResult> Delete(Guid İd, Guid UserId);
        Task<IResult> DeleteBlogMedia(Guid İd,Guid BlogId,Guid UserId);
        Task<IResult>Update(IFormFile file, Guid MediaId, Guid UserId);
        Task<IResult> UpdateBlogMedia(IFormFile file, Guid MediaId,Guid BlogId,Guid UserId);
        Task<IDataResult<List<MediaDTO>>> GetAllMediaDetails();
        Task<IDataResult<Media>> GetMediaByUserId(Guid UserId);
        Task<IDataResult<Media>> GetMediaByBlogId(Guid BlogId);
    }
}
