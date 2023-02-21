using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using WEB.Dal.Services;
using WEB.Database.Models;
using Webfeb.Models.Admin;

namespace Webfeb.Controllers.Admin
{
	[Authorize(Roles = "Admin")]
    public class ProductController : Controller
	{
		private readonly ProductService productService;
		private readonly CategoryService categoryService;
        private readonly IWebHostEnvironment environment;
		public ProductController(ProductService productService, CategoryService categoryService, IWebHostEnvironment environment)
		{
			this.productService = productService;
			this.categoryService = categoryService;
			this.environment = environment;
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
        public async Task<IActionResult> Create(ProductCreateModel productModel)
        {
            string filePath = await UploadFile(productModel.MainImage);

            Product product = new Product
            { 
                Name = productModel.Name,
                Discription = productModel.Discription,
                Quantity = productModel.Quantity,
                Price = productModel.Price,
                MainImage = filePath,
                CategoryId = productModel.CategoryId
            };

            this.productService.AddProduct(product);

            return Redirect("/Admin/Products");
        }

        private async Task<string> UploadFile(IFormFile file)
        {
            var uniqueFileName = Guid.NewGuid() + "-" + file.FileName;
            var filePath = Path.Combine("wwwroot", "img", "products", uniqueFileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            return uniqueFileName;
        }
    }
}
