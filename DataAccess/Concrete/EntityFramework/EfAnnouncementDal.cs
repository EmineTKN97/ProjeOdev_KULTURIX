using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAnnouncementDal : EfEntityRepositoryBase<Announcement, ProjeOdevContext>, IAnnouncementDal
    {
        private readonly ProjeOdevContext _context;

        public EfAnnouncementDal(ProjeOdevContext context)
        {
            _context = context;
        }
        public void Add(AnnouncementDTO announcementdto, Guid AdminId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var newAnnouncement = new Announcement
                    {
                        AnnouncementTitle = announcementdto.AnnouncementTitle,
                        AnnouncementContent = announcementdto.AnnouncementContent,
                        CreateDate = DateTime.Now,
                    };

                    _context.Announcements.Add(newAnnouncement);
                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Delete(Guid id, Guid adminId)
        {
            var announcementToDelete = _context.Announcements.FirstOrDefault(ac => ac.Id == id);

            if (announcementToDelete != null)
            {
                announcementToDelete.Status = true;
                _context.Entry(announcementToDelete).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public List<AnnouncementDTO> GetAllAnnouncement()
        {
            var announcementDTOs = _context.Announcements
                .OrderByDescending(ac => ac.CreateDate)
                .Where(ac => ac.Status == false)
                .Select(ac => new AnnouncementDTO
                {
                   AnnouncementId = ac.Id,
                    AnnouncementContent=ac.AnnouncementContent,
                    AnnouncementTitle=ac.AnnouncementTitle,
                    CreateDate= ac.CreateDate,
                }).ToList();
            return announcementDTOs;
        }

        public List<AnnouncementDTO> GetLatestAnnouncement()
        {
            var announcementDTOs = _context.Announcements
                        .OrderByDescending(ac => ac.CreateDate) 
                        .Take(5) 
                        .Select(ac => new AnnouncementDTO
                         {
                             AnnouncementId = ac.Id,
                             AnnouncementTitle = ac.AnnouncementTitle,
                             AnnouncementContent = ac.AnnouncementContent,
                             CreateDate = ac.CreateDate
                         }) .ToList();

            return announcementDTOs;



        }

        public void Update(Guid id, AnnouncementDTO updatedannouncementdto, Guid adminId)
        {
            var announcementToUpdate = _context.Announcements.FirstOrDefault(ac => ac.Id == id);

            if (announcementToUpdate != null && announcementToUpdate.Status == false)
            {
                announcementToUpdate.AnnouncementTitle = updatedannouncementdto.AnnouncementTitle;
                announcementToUpdate.AnnouncementContent = updatedannouncementdto.AnnouncementContent;
                announcementToUpdate.CreateDate = DateTime.Now;
                _context.Entry(announcementToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Duyuru güncellenemedi");
            }

        }
    }
}
