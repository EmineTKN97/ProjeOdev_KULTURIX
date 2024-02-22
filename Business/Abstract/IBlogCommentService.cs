
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

        Task<IResult> Add(Guid Blogİd, BlogCommentDTO blogcommentdto,Guid userId);
        Task<IResult> Delete(Guid İd, Guid userId);
        Task<IResult> Update(Guid id, BlogCommentDTO updatedCommentBlogDto, Guid userId);
        Task<IDataResult<List<BlogCommentDTO>>> GetAllCommentsDetails();
        Task<IDataResult<List<BlogCommentDTO>>> GetCommentsByBlogId(Guid BlogId);
        Task<IDataResult<List<BlogCommentDTO>>> GetByCommentUserId(Guid UserId);
        Task<IDataResult<BlogCommentDTO>> GetById(Guid CommentId);

    }
}
