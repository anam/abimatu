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
using System.Collections.Generic;

public partial class AdminFOODITEM_MASTERDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (!User.Identity.IsAuthenticated)
            {
                Session.RemoveAll(); Response.Redirect("LogInPage.aspx");
            }
            else
            {
                reLoadSession();
            }
            loadLocation();
            showFOODITEM_MASTERGrid(ddlLocation.SelectedItem.Value);
        }
    }

    private void loadLocation()
    {

        List<LOCATIONGROUP> lOCATIONs = new List<LOCATIONGROUP>();
        lOCATIONs = LOCATIONGROUPManager.GetAllLOCATIONGROUPsFood();
        foreach (LOCATIONGROUP lOCATION in lOCATIONs)
        {
            ListItem litems = new ListItem(lOCATION.GROUPNAME.ToString(), lOCATION.LOCATIONGROUPID.ToString());
            ddlLocation.Items.Add(litems);
        }
        ddlLocation.DataBind();
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
        Response.Redirect("AdminFOODITEM_MASTERInsertUpdate.aspx?fOODITEM_MASTERID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminFOODITEM_MASTERInsertUpdate.aspx?fOODITEM_MASTERID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = FOODITEM_MASTERManager.DeleteFOODITEM_MASTER(Convert.ToInt32(linkButton.CommandArgument));
        showFOODITEM_MASTERGrid(ddlLocation.SelectedValue);
    }

    private void showFOODITEM_MASTERGrid(string locationGroupID)
    {
        List<FOODITEM_MASTER> foodItemMastertmp = new List<FOODITEM_MASTER>();
        List<FOODITEM_MASTER> foodItemMaster = new List<FOODITEM_MASTER>();
        foodItemMastertmp = FOODITEM_MASTERManager.GetAllFOODITEM_MASTERs();

        for (int i = 0; i < foodItemMastertmp.Count; i++)
        {
            if (foodItemMastertmp[i].SEQ.ToString() == locationGroupID)
            {
                foodItemMaster.Add(foodItemMastertmp[i]);
            }
        }

        gvFOODITEM_MASTER.DataSource = foodItemMaster;
        gvFOODITEM_MASTER.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        showFOODITEM_MASTERGrid(ddlLocation.SelectedValue);
    }
}
