using CatalogServiceAPI.Models;
using CatalogServiceAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CatalogServiceAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private CatalogService _catalogService = new CatalogService();

        // GET: api/Products
        public IEnumerable<ProductView> Get()
        {
            return _catalogService.GetProducts();
        }

        // GET: api/Products/5
        public ProductView Get(Guid id)
        {
            return _catalogService.GetProduct(id);
        }

        // POST: api/Products
        public void Post([FromBody]ProductView product)
        {
            _catalogService.AddProduct(product);
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
