using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Database.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }
        public string? MainImage { get; set; }
        public string? GalleryImage { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}
