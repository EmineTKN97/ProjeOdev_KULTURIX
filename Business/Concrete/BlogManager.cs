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
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(BlogDTO blogdto)
        {
            _blogDal.Add(blogdto);
        }



        public void Delete(Guid İd)
        {
            _blogDal.Delete(İd);
        }

        public List<BlogDetailsDTO> GetAllBlogDetails()
        {
            return _blogDal.GetAllBlogDetails();
        }

        public List<BlogDTO> GetBlogDetails()
        {
            return _blogDal.GetBlogDetails();

        }

        public Blog GetById(Guid id)
        {
            return _blogDal.Get(blog => blog.BlogId == id);
        }

       

        public void Update(Guid id, BlogDTO updatedBlogDto)
        {
            _blogDal.Update(id,updatedBlogDto);
        }
    }
}
