using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DailyClientMeet.Controllers
{
   
        public class DashboardController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
        }
    }

