using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DailyClientMeet.Models;

namespace DailyClientMeet.Controllers
{
    
        public class AccountController : Controller
        {
            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Login(LoginViewModel model)
            {
                if (!ModelState.IsValid)
                    return View(model);

                // Temporary login logic
                if (model.UserName == "admin" &&
                    model.Password == "admin123")
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }
        }
    
}
