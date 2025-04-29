namespace ProductsCatalogService.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string InStock { get; set; }
        public string Country { get; set; }
    }
}
