
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

        IResult Add(Guid Blogİd, BlogCommentDTO blogcommentdto);
        IResult Delete(Guid İd);
        IResult Update(Guid id, BlogCommentDTO updatedCommentBlogDto);
        IDataResult<List<BlogCommentDTO>> GetAllCommentsDetails();
        IDataResult<List<BlogCommentDTO>> GetCommentsByBlogId(Guid BlogId);

    }
}
