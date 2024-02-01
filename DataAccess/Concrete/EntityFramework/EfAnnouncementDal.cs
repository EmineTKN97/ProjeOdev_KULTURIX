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
        public void Add(AnnouncementDTO announcementdto,Guid AdminId)
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
