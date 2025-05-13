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
        private EmployeeLogic _employeeLogic;   

        public EmployeeController()
        {
            _authenticationLogic = new AuthenticationLogic();
            _employeeLogic = new EmployeeLogic();
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
                if (EnvironmentVariables._userRoleId != ApplicationSettings._role_employee_id) throw new Exception("You do not have permission to add a farmer. Only employees may add farmers.");

                _authenticationLogic.SignUserUp(request.Name, request.Email, request.Password, ApplicationSettings._role_farmer_id);
                return RedirectToAction("Success");
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorViewModel 
                { 
                    Message = ex.Message, 
                    ControllerAction = "Farmer",
                    ControllerName = "AddFarmer"
                };

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

        [HttpGet]
        [AuthenticationFilter]
        public IActionResult GetFarmers()
        {
            try
            {
               if (EnvironmentVariables._userRoleId != ApplicationSettings._role_employee_id) throw new Exception("You do not have permission to view farmers. Only employees may view farmers.");

                var farmers = _employeeLogic.GetAllFarmers();
               return View("AllFarmers", farmers);
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorViewModel
                {
                    Message = ex.Message,
                    ControllerAction = "Farmer",
                    ControllerName = "GetFarmers"
                };
                TempData["ErrorMessage"] = errorModel.Message;

                return RedirectToAction("Error", "Home");
            }
        }
    }
}
