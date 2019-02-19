using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TrainDotNetCore.Models.SecureJWT;

namespace TrainDotNetCore.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private ILogger LOGGER;

        public AuthController(IConfiguration config,ILogger<AuthController> logger)
        {
            this._config = config;
            this.LOGGER = logger;
        }

        // GET api/values
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]LoginModel user)
        {
            LOGGER.LogInformation($"LogginModel {user}");
            if (user == null)
            {
                LOGGER.LogError("Invalid client request");
                return BadRequest("Invalid client request");
            }

            if (user.UserName == "mario" && user.Password == "secret")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Issuer"],
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                LOGGER.LogWarning("Unauthorized");
                return Unauthorized();
            }
        }
    }
}