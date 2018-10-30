using ConsoleApp.DTO;
using ConsoleApp.Models;
using ConsoleApp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = -1;

            do
            {
                Console.WriteLine("1 - Add Product");
                Console.WriteLine("2 - List Products Catalog");
                Console.WriteLine("3 - Add All Catalog Products to Cart");
                Console.WriteLine("4 - Exit");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddProduct();
                        Console.WriteLine();
                        break;
                    case 2:
                        ListCatalog(true);
                        Console.WriteLine();
                        break;
                    case 3:
                        AddAllCatalogProductsToCart();
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            } while (option != 4);


        }

        private static void AddProduct()
        {
            Product product = new Product()
            {
                Id = Guid.NewGuid()
            };
            Console.WriteLine("Type product title");
            product.Title = Console.ReadLine();
            Console.WriteLine("Type product description");
            product.Description = Console.ReadLine();
            Console.WriteLine("Type product price");
            product.Price = Decimal.Parse(Console.ReadLine());

            //=== Acesso o CatalogServiceAPI ===
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:58939/");
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //HTTP Post 
            Task<HttpResponseMessage> response = client.PostAsJsonAsync("api/products", product);
            //=======================================
        }

        private static IEnumerable<ProductView> ListCatalog(bool print)
        {
            //=== Acesso o CatalogServiceAPI ===
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59879/");
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //HTTP Get
            Task<HttpResponseMessage> response2 = client.GetAsync("api/products");
            Task<IEnumerable<ProductView>> taskProducts = response2.Result.Content.ReadAsAsync<IEnumerable<ProductView>>();
            IEnumerable<ProductView> products = taskProducts.Result;

            if (print)
            {
                Console.WriteLine("Catalog Service (List ProductView)");
                foreach (var product in products)
                    Console.WriteLine($"{product.Title} - {product.Price}");
            }

            return products;
            //=======================================
        }

        private static void AddAllCatalogProductsToCart()
        {
            var products = ListCatalog(false);

            Cart cart = new Cart();
            cart.Id = Guid.NewGuid();
            cart.Items = new List<CartItem>();
            foreach(var product in products)
            {
                cart.Items.Add(new CartItem
                {
                    ProductId = product.Id,
                    Title = product.Title,
                    Price = product.Price,
                    Quantity = 1
                });
            }



            //=== Acesso o CartServiceAPI ===
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64918/");
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //HTTP Post 
            Task<HttpResponseMessage> response = client.PostAsJsonAsync("api/carts", cart);
            response.Wait();
            //=======================================


            //HTTP Get
            Task<HttpResponseMessage> response2 = client.GetAsync("api/carts");
            Task<IEnumerable<Cart>> taskProducts = response2.Result.Content.ReadAsAsync<IEnumerable<Cart>>();
            IEnumerable<Cart> carts = taskProducts.Result;

            foreach(var c in carts)
            {
                Console.WriteLine($"Cart {c.Id}:");
                foreach (var item in c.Items)
                    Console.WriteLine($" - {item.Title} - R${item.Price}");
            }
                

        }
    }
}
