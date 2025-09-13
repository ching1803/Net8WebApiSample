
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Web.Models;

namespace Web.Controller
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public AuthController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost("")]
        public IActionResult Login([FromBody] LoginRequestModel loginRequest)
        {
            if (true)
            {
                var issuer = Configuration["JwtConfig:Issuer"];
                var audience = Configuration["JwtConfig:Audience"];
                var key = Configuration["JwtConfig:Key"];
                var tokenValidityMins = Configuration.GetValue<int>("JwtConfig:TokenValidityMins");
                var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(tokenValidityMins);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Name, loginRequest.Username)
                        }),
                    Expires = tokenExpiryTimeStamp,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature)
                };


                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var accessToken = tokenHandler.WriteToken(securityToken);

                var response = new LoginResponseModel
                {
                    AccessToken = accessToken
                };

                return Ok(ApiResponse<LoginResponseModel>.Success(response, "login Success"));

            }
        }
    }
}
