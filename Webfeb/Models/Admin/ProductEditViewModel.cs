using WEB.Database.Models;

namespace Webfeb.Models.Admin
{
    public class ProductEditViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public List<Color> Colors { get; set; }
        public List<Size> Sizes { get; set; }
        public List<ProductCreateModel> Products { get; set; }
    }
}
