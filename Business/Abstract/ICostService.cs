using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICostService
    {
        Task<IResult> AddTicketPrice(CostDTO costDTO);
        Task<IResult> UpdateTicketPrice(Guid Id,CostDTO costDTO);
        Task<IDataResult<CostDTO>> GetById(Guid CostId);
    }
}
