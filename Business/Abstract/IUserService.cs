using Core.Utilities.Results;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IUserService
    {
       Task<IResult> Add(IFormFile file,UserDTO userDto);
        Task<IResult> Delete(Guid İd);
        Task<IResult> Update(UserDTO userDto);
       Task< IDataResult<List<UserDTO>>> GetAllUsers();
    }
}
