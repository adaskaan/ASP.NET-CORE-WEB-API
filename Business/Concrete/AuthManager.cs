using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilites.Results;
using Core.Utilites.Security.Jwt;
using Entities.Dtos;
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

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
           var accessToken = _tokenHelper.CreateToken(user);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userLoginDto)
        {
            var userToCheck = _userService.getByUserName(userLoginDto.UserName);
            if(userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!(userLoginDto.Password == userToCheck.Password)) {
                return new ErrorDataResult<User>(Messages.PasswordError); 
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SuccesfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userRegisterDto, string password)
        {

            var user = new User{
                UserName = userRegisterDto.UserName,
                Password = userRegisterDto.Password,
                IsAdmin = false
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(Messages.UserRegistered);
        }

        public IResult UserExists(string userName)
        {
            if (_userService.getByUserName(userName) != null) { 
                return new ErrorResult(Messages.UserExists);
            }
            return new SuccessResult();
        }
    }
}
