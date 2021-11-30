using EstudoDDD.Domain.DTO;
using EstudoDDD.Domain.Entities;
using EstudoDDD.Domain.Interfaces.Services.User;
using EstudoDDD.Domain.Repository.Interface;
using EstudoDDD.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;
        private TokenConfigurations _tokenConfigurations;
        private SigningConfigurations _signingConfigurations;
        private IConfiguration _configuration;

        public LoginService(IUserRepository repository, TokenConfigurations tokenConfigurations,
                            SigningConfigurations signingConfigurations, IConfiguration configuration)
        {
            _repository = repository;
            _tokenConfigurations = tokenConfigurations;
            _signingConfigurations = signingConfigurations;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDTO user)
        {
            UserEntity baseUser = new();

            if (user != null && !string.IsNullOrEmpty(user.Email))
            {
                baseUser = await _repository.FindByLogin(user.Email);

                if (baseUser == null)
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };

                else
                {
                    ClaimsIdentity identity = new(new GenericIdentity(baseUser.Email),
                                                  new[] {new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Jti = Id do token
                                                         new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)});

                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                    JwtSecurityTokenHandler handler = new();

                    string token = CreateToken(identity, createDate,expirationDate, handler);
                    return SuccessObject(createDate, expirationDate, token, user);
                }
            }

            else
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                                                            {
                                                                Issuer = _tokenConfigurations.Issuer,
                                                                Audience = _tokenConfigurations.Audience,
                                                                SigningCredentials = _signingConfigurations.SigningCredentials,
                                                                Subject = identity,
                                                                NotBefore = createDate,
                                                                Expires = expirationDate,
                                                            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, LoginDTO user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = user.Email,
                message = "usuário logado com sucesso!"
            };
        }
    }
}
