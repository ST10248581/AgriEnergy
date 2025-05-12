using AgriEnergyConnect.Data;

namespace AgriEnergyConnect.Logic
{
    public class FarmerLogic
    {

        public MarketplaceItem AddMarketPlaceItem(string productName, string description, string type, decimal price)
        {
            if (string.IsNullOrWhiteSpace(productName)) throw new Exception("Product name required.");
            if (string.IsNullOrWhiteSpace(type)) throw new Exception("Product type required.");
            if (price <= 0) throw new Exception("Invalid Price.");

            using (var dm = new AgriEnergyConnectContext())
            {
                var product = new MarketplaceItem
                {
                    Name = productName,
                    Description = description,
                    Type = type,
                    ProviderId = EnvironmentVariables._userId,
                    Price = price
                };

                dm.MarketplaceItems.Add(product);
                dm.SaveChanges();

                return product;
            }          
        }
    }
}
