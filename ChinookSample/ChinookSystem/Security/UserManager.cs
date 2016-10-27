using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.AspNet.Identity.EntityFramework;    // UserStore
using Microsoft.AspNet.Identity;                    // UserManager
using System.ComponentModel;                        // ODS
using ChinookSystem.DAL;                            // DbContext
#endregion

namespace ChinookSystem.Security
{
    [DataObject]
    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager()
            : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
        }

        // Settinh up the default web master (Admin)
        #region Constants
        private const string STR_DEFAULT_PASSWORD = "Pa$$word1"; // minimum strength for password
        private const string STR_USERNAME_FORMAT = "{0}.{1}";
        private const string STR_EMAIL_FORMAT = "{0}@chinook.ca";
        private const string STR_WEBMASTER_USERNAME = "Webmaster";
        #endregion
        public void AddWebmaster()
        {
            if (!Users.Any(u => u.UserName.Equals(STR_WEBMASTER_USERNAME)))
            {
                var webMasterAccount = new ApplicationUser()
                {
                    UserName = STR_WEBMASTER_USERNAME,
                    Email = string.Format(STR_EMAIL_FORMAT, STR_WEBMASTER_USERNAME)
                };
                // This Create command is from the inherited UserManager class
                // This command creates a record on the security Users table (AspNetUsers)
                this.Create(webMasterAccount, STR_DEFAULT_PASSWORD);
                // This AddToRole command is from the inherited UserManager class
                // This command creates a record on the security UserRole table (AspNetUserRoles)
                this.AddToRole(webMasterAccount.Id, SecurityRoles.WebsiteAdmins);
            }
        } //eom

        // Create the CRUD methods for adding a User to the Security Users table
        // Read of data to display on GridView
        // This is a multi-step retrieval from the database:
        //    1. Which Employees are registered
        //        \--> All Employees on file which are NOT registered
        //                \--> Unregistered employees
        //    2. Which Customers are registered
        //        \--> All Customers on file which are NOT registered
        //                \--> Unregistered customers
        //    3. Combine the DataSets to get the data for the GridView;
        //        UnregisteredEmployees.Union(UnregisteredCustomers).ToList()
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<UnregisteredUserProfile> ListAllUnRegisteredUsers()
        {
            using (var context = new ChinookContext())
            {
                // The data needs to be in memory for execution for the next query
                // To accomplish this use .ToList() which will force the query to execute
                // List set containin a List<> of employee ids
                var registeredEmployees = (from emp in Users
                                          where emp.EmployeeId.HasValue
                                          select emp.EmployeeId).ToList();
                // Compare the List set to the user data table Employees
                var unregisteredEmployees = (from emp in context.Employees
                                            where !registeredEmployees.Any(eId => emp.EmployeeId == eId)
                                            select new UnregisteredUserProfile
                                            {
                                                CustomerEmployeeId = emp.EmployeeId,
                                                FirstName = emp.FirstName,
                                                LastName = emp.LastName,
                                                UserType = UnregisteredUserType.Employee
                                            }).ToList();

                // List set containin a List<> of customer ids
                var registeredCustomers = (from cust in Users
                                          where cust.CustomerId.HasValue
                                          select cust.CustomerId).ToList();
                // Compare the List set to the user data table Customers
                var unregisteredCustomers = (from cust in context.Customers
                                            where !registeredCustomers.Any(cId => cust.CustomerId == cId)
                                            select new UnregisteredUserProfile
                                            {
                                                CustomerEmployeeId = cust.CustomerId,
                                                FirstName = cust.FirstName,
                                                LastName = cust.LastName,
                                                UserType = UnregisteredUserType.Customer
                                            }).ToList();
                // Last thing to do is to combine the two physically identcally laid out DataSets
                //   of UnregisteredUserProfile
                return unregisteredEmployees.Union(unregisteredCustomers).ToList();
            }
        } // eom

        // Register a User to the Users table (GridView)
        public void RegisterUser(UnregisteredUserProfile userInfo)
        {
            // Basic information needed for the security user record is
            //   password, email, and username
            // You could randomly generate a password, we will use the default password
            // The instance of the required user is based on our ApplicationUser
            var newUserAccount = new ApplicationUser()
            {
                UserName = userInfo.AssignedUserName,
                Email = userInfo.AssignedEmail
            };

            // Set the CustomerId or EmployeeId
            switch(userInfo.UserType)
            {
                case UnregisteredUserType.Customer:
                    newUserAccount.CustomerId = userInfo.CustomerEmployeeId;
                    break;
                case UnregisteredUserType.Employee:
                    newUserAccount.EmployeeId = userInfo.CustomerEmployeeId;
                    break;
            }

            // Create the actual AspNetUser record
            this.Create(newUserAccount, STR_DEFAULT_PASSWORD);

            // Assign the user to an appropriate role
            // Uses the GUID-like User ID from the Users table
            switch (userInfo.UserType)
            {
                case UnregisteredUserType.Customer:
                    this.AddToRole(newUserAccount.Id, SecurityRoles.RegisteredUsers);
                    break;
                case UnregisteredUserType.Employee:
                    this.AddToRole(newUserAccount.Id, SecurityRoles.Staff);
                    break;
            }
        } //eom

        // Add a user to the Users table (ListView)

        // Delete a user from the Users table (ListView)

    } //eoc
} //eon
