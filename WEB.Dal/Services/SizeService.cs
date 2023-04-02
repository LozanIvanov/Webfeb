using Microsoft.Extensions.Configuration;
using WEB.Database.Models;

namespace WEB.Dal.Services
{
    public class SizeService : BaseService
    {
        public SizeService(IConfiguration configuration) : base(configuration) { }

        public List<Size> GetSizes()
        {
            return this.dbContext.Sizes.ToList();
        }
    }
}
