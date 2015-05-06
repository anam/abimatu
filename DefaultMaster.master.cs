using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class DefaultMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadLogin();
        }  
    }

   
    private void loadLogin()
    {
        if (Session["userType"] != null && (Session["aGENT"] != null || Session["lOCATION"] != null))
        {
            if (Session["userType"].ToString() == "Location")
            {
                LOCATIONGROUP lOCATIONGROUP = new LOCATIONGROUP();
                lOCATIONGROUP = (LOCATIONGROUP)Session["lOCATION"];
                lblAgentName.Text = lOCATIONGROUP.GROUPNAME.ToString();
            }
            else
            {
                AGENT aGENT = new AGENT();
                aGENT = (AGENT)Session["aGENT"];
                lblAgentName.Text = aGENT.AGENTNAME.ToString();
            }
        }
        else
        {
            Session.RemoveAll(); Response.Redirect("LogInPage.aspx"); 
        }
    }
}
