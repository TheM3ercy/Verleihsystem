using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verleihsystem.Dtos
{
    public class LeaseDto
    {
        public string id { get; set; }
        public string kunden_id { get; set; }
        public string produkt_id { get; set; }
    }
}
