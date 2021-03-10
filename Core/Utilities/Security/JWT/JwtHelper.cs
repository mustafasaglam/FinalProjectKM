using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
//using Microsoft.Extensions.Configuration;  //IConfiguration için nugetten kurduk.
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } //appstart json daki değerleri okumaya yarar
        private TokenOptions _tokenOptions { get; }  //Jwt klasörü içindekiTokenOptions nesnesi** yukarıda Okuduğumuz verileri tutacağımız nesne
        private DateTime _accessTokenExpiration; //token süresinin ne zaman biteceğini tutar
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //Microsoft.Extensions.Configuration.Binder bunu yükleyince sorun düzeldi.

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration+5); //Kaç dk sonra biteceği + 5 verdimm aşağıdaki NotBefore ile çakışıyordu.
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); //security key, güvenlik anahtarı
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey); 
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                //notBefore: DateTime.Now.AddMinutes(-1), //bu şekild ebu zamanı küçültünce çalıştı
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
