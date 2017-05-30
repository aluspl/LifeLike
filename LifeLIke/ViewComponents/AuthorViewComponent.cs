using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.ViewComponents
{
    public class AuthorViewComponent : ViewComponent
    {
        public async Task< IViewComponentResult> InvokeAsync()
        {
           

            return View();
        }
    }
}