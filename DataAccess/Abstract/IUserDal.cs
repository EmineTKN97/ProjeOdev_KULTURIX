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
    public interface IUserDal : IEntityRepository<User>
    {
        void Add(UserDTO userdto);
        void Delete(Guid id);
        List<UserDTO> GetAllUsers();
    
        void Update(Guid id, UserDTO userDto);
    }
}
