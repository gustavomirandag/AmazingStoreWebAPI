using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductServiceAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}