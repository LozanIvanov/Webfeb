using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB.Database.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Parent { get; set; }
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();     
        }
    }
}
