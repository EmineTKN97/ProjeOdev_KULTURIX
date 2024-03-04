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
    public interface ITicketDal : IEntityRepository<Ticket>
    {
        void Add(TicketDTO ticketDTO, Guid userId);
        void Delete(Guid ıd, Guid userId);
        List<TicketDTO> GetAllTicketDetails();
        List<TicketDTO> GetByUserId(Guid userId);
        void Update(Guid id, TicketDTO ticketDTO, Guid userId);
    }
}
