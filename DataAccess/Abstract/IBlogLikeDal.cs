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
  public  interface IBlogLikeDal:IEntityRepository<BlogLike>
    {
      
        void AddBlogLike(Guid blogİd, BlogLikeDTO bloglikedto);
        void AddBlogCommentLike(Guid blogCommentİd, BlogLikeDTO bloglikedto);
        void Delete(Guid id);
        List<BlogLikeDTO> GetAllLikeDetails();
        List<BlogLikeDTO> GetLikesByBlogId(Guid BlogId);
    }
}
