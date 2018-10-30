using ProductServiceAPI.Models;
using ProductServiceAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductServiceAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductService _productService = new ProductService();

        // GET: api/Products
        public IEnumerable<Product> Get()
        {
            return _productService.GetProducts();
        }

        // GET: api/Products/5
        public Product Get(Guid id)
        {
            return _productService.GetProduct(id);
        }

        // POST: api/Products
        public void Post([FromBody]Product product)
        {
            _productService.AddProduct(product);
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
