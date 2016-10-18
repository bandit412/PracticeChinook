using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.Security
{
    public class UserProfile
    {
        public string UserId { get; set; }            // AspNetUsers
        public string UserName { get; set; }          // AspNetUsers
        public int? EmployeeId { get; set; }          // AspNetUsers
        public int? CustomerId { get; set; }          // AspNetUsers
        public string FirstName { get; set; }         // Employees or Customers table
        public string LastName { get; set; }          // Employees or Customers table
        public string Email { get; set; }             // AspNetUsers
        public string EmailConfirmation { get; set; } // AspNetUsers
        public IEnumerable<string> RoleMemberships { get; set; }
    }
}
