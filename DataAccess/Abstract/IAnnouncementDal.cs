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
    public interface IAnnouncementDal : IEntityRepository<Announcement>
    {
        void Add(AnnouncementDTO announcementdto, Guid adminId);
        void Delete(Guid id, Guid adminId);
        List<AnnouncementDTO> GetAllAnnouncement();
        AnnouncementDTO GetById(Guid id);
        List<AnnouncementDTO> GetLatestAnnouncement();
        void Update(Guid id, AnnouncementDTO updatedannouncementdto, Guid adminId);
    }
}
