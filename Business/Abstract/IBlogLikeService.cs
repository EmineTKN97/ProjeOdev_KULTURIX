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
        Task<IResult> AddBlogLike(Guid Blogİd, BlogLikeDTO bloglikedto);
        Task<IResult> AddBlogCommentLike(Guid BlogCommentİd, BlogLikeDTO bloglikedto);
        Task<IResult> Delete(Guid İd);
        Task<IDataResult<List<BlogLikeDTO>>> GetAllLikeDetails();
        Task<IDataResult<List<BlogLikeDTO>>> GetLikesByBlogId(Guid BlogId);

    }
}
