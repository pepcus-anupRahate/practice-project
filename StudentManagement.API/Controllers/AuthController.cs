using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.Controllers;
using StudentManagement.Models;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(ILogger<AuthController> logger) : base(logger)
        {

        }
        /// <summary>
        /// Authenticates a user and returns a JWT token.
        /// </summary>
        /// <param name="login">The login details including username and password.</param>
        /// <returns>A JWT token if authentication is successful; otherwise, Unauthorized.</returns>
        //https://localhost:7265/api/Auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            // Hardcoded login credentials for simplicity
            if (login.Username == "admin" && login.Password == "password")
            {
                var token = GenerateJwtToken();
                return Ok(new { token });
            }

            return Unauthorized();
        }

        private string GenerateJwtToken()
        {
            var secretKey = "MySuperSecretKeyWithAtLeast32Characters!";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "mydomain.com",
                audience: "mydomain.com",
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
