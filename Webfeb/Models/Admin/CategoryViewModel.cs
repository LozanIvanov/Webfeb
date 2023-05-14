using System.ComponentModel.DataAnnotations.Schema;
using WEB.Database.Models;

namespace Webfeb.Models.Admin
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Parent { get; set; }
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        public IFormFile? MainImage { get; set; }
        public string MainImages { get; set; }
        public int ProductCount { get; set; }

        public ICollection<Product> Products { get; set; }
        public CategoryViewModel()
        {
            Products = new List<Product>();
        }
    }
}
