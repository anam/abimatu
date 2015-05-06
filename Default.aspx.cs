using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
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

    private void loadLogin()
    {
        if (User.Identity.IsAuthenticated && Session["userType"] != null && (Session["aGENT"] != null || Session["lOCATION"] != null))
        {
            if (Session["userType"].ToString() == "Location")
            {
                LOCATIONGROUP lOCATIONGROUP = new LOCATIONGROUP();
                lOCATIONGROUP = (LOCATIONGROUP)Session["lOCATION"];
                a_locationReport.Visible = true;
                a_transferMoney.Visible = false;
                a_foodItems.Visible = false;
                a_editTransfer.Visible = true;
                a_dailyReport.Visible = false;
                //a_dailyReport.HRef = "ReportLocationWiseDaily.aspx";

                a_compliance.Visible = false;
                a_agentWiseReport.Visible = false;
                a_agentCommReport.Visible = false;
                a_administrator.Visible = false;
                
            }
            else
            {

                AGENT aGENT = new AGENT();
                aGENT = (AGENT)Session["aGENT"];

                if (aGENT.AGENTID == 4) //for admin
                {
                    //a_transferMoney.Visible = false;
                    //a_dailyReport.HRef = "ReportAgentWiseDaily.aspx";
                }
                else
                {
                    a_transferMoney.Visible = true;
                    a_locationReport.Visible = true;
                    a_foodItems.Visible = true;
                    a_editTransfer.Visible = true;
                    a_dailyReport.Visible = true;
                    //a_dailyReport.HRef = "ReportLocationWiseDaily.aspx";

                    a_compliance.Visible = false;
                    a_agentWiseReport.Visible = false;
                    a_agentCommReport.Visible = false;
                    a_administrator.Visible = false;
                }
            }
        }
        else
        {
            Session.RemoveAll(); Response.Redirect("LogInPage.aspx"); 
        }
    }


    protected void btnExit_Click(object sender, EventArgs e)
    {

    }
}