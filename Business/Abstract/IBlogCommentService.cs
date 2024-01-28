
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogCommentService
    {

        Task<IResult> Add(Guid Blogİd, BlogCommentDTO blogcommentdto);
        Task<IResult> Delete(Guid İd);
        Task<IResult> Update(Guid id, BlogCommentDTO updatedCommentBlogDto);
        Task<IDataResult<List<BlogCommentDTO>>> GetAllCommentsDetails();
        Task<IDataResult<List<BlogCommentDTO>>> GetCommentsByBlogId(Guid BlogId);

    }
}
