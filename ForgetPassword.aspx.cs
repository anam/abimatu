using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class ForgetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        string userPassword = string.Empty;
        string userEmail = string.Empty;
        MembershipUser user = Membership.GetUser(txtUserName.Text);
        try
        {
            //lblPassword.Text = Membership.Provider.GetPassword(txtUserName.Text, txtAnswer.Text);
            userPassword = Membership.Provider.GetPassword(txtUserName.Text, txtAnswer.Text);
            userEmail = user.Email.ToString();

            lblPassword.Text = userEmail.ToString();
            string body = "";

            body += "<h2>AbiMatu Password Recovery</h2>";
            body += "User Name :<b>" + txtUserName.Text + "</b><br/>";
            body += "Password : <b>" + userPassword + "</b><br/>";
            Sendmail.sendEmail("Admin@AbiMatu.com", "", userEmail.ToString(), "", "Password From AbiMatu", body, "soft.mavrick@gmail.com", "mavs123456");
            panForgetPassword.Visible = false;
            panPassword.Visible = true;
            panError.Visible = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            panError.Visible = true;
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
    protected void btnReset_OnClick(object sender, EventArgs e)
    {
        txtUserName.Text = "";
        txtAnswer.Text = "";
        panError.Visible = false;
        lblError.Visible = false;
        panPassword.Visible = false;
    }
}