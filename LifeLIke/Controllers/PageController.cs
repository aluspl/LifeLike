using LifeLike.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.Controllers
{
    public class PageController : Controller
    {
        private IPageRepository _pages;

        public PageController(IPageRepository pageRepository)
        {
            _pages = pageRepository;
        }
        // GET
        public ActionResult List()
        {
            var list=_pages.List();
            return View(list);
        }

        public ActionResult Detail(string id)
        {
            var page = _pages.Get(id);
            if (page == null) return RedirectToAction("Index", "Home");
            return View(page);
        }

    }
}