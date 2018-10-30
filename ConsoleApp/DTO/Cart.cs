using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleApp.Models.DTO
{
    public class Cart
    {
        public Guid Id { get; set; } //CartId
        public Guid ClientId { get; set; }
        public List<CartItem> Items { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
        }
    }
}