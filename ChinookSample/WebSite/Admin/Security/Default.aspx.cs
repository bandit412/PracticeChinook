using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

# region Security Namespace
using ChinookSystem.Security;
#endregion

public partial class Admin_Security_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RefreshAll(object sender, EventArgs e)
    {
        DataBind();
    }

    protected void UnregisteredUsersGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        // Position the GridView to the selected index (row) that caused the PostBack
        UnregisteredUsersGridView.SelectedIndex = e.NewSelectedIndex;

        // Set up a variable that will be the physical pointer to the selected row
        GridViewRow gvRow = UnregisteredUsersGridView.SelectedRow;

        // You can always check a pointer to see if something has been obtained
        if(gvRow != null)
        {
            // Access information contained in a TextBox on the GridView row
            // Use the method .FindControl("ControlID_Name") as control type
            // Once you have a pointer to the control, you can access the data
            //   data content of the control using the control's access method

            // The long way
            string assignedUserName = "";
            TextBox inputControl = gvRow.FindControl("AssignedUserName") as TextBox;
            if(inputControl != null)
            {
                assignedUserName = inputControl.Text;
            }

            // The short way: If you trust that your control is there
            string assignedEmail = (gvRow.FindControl("AssignedEmail") as TextBox).Text;

            // Create the UnregisteredUser instance
            // During creation I will pass the needed data to load the instance attributes

            // Accessing BoundFields on a GridView row uses .Cells[index].Text,
            //   where index represents the column of the GridView. Columns are indexed
            //   therefore they start at 0
            UnregisteredUserProfile user = new UnregisteredUserProfile()
            {
                CustomerEmployeeId = int.Parse(UnregisteredUsersGridView.SelectedDataKey.Value.ToString()),
                UserType = (UnregisteredUserType)Enum.Parse(typeof(UnregisteredUserType), gvRow.Cells[1].Text),
                FirstName = gvRow.Cells[2].Text,
                LastName = gvRow.Cells[3].Text,
                AssignedUserName = assignedUserName,
                AssignedEmail = assignedEmail
            };

            // Register the user via the Chinook.UserManager controller
            UserManager sysManager = new UserManager();
            sysManager.RegisterUser(user);

            // Assume successful creation of a User
            // Refresh the form
            DataBind();
        }
    }

    protected void UserListView_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        // One needs to manually walk through the CheckBoxList

        // Create the RoleMembership string List of selected Roles
        var addToRoles = new List<string>();

        // Pointt the phusical CheckBoxList control
        var roles = e.Item.FindControl("RoleMemberships") as CheckBoxList;

        // Does the control exist? (safety check)
        if(roles != null)
        {
            // Cycle through the CheckBoxList find which roles that have been selected (Checked)
            //   add to the List<string> and assign the List<string> to the inserting
            //   instnace represented by e
            foreach(ListItem role in roles.Items)
            {
                if(role.Selected)
                {
                    addToRoles.Add(role.Value);
                }
                e.Values["RoleMemberships"] = addToRoles;
            }
        }
    }
}