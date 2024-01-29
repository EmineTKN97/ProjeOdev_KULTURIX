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
            _userDal.Delete(İd);
            return new Result(true, Messages.UserDeleted);
        }

        public async Task<IDataResult<List<UserDTO>>>GetAllUsers()
        {
            return new SuccessDataResult<List<UserDTO>>(_userDal.GetAllUsers(), Messages.UserListed);
        }

        public async Task<IResult> Update(Guid İd,UserDTO userDto)
        {
            try
            {

                _userDal.Update(İd,userDto);
                return new Result(true, Messages.UserUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.UserNotUpdated);
            }
        }
    }
}
