using System;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using LifeLike.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEventLogRepository _logger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            IEventLogRepository logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<RegisterViewModel> R(RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Invalid Model");
                    return model;
                }

                var user = new User {UserName = model.Username, Email = model.Email, EmailConfirmed = true};
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return null;
                }

                foreach (var error in result.Errors)
                {
                    await _logger.LogInformation(EventLogType.Error, error.Description);

                    ModelState.AddModelError("", error.Description);
                }

                return model;
            }
            catch (Exception error)
            {
                await _logger.AddException(error);
                ModelState.AddModelError("", error.Message);
                return model;
            }
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<LoginViewModel> L(LoginViewModel model)
        {
            if (!ModelState.IsValid) return model;
            var result = await _signInManager.PasswordSignInAsync(model.Login,
                model.Password, model.RememberMe, false);

            return result.Succeeded ? model :  null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
              
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}