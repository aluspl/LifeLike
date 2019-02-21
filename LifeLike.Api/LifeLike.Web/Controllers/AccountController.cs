using LifeLike.Data.Models;
using LifeLike.Services.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LifeLike.Web.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]Register model)
        {
            if (!ModelState.IsValid)
            {
                model.Info = "Invalid Model";
                return BadRequest(model);
            }
            Debug.WriteLine($"LOGIN: {model}");
            var user = new User { UserName = model.Username, Email = model.Email, EmailConfirmed = true };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                var token = GenerateJwtToken(model.Username, user);
                var loginModel = new Login()
                {
                    Token = token,
                    Id = user.Id,
                };
                return Ok(loginModel);
            }
            return Unauthorized();
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]Login model)
        {
            if (!ModelState.IsValid)
            {
                model.Info = "Invalid Model";
                return BadRequest(model);
            }
            Debug.WriteLine($"LOGIN: {model}");
            var result = await _signInManager.PasswordSignInAsync(model.UserName,
                model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                var user = _userManager.Users.SingleOrDefault(p => p.UserName == model.UserName);
                var token = GenerateJwtToken(model.UserName, user);
                model.Token = token;
                model.Id = user.Id;
                return Ok(model);
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string login, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}