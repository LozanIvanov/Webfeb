using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB.Database.Models;

namespace WEB.Dal.Services
{
    public class CountryService :BaseService
    {
        public CountryService(IConfiguration configuration) : base(configuration) { }

        public List<Country> GetCountries()
        {
            return this.dbContext.Countries.ToList();
               
              
        }
    }
}
