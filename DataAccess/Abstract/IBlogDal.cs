using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IEntityRepository<Blog>
    {
        List<BlogDetailsDTO> GetBlogsByCommentAndLikeCount();
        void Delete(Guid id, Guid userId);
        void Update(Guid id, BlogDTO updatedBlogDto,Guid UserId);
        void Add(BlogDTO blogdto, Guid userId);
        List<Blog> GetByUserId(Guid userId);
        BlogDetailsDTO GetById(Guid BlogId);
        List<BlogDTO> GetLatestBlog();
    }
}