namespace ProductsCatalogService.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public bool InStock { get; set; }
        public string Country { get; set; }
    }
}