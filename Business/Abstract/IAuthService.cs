
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDTO userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDTO userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IDataResult<Admin> RegisterAdmin(AdminForRegisterDTO adminForRegisterDto, string password);
        IDataResult<Admin> LoginAdmin(AdminForLoginDTO adminForLoginDto);
        IResult AdminExists(string email);
        IDataResult<AccessToken> CreateAccessTokenAdmin(Admin admin);
        Task<IResult> ChangeRoles(Guid UserId);
      
       
    }
}
