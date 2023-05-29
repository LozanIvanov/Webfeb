using WEB.Database.Models;

namespace Webfeb.Models.Payment
{
    public class CheckoutViewModel

    {
        public CheckoutModel Checkouts { get; set; }
        public List<Country> CountryList { get; set; }
        public List<CartItem> CartItemList { get; set; }
        public List<Product> Products { get; set; }
    }
}
