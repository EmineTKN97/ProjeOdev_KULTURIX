using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogLikeManager : IBlogLikeService
    {
        private readonly IBlogLikeDal _bloglikeDal;

        public BlogLikeManager(IBlogLikeDal bloglikeDal)
        {
            _bloglikeDal = bloglikeDal;
        }

        public void Add(Guid Blogİd, BlogLikeDTO bloglikedto)
        {
            _bloglikeDal.Add(Blogİd, bloglikedto);
        }

        public void Delete(Guid İd)
        {
            _bloglikeDal.Delete(İd);
        }

        public List<BlogLikeDTO> GetAllLikeDetails()
        {
            return _bloglikeDal.GetAllLikeDetails();
        }
    }
}
