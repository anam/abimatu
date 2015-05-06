using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class AdminLOCATION_AGENT_RATEInsertUpdate : System.Web.UI.Page
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

            loadLOCATION();
            loadAGENT();
            if (Request.QueryString["lOCATION_AGENT_RATEID"] != null)
            {
                int lOCATION_AGENT_RATEID = Int32.Parse(Request.QueryString["lOCATION_AGENT_RATEID"]);
                if (lOCATION_AGENT_RATEID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showLOCATION_AGENT_RATEData();
                }
            }
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
        LOCATION_AGENT_RATE lOCATION_AGENT_RATE = new LOCATION_AGENT_RATE();

        lOCATION_AGENT_RATE.LOCATIONID = Int32.Parse(ddlLOCATION.SelectedValue);
        lOCATION_AGENT_RATE.AGENTID = Int32.Parse(ddlAGENT.SelectedValue);
        lOCATION_AGENT_RATE.RATE = Decimal.Parse(txtRATE.Text);
        int resutl = LOCATION_AGENT_RATEManager.InsertLOCATION_AGENT_RATE(lOCATION_AGENT_RATE);
        Response.Redirect("AdminLOCATION_AGENT_RATEDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        LOCATION_AGENT_RATE lOCATION_AGENT_RATE = new LOCATION_AGENT_RATE();
        lOCATION_AGENT_RATE = LOCATION_AGENT_RATEManager.GetLOCATION_AGENT_RATEByID(Int32.Parse(Request.QueryString["lOCATION_AGENT_RATEID"]));
        LOCATION_AGENT_RATE tempLOCATION_AGENT_RATE = new LOCATION_AGENT_RATE();
        tempLOCATION_AGENT_RATE.LOCATION_AGENT_RATEID = lOCATION_AGENT_RATE.LOCATION_AGENT_RATEID;

        tempLOCATION_AGENT_RATE.LOCATIONID = Int32.Parse(ddlLOCATION.SelectedValue);
        tempLOCATION_AGENT_RATE.AGENTID = Int32.Parse(ddlAGENT.SelectedValue);
        tempLOCATION_AGENT_RATE.RATE = Decimal.Parse(txtRATE.Text);
        bool result = LOCATION_AGENT_RATEManager.UpdateLOCATION_AGENT_RATE(tempLOCATION_AGENT_RATE);
        Response.Redirect("AdminLOCATION_AGENT_RATEDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlLOCATION.SelectedIndex = 0;
        ddlAGENT.SelectedIndex = 0;
        txtRATE.Text = "";
    }
    private void showLOCATION_AGENT_RATEData()
    {
        LOCATION_AGENT_RATE lOCATION_AGENT_RATE = new LOCATION_AGENT_RATE();
        lOCATION_AGENT_RATE = LOCATION_AGENT_RATEManager.GetLOCATION_AGENT_RATEByID(Int32.Parse(Request.QueryString["lOCATION_AGENT_RATEID"]));

        ddlLOCATION.SelectedValue = lOCATION_AGENT_RATE.LOCATIONID.ToString();
        ddlAGENT.SelectedValue = lOCATION_AGENT_RATE.AGENTID.ToString();
        txtRATE.Text = lOCATION_AGENT_RATE.RATE.ToString();
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
    private void loadAGENT()
    {
        ListItem li = new ListItem("Select AGENT...", "0");
        ddlAGENT.Items.Add(li);

        List<AGENT> aGENTs = new List<AGENT>();
        aGENTs = AGENTManager.GetAllAGENTs();
        foreach (AGENT aGENT in aGENTs)
        {
            ListItem item = new ListItem(aGENT.AGENTNAME.ToString(), aGENT.AGENTID.ToString());
            ddlAGENT.Items.Add(item);
        }
    }
}
