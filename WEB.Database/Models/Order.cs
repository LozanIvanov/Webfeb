using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB.Database.Models
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        [Column(TypeName = "nvarchar(450)")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Country")]
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        [ForeignKey("City")]
        public int? CityId { get; set; }
        public City? City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? Note { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}

