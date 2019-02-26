using LifeLike.Services;
using LifeLike.Services.ViewModel;
using LifeLike.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Route("api/[controller]")]
    public class LinkManagerController : Controller
    {
        private readonly ILinkService service;
        private readonly ILogService _logger;

        public LinkManagerController(ILinkService repository, ILogService logger)
        {
            service = repository;
            _logger = logger;
        }
        // GET
        [Authorize]
        [HttpGet]
        public IActionResult GetList()
        {
            var list = service.List();
            return Ok(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Link model)
        {
            if (ModelState.IsValid)
            {
                return Ok(service.Create(model));
            }
            return BadRequest();
        }
        [HttpGet("Update")]
        [Authorize]
        public IActionResult Update(long id)
        {
            var model = service.Get(id);
            return Ok(model);

        }
        [HttpPut("Update")]
        [ValidateAntiForgeryToken]
        public Result Update([FromBody]Link model)
        {
            return ModelState.IsValid
                ? service.Update(model)
                : Result.Failed;
        }

        [HttpDelete("Delete")]
        public Result Delete([FromBody]Link model)
        {
            return ModelState.IsValid
                ? service.Delete(model.Action)
                : Result.Failed;

        }

    }
}