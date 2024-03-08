using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
    public class TicketManager : ITicketService
    {
        ITicketDal _ticketDal;

        public TicketManager(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }
        [SecuredOperation("USER")]
        [ValidationAspect(typeof(TicketValidator))]
        public async Task<IResult> Add(TicketDTO ticketDTO, Guid UserId)
        {
            _ticketDal.Add(ticketDTO, UserId);
            return new SuccessResult(Messages.TicketAdded);
        }
        [SecuredOperation("USER")]
        public async Task<IResult> Delete(Guid Id, Guid UserId)
        {
            _ticketDal.Delete(Id, UserId);
            return new Result(true, Messages.TicketDeleted);
        }

        public async Task<IDataResult<List<TicketDTO>>> GetAllTicketDetails()
        {
            return new SuccessDataResult<List<TicketDTO>>(_ticketDal.GetAllTicketDetails());
        }
        [SecuredOperation("USER")]
        public async Task<IDataResult<TicketDTO>> GetByUserId(Guid UserId)
        {
            return new SuccessDataResult<TicketDTO>(_ticketDal.GetByUserId(UserId), Messages.TicketListed);
        }
        

        [SecuredOperation("USER")]
        [ValidationAspect(typeof(TicketValidator))]
        public async Task<IResult> Update(Guid id, TicketDTO ticketDTO, Guid UserId)
        {

            try
            {
                _ticketDal.Update(id, ticketDTO, UserId);
                return new Result(true, Messages.TicketUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.TicketNotUpdated);
            }
        }
      
    }
}
