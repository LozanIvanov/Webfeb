using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using WEB.Database.Models;

namespace Webfeb.Models.Admin
{
    public class ProductCreateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }
        public IFormFile? MainImage { get; set; }
        public string? GalleryImage { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
