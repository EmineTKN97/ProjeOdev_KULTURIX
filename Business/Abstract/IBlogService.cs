using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IResult Add(BlogDTO blogdto);
        IResult Delete(Guid İd);
        IResult Update(Guid id, BlogDTO updatedBlogDto);
        IDataResult<Blog> GetById(Guid id);
        IDataResult<List<BlogDetailsDTO>>GetBlogsByCommentAndLikeCount();
    }
}
