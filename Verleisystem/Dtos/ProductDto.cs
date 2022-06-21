using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verleihsystem.Dtos
{
    public class ProductDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string kategorie { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
