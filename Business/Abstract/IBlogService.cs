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
    public interface IBlogService
    {
        Task<IResult> Add(BlogDTO blogdto,Guid UserId);
        Task<IResult> Delete(Guid İd,Guid UserId);
        Task<IResult> Update(Guid id, BlogDTO updatedBlogDto,Guid UserId);
        Task<IDataResult<BlogDetailsDTO>> GetById(Guid BlogId);
        Task<IDataResult<List<BlogDTO>>> GetByUserId(Guid UserId);
        Task<IDataResult<List<BlogDetailsDTO>>>GetBlogsByCommentAndLikeCount();
        Task<IDataResult<List<BlogDTO>>> GetLatestBlog();
        Task<IDataResult<BlogDTO>> GetLastBlogByUserId(Guid UserId);
    }
}
