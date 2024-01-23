using Entities.DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IBlogLikeService
    {
        void Add(Guid Blogİd, BlogLikeDTO bloglikedto);
        void Delete(Guid İd);
        List<BlogLikeDTO> GetAllLikeDetails();
    }
}
