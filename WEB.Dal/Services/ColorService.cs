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
    public class ColorService : BaseService
    {
        public ColorService(IConfiguration configuration) : base(configuration) { }

        public List<Color> GetColors()
        {
            return this.dbContext.Colors.ToList();
        }
    }
}
