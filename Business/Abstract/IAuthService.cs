using Core.Entities.Concrete;
using Core.Utilites.Results;
using Core.Utilites.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userLoginDto);

        IResult UserExists(string userName);
        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
