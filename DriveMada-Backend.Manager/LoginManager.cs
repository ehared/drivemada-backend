using DriveMada_Backend.DataManager;
using DriveMada_Backend.Manager.Interfaces;
using DriveMada_Backend.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DriveMada_Backend.Manager
{
    public class LoginManager : ILoginManager
    {
        private ILoginDataManager _loginDataManager;
        private readonly IConfiguration _configuration;

        public LoginManager(ILoginDataManager loginDataManager, IConfiguration configuration)
        {
            _loginDataManager = loginDataManager ?? throw new ArgumentNullException(nameof(loginDataManager));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public User Authenticate(User user)
        {
            var validUser = _loginDataManager.GetUser(user);

            if (validUser != null)
            {
                validUser.Token = GenerateJSONWebToken();
            }
            
            return validUser;
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
