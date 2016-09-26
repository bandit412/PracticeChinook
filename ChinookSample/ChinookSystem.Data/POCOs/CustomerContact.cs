using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This is a plain class so no need to add addtional Namespaces

namespace ChinookSystem.Data.POCOs
{
    public class CustomerContact
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
