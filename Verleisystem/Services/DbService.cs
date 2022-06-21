using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Verleihsystem.Dtos;

namespace Verleihsystem.Services
{
    public class DbService
    {
        private const string BASE_URL = "https://omnic-systems.com/verleihsystem/";
        private const string GET = "get/";
        private const string POST = "post/";
        private const string PUSH = "push/";

        private static readonly HttpClient client = new HttpClient();

        public List<CustomerDto> GetAllCustomers()
        {
            var result = CallApiGet($"{BASE_URL}{GET}kunde.php");
            var list = JsonSerializer.Deserialize<List<CustomerDto>>(result);
            Console.WriteLine(result);
            return list;
        }

        public List<EmployeeDto> GetAllEmployees()
        {
            var result = CallApiGet($"{BASE_URL}{GET}mitarbeiter.php");
            var list = JsonSerializer.Deserialize<List<EmployeeDto>>(result);
            Console.WriteLine(result);
            return list;
        }

        public List<ProductDto> GetAllProducts()
        {
            var result = CallApiGet($"{BASE_URL}{GET}produkt.php");
            var list = JsonSerializer.Deserialize<List<ProductDto>>(result);
            Console.WriteLine(result);
            return list;
        }

        public List<CategoryDto> GetAllCategories()
        {
            var result = CallApiGet($"{BASE_URL}{GET}kategorie.php");
            var list = JsonSerializer.Deserialize<List<CategoryDto>>(result);
            Console.WriteLine(result);
            return list;
        }

        public List<LeaseDto> GetAllLeasedProducts()
        {
            var result = CallApiGet($"{BASE_URL}{GET}ausgelieheneProdukte.php");
            var list = JsonSerializer.Deserialize<List<LeaseDto>>(result);
            Console.WriteLine(result);
            return list;
        }

        public string PostCustomer(CustomerDto customer)
        {
            var result = CallApiPost($"{BASE_URL}{POST}customer.php", 
                new Dictionary<string, string> { 
                    { "id", customer.id},
                    { "name", customer.name},
                    { "email", customer.email },
                    { "tel", customer.tel },
                });
            return result;
        }

        public string PostEmployee(EmployeeDto employee)
        {
            var result = CallApiPost($"{BASE_URL}{POST}mitarbeiter.php",
                new Dictionary<string, string> {
                    { "id", employee.id},
                    { "username", employee.username},
                });
            return result;
        }

        public string PostProduct(ProductDto product)
        {
            var result = CallApiPost($"{BASE_URL}{POST}produkt.php",
                new Dictionary<string, string> {
                    { "id", product.id},
                    { "name", product.name},
                    { "kategorie", product.kategorie},
                    { "code", product.code },
                });
            return result;
        }

        public string PostCategory(CategoryDto category)
        {
            var result = CallApiPost($"{BASE_URL}{POST}kategorie.php",
                new Dictionary<string, string> {
                    { "id", category.id},
                    { "name", category.name},
                    { "beschreibung", category.beschreibung},
                });
            return result;
        }

        public string PostLeasedProduct(string productid, string customerid)
        {
            var result = CallApiLease($"{BASE_URL}{POST}ausgelieheneProdukte.php",
                new Dictionary<string, string> {
                    { "kunden_id", customerid },
                    { "produkt_id", productid },
                });
            return result;
        }

        public string CallApiGet(string url)
        {
            List<string> response = new();
            return client.GetStringAsync(url).Result;
        }

        public string CallApiPost(string url, IEnumerable<KeyValuePair<string, string>> content)
        {
            var body = new FormUrlEncodedContent(content);
            return client.PostAsync(url, body).Result.Content.ToString();
        }

        public string CallApiLease(string url, IEnumerable<KeyValuePair<string, string>> content)
        {
            var body = new FormUrlEncodedContent(content);
            return client.PostAsync(url, body).Result.StatusCode.ToString();
        }
    }
}
