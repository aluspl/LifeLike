using LifeLike.Services;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Model;
using LifeLike.Shared.Structures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LifeLike.Web.Controllers
{
    [Route("api/[controller]")]
    public class LinkManagerController : BaseController
    {
        private readonly ILinkService service;
        private readonly ILogger _logger;

        public LinkManagerController(ILinkService repository, ILogger logger)
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
        public IActionResult Create(Link model)
        {
            if (ModelState.IsValid)
            {
                return Ok(service.Create(model));
            }
            return BadRequest();
        }
        [HttpPut]
        public Result Update([FromBody]Link model)
        {
            return ModelState.IsValid
                ? service.Update(model)
                : Result.Failed;
        }
        [HttpDelete]
        public Result Delete([FromBody]Link model)
        {
            return ModelState.IsValid
                ? service.Delete(model.Action)
                : Result.Failed;
        }

    }
}