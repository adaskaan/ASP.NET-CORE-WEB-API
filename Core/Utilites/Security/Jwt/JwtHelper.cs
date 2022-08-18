using Core.Entities.Concrete;
using Core.Utilites.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
       public IConfiguration Configuration { get; }
       private TokenOptions _tokenOptions;
       private DateTime _AccessTokenExpiration;

        public JwtHelper(IConfiguration configuration) {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection(key:"TokenOptions").Get<TokenOptions>();
            _AccessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }
        public AccessToken CreateToken(User user)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _AccessTokenExpiration
            };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                claims:SetClaims(user),
                expires:_AccessTokenExpiration,
                notBefore:DateTime.Now,
                signingCredentials:signingCredentials
                );
            return jwt;
        }
        public List<Claim> SetClaims(User user)
        {
            var  permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("isAdmin", user.IsAdmin.ToString()));
            permClaims.Add(new Claim("userId", user.Id.ToString()));
            permClaims.Add(new Claim("userName", user.UserName));
            return permClaims;
        }
    }

}
