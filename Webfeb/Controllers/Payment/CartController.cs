using Microsoft.AspNetCore.Mvc;
using WEB.Dal.Services;
using WEB.Database;
using WEB.Database.Models;
using Webfeb.Models.Admin;

namespace Webfeb.Controllers.Payment
{
    public class CartController : Controller
    {
        private readonly ProductService productService;
        private readonly CartService cartService;
        private ApplicationDbContext _context;
       

        public CartController(ProductService productService, ApplicationDbContext db, CartService cartService)
        {
            this.productService=productService;
            this._context = db;
            this.cartService=cartService;
           
           
        }
      

        [HttpGet]
        [Route("/Payment/Cart")]

        public IActionResult Index()
        {/*
            CategoryEditViewModel category = new CategoryEditViewModel();
            category.TrandyProduct = productService.GetProducts().Select(c=>new ProductCreateModel()
            {
                Name = c.Name,
                Quantity = c.Quantity,
                Price = c.Price,
                Total=c.Price,
                MainImages = c.MainImage
            }).ToList();
            return View(category.TrandyProduct);*/
            return View("~/Views/Home/Index.cshtml");
        }
      
        [HttpGet]
        [Route("/Payment/Cart/Add")]
        public IActionResult Add(int id)
        {
            string h = id.ToString();
            Product product = productService.GetProductById(id);
           

            if (product != null)
            {
                // Create a new CartItem and set its properties
                CartItem cartItem = new CartItem
                {
                    ProductId = product.Id,
                    Product = product,
                    Quantity = 1 // Set the desired quantity
                };

                // Add the cartItem to the shopping cart
                cartService.AddProduct(cartItem);
            }
   
      


            return View("~/Views/Payment/Cart.cshtml");
        }

       
        [HttpGet]
        [Route("/Admin/Products/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            productService.Delete(id);
            return Redirect("Payment/Cart/Add");
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
