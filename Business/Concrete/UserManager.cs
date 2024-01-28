using Business.Abstract;
using Business.Constants;
using Business.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }



        public async Task<IResult> Add(UserDTO userDto)
        {
           _userDal.Add(userDto);
            return new SuccessResult(Messages.UserAdded);
        }
        public async Task<IResult> Delete(Guid İd)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<UserDTO>>>GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Update(UserDTO userDto)
        {
            throw new NotImplementedException();
        }
    }
}
