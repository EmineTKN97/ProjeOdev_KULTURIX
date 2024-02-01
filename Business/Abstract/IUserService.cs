
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
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        Task<IResult> Add(User user);
        User GetByMail(string email);
        //Task<IResult> Delete(Guid İd);
        //Task<IResult> Update(Guid id, User user);
    }
}
