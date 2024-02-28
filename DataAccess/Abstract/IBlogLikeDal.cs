using Core.DataAccess;
using Core.Utilities.Results;
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
      
        void AddBlogLike(Guid blogİd, BlogLikeDTO bloglikedto, Guid userId);
        List<BlogLikeDTO> GetAllLikeDetails();
         void Delete(Guid İd,Guid UserId);
        List<BlogLikeDTO> GetLikesByBlogId(Guid BlogId);
        List<BlogDetailsDTO> GetLikedBlogsByUserId(Guid userId);
    }
}
