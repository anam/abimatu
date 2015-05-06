using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
public partial class LogOutPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            //lblMessage.Text = User.Identity.Name.ToString();
            Session.Abandon();
            FormsAuthentication.SignOut();
            //form

            Response.Redirect("LogInPage.aspx");
        }
    }
}