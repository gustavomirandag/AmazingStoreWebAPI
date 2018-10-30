using ProductServiceAPI.Models;
using ProductServiceAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ProductServiceAPI.Services
{
    public class ProductService
    {
        private static List<Product> _products = new List<Product>();

        public void AddProduct(Product product)
        {
            _products.Add(product);

            //=== Acesso o CatalogServiceAPI ===
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59879/");
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //Prepare the DTO
            ProductView productView = new ProductView()
            {
                Id = product.Id,
                Title = product.Title,
                Photo = product.Photo,
                Price = product.Price
            };

            //HTTP Post 
            Task<HttpResponseMessage> response = client.PostAsJsonAsync("api/products", productView);
            if (!response.Result.IsSuccessStatusCode)
                throw new Exception(response.Result.StatusCode.ToString());
            //=======================================
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public Product GetProduct(Guid id)
        {
            return _products.SingleOrDefault(p => p.Id == id);
        }


    }
}