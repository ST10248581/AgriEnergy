using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models.Employees;
using Microsoft.Identity.Client;

namespace AgriEnergyConnect.Logic
{
    public class EmployeeLogic
    {

        public FarmerListResultModel GetAllFarmers()
        {
            var result = new FarmerListResultModel()
            {
                Farmers = new List<FarmerItem> ()
            };
            
            using(var dm = new AgriEnergyConnectContext())
            {
               var farmers = (from u in dm.Users
                          where u.RoleId == ApplicationSettings._role_farmer_id
                          select new FarmerItem
                          {
                              Email = u.Email,  
                              Name = u.Name,
                          }).ToList();

              foreach(var f in farmers) result.Farmers.Add(f);
            }
            
            return result;
        }
    }
}
