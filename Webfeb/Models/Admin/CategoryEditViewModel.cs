using WEB.Database.Models;

namespace Webfeb.Models.Admin
{
    public class CategoryEditViewModel
    {
        public List<Category> Categories { get; set; }
        public Category SelectedCategory { get; set; }
    }
}
