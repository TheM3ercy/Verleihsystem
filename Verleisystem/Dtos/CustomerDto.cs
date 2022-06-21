using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verleihsystem.Dtos
{
    public class CustomerDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string tel { get; set; }
        public string email { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
