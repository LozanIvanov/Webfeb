using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WEB.Database.Models;

namespace WEB.Dal.Services
{
    public class CategoryService : BaseService
    {
        public CategoryService(IConfiguration configuration) : base(configuration) { }

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
        public void Update(int id,Category category)
        { 
        var currentCategory = this.dbContext.Categories.Where(p => p.Id == id).FirstOrDefault();

            if (currentCategory != null)
            {
                currentCategory.Name = category.Name;

                currentCategory.ParentId = category.ParentId;


                if (!string.IsNullOrEmpty(category.MainImage))
                {
                    currentCategory.MainImage = category.MainImage;
                }
            }
                dbContext.Entry(currentCategory).State = EntityState.Modified;
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
