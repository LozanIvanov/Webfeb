using WEB.Database.Models;

namespace Webfeb.Models.Admin
{
    public class ProductCreateViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Color> Colors { get; set; }
    }
}
