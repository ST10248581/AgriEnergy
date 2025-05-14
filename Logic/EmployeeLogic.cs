using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models.Employees;
using Microsoft.Identity.Client;

namespace AgriEnergyConnect.Logic
{
    public class EmployeeLogic
    {
        public User AddFarmer(string name, string email, string password, int roleId, string farmName, string farmingType)
        {
            if (string.IsNullOrEmpty(name)) throw new Exception("Name is required.");
            if (string.IsNullOrEmpty(email)) throw new Exception("Email is required.");
            if (string.IsNullOrEmpty(password)) throw new Exception("Password is required.");
            if (roleId == 0) throw new Exception("User role required");

            using (var dm = new AgriEnergyConnectContext())
            {
                var role = dm.UserRoles.FirstOrDefault(r => r.RoleId == roleId);
                if (role == null) throw new Exception("User role not found.");

                var user = new User()
                {
                    Name = name,
                    Email = email,
                    Password = password,
                    RoleId = role.RoleId
                };

                dm.Add(user);
                dm.SaveChanges();

                return user;
            }

        }

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
                              Id = u.UserId,
                              Email = u.Email,  
                              Name = u.Name,
                              FarmName = "",
                              FarmingType = ""
                          }).ToList();

              foreach(var f in farmers) result.Farmers.Add(f);
            }
            
            return result;
        }
    }
}
