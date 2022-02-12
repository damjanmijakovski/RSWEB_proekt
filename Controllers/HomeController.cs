using FeedbackPortal.Areas.Identity.Data;
using FeedbackPortal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FeedbackPortalContext _context;
        private readonly UserManager<FeedbackPortalUser> userManager;

        public HomeController(ILogger<HomeController> logger, FeedbackPortalContext context, UserManager<FeedbackPortalUser> usrMgr)
        {
            _logger = logger;
            _context = context;
            userManager = usrMgr;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Products");
            }
            else if (User.IsInRole("Employee"))
            {
                //Get TeacherId
                var userID = userManager.GetUserId(User);
                FeedbackPortalUser user = await userManager.FindByIdAsync(userID);
                return RedirectToAction("Index", "Products", new { id = user.EmployeeId });
            }
            else if (User.IsInRole("Client"))
            {
                var userID = userManager.GetUserId(User);
                FeedbackPortalUser user = await userManager.FindByIdAsync(userID);
                return RedirectToAction("Index", "Products", new { id = user.ClientId });
            }
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
