using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstarct;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
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
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
        [SecuredOperation("USER")]
        public async Task<IResult> Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }
        [SecuredOperation("USER")]
        public async Task<IResult> Delete(Guid İd)
        {
            _userDal.Delete(İd);
            return new Result(true, Messages.UserDeleted);
        }
        [SecuredOperation("USER")]
        public async Task<IResult> Update(Guid id, UserDTO userdto)
        {
            try
            {
                _userDal.Update(id, userdto);
                return new Result(true, Messages.UserUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.UserNotUpdated);
            }

        }
        public async Task<IDataResult<User>> GetById(Guid Userİd)
        {
            
                return new SuccessDataResult<User>(_userDal.Get(u=> u.Id == Userİd), Messages.UserListed);
            
        }
        [SecuredOperation("USER")]
        public async Task<IResult> ChangePassword(string currentPassword, string newPassword, Guid UserId)
        {
            _userDal.UpdatePassword(currentPassword, newPassword, UserId);
            return new Result(true, Messages.ChangePassword);
        }
    }
}

