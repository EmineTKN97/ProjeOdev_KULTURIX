using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        private IAdminService _adminService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IAdminService adminService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _adminService = adminService;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IDataResult<User> Register(UserForRegisterDTO userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                Name = userForRegisterDto.Name,
                SurName = userForRegisterDto.SurName,
                BirthDate = userForRegisterDto.BirthDate,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = false,
                ImagePath = "user.jpg",
                CreateDate = DateTime.Now,
            };

            using (var unitOfWork = new ProjeOdevContext())
            {
                try
                {
                    unitOfWork.Users.Add(user);
                    unitOfWork.SaveChanges();

                    var userOperationClaim = new UserOperationClaim
                    {
                        UserId = user.Id,
                        OperationClaimsId = OperationClaimsStaticId.DefaultUserOperationClaimId
                    };

                    unitOfWork.UserOperationClaims.Add(userOperationClaim);
                    unitOfWork.SaveChanges();

                    return new SuccessDataResult<User>(user, Messages.UserRegistered);
                }
                catch (Exception ex)
                {
                    return new ErrorDataResult<User>(Messages.UserRegistrationFailed);
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

            if (userToCheck.Status == true)
            {
                return new ErrorDataResult<User>(Messages.UserNotActive);
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
        [ValidationAspect(typeof(AdminValidator))]
        public IDataResult<Admin> RegisterAdmin(AdminForRegisterDTO adminForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var admin = new Admin
            {
                Email = adminForRegisterDto.Email,
                FirstName = adminForRegisterDto.FirstName,
                LastName = adminForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = false,

            };

            using (var unitOfWork = new ProjeOdevContext())
            {
                try
                {
                    unitOfWork.Admins.Add(admin);
                    unitOfWork.SaveChanges();

                    var adminOperationClaim = new AdminOperationClaim
                    {
                        AdminId = admin.Id,
                        OperationClaimsId = OperationClaimsStaticId.DefaultAdminOperationClaimId
                    };

                    unitOfWork.AdminOperationClaims.Add(adminOperationClaim);
                    unitOfWork.SaveChanges();

                    return new SuccessDataResult<Admin>(admin, Messages.AdminRegistered);
                }
                catch (Exception ex)
                {
                    return new ErrorDataResult<Admin>(Messages.AdminRegistrationFailed);
                }
            }
        }

        public IDataResult<Admin> LoginAdmin(AdminForLoginDTO adminForLoginDto)
        {
            var adminToCheck = _adminService.GetByMail(adminForLoginDto.Email);
            if (adminToCheck == null)
            {
                return new ErrorDataResult<Admin>(Messages.AdminNotFound);
            }
            if (adminToCheck.Status == true)
            {
                return new ErrorDataResult<Admin>(Messages.AdminNotActive);
            }

            if (!HashingHelper.VerifyPasswordHash(adminForLoginDto.Password, adminToCheck.PasswordHash, adminToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Admin>(Messages.PasswordError);
            }

            return new SuccessDataResult<Admin>(adminToCheck, Messages.SuccessfulLogin);
        }

        public IResult AdminExists(string email)
        {
            if (_adminService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.AdminAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessTokenAdmin(Admin admin)
        {
            var claims = _adminService.GetClaims(admin);
            var accessToken = _tokenHelper.CreateToken(admin, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
        [SecuredOperation("ADMİN")]
        public async Task<IResult> ChangeRoles(Guid UserId)
        {

            using (var unitOfWork = new ProjeOdevContext())
            {
             
                var user = unitOfWork.Users.FirstOrDefault(u => u.Id == UserId);
                if (user != null)
                {
                    
                    var newAdmin = new Admin
                    {
                        FirstName = user.Name,
                        LastName = user.SurName,
                        Email = user.Email,
                        PasswordHash = user.PasswordHash,
                        PasswordSalt = user.PasswordSalt,
                        Id = Guid.NewGuid(),

                    };

                
                    unitOfWork.Admins.Add(newAdmin);
                    unitOfWork.SaveChanges();

                    
                    var adminOperationClaim = new AdminOperationClaim
                    {
                        Id = Guid.NewGuid(),
                        AdminId = newAdmin.Id,
                        OperationClaimsId = OperationClaimsStaticId.DefaultAdminOperationClaimId
                    };

                    unitOfWork.AdminOperationClaims.Add(adminOperationClaim);
                    unitOfWork.SaveChanges();

                    return new SuccessResult(Messages.UserRoleUpdatedToAdmin);
                }
                else
                {
                    return new ErrorResult(Messages.UserNotFound);
                }
            }


        }
      

       
    }
}


