using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Concrete.Context;
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
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDTO userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                Name = userForRegisterDto.Name,
                SurName = userForRegisterDto.SurName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                ImagePath = "wwwroot\\Uploads\\StaticContent\\default.jpg",
                CreateDate = DateTime.Now,
            };

            using (var unitOfWork =new ProjeOdevContext())
            {
                try
                {
                    unitOfWork.Users.Add(user);
                    unitOfWork.SaveChanges();

                    var userOperationClaim = new UserOperationClaim
                    {
                        UserId = user.Id,
                        OperationClaimsId = OperationClaimsStaticId.DefaultOperationClaimId 
                    };

                    unitOfWork.UserOperationClaims.Add(userOperationClaim);
                    unitOfWork.SaveChanges();

                    return new SuccessDataResult<User>(user, Messages.UserRegistered);
                }
                catch (Exception ex)
                {
                    return new ErrorDataResult<User>( Messages.UserRegistrationFailed);
                }
            }
        }
    

        public IDataResult<User> Login(UserForLoginDTO userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
