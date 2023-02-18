using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB.Dal.Services;
using WEB.Database.Models;

namespace Webfeb.Controllers.Admin
{
	[Authorize(Roles = "Admin")]
    public class ProductController : Controller
	{
		private readonly ProductService productService;
		private readonly CategoryService categoryService;
		public ProductController(ProductService productService, CategoryService categoryService)
		{
			this.productService = productService;
			this.categoryService = categoryService;
		}

		[Route("Admin/Products")]
		public IActionResult Index()
		{
			var products = this.productService.GetProducts();

			return View("~/Views/Admin/Products/Index.cshtml", products);
        }

        [Route("Admin/Products/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            var categories = this.categoryService.GetCategories();

            return View("~/Views/Admin/Products/Create.cshtml", categories);
        }

        [Route("Admin/Products/Create")]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            this.productService.AddProduct(product);

            return Redirect("/Admin/Products");
        }
    }
}
