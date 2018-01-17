using System;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Controllers
{
    public class SiteManagerController : Controller
    {
        private readonly IConfigRepository _config;

        public IEventLogRepository _logger;

        public SiteManagerController(IConfigRepository configRepository, IEventLogRepository logger)
        {
            _config = configRepository;
            _logger = logger;
        }

        // GET
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var configs =await _config.List();
            return View(configs);
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new Config();
            return View(model);

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Config model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _config.Create(model);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
              await  _logger.AddExceptionLog(e);
            }
            return View(model);

        }

        [Authorize]
        public async Task<ActionResult> Update(string id)
        {
            var model = await _config.Get(id);
            if (model == null) return RedirectToAction("Index");
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(Config model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                 await   _config.Update(model);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
              await  _logger.AddExceptionLog(e);
            }
            return View(model);
        }


    }
}