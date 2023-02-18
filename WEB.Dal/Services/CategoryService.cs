using Microsoft.EntityFrameworkCore;
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
        private ApplicationDbContext dbcontext;
        public CategoryService()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer("Server=.;Database=Feb;Trusted_Connection=true");
            dbcontext= new ApplicationDbContext(builder.Options);
        }
        public void Store(Category category)
        {
            dbcontext.Categories.Add(category);
            dbcontext.SaveChanges();    
        }
        public List<Category>GetCategory()
        {
            return dbcontext.Categories.ToList();
        }
        public Category GetCategoryById(int id)
        {
            return dbcontext.Categories.Where(c => c.Id == id).FirstOrDefault();
        }
        public void Update(Category category)
        {
            dbcontext.Entry(category).State = EntityState.Modified;
            dbcontext.SaveChanges();
        }
        public void Delete(int id)
        {
            Category cat = GetCategoryById(id);
            dbcontext.Entry(cat).State = EntityState.Deleted;
            dbcontext.SaveChanges();
        }
    }
}
