using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB.Database;
using WEB.Database.Models;

namespace WEB.Dal.Services
{
    public class CategoryService
    {
        private ApplicationDbContext dbContext;
        public CategoryService(IConfiguration configuration)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            dbContext = new ApplicationDbContext(builder.Options);
        }
        public void Store(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
        }
        public List<Category> GetCategories()
        {
            return dbContext.Categories.ToList();
        }
        public Category GetCategoryById(int id)
        {
            return dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();
        }
        public void Update(Category category)
        {
            dbContext.Entry(category).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Category cat = GetCategoryById(id);
            dbContext.Entry(cat).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }
    }
}
