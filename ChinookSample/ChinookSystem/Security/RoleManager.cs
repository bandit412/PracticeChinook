using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.AspNet.Identity;                    // RoleManager
using Microsoft.AspNet.Identity.EntityFramework;    // IdentityRole, RoleStore
using System.ComponentModel;                        // Needed for ObjectDataSource
#endregion

namespace ChinookSystem.Security
{
    [DataObject]
    public class RoleManager : RoleManager<IdentityRole>
    {
        public RoleManager() : base (new RoleStore<IdentityRole>(new ApplicationDbContext()))
        {

        }

        // This method will be executed when the application starts up under IIS
        public void AddStartupRoles()
        {
            foreach(string roleName in SecurityRoles.StartupSecurityRoles)
            {
                // Check if the role already exists in the Security tables located
                //  in the database
                if(!Roles.Any(r => r.Name.Equals(roleName)))
                {
                    // Role is not currently on the database
                    this.Create(new IdentityRole(roleName));
                }
            }
        } // eom

        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<RoleProfile> ListAllRoles()
        {
            var um = new UserManager();
            // The data from Roles needs to be in memory
            //   for use by the query --> use .ToList()
            var results = from role in Roles.ToList()
                          select new RoleProfile
                          {
                              RoleId = role.Id,         // Security table
                              RoleName = role.Name,     // Security table
                              UserNames = role.Users.Select(r => um.FindById(r.UserId).UserName)
                          };
            return results.ToList();
        } // eom

        [DataObjectMethod(DataObjectMethodType.Insert,true)]
        public void AddRole(RoleProfile role)
        {
            // Any business rules to consider?
            // Yes, the new role should not already exit on the Roles table
            if(!this.RoleExists(role.RoleName))
            {
                this.Create(new IdentityRole(role.RoleName));
            }
        } //eom

        [DataObjectMethod(DataObjectMethodType.Delete,true)]
        public void RemoveRole(RoleProfile role)
        {
            this.Delete(this.FindById(role.RoleId));
        } // eom

        // This method will produce a list of all roles (RoleName)
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<string> ListAllRoleNames()
        {
            return this.Roles.Select(r => r.Name).ToList();
        } //eom

    } //eoc
} //eon
