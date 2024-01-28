using Core.Utilities.Results;
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
        Task<IResult> AddBlogMedia(IFormFile file, Guid BlogId );
        Task<IResult> Delete(Guid İd);
        Task<IResult>Update(IFormFile file, BlogCommentDTO updatedCommentBlogDto);
        Task<IDataResult<List<MediaDTO>>> GetAllMediaDetails();
        Task<IDataResult<List<MediaDTO>>> GetMediaByUserId(Guid UserId);
        Task<IDataResult<List<MediaDTO>>> GetMediaByBlogId(Guid BlogId);
    }
}
