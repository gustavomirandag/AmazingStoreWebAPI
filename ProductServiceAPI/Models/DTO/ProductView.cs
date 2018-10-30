using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductServiceAPI.Models.DTO
{
    public class ProductView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public Decimal Price { get; set; }
    }
}