
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

        void Add(Guid Blogİd,BlogCommentDTO blogcommentdto);
        void Delete(Guid İd);
        void Update(Guid id, BlogCommentDTO updatedCommentBlogDto);
        List<BlogCommentDTO> GetAllCommentsDetails();
        
    }
}
