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
    public class EfTicketDal : EfEntityRepositoryBase<Ticket, ProjeOdevContext>, ITicketDal
    {
        private readonly ProjeOdevContext _context;
        public EfTicketDal(ProjeOdevContext context)
        {
            _context = context;
        }
        public void Add(TicketDTO ticketDTO, Guid userId)
        {
            var newTicket = new Ticket
            {
                Id = ticketDTO.Id,  
                CityId= ticketDTO.CityId,
                DistrictId= ticketDTO.DistrictId,   
                Price = ticketDTO.Price,    
                Quantity = ticketDTO.Quantity,  
                MuseumName= ticketDTO.MuseumName,   
                Time = DateTime.Now,
                UserId = userId,
            };

            _context.Tickets.Add(newTicket);
            _context.SaveChanges();
        }
    

        public void Delete(Guid ıd, Guid userId)
        {
            var ticketToDelete = _context.Tickets.FirstOrDefault(t => t.Id == ıd && t.UserId == userId);

            if (ticketToDelete != null)
            {
                ticketToDelete.Status = true;
                _context.Tickets.Update(ticketToDelete);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Bilet bulunamadı veya silinemedi.");
            }
        }

        public List<TicketDTO> GetAllTicketDetails()
        {
            var result = (
                 from t in _context.Tickets
                 where t.Status == false
                 orderby t.Status descending
                 select new TicketDTO
                 {
                     UserName = t.user.Name,
                     UserSurname = t.user.SurName,
                     CityId= t.CityId,
                     DistrictName = t.District.DistrictName,
                     CityName = t.city.CityName,
                     DistrictId = t.DistrictId,
                     Quantity = t.Quantity,
                     Price = t.Price,
                     MuseumName = t.MuseumName, 
                     Time = t.Time,
                     UserId = t.UserId,
                     Id = t.Id  
                 }).ToList();

            return result;
        }

        public List<TicketDTO> GetByUserId(Guid userId)
        {
            var result = (from t in _context.Tickets
                         join u in _context.Users on t.UserId equals u.Id
                         where t.UserId == userId && t.Status == false
                         orderby t.Time descending
                         select new TicketDTO
                         {
                             UserName = t.user.Name,
                             UserSurname = t.user.SurName,
                             DistrictName = t.District.DistrictName,
                             CityName = t.city.CityName,
                             Quantity = t.Quantity,
                             Price = t.Price,
                             MuseumName = t.MuseumName,
                             Time = t.Time,
                         }).ToList();

            return result;
        }

        public void Update(Guid id, TicketDTO ticketDTO, Guid userId)
        {
            var ticketToUpdate = _context.Tickets.FirstOrDefault(t => t.Id == id && t.UserId == userId);

            if (ticketToUpdate != null && ticketToUpdate.Status == false)
            {
                ticketToUpdate.Quantity = ticketDTO.Quantity;
                ticketToUpdate.Price = ticketDTO.Price;
                ticketToUpdate.MuseumName = ticketDTO.MuseumName;
                ticketToUpdate.CityId = ticketDTO.CityId;
                ticketToUpdate.DistrictId = ticketDTO.DistrictId;
                ticketToUpdate.Time = ticketDTO.Time;  
                _context.Entry(ticketToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Bilet bulunamadı veya güncellenemedi.");
            }
        }
    }
}
