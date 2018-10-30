using CartServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CartServiceAPI.Services
{
    public class CartService
    {
        private static List<Cart> _carts = new List<Cart>();

        public void AddCart(Cart cart)
        {
            _carts.Add(cart);
        }
        
        public IEnumerable<Cart> GetCarts()
        {
            return _carts;
        }
    }
}