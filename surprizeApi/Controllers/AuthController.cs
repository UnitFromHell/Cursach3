using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using surprizeApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace surprizeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static UserSite user = new UserSite();

        private readonly SurpriseBoxContext _context;

        private readonly IConfiguration _configuration;

        private readonly JwtSettings _options;
        public AuthController(SurpriseBoxContext context, IConfiguration configuration, IOptions<JwtSettings> optAccess)
        {
            _context = context;
            _configuration = configuration;
            _options = optAccess.Value;
        }


        [HttpPost]
        public async Task<bool> CheckUniquenessAsync(UserSite user)
        {
           
            var existingLogin = await _context.UserSites.FirstOrDefaultAsync(u => u.LoginUser == user.LoginUser);
            if (existingLogin != null)
            {
                
                return false;
            }

         

           
            return true;
        }


        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Register(UserSite user)
        {
            
            var check = await CheckUniquenessAsync(user);
           
            if(!check)
            {
                return BadRequest();
            }
            else
            {
                Password pas = new Password();
                var salt = pas.GenerateSalt();
                user.PasswordUser = pas.HashPassword(user.PasswordUser, salt);



                user.Salt = salt;

                _context.UserSites.Add(user);
                await _context.SaveChangesAsync();




                return Ok(new { message = "Регистрация прошла успешно" });
            }
            
        }

        [HttpPost]
        [Route("authorization")]
        public async Task<object> authorization(UserDTO user)
        {
            Password pass = new Password();
            var currentUser = _context.UserSites.FirstOrDefault(u => u.LoginUser == user.LoginUser);
          
            if (currentUser == null) return new { message = "Клиента с такими данными нет в системе" };

            if (pass.VerifyPassword(user.PasswordUser, currentUser.Salt, currentUser.PasswordUser))
            {
                var token = GenerateToken(currentUser.LoginUser, currentUser.RoleId, currentUser.IdUser);
                return new { message = "Авторизация прошла успешно", token, currentUser.IdUser};
            }
            else
            {
                return new { message = "Авторизация не удалась" };
            }
           
        }

        private string GenerateToken(string username, int roleId, int idUser)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, username));

            claims.Add(new Claim(ClaimTypes.Role, roleId.ToString()));

            claims.Add(new Claim("UserId", idUser.ToString())); // Добавление кода пользователя в утверждения

            claims.Add(new Claim("login", username));

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        private byte[] GetBytes(string password)
        {
            throw new NotImplementedException();
        }
    }
       
}

