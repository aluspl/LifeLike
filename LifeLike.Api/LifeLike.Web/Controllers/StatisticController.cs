using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Services.Structures;
using LifeLike.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _statistic;

        public StatisticController(IStatisticService service)
        {
            _statistic = service;
        } 
        [HttpGet]
        public IActionResult List()
        {
            return Ok(_statistic.List());
        }
        [HttpPost]
        public IActionResult Create([FromBody] Statistic item)
        {
            return Ok(_statistic.Create(item));
        }

    }
}