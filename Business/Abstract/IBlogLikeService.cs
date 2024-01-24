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
        IResult AddBlogLike(Guid Blogİd, BlogLikeDTO bloglikedto);
        IResult AddBlogCommentLike(Guid BlogCommentİd, BlogLikeDTO bloglikedto);
        IResult Delete(Guid İd);
        IDataResult<List<BlogLikeDTO>> GetAllLikeDetails();
        IDataResult<List<BlogLikeDTO>> GetLikesByBlogId(Guid BlogId);

    }
}
