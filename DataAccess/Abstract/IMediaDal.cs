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
    public interface IMediaDal : IEntityRepository<Media>
    {
        void AddBlogMedia(string fileName, Guid blogId);
        void AddUserMedia(string fileName, Guid userId);
        void Delete(Guid id);
        List<MediaDTO> GetAllMediaDetails();
        void Update(string fileName, Guid mediaId);
    }
}
