using Microsoft.Extensions.Configuration;
using WEB.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace WEB.Dal.Services
{
    public class SizeService : BaseService
    {
        public SizeService(IConfiguration configuration) : base(configuration) { }

        public List<Size> GetSizes()
        {
            return this.dbContext.Sizes.ToList();
        }
        public void Create(Size size)
        {
              this.dbContext.Sizes.Add(size);
            dbContext.SaveChanges();
        }
        public Size GetSizeById(int id)
        {
            return dbContext.Sizes.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Update(int id,Size size)
        {
            var newsize = dbContext.Sizes.Where(x => x.Id == id).FirstOrDefault();
            newsize.Name = size.Name;

            dbContext.Entry(newsize).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var deleted = GetSizeById(id);
            dbContext.Entry(deleted).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }
    }
}
