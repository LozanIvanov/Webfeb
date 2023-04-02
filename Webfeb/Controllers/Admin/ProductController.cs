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
    [Authorize(Roles = "Admin,Manager")]
    public class ProductController : Controller
    {
        private readonly ProductService productService;
        private readonly CategoryService categoryService;
        private readonly ColorService colorService;
        private readonly SizeService sizeService;
        private readonly IWebHostEnvironment environment;
        public ProductController(ProductService productService, CategoryService categoryService, ColorService colorService, SizeService sizeService, IWebHostEnvironment environment)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.sizeService = sizeService;
            this.colorService = colorService;
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
            var colors = this.colorService.GetColors();
            var sizes = this.sizeService.GetSizes();

            return View("~/Views/Admin/Products/Create.cshtml", new ProductCreateViewModel { Categories = categories, Colors = colors, Sizes = sizes });
        }

        [Route("Admin/Products/Create")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateModel productModel)
        {
            string filePath = "no-image.png";
            if (productModel.MainImage != null)
            {
                filePath = await UploadFile(productModel.MainImage);
            }

            Product product = new Product
            {
                Name = productModel.Name,
                Discription = productModel.Discription,
                Quantity = productModel.Quantity,
                Price = productModel.Price,
                MainImage = filePath,
                CategoryId = productModel.CategoryId,
                ColorId = productModel.ColorId,
                SizeId = productModel.SizeId
            };

            this.productService.AddProduct(product);

            return Redirect("/Admin/Products");
        }

        [Route("Admin/Products/Edit/{id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = this.productService.GetProductById(id);
            var categories = this.categoryService.GetCategories();
            var colors = this.colorService.GetColors();
            var sizes = this.sizeService.GetSizes();

            ProductEditViewModel model = new ProductEditViewModel
            {
                Product = product,
                Categories = categories,
                Colors = colors,
                Sizes = sizes
            };

            return View("~/Views/Admin/Products/Edit.cshtml", model);
        }

        [Route("Admin/Products/Edit/{id}")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductCreateModel productModel)
        {
            string filePath = String.Empty;
            if (productModel.MainImage != null)
            {
                filePath = await UploadFile(productModel.MainImage);
            }

            Product product = new Product
            {
                Name = productModel.Name,
                Discription = productModel.Discription,
                Quantity = productModel.Quantity,
                Price = productModel.Price,
                MainImage = filePath,
                CategoryId = productModel.CategoryId,
                ColorId = productModel.ColorId,
                SizeId = productModel.SizeId
            };

            this.productService.UpdateProduct(id, product);

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
