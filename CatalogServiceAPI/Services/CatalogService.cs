using CatalogServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogServiceAPI.Services
{
    public class CatalogService
    {
        private static List<ProductView> _products = new List<ProductView>();

        public void AddProduct(ProductView product)
        {
            _products.Add(product);
        }

        public IEnumerable<ProductView> GetProducts()
        {
            return _products;
        }

        public ProductView GetProduct(Guid id)
        {
            return _products.SingleOrDefault(p => p.Id == id);
        }
    }
}