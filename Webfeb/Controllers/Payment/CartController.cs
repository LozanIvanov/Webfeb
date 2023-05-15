using Microsoft.AspNetCore.Mvc;

namespace Webfeb.Controllers.Payment
{
    public class CartController : Controller
    {
        [HttpGet]
        [Route("/Payment/Index")]
        public IActionResult Index()
        {
            return View("~/Views/Payment/Cart.cshtml");
        }
    }
}
