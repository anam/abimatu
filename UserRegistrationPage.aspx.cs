using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
public partial class UserRegistrationPage : System.Web.UI.Page
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
            LoadAgent_Location();
            GetUserInfo();
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
        if (User.Identity.IsAuthenticated && Session["userType"] != null && Session["aGENT"] != null )
        {
            AGENT aGENT = new AGENT();
            aGENT = (AGENT)Session["aGENT"];

            if (aGENT.AGENTID != 4 && Session["userType"].ToString()=="Agent") //for admin
            {
                Session.RemoveAll(); Response.Redirect("LogInPage.aspx"); 
            }
        }
        else
        {
            Session.RemoveAll(); Response.Redirect("LogInPage.aspx"); 
        }
    }
    private void LoadAgent_Location()
    {
        ddlAgent_Location.Items.Clear();


        if (ddlUserType.SelectedItem.Value == "Agent")
        {
            ListItem li = new ListItem("-Select Agent-", "0");
            ddlAgent_Location.Items.Add(li);
            List<AGENT> aGENTs = new List<AGENT>();
            aGENTs = AGENTManager.GetAllAGENTs();
            foreach (AGENT aGENT in aGENTs)
            {
                ListItem litems = new ListItem(aGENT.AGENTNAME.ToString(), aGENT.AGENTID.ToString());
                ddlAgent_Location.Items.Add(litems);
            }
            ddlAgent_Location.DataBind();
        }

        if (ddlUserType.SelectedItem.Value == "Location")
        {
            ListItem li = new ListItem("-Select Location-", "0");
            ddlAgent_Location.Items.Add(li);
            List<LOCATIONGROUP> lOCATIONs = new List<LOCATIONGROUP>();
            lOCATIONs = LOCATIONGROUPManager.GetAllLOCATIONGROUPs();
            foreach (LOCATIONGROUP lOCATION in lOCATIONs)
            {
                ListItem litems = new ListItem(lOCATION.GROUPNAME.ToString(), lOCATION.LOCATIONGROUPID.ToString());
                ddlAgent_Location.Items.Add(litems);
            }
            ddlAgent_Location.DataBind();
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (lblUserInfoID.Text == "")
            {

                MembershipCreateStatus status;

                MembershipUser muser = Membership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text, "a", "a", true, out status);

                if (muser == null)
                {
                    lblregistrationError.Text = GetErrorMessage(status);
                    return;
                }
                else if (status == MembershipCreateStatus.Success)
                {

                    if (Roles.RoleExists("User"))
                    {
                        Roles.AddUserToRole(txtUserName.Text, "User");
                        //FormsAuthentication.SetAuthCookie(txtUserName.Text, true);
                        InsertUserInfo();
                    }
                    else
                    {
                        Roles.CreateRole("User");
                        Roles.AddUserToRole(txtUserName.Text, "User");
                        InsertUserInfo();
                    }

                }

            }
            else
            {

                UpdateUserInfo();
                lblMessage.Text = "Update User Successfully";
            }


            GetUserInfo();
        }
        catch (Exception ex)
        {
            lblregistrationError.Text = ex.Message;
        }
    }
    public string GetErrorMessage(MembershipCreateStatus status)
    {
        string errorMsg = "";
        switch (status)
        {
            case MembershipCreateStatus.DuplicateUserName:
                errorMsg+= "Username already exists. Please enter a different user name.";
                break;
            case MembershipCreateStatus.DuplicateEmail:
                errorMsg+= "A username for that e-mail address already exists. Please enter a different e-mail address.";
                break;
            case MembershipCreateStatus.InvalidPassword:
                errorMsg+= "The password provided is invalid. Please enter a valid password value.";
                break;
            case MembershipCreateStatus.InvalidEmail:
                errorMsg+= "The e-mail address provided is invalid. Please check the value and try again.";
                break;
            case MembershipCreateStatus.InvalidAnswer:
                errorMsg+= "The password retrieval answer provided is invalid. Please check the value and try again.";
                break;
            case MembershipCreateStatus.InvalidQuestion:
                errorMsg+= "The password retrieval question provided is invalid. Please check the value and try again.";
                break;
            case MembershipCreateStatus.InvalidUserName:
                errorMsg+= "The user name provided is invalid. Please check the value and try again.";
                break;
            case MembershipCreateStatus.ProviderError:
                errorMsg+= "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                break;
            case MembershipCreateStatus.UserRejected:
                errorMsg+= "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                break;
            default:
                errorMsg+= "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                break;
        }
        return errorMsg + "<br/>'*' are the mandatory Fields..";
    }


    private void InsertUserInfo()
    {
        try
        {
            USERINFO uSERINFO = new USERINFO();

            uSERINFO.AddedDate = DateTime.Now;
            uSERINFO.AddedBy = User.Identity.Name.ToString();
            uSERINFO.ModifyDate = DateTime.Now;
            uSERINFO.ModifyBy = User.Identity.Name.ToString();
            uSERINFO.Type = ddlUserType.SelectedItem.Value.ToString();
            uSERINFO.UserName = txtUserName.Text;
            uSERINFO.Agent_LocationID = Int32.Parse(ddlAgent_Location.SelectedValue);
            uSERINFO.FirstName = txtFirstName.Text;
            uSERINFO.LastName = txtLastName.Text;
            uSERINFO.MiddleName = txtMiddleName.Text;
            uSERINFO.Address = txtAddress.Text;
            uSERINFO.City = txtCity.Text;
            uSERINFO.State = txtState.Text;
            uSERINFO.Country = txtCountry.Text;
            uSERINFO.PostalCode = txtPostalCode.Text;
            uSERINFO.ExpDate = DateTime.Now;
            uSERINFO.Status = 1;
            uSERINFO.HomePhone = txtHomePhone.Text;
            uSERINFO.WorkPhone = txtWorkPhone.Text;
            uSERINFO.Mobile = txtMobile.Text;
            uSERINFO.Comm = "";
            int resutl = USERINFOManager.InsertUSERINFO(uSERINFO);

            if (resutl > 0)
            {
                lblregistrationError.Text = "Successfully Submited!!!! <br/><b>User Name:</b> " + txtUserName.Text + "<br/><b>Password:</b>" + txtPassword.Text + "<br/><b>Email: </b><a href='mailto:" + txtEmail.Text + "?body=Login page: http://abimatu.net/ USER NAME: (" + txtUserName.Text + ")    PASSWORD: (" + txtPassword.Text + ")&subject=Password for ABIMATU Enterprise'>" + txtEmail.Text + "</a><br/>(Click on the mail address to send mail)";
                lblregistrationError.ForeColor = System.Drawing.Color.Green;
                ClearData();
            }

        }
        catch (Exception ex)
        {
            lblregistrationError.Text = ex.Message;
        }
    }

    private void ClearData()
    {
        txtUserName.Text = "";
        txtPostalCode.Text = "";
        txtPassword.Text = "";
        txtMiddleName.Text = "";
        txtLastName.Text = "";
        txtFirstName.Text = "";
        txtEmail.Text = "";
        txtConfirmPassword.Text = "";
        txtAddress.Text = "";
        txtCountry.Text = "";
        txtCity.Text = "";
        txtState.Text = "";
        ddlAgent_Location.SelectedValue = "0";
        txtHomePhone.Text = "";
        txtMobile.Text = "";
        txtWorkPhone.Text = "";
        txtSecurityQuestion.Text = "";
        txtSecurityAnswer.Text = "";
    }


    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadAgent_Location();
        GetUserInfo();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        lblregistrationError.Text = "";
        lblError.Text = "";

        lblUserInfoID.Text = "";
        panAspUserName.Visible = true;
        panAspSecurity.Visible = true;
        ClearData();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        lblregistrationError.Text = "";
        lblError.Text = "";

        //panAspUserName.Visible = false;
        //panAspSecurity.Visible = false;
        showUSERINFOData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (lblUserInfoID.Text == "")
        {

                InsertUserInfo();

       }
        else
        {

            UpdateUserInfo();
            lblMessage.Text = "Update User Successfully";
        }


        GetUserInfo();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }

    protected void UpdateUserInfo()
    {
        int userInfoID = 0;
        userInfoID = selecetedGridRow();



        USERINFO uSERINFO = new USERINFO();
        uSERINFO = USERINFOManager.GetUSERINFOByID(userInfoID);
        USERINFO tempUSERINFO = new USERINFO();
        tempUSERINFO.USERINFOID = uSERINFO.USERINFOID;


        tempUSERINFO.AddedDate =  uSERINFO.AddedDate;
        tempUSERINFO.AddedBy = User.Identity.Name.ToString();
        tempUSERINFO.ModifyDate = DateTime.Now;
        tempUSERINFO.ModifyBy = User.Identity.Name.ToString();
        tempUSERINFO.Type = ddlUserType.SelectedItem.Value.ToString();
        tempUSERINFO.UserName = uSERINFO.UserName;
        tempUSERINFO.Agent_LocationID = Int32.Parse(ddlAgent_Location.SelectedValue);
        tempUSERINFO.FirstName = txtFirstName.Text;
        tempUSERINFO.LastName = txtLastName.Text;
        tempUSERINFO.MiddleName = txtMiddleName.Text;
        tempUSERINFO.Address = txtAddress.Text;
        tempUSERINFO.City = txtCity.Text;
        tempUSERINFO.State = txtState.Text;
        tempUSERINFO.Country = txtCountry.Text;
        tempUSERINFO.PostalCode = txtPostalCode.Text;
        tempUSERINFO.ExpDate = DateTime.Now;
        tempUSERINFO.Status = 1;
        tempUSERINFO.HomePhone = txtHomePhone.Text;
        tempUSERINFO.WorkPhone = txtWorkPhone.Text;
        tempUSERINFO.Mobile = txtMobile.Text;
        tempUSERINFO.Comm = "";
        bool result = USERINFOManager.UpdateUSERINFO(tempUSERINFO);



        MembershipUser mu = Membership.GetUser(uSERINFO.UserName);

        if (mu != null)
        {
            if (txtPassword.Text == "" && txtConfirmPassword.Text == "")
            {
            }

            else
            {
                if (lblPassword.Text != "")
                {
                    mu.ChangePassword(lblPassword.Text, txtPassword.Text);
                }

            }

            mu.Email = txtEmail.Text;
            Membership.UpdateUser(mu);

            MSSQL.SQLExec("update aspnet_Membership set IsLockedOut=" + (chkActive.Checked ? "0" : "1") + " where UserId=(SELECT [UserId] FROM [aspnet_Users] where [UserName]='" + mu.UserName + "')");
        }
    }
    public void GetUserInfo()
    {
        gvUSERINFO.DataSource = USERINFOManager.GetAllUSERINFOsByType(ddlUserType.SelectedItem.Value.ToString());
        gvUSERINFO.DataBind();

    }

    protected void gvUSERINFO_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblAgent_LocationID = (Label)e.Row.FindControl("lblAgent_LocationID");
            Label lblAgent_LocationName = (Label)e.Row.FindControl("lblAgent_LocationName");
            if (ddlUserType.SelectedItem.Value.ToString() == "Agent") 
            {
                AGENT aGENT = new AGENT();
                aGENT = AGENTManager.GetAGENTByID(int.Parse(lblAgent_LocationID.Text));

                if (aGENT != null)
                {
                    lblAgent_LocationName.Text = aGENT.AGENTNAME.ToString();
                }
            }
            else
            {
                LOCATION lOCATION = new LOCATION();
                lOCATION = LOCATIONManager.GetLOCATIONByID(int.Parse(lblAgent_LocationID.Text));
                if (lOCATION != null)
                {
                    lblAgent_LocationName.Text = lOCATION.BRANCH.ToString();
                }
            }
        }
    }

    
    private void showUSERINFOData()
    {
        int userInfoID = 0;
        userInfoID = selecetedGridRow();
        USERINFO uSERINFO = new USERINFO();
        uSERINFO = USERINFOManager.GetUSERINFOByID(userInfoID);

        lblUserInfoID.Text = userInfoID.ToString();


        txtUserName.Text = uSERINFO.UserName;
        ddlAgent_Location.SelectedValue = uSERINFO.Agent_LocationID.ToString();
        txtFirstName.Text = uSERINFO.FirstName;
        txtLastName.Text = uSERINFO.LastName;
        txtMiddleName.Text = uSERINFO.MiddleName;
        txtAddress.Text = uSERINFO.Address;
        txtCity.Text = uSERINFO.City;
        txtState.Text = uSERINFO.State;
        txtCountry.Text = uSERINFO.Country;
        txtPostalCode.Text = uSERINFO.PostalCode;
        txtHomePhone.Text = uSERINFO.HomePhone;
        txtWorkPhone.Text = uSERINFO.WorkPhone;
        txtMobile.Text = uSERINFO.Mobile;
        ddlUserType.SelectedValue = uSERINFO.Type.ToString();

        MembershipUser mu = Membership.GetUser(uSERINFO.UserName);
        if (mu != null)
        {
            lblPassword.Text = mu.GetPassword().ToString();

            txtEmail.Text = mu.Email.ToString();
            chkActive.Checked = !mu.IsLockedOut;
        }

    }


    protected int selecetedGridRow()
    {
        int rowCount = 0;
        int id = 0;
        rowCount = gvUSERINFO.Rows.Count;

        for (int i = 0; i < rowCount; i++)
        {
            RadioButton rbtSelect = (RadioButton)gvUSERINFO.Rows[i].FindControl("rbtSelect");
            if (rbtSelect.Checked == true)
            {
                Label lblUSERINFOID = (Label)gvUSERINFO.Rows[i].FindControl("lblUSERINFOID");
                id = int.Parse(lblUSERINFOID.Text);
            }
        }

        return id;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        int userUnfoID = 0;
        userUnfoID = selecetedGridRow();
        bool result = USERINFOManager.DeleteUSERINFO(userUnfoID);
        GetUserInfo();
        lblMessage.Text = "Delete Successfully";
    }
}