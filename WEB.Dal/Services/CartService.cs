using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB.Database.Models;

namespace WEB.Dal.Services
{
    public class CartService : BaseService
    {
        public CartService(IConfiguration configuration) : base(configuration) { }

        public List<CartItem> GetProducts()
        {
            

            return this.dbContext.CartItems.ToList();

        }
        public CartItem GetProductById(int id)
        {
            return this.dbContext.CartItems.Where(p => p.Id == id)
                .FirstOrDefault();
        }
        public void AddProduct(CartItem product)
        {

            dbContext.CartItems.Add(product);
            dbContext.SaveChanges();
          
        }

       
        
        public void Delete(int id)
        {
            var cat = GetProductById(id);
            dbContext.Entry(cat).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }
    }
}
