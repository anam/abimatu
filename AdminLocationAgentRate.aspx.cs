using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminLocationAgentRate : System.Web.UI.Page
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

            loadLogin();
            loadLOCATION();
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

    /// <summary>
    /// This function for the admin login checking as this part only for the admin
    /// </summary>
    private void loadLogin()
    {
        if (User.Identity.IsAuthenticated && Session["userType"] != null && Session["aGENT"] != null)
        {
            AGENT aGENT = new AGENT();
            aGENT = (AGENT)Session["aGENT"];

            if (aGENT.AGENTID != 4 && Session["userType"].ToString() == "Agent") //for admin
            {
                Session.RemoveAll(); Response.Redirect("LogInPage.aspx"); 
            }
        }
        else
        {
            Session.RemoveAll(); Response.Redirect("LogInPage.aspx"); 
        }
    }

    private void loadLOCATION()
    {
        ListItem li = new ListItem("Select LOCATION...", "0");
        ddlLOCATION.Items.Add(li);

        List<LOCATION> lOCATIONs = new List<LOCATION>();
        lOCATIONs = LOCATIONManager.GetAllLOCATIONs();
        foreach (LOCATION lOCATION in lOCATIONs)
        {
            ListItem item = new ListItem(lOCATION.BRANCH.ToString(), lOCATION.LOCATIONID.ToString());
            ddlLOCATION.Items.Add(item);
        }
    }
    protected void ddlLOCATION_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLOCATION.SelectedValue != "0")
        {
            List<LOCATION_AGENT_RATE> locationAgentRate = new List<LOCATION_AGENT_RATE>();

            locationAgentRate = LOCATION_AGENT_RATEManager.GetAllLOCATION_AGENT_RATEsLOCATIONID(int.Parse(ddlLOCATION.SelectedValue));

            gvAgentRate.DataSource = locationAgentRate;
            gvAgentRate.DataBind();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        LOCATION_AGENT_RATE locationAgentRate = new LOCATION_AGENT_RATE();

        foreach (GridViewRow gr in gvAgentRate.Rows)
        {
            Label lblLOCATION_AGENT_RATEID = (Label)gr.FindControl("lblLOCATION_AGENT_RATEID");
            Label lblAGENTID = (Label)gr.FindControl("lblAGENTID");
            TextBox txtRATE = (TextBox)gr.FindControl("txtRATE");

            locationAgentRate.AGENTID = int.Parse(lblAGENTID.Text);
            locationAgentRate.LOCATION_AGENT_RATEID = int.Parse(lblLOCATION_AGENT_RATEID.Text);
            locationAgentRate.LOCATIONID = int.Parse(ddlLOCATION.SelectedValue);
            locationAgentRate.RATE = decimal.Parse(txtRATE.Text);

            LOCATION_AGENT_RATEManager.UpdateLOCATION_AGENT_RATE(locationAgentRate);
        }
    }
}