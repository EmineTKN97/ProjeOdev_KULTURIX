using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
 public interface IBlogCommentService
    {

        void Add(BlogComment blogComment);
        void Delete(BlogComment blogComment);
        void Update(BlogComment blogComment);
        List<BlogComment> GetAll();
        BlogComment GetById(Guid id);
    }
}
