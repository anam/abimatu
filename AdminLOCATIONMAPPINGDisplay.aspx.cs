using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class AdminLOCATIONMAPPINGDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Redirect("AdminLOCATIONMAPPINGInsertUpdate.aspx?lOCATIONMAPPINGID=0");

            if (!User.Identity.IsAuthenticated)
            {
                Session.RemoveAll(); Response.Redirect("LogInPage.aspx");
            }
            else
            {
                reLoadSession();
            }
            showLOCATIONMAPPINGGrid();
        }
    }

    private void reLoadSession()
    {
        if (Session["userType"] == null || Session["aGENT"] != null || Session["lOCATION"] != null)
        {
            USERINFO userInfo = new USERINFO();
            userInfo = USERINFOManager.GetUSERINFOByUserNameType("Agent", User.Identity.Name);//"Agent" is dami in database i have not use the

            if (userInfo != null)
            {
                Session["userType"] = userInfo.Type.ToString();
                Session["userInfoID"] = userInfo.USERINFOID.ToString();
                Session["userName"] = userInfo.UserName.ToString();

                //if (userInfo.Agent_LocationID.ToString() == ddlAgent.SelectedItem.Value.ToString())
                if (userInfo.Type == "Agent")
                {
                    Session["aGENT"] = AGENTManager.GetAGENTByID(userInfo.Agent_LocationID);
                    Session["role"] = "Agent";
                }
                else if (userInfo.Type == "Location")
                {
                    Session["lOCATION"] = LOCATIONGROUPManager.GetLOCATIONGROUPByID(userInfo.Agent_LocationID);
                    Session["role"] = "Location";
                }

            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminLOCATIONMAPPINGInsertUpdate.aspx?lOCATIONMAPPINGID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminLOCATIONMAPPINGInsertUpdate.aspx?lOCATIONMAPPINGID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = LOCATIONMAPPINGManager.DeleteLOCATIONMAPPING(Convert.ToInt32(linkButton.CommandArgument));
        showLOCATIONMAPPINGGrid();
    }

    private void showLOCATIONMAPPINGGrid()
    {
        gvLOCATIONMAPPING.DataSource = LOCATIONMAPPINGManager.GetAllLOCATIONMAPPINGs();
        gvLOCATIONMAPPING.DataBind();
        foreach(GridViewRow gvr in gvLOCATIONMAPPING.Rows)
        {
            Label lblLOCATIONID=gvr.FindControl("lblLOCATIONID") as Label;
            Label lblLOCATIONGROUPID = gvr.FindControl("lblLOCATIONGROUPID") as Label;

            LOCATION location = LOCATIONManager.GetLOCATIONByID(int.Parse(lblLOCATIONID.Text));
            if (location != null)
            {
                lblLOCATIONID.Text = location.COUNTRY + ", " + location.CITY + ", " + location.BRANCH;
            }

            LOCATIONGROUP locationGroup = LOCATIONGROUPManager.GetLOCATIONGROUPByID(int.Parse(lblLOCATIONGROUPID.Text));
            if (locationGroup != null)
            {
                lblLOCATIONGROUPID.Text = locationGroup.GROUPNAME;
            }
        }
    }
}
