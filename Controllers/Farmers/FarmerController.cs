using AgriEnergyConnect.Filters;
using AgriEnergyConnect.Logic;
using AgriEnergyConnect.Models;
using AgriEnergyConnect.Models.Farmers;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace AgriEnergyConnect.Controllers.Farmers
{
    public class FarmerController : Controller
    {
        public FarmerLogic _farmerLogic;

        public FarmerController()
        {
            _farmerLogic = new FarmerLogic();
        }

        [HttpGet]
        [AuthenticationFilter]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [AuthenticationFilter]
        public IActionResult AddProduct(ProductAddRequestModel request)
        {
            try
            {
                if (EnvironmentVariables._userRoleId != ApplicationSettings._role_farmer_id) throw new Exception("You do not have permission to add a product. Only farmers may add products.");

               _farmerLogic.AddMarketPlaceItem(request.ProductName, request.Description, request.Type, request.Price);

                return View("Success");
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorViewModel
                {
                    Message = ex.Message,
                    ControllerAction = "Farmer",
                    ControllerName = "AddProduct"
                };

                TempData["ErrorMessage"] = errorModel.Message;

                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        [AuthenticationFilter]
        public IActionResult GetFarmerPorducts(int id)
        {
            try
            { 
                var prodList = _farmerLogic.GetFarmerProducts(id);
                return View("FarmerProducts", prodList);
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorViewModel 
                {
                    Message = ex.Message,
                    ControllerAction = "Employee",
                    ControllerName = "GetFarmers" 
                };
                TempData["ErrorMessage"] = errorModel.Message;

                return RedirectToAction("Error", "Home");
            }
        }


        [HttpGet]
        [AuthenticationFilter]
        public IActionResult GetAllPorducts()
        {
            try
            {
                var prodList = _farmerLogic.GetAllProducts();
                return View("AllProducts", prodList);
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorViewModel
                {
                    Message = ex.Message,
                    ControllerAction = "Home",
                    ControllerName = "Index"
                };

                TempData["ErrorMessage"] = errorModel.Message;

                return RedirectToAction("Error", "Home");
            }
        }
    }
}
