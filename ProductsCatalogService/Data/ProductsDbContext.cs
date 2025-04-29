using Microsoft.EntityFrameworkCore;
using ProductsCatalogService.Entities;

namespace ProductsCatalogService.Data

{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
