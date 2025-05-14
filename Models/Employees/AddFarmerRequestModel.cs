using AgriEnergyConnect.Models.Authentication;

namespace AgriEnergyConnect.Models.Employees
{
    public class AddFarmerRequestModel : RegisterRequestModel
    {
        public string FarmName { get; set; }
        public string FarmingType { get; set; }
    }
}
