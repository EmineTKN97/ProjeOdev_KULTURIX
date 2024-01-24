using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogCommentManager : IBlogCommentService
    {
        private readonly IBlogCommentDal _blogcommentDal;
        public BlogCommentManager(IBlogCommentDal blogcommentDal)
        {
            _blogcommentDal = blogcommentDal;
        }
       
        public void Add(Guid Blogİd, BlogCommentDTO blogcommentdto)
        {
            _blogcommentDal.Add(Blogİd,blogcommentdto);
        }

        public void Delete(Guid İd)
        {
            _blogcommentDal.Delete(İd);
        }

        public List<BlogCommentDTO> GetCommentsByBlogId(Guid BlogId)
        {
            return _blogcommentDal.GetCommentsByBlogId(BlogId);
        }

        public List<BlogCommentDTO> GetAllCommentsDetails()
        {
            return _blogcommentDal.GetAllCommentDetails();
        }

        public void Update(Guid id, BlogCommentDTO updatedCommentBlogDto)
        {
            _blogcommentDal.Update(id,updatedCommentBlogDto);
        }
    }
}
