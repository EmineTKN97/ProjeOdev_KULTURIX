using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstarct
{
    public interface IUserDal : IEntityRepository<User>
    {
        void Delete(Guid id);
        List<UserDTO> GetAllUser();
        UserDTO GetById(Guid userId);
        List<OperationClaim> GetClaims(User user);
        void Update(Guid id, UserDTO userdto);
        void UpdatePassword(string currentPassword, string newPassword, Guid userId);
    
    }
}
