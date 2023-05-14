using WEB.Database.Models;

namespace Webfeb.Models.Admin
{
    public class CategoryEditViewModel
    {
        public List<Category> Categories { get; set; }
        public Category SelectedCategory { get; set; }
        public Category CategoryViewModel { get; set; }
        public List<CategoryViewModel> CategoriesView { get; set; }
        public List<ProductCreateModel> TrandyProduct { get; set; }
    }
}
