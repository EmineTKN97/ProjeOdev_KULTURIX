using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ITicketService
    {
        Task<IResult> Add(TicketDTO ticketDTO, Guid UserId);
        Task<IResult> Delete(Guid Id, Guid UserId);
        Task<IResult> Update(Guid Id, TicketDTO ticketDTO , Guid UserId);
        Task<IDataResult<List<TicketDTO>>> GetAllTicketDetails();
        Task<IDataResult<TicketDTO>> GetByUserId(Guid UserId);
    
    }
}
