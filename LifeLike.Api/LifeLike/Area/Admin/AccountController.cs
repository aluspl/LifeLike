using System.Threading.Tasks;
using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Models.Identity;
using LifeLike.Services.Commons.Interfaces.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Area.Admin
{
    [Area("admin")]
    [Route("[area]/[controller]")]
    public class AccountController : BaseAuthController
    {
        private readonly IUserIdentityService _userIdentityService;

        public AccountController(IUserIdentityService userIdentityService)
        {
            _userIdentityService = userIdentityService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [Return(typeof(AuthenticationResponseModel))]
        public async Task<IActionResult> Login([FromBody]LoginRequestModel model)
        {
            var response = await _userIdentityService.LoginAsync(model.Email, model.Password);
            return GetResult(response);
        }

        [HttpPost("refresh-token")]
        [Return(typeof(AuthenticationResponseModel))]
        public async Task<IActionResult> Login([FromBody]RefreshTokenRequestModel readModel)
        {
            var response = await _userIdentityService.RefreshUserTokenAsync(XUserId, readModel.Token);
            return GetResult(response);
        }
    }
}
