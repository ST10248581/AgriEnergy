using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models.Farmers;

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

        public ProductListResultModel GetFarmerProducts(int farmerId)
        {
            var result = new ProductListResultModel()
            {
                Products = new List<ProductItem>()
            };
            
            using (var dm = new AgriEnergyConnectContext())
            {
                var farmer = (from u in dm.Users
                               where u.RoleId == ApplicationSettings._role_farmer_id
                               && u.UserId == farmerId
                              select u).FirstOrDefault();

                if (farmer == null) throw new Exception("Farmer not found.");

                result.FarmerName = farmer.Name;

                var products = (from p in dm.MarketplaceItems
                                where p.ProviderId == farmer.UserId
                                select new ProductItem
                                {
                                    Id = p.ItemId,
                                    ProductName = p.Name,
                                    Description = p.Description,
                                    Type = p.Type,
                                    Price = p.Price ?? 0
                                }).ToList();  

                foreach (var product in products) result.Products.Add(product);

                return result;
            }
           
        }

        public ProductListResultModel GetAllProducts()
        {
            var result = new ProductListResultModel()
            {
                Products = new List<ProductItem>()
            };

            using (var dm = new AgriEnergyConnectContext())
            {
                
                var products = (from p in dm.MarketplaceItems
                                select new ProductItem
                                {
                                    ProductName = p.Name,
                                    Description = p.Description,
                                    Type = p.Type,
                                    Price = p.Price ?? 0
                                }).ToList();

                foreach (var product in products) result.Products.Add(product);

                return result;
            }

        }
    }
}
