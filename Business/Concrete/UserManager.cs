using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstarct;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        [ValidationAspect(typeof(UserValidator))]
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
        [ValidationAspect(typeof(UserUpdateValidator))]
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
        public async Task<IDataResult<UserDTO>> GetById(Guid UserId)
        {
            
            return new SuccessDataResult<UserDTO>(_userDal.GetById(UserId), Messages.UserListed);
            
        }
        [SecuredOperation("USER")]
        public async Task<IResult> ChangePassword(string currentPassword, string newPassword, Guid UserId)
        {
            ValidationResult validationResult = ChangePasswordValidator.ValidateChangePassword(currentPassword, newPassword);
            if (!validationResult.IsValid)
            {
                string errorMessages = string.Join(Environment.NewLine, validationResult.Errors);
                return new ErrorResult(errorMessages);
            }

            _userDal.UpdatePassword(currentPassword, newPassword, UserId);
            return new Result(true, Messages.ChangePassword);
        }
        
    }
}

