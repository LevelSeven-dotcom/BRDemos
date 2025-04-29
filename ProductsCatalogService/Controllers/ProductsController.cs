using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsCatalogService.Data;
using ProductsCatalogService.Entities;

namespace ProductsCatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //..api/Products
    public class ProductsController : ControllerBase
    {
        private readonly ProductsDbContext db;

        public ProductsController(ProductsDbContext db)
        {
            this.db = db;
        }

        // GET .../api/products
        [HttpGet]
        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        // GET .../api/products/{id}
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Product), StatusCodes.Status404NotFound)]
        public IActionResult GetProducts(int id)
        {
            //return db.Products.FirstOrDefault(p => p.Id == id);
            //return db.Products.Find(id);
            var product = db.Products.Find(id);

            if (product == null)//not found
            {
                //return a 404 not found
                return NotFound($"The product with ID: {id} was not found");
            }
            else
            {
                //return a 200 ok http status code
                return Ok(product);
            }
        }

        //get all products to some brand 
        // GET .../api/products/brand/{brand}
        [HttpGet]
        [Route("brand/{brand}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Product), StatusCodes.Status404NotFound)]

        public IActionResult GetBrand(string brand)
        {
            var products = db.Products.Where(p => p.Brand.Contains(brand)).ToList();
            if (products == null || products.Count == 0)//not found
            {
                //return a 404 not found
                return NotFound($"The product with Brand: {brand} was not found");
            }
            else
            {
                //return a 200 ok http status code
                return Ok(products);
            }
        }

        //Get all products belongs to some country
        // GET .../api/products/country/{country}

        [HttpGet]
        [Route("country/{country}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Product), StatusCodes.Status404NotFound)]

        public IActionResult GetCountry(string country)
        {
            var products = db.Products.Where(p => p.Country.Contains(country)).ToList();
            if (products == null || products.Count == 0)//not found
            {
                //return a 404 not found
                return NotFound($"The product with Country: {country} was not found");
            }
            else
            {
                //return a 200 ok http status code
                return Ok(products);
            }
        }

        //Get all products between price range from min price to max price
        // GET .../api/products/price/min/{minPrice}/max/{maxPrice}
        [HttpGet]
        [Route("price/min/{minPrice}/max/{maxPrice}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Product), StatusCodes.Status404NotFound)]
        public IActionResult GetPrice(int minPrice, int maxPrice)
        {
            var products = db.Products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
            if (products == null || products.Count == 0)//not found
            {
                //return a 404 not found
                return NotFound($"The product with Price between {minPrice} and {maxPrice} was not found");
            }
            else
            {
                //return a 200 ok http status code
                return Ok(products);
            }
        }
    }
}

