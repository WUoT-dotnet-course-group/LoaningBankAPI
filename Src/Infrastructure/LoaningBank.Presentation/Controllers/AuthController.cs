using LoaningBank.CrossCutting.DTO;
using LoaningBank.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoaningBank.Presentation.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IServicesConfiguration _configuration;

        public AuthController(IServicesConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("token")]
        public ActionResult<string> Authorize([FromForm] AuthRequest request)
        {
            if (request.ClientId == _configuration.AdminClientCredentails.Key 
                && request.ClientSecret == _configuration.AdminClientCredentails.Value)
            {
                return GenerateToken("Admin");
            }
            else if (request.ClientId == _configuration.ClientCredentails.Key 
                && request.ClientSecret == _configuration.ClientCredentails.Value)
            {
                return GenerateToken("Client");
            }

            return Unauthorized();
        }

        private ActionResult<string> GenerateToken(string role)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Role, role) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.AuthSecretKey)), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
