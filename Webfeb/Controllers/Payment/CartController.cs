using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        public async Task< IActionResult> Index()
        {
            List<Product> w = new List<Product>();
          List<Product> pro = _context.CartItems.Select(x => new Product
            {
                Id=x.ProductId
            }).ToList();
            foreach (var pr in pro)
            {
                Product product = _context.Products.Where(x => x.Id == pr.Id).FirstOrDefault() ;
                w.Add(product);
            }
            var model = new ProductEditViewModel();
            model.Products = new List<ProductCreateModel>();
            
            foreach (var item in w)
            {
               
                ProductCreateModel t = new ProductCreateModel()
                {
                    Name = item.Name,
                    MainImages = item.MainImage,
                    Price = item.Price,
                    Total = item.Price
                };
                model.Products.Add(t);
                
            }

            return View("~/Views/Payment/Cart.cshtml", model);
        }
      
        [HttpGet]
        [Route("/Payment/Cart/Add")]

        public IActionResult Add(int id)
        {
            // Check if the user is authenticated first
            if (User.Identity.IsAuthenticated)
            {
                // Retrieve the User ID
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Product product = productService.GetProductById(id);

                if (product != null)
                {
                    CartItem cartItem = new CartItem()
                    {
                        ProductId = product.Id,
                        Quantity = 1,
                        UserId = userId

                    };
                    cartService.AddProduct(cartItem);
                }

                else
                {
                    return Unauthorized();
                }
                // ... rest of your action logic here


            }


           return Redirect("/Home");


            // return View("~/Views/Home/Index.cshtml");
        }

       
        [HttpGet]
        [Route("/Payment/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            productService.Delete(id);
            return Redirect("/Home");
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
