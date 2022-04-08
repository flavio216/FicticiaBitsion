using Ficticia_Bitsion.Models;
using Ficticia_Bitsion.Models.Common;
using Ficticia_Bitsion.Models.Response;
using Ficticia_Bitsion.Models.ViewModels;
using Ficticia_Bitsion.Tools;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ficticia_Bitsion.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        
         public UserResponse Auth(AuthRequest model)
         {
            UserResponse userResponse = new UserResponse();

            using (var db = new FicticiaSAContext())
             {
                 string spassword = Encrypt.GetHA256(model.UsrPassword);

                 var user = db.Users.Where(d => d.UsrEmail == model.UsrEmail &&
                                                    d.UsrPassword == spassword).FirstOrDefault();
                 if (user == null) return null;
  
                 userResponse.UsrEmail = user.UsrEmail;
                 userResponse.UsrToken = GetToken(user);
                 
             }

             return userResponse;
         }
        private string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var llave = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UsrId.ToString()),
                    new Claim(ClaimTypes.Email, user.UsrEmail.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
