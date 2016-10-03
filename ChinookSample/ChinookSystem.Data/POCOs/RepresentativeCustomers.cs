using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.Data.POCOs
{
    public class RepresentativeCustomers
    {
        public string Name { get; set; }//= x.LastName + ", " + x.FirstName,
        public string City { get; set; }//= x.City,
        public string State { get; set; }//= x.State,
        public string Phone { get; set; }//= x.Phone,
        public string Email { get; set;}//= x.Email
    }
}
