using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.AspNet.Identity; //RoleManager
using Microsoft.AspNet.Identity.EntityFramework; // IdentityRole, RoleStore
#endregion

namespace ChinookSystem.Security
{
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
        }
    }
}
