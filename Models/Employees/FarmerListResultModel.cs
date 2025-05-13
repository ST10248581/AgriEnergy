using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect.Models.Employees
{
    public class FarmerListResultModel
    {
        public List<FarmerItem> Farmers { get; set; } = new List<FarmerItem>();
    }

    public class FarmerItem
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
