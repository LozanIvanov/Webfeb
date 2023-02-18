using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WEB.Database;
using WEB.Database.Models;

namespace WEB.Dal.Services
{
    public class ProductService
	{
        private readonly ApplicationDbContext dbContext;
        public ProductService(IConfiguration configuration)
		{
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            dbContext = new ApplicationDbContext(builder.Options);
        }

        public List<Product> GetProducts()
        {
            return this.dbContext.Products
                .Include(p => p.Category)
                .ToList();
        }

        public void AddProduct(Product product)
        {
            this.dbContext.Products.Add(product);
            this.dbContext.SaveChanges();
        }
	}
}
