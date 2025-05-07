using AgriEnergyConnect.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AgriEnergyConnect.Controllers.Authentication
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(LoginRequestModel request)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
