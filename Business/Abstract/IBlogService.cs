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
        void Add(BlogDTO blogdto);
        void Delete(Guid İd);
           void Update(Guid id, BlogDTO updatedBlogDto);
        Blog GetById(Guid id);
        List<BlogDetailsDTO> GetAllBlogDetails();
        List<BlogDTO> GetBlogDetails();
    }
}
