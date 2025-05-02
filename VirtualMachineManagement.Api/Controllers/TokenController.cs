using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VirtualMachineManagement.Core.Entities;
using VirtualMachineManagement.Core.Interfaces;

namespace SalesVirtualMachines.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISecurityService _securityService;

        public TokenController(IConfiguration configuration, ISecurityService securityService)
        {
            _configuration = configuration;
            _securityService = securityService;
        }
        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            var validation = await IsValidUser(login);
            if (validation.Item1 && validation.Item2 != null)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token });
            }
            return NotFound();
        }
        private async Task<(bool, Security)> IsValidUser(UserLogin login)
        {
            var user = await _securityService.GetLoginByCredentials(login);

            return (true, user);
        }
        private string GenerateToken(Security security)
        {
            #region Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            //vamos a generar las credenciales
            var signiCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signiCredentials);
            #endregion
            #region Phayload claims
            //claims
            var claims = new[]
            {
            new Claim(ClaimTypes.Name,security.UserName),
            new Claim("User", security.User),
            new Claim(ClaimTypes.Role, security.Role.ToString()),
            };
            //payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );
            #endregion
            #region signature - firma
            var token = new JwtSecurityToken(header, payload);
            #endregion
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

