using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        public void GetCustomers()
        {
            var result = CallApi($"{BASE_URL}{GET}kunden.php");
            result.ForEach(x => Console.WriteLine(x));
        }

        public void GetEmployee()
        {
            var result = CallApi($"{BASE_URL}{GET}mitarbeiter.php?username=test&password=test");
            result.ForEach(x => Console.WriteLine(x));
        }

        public void GetProduct()
        {
            var result = CallApi($"{BASE_URL}{GET}product.php");
            result.ForEach(x => Console.WriteLine(x));
        }

        public void GetCategories()
        {
            var result = CallApi($"{BASE_URL}{GET}kategorie.php");
            result.ForEach(x => Console.WriteLine(x));
        }

        public List<string> CallApi(string url)
        {
            List<string> response = new();
            using (var client = new HttpClient())
            { 
                response.Add(client.GetStringAsync(url).Result);
            }
            return response;
        }
    }
}
