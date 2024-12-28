using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StyleSphere.Models;

namespace StyleSphere.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private AppDbContext _context;
        private IConfiguration config;
        public AuthenticationController(AppDbContext context, IConfiguration _config)
        {
            this._context = context;
            config = _config;
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult<dynamic> Login(LoginModel model)
        {
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                var user = _context.users.FirstOrDefault(s => s.Email == model.Email && s.Password == model.Password);

                if (user != null)
                {
                    var token = GenerateToken(user);
                    return Ok(new { user.UserId, user.UserName, user.Email, user.PhoneNumber,user.Status, user.UserRole, Token = token });
                }
                else
                {
                    return Unauthorized();// status code 403
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [NonAction]
        private string GenerateToken(User user)
        {
            //This is a claims list that defined who are the subject, what is to be checked and 
            //who are the audience for the claim

            var claims = new List<Claim>
     {
         new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
         new Claim(JwtRegisteredClaimNames.Email, user.Email),
         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
         new Claim(ClaimTypes.Role,user.UserRole),
           };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("Jwt:secret")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: config.GetValue<string>("Jwt:issuer"),
                audience: config.GetValue<string>("Jwt:audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}