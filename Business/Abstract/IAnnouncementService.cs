using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAnnouncementService
    {
        Task<IResult> Add(AnnouncementDTO announcementdto,Guid AdminId);
        Task<IResult> Delete(Guid İd, Guid AdminId);
        Task<IResult> Update(Guid id, AnnouncementDTO updatedannouncementdto, Guid AdminId);
        Task<IDataResult<List<AnnouncementDTO>>> GetLatestAnnouncement();
        Task<IDataResult<Announcement>> GetById(Guid id);
        Task<IDataResult<List<AnnouncementDTO>>> GetAllAnnouncement();
    }
}
