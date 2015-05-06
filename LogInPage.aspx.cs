using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class LogInPage : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //LoadAgent();
        }
    }


    private void LoadAgent()
    {
        ListItem li = new ListItem("-Select-", "0");
        ddlAgent.Items.Add(li);
        
        List<AGENT> aGENTs = new List<AGENT>();
        aGENTs = AGENTManager.GetAllAGENTs();

        foreach (AGENT aGENT in aGENTs)
        {
            ListItem litems = new ListItem(aGENT.AGENTNAME.ToString(), aGENT.AGENTID.ToString());
            ddlAgent.Items.Add(litems);
        }
        ddlAgent.DataBind();
    }


    protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
    {      

        lblMessage.Text = "";
        e.Authenticated = false;
        Login masterLogin = (Login)masterview.FindControl("masterLogin");
        string userName = masterLogin.UserName.ToString();
        string password = masterLogin.Password.ToString();

        //if (Membership.ValidateUser(userName, password) && (userName.Equals("admin")))
        //{
        //    masterLogin.DestinationPageUrl = "Default.aspx";
        //    Session["role"] = "Admin";
        //    e.Authenticated = true;

        //}
        //else
        //{
        if (Membership.ValidateUser(userName, password))
        {
            USERINFO userInfo = new USERINFO();
            userInfo = USERINFOManager.GetUSERINFOByUserNameType("Agent", userName);//"Agent" is dami in database i have not use the
                
            if (userInfo != null)
            {
                Session["userType"] = userInfo.Type.ToString();
                Session["userInfoID"] = userInfo.USERINFOID.ToString();
                Session["userName"] = userInfo.UserName.ToString();
                e.Authenticated = true;

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

                //Response.Redirect("Default.aspx");
                masterLogin.DestinationPageUrl = "~/Default.aspx";
            }
            else
            {
                lblMessage.Text = "Password incorrect!!!";
            }
        }
        else
        {
            //Response.Redirect("~/Forgetpassword.aspx");
        }
        //}

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
}