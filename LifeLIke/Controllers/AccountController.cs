using System;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.ViewModel;
using LifeLIke.Controllers;
using LifeLIke.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LifeLike.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEventLogRepository _logger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,IEventLogRepository logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }
        [HttpGet] 
        public ViewResult R() { 
            var model = new RegisterViewModel();

            return View(); 
        } 
        [HttpPost] 
        public async Task<IActionResult> R(RegisterViewModel model) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("","Invalid Model");
                    return View(model);
                }
                var user = new User {UserName = model.Username, Email = model.Email, EmailConfirmed = true};
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    _logger.LogInformation(EventLogType.Error,error.Description);

                    ModelState.AddModelError("", error.Description);
                }
                return View(model); 

            }
            catch (Exception error)
            {
                _logger.AddExceptionLog(error);
                ModelState.AddModelError("", error.Message);
                return View(model); 
            }
          
        }        
        
        public  IActionResult L()
        {
           var model = new LoginViewModel();
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> L(LoginViewModel model)
        {
            if (ModelState.IsValid) { 
                var result = await _signInManager.PasswordSignInAsync(model.Login,
                    model.Password, model.RememberMe,false); 
      
                if (result.Succeeded) {                        
                   return RedirectToAction("Index", "SiteManager");                     
                } 
            } 
            
            ModelState.AddModelError("","Invalid login attempt"); 
            return View(model); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");
            return RedirectToAction("Index", "Home");
        }
    }
}