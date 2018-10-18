using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using LifeLike.Services.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LifeLike.Web.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogService _logger;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            ILogService logger,    
            IConfiguration configuration
)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(Register model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Info = "Invalid Model";
                    return BadRequest(model);
                }
                Debug.WriteLine($"LOGIN: {model}");               
                var user = new User {UserName = model.Login, Email = model.Email, EmailConfirmed = true};
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Ok(GenerateJwtToken(model.Login, user));
                }    
                return Unauthorized();
        
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return StatusCode(500, e);
            }
        }


        [HttpPost]
        [Route("Login")]    
        public async Task<IActionResult> Login(Login model)
        {
            try
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
                    var user=_userManager.Users.SingleOrDefault(p=>p.UserName == model.UserName);
                    return Ok(GenerateJwtToken(model.UserName, user));
                }
                return Unauthorized();

            }
            catch(Exception e)
            {
                await _logger.AddException(e);
                model.Info=e.Message;
                return StatusCode(500, e);
            }
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