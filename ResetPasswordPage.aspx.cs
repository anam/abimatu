using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class ResetPasswordPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //panForgetPassword.Visible = true;
            //panPassword.Visible = false;
            //panError.Visible = false;

        }
    }
    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        string userName = txtUserName.Text;
        string password = txtOldPassword.Text;
        string newPassword = txtNewPassword.Text;



        if (Membership.ValidateUser(userName, password))
        {
            panForgetPassword.Visible = false;
            panPassword.Visible = true;
            panError.Visible = false;




            MembershipUser mu = Membership.GetUser(userName);
            mu.ChangePassword(mu.ResetPassword(), newPassword);




            lblPassword.Text = "Your Password has been Changed";
        }
        else
        {
            panForgetPassword.Visible = true;
            panError.Visible = true;
            lblError.Text = "Please Select valid UserName/Password";
        }
    }
    protected void btnReset_OnClick(object sender, EventArgs e)
    {
        txtUserName.Text = "";
        txtOldPassword.Text = "";
        txtNewPassword.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}