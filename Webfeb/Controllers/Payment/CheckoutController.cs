using Microsoft.AspNetCore.Mvc;
using WEB.Dal.Services;
using WEB.Database;
using WEB.Database.Models;
using Webfeb.Models.Payment;

namespace Webfeb.Controllers.Payment
{
    public class CheckoutController : Controller
    {
        private readonly CartService cartService;
        private readonly CountryService countryService;
        private  readonly ApplicationDbContext _context;
        private readonly CheckoutService checkoutService;


        public CheckoutController(CartService cartService, CountryService countryService,  ApplicationDbContext context, CheckoutService checkoutService)
        {
            this.cartService = cartService; 
            this.countryService =countryService;
            this._context=context;
            this.checkoutService = checkoutService;
        }
        CheckoutViewModel model = new CheckoutViewModel();
        [HttpGet]
        [Route("/Payment/Checkout")]
        public IActionResult Index()
        {
            return View("~/Views/Payment/Checkout.cshtml");
        }

        [HttpGet]
        [Route("/Payment/Checkout/Create")]
        public IActionResult Create()
        {
              
            List<Product> w = new List<Product>();
            List<Product> pro = _context.CartItems.Select(x => new Product
            {
                Id = x.ProductId
            }).ToList();
            foreach (var pr in pro)
            {
                Product product = _context.Products.Where(x => x.Id == pr.Id).FirstOrDefault();
                w.Add(product);
            }
          
            model.CartItemList = cartService.GetProducts();
            model.CountryList = countryService.GetCountries();
          
               model.Products = w;
            

            
            return View("~/Views/Payment/Checkout/Create.cshtml",model);
        }
        [HttpPost]
        [Route("/Payment/Checkout/Create")]
        public IActionResult Create(CheckoutViewModel products)
        {
            List<Product> w = new List<Product>();
           
            List<Product> pro = _context.CartItems.Select(x => new Product
            {
                Id = x.ProductId
            }).ToList();
            foreach (var pr in pro)
            {
                Product product = _context.Products.Where(x => x.Id == pr.Id).FirstOrDefault();
                w.Add(product);
            };
            model.Products = w;

            List<Product> me = new List<Product>();
            List<CartItem>sd = cartService.GetProducts();
      
          
            
            Checkout m = new Checkout()
            {
                Id = products.Checkouts.Id,
                FirstName = products.Checkouts.FirstName,
                LastName = products.Checkouts.LastName,
                Email = products.Checkouts.Email,
                MobilNumber = products.Checkouts.MobilNumber,
                Address = products.Checkouts.Address,
                City = products.Checkouts.City,
                State = products.Checkouts.State,
                DateTime = products.Checkouts.DateTime,
               CountryId = products.Checkouts.CountryId,
                
                

            };           
             
            checkoutService.AddCheckout(m);

            return Redirect("/Home");
        }
    }
}
