using Entities.DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IBlogLikeService
    {
        Task<IResult> AddBlogLike(Guid BlogId, BlogLikeDTO blogLikedto, Guid UserId);
        Task<IResult> AddBlogCommentLike(Guid BlogCommentId, BlogLikeDTO blogLikedto, Guid UserId);
        Task<IResult> Delete(Guid Id, Guid UserId);
        Task<IDataResult<List<BlogLikeDTO>>> GetAllLikeDetails();
        Task<IDataResult<List<BlogLikeDTO>>> GetLikesByBlogId(Guid BlogId);

    }
}
