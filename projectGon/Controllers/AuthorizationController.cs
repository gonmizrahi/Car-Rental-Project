using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLL.Logic;
using DAL.Databases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using projectGon.Car;

namespace projectGon.Controllers
{
    [EnableCors("pol1")]
    [Route("api/Authorization")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        UserData userData;
        readonly JWTSettings _jwtsettings;
        //User userWithToken = new User();
        public AuthorizationController(IOptions<JWTSettings> jwtsettings, UserData userData1)
        {
            _jwtsettings = jwtsettings.Value;
            userData = userData1;
        }
        // login to the system + verifacation
        [HttpPost]
        [Route("Login")] //// http://localhost:49924/api/Authorization/Login ***
        [AllowAnonymous]
        public IActionResult Login([FromBody] User user)
        {

            var userLogin = userData.UserLogin(user);




            if (userLogin == null)
            {
                return NotFound();
            }

            //sign your token here here..
            var token = GenerateAccessToken(userLogin);

            userData.UpdateToken(userLogin, token);
            
            return Ok(userLogin);
        }

        private string GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Role)
                }),
                Expires = DateTime.UtcNow.AddMonths(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }




    }

}
