using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.Security
{
    public enum UnregisteredUserType
    {
        Undefined, Employee, Customer
    }

    public class UnregisteredUserProfile
    {
        public int UserId { get; set; } // generated when a user is added
        public string UserName { get; set; } // collected
        public string Email { get; set; } // collected
        public string FirstName { get; set; } // comes from User table
        public string LastName { get; set; } // comes from User table
        public UnregisteredUserType UserType { get; set; }
    }
}
