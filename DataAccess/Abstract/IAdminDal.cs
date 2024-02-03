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
    public interface IAdminDal : IEntityRepository<Admin>
    {
        void Delete(Guid id);
        List<OperationClaim> GetClaims(Admin admin);
        void Update(Guid id, AdminDTO adminDto);
        void UpdateAdminPassword(string currentPassword, string newPassword, Guid adminID);
    }
    
    
}
