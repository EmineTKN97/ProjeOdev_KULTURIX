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
       Task<IResult> Add(BlogDTO blogdto);
        Task<IResult> Delete(Guid İd);
        Task<IResult> Update(Guid id, BlogDTO updatedBlogDto);
        Task<IDataResult<Blog>> GetById(Guid id);
        Task<IDataResult<List<BlogDetailsDTO>>>GetBlogsByCommentAndLikeCount();
    }
}
