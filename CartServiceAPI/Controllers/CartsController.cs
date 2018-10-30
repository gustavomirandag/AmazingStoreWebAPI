using CartServiceAPI.Models;
using CartServiceAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CartServiceAPI.Controllers
{
    public class CartsController : ApiController
    {
        private CartService _cartService = new CartService();

        // GET: api/Carts
        public IEnumerable<Cart> Get()
        {
            return _cartService.GetCarts();
        }

        // GET: api/Carts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Carts
        public void Post([FromBody]Cart cart)
        {
            _cartService.AddCart(cart);
        }

        // PUT: api/Carts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Carts/5
        public void Delete(int id)
        {
        }
    }
}
