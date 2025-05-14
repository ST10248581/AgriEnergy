namespace AgriEnergyConnect.Models.Farmers
{
    public class ProductListResultModel
    {
        public string? FarmerName { get; set; }
        public List<ProductItem> Products { get; set; }
    }

    public class ProductItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}
