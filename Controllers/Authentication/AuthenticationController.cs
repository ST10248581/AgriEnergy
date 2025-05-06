using Microsoft.AspNetCore.Mvc;

namespace AgriEnergyConnect.Controllers.Authentication
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
