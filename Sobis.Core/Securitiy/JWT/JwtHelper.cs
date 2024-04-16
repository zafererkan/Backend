using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sobis.Core.Entities.Concrete;
using Sobis.Core.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Sobis.Core.Securitiy.JWT
{
    public class JwtHelper : ITokenHelper
    {
        //public IConfiguration Configuration { get; }
        private DateTime _accessTokenExpiration;
        //private TokenOptions _tokenOptions;
        public AccessToken CreateToken(AppUserEntity user, IEnumerable<AppClaimEntity> operationClaims)
        {
            TokenOptions _tokenOptions = new TokenOptions
            {
                Issuer = TokenOptionsStatic.Issuer,
                Audience = TokenOptionsStatic.Audience,
                AccessTokenExpiration = TokenOptionsStatic.AccessTokenExpiration,
                SecurityKey = TokenOptionsStatic.SecurityKey,
            };
            _accessTokenExpiration = DateTime.Now.AddMinutes(TokenOptionsStatic.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(TokenOptionsStatic.SecurityKey);
            var signingCredentials = SigningCredetialsHelper.CreateSigningCredetial(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }    

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, AppUserEntity user,
            SigningCredentials signingCredentials, IEnumerable<AppClaimEntity> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(AppUserEntity user, IEnumerable<AppClaimEntity> appClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddId(appClaims.Select(c => c.ClaimCode).FirstOrDefault().ToString());
            claims.AddEmail(user.Email);
            claims.AddName(user.Name);
            claims.AddSurName(user.Surname);
            claims.AddRoles(appClaims.Select(c => c.ClaimCode).ToArray());

            return claims;
        }
    }
}
