using FeedbackPortal.Areas.Identity.Data;
using FeedbackPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackPortal.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<FeedbackPortalUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private readonly FeedbackPortalContext _context;
        private IPasswordHasher<FeedbackPortalUser> passwordHasher;
        public AdminController(UserManager<FeedbackPortalUser> usrMgr, FeedbackPortalContext context, RoleManager<IdentityRole> roleMgr, IPasswordHasher<FeedbackPortalUser> passwordHash)
        {
            userManager = usrMgr;
            _context = context;
            roleManager = roleMgr;
            passwordHasher = passwordHash;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(userManager.Users);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Employees"] = new SelectList(_context.Set<Employee>(), "Id", "Name");
            ViewData["Clients"] = new SelectList(_context.Set<Client>(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {

                ViewData["Employees"] = new SelectList(_context.Set<Employee>(), "Id", "Name", user.EmployeeId);
                ViewData["Clients"] = new SelectList(_context.Set<Client>(), "Id", "Name", user.ClientId);
                FeedbackPortalUser appUser = new FeedbackPortalUser
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    ClientId = user.ClientId,
                    EmployeeId = user.EmployeeId
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    //Stavi mu Role na korisnikot
                    if (user.EmployeeId != null)
                    {
                        var result1 = await userManager.AddToRoleAsync(appUser, "Employee");
                    }
                    else if (user.ClientId != null)
                    {
                        var result2 = await userManager.AddToRoleAsync(appUser, "Client");
                    }
                    return RedirectToAction("Index");
                }

                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string id)
        {
            FeedbackPortalUser user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string id, string email, string password)
        {
            FeedbackPortalUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(email))
                    user.Email = email;
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                if (!string.IsNullOrEmpty(password))
                    user.PasswordHash = passwordHasher.HashPassword(user, password);
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            FeedbackPortalUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IList<String> list = await userManager.GetRolesAsync(user);
                //Admins ne mozhat da se izbrishat
                if (!list.Contains("Admin"))
                {
                    IdentityResult result = await userManager.DeleteAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", userManager.Users);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
