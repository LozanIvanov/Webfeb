using WEB.Database.Models;

namespace Webfeb.Models.Admin
{
    public class ProductEditViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
