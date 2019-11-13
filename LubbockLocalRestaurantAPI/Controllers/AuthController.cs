using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LubbockLocalRestaurant.Core.Models;
using LubbockLocalRestaurantAPI.APIModels;
using LubbockLocalRestaurantAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace LubbockLocalRestaurantAPI.Controllers
{
    [EnableCors("AllowOrigin")]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;
        private readonly AppDbContext _appDbContext;

        public AuthController(UserManager<AppUser> usermanager, IConfiguration configuration, AppDbContext appDbContext)
        {
            _userManager = usermanager;
            _config = configuration;
            _appDbContext = appDbContext;
        }

        // POST api/values
        [HttpPost("register")]
        [AllowAnonymous]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Register([FromBody]RegistrationModel registration)
        {
            var newUser = new AppUser
            {
                UserName = registration.Email,
                Email = registration.Email,
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                ProfileImage = registration.ProfileImage,
                Address = registration.Address
            };
            var result = await _userManager.CreateAsync(newUser, registration.Password);
           await _appDbContext.SaveChangesAsync();
            if (result.Succeeded)
            {
                return Ok(newUser.ToAPIModel());
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(ModelState);
        }

        // POST api/auth/login
        [AllowAnonymous]
        [HttpPost("login")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Login([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            
            var user = await AuthenticateUserAsync(login.Email, login.Password);

            
            if (user != null)
            {
                
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString, email = login.Email });
            }

            return response;
        }
        private string GenerateJSONWebToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // retrieve secret key from configuration
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            // create signing credentials using secrety key
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var roles = _userManager.GetRolesAsync(user).Result;
            // set up claims containing additional info that will be stored in token
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
             };
            // add role claims
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
            // create the token
            IdentityModelEventSource.ShowPII = true;
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials);
            return tokenHandler.WriteToken(token);
        }

        private async Task<AppUser> AuthenticateUserAsync(string userName, string password)
        {
            // retrieve the user by username and then check password
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }
            return null;
        }
    }
}
