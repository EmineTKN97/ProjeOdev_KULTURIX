using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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
        public void Add(BlogComment blogComment)
        {
            _blogcommentDal.Add(blogComment);
        }

        public void Delete(BlogComment blogComment)
        {
            _blogcommentDal.Delete(blogComment);
        }

        public List<BlogComment> GetAll()
        {
            return _blogcommentDal.GetAll();
        }

        public BlogComment GetById(Guid id)
        {

            return _blogcommentDal.Get(blogComment => blogComment.CommentId == id);
        }

        public void Update(BlogComment blogComment)
        {
            _blogcommentDal.Update(blogComment);
        }
    }
}
