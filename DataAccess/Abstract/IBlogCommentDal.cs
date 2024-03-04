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
   public interface IBlogCommentDal : IEntityRepository<BlogComment>
    {
        List<BlogCommentDTO> GetAllCommentDetails();
        void Add(Guid Blogİd,BlogCommentDTO blogcommentdto, Guid userId);
       Task Delete(Guid id, Guid userId);
        void Update(Guid id, BlogCommentDTO updatedCommentBlogDto, Guid userId);
        List<BlogCommentDTO> GetCommentsByBlogId(Guid BlogId);
        List<BlogCommentDTO> GetByCommentUserId(Guid userId);
        BlogCommentDTO GetById(Guid commentId);
    }
}
