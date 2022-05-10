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
        const string BASE_URL = "https://omnic-systems.com/verleihsystem/";
        const string GET = "get/";
        const string PUSH = "push/";

        private List<Task> tasks = new();

        public List<CustomerDto> GetAllCustomers()
        {
            var result = CallApi($"{BASE_URL}{GET}kunde.php");
            var list = JsonSerializer.Deserialize<List<CustomerDto>>(result);
            Console.WriteLine(result);
            return list;
        }

        public List<EmployeeDto> GetAllEmployees()
        {
            var result = CallApi($"{BASE_URL}{GET}mitarbeiter.php");
            var list = JsonSerializer.Deserialize<List<EmployeeDto>>(result);
            Console.WriteLine(result);
            return list;
        }

        public List<ProductDto> GetAllProducts()
        {
            var result = CallApi($"{BASE_URL}{GET}produkt.php");
            var list = JsonSerializer.Deserialize<List<ProductDto>>(result);
            Console.WriteLine(result);
            return list;
        }

        public List<CategoryDto> GetAllCategories()
        {
            var result = CallApi($"{BASE_URL}{GET}kategorie.php");
            var list = JsonSerializer.Deserialize<List<CategoryDto>>(result);
            Console.WriteLine(result);
            return list;
        }

        public string CallApi(string url)
        {
            List<string> response = new();
            using (var client = new HttpClient())
            { 
                return client.GetStringAsync(url).Result;
            }
        }
    }
}
