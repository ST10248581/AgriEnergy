using AgriEnergyConnect.Filters;
using AgriEnergyConnect.Logic;
using AgriEnergyConnect.Models;
using AgriEnergyConnect.Models.Authentication;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace AgriEnergyConnect.Controllers.Employees
{
    public class EmployeeController : Controller
    {
        private AuthenticationLogic _authenticationLogic;

        public EmployeeController()
        {
            _authenticationLogic = new AuthenticationLogic();
        }

        [HttpGet]
        [AuthenticationFilter]
        public IActionResult AddFarmer()
        {
            return View("AddFarmer");
        }

        [HttpPost]
        [AuthenticationFilter]
        public IActionResult AddFarmer(RegisterRequestModel request)
        {
            try
            {
                _authenticationLogic.SignUserUp(request.Name, request.Email, request.Password, ApplicationSettings._role_farmer_id);
                return RedirectToAction("Success");
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorViewModel { Message = ex.Message };
                TempData["ErrorMessage"] = errorModel.Message;

                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        [AuthenticationFilter]
        public IActionResult Success()
        {
            return View();
        }
    }
}
