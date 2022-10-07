using CoinQualify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinQualify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CqContext _context;
        public HomeController(ILogger<HomeController> logger, CqContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Dashboard()
        {            
            return View();
        }
        
    }
}
