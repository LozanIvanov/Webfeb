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

        public Product GetProductById(int id)
        {
            return this.dbContext.Products.Where(p => p.Id == id)
                .Include(p => p.Category)
                .FirstOrDefault();
        }

        public void AddProduct(Product product)
        {
            this.dbContext.Products.Add(product);
            this.dbContext.SaveChanges();
        }

        public void UpdateProduct(int id, Product product)
        {
            var currentProduct = this.dbContext.Products.Where(p => p.Id == id)
                .Include(p => p.Category)
                .FirstOrDefault();

            if (currentProduct != null)
            {
                currentProduct.Name = product.Name;
                currentProduct.Discription = product.Discription;
                currentProduct.Price = product.Price;
                currentProduct.Quantity = product.Quantity;
                currentProduct.CategoryId = product.CategoryId;

                if (!string.IsNullOrEmpty(product.MainImage))
                {
                    currentProduct.MainImage = product.MainImage;
                }

                dbContext.Entry(currentProduct).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
	}
}
