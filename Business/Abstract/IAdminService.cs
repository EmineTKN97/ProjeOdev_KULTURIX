using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{public interface IAdminService
    {
        List<OperationClaim> GetClaims(Admin admin);
        void Add(Admin admin);
        Admin GetByMail(string email);
        Task<IResult> Delete(Guid İd);
        Task<IResult> Update(Guid id, AdminDTO adminDto);
        Task<IDataResult<Admin>> GetById(Guid Adminİd);
        Task<IResult> ChangeAdminPassword(string currentPassword, string newPassword, Guid AdminID);
    }
}
