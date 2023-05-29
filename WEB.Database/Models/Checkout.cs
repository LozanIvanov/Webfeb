﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB.Database.Models
{
    public class Checkout
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobilNumber { get; set; }
       
        public string Address { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime? DateTime { get; set; }
        public int? CartItemId { get; set; }
        public CartItem CartItem { get; set; }
        
    }
}
