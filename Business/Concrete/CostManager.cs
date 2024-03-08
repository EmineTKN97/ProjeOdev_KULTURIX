using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.Context.Configurations;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CostManager : ICostService
    {
        ICostDal _costDal;

        public CostManager(ICostDal costDal)
        {
            _costDal = costDal;
        }

        [SecuredOperation("ADMİN")]
        public async Task<IResult> AddTicketPrice(CostDTO costDTO)
        {
            _costDal.AddTicket(costDTO);
            return new SuccessResult(Messages.AddTicketPrice);
        }
        [SecuredOperation("ADMİN")]
        public async Task<IDataResult<CostDTO>> GetById(Guid CostId)
        {
            return new SuccessDataResult<CostDTO>(_costDal.GetById(CostId), Messages.CostListed);
        }

        [SecuredOperation("ADMİN")]
        public async Task<IResult> UpdateTicketPrice(Guid Id,CostDTO costDTO)
        {
            try
            {
                _costDal.UpdateTicket(Id,costDTO);
                return new Result(true, Messages.TicketPriceUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.TicketPriceNotUpdated);
            }
        }

       
    }
}
