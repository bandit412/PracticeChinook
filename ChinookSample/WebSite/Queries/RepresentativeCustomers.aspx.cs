using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Queries_RepresentativeCustomers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Are you logged in?
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            // These lines are commented out as an authenticated user can access this page
            //else
            //{
            //    // Are you allowed to be on this page?
            //    if (!User.IsInRole(SecurityRoles.WebsiteAdmins))
            //    {
            //        Response.Redirect("~/Default.aspx");
            //    }
            //}
        }
    }
}