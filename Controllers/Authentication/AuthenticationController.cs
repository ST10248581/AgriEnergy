using AgriEnergyConnect.Logic;
using AgriEnergyConnect.Models;
using AgriEnergyConnect.Models.Authentication;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace AgriEnergyConnect.Controllers.Authentication
{
    public class AuthenticationController : Controller
    {
        private AuthenticationLogic _authenticationLogic;

        public AuthenticationController()
        {
            _authenticationLogic = new AuthenticationLogic();
        }

        #region Sign In
        [HttpGet]
        public IActionResult SignIn()
        {
            return View("SignIn");
        }

        [HttpPost]
        public IActionResult SignIn(LoginRequestModel request)
        {
            try
            {
                _authenticationLogic.SignUserIn(request.Email, request.Password);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorViewModel
                {
                    Message = ex.Message,
                    ControllerAction = "Authentication",
                    ControllerName = "SignIn"
                };
                TempData["ErrorMessage"] = errorModel.Message;

                return RedirectToAction("Error", "Home");
            }
            
        }

        #endregion

        #region Sign up

        [HttpGet]
        public IActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpPost]
        public IActionResult SignUp(RegisterRequestModel request)
        {
            try
            {
                _authenticationLogic.SignUserUp(request.Name, request.Email, request.Password, request.RoleId);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorViewModel
                {
                    Message = ex.Message,
                    ControllerAction = "Authentication",
                    ControllerName = "SignUp"
                };

                TempData["ErrorMessage"] = errorModel.Message;

                return RedirectToAction("Error", "Home");
            }
        }

        #endregion

        #region Sign Out

        [HttpGet]
        public IActionResult SignOut()
        {
            try
            {
                _authenticationLogic.SignUserOut();

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorViewModel
                {
                    Message = ex.Message,
                    ControllerAction = "Authentication",
                    ControllerName = "SignOut"
                };

                TempData["ErrorMessage"] = errorModel.Message;
                return RedirectToAction("Error", "Home");
            }    
        }

        #endregion

    }
}
