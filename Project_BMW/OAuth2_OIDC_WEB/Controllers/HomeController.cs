using Microsoft.AspNetCore.Mvc;
using OAuth2_OIDC_WEB.Models;
using OAuth2_OIDC_WEB.Models.Entity;
using System;
using System.Diagnostics;

namespace OAuth2_OIDC_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OauthOidcsystemContext _context;

        public HomeController(ILogger<HomeController> logger, OauthOidcsystemContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
