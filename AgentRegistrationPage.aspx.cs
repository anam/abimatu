using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class AgentRegistrationPage : System.Web.UI.Page
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
            LoadCountry();
            LoadAgent();
            showUserInfoGrid();

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

    protected void showUserInfoGrid()
    {
        gvAGENT.DataSource = AGENTManager.GetAllAGENTs();
        gvAGENT.DataBind();
    }

    private void showAgentInfoData()
    {

        int agentInfoGrid = 0;
        agentInfoGrid = selecetedGridRow();

        AGENT aGENT = new AGENT();
        aGENT = AGENTManager.GetAGENTByID(agentInfoGrid);
        
        if (aGENT != null)
        {
            lblUserInfoID.Text = aGENT.AGENTID.ToString();
            txtAGENTNAME.Text = aGENT.AGENTNAME;
              txtUserName.Text = aGENT.USERNAME;
              txtAGENTLOCATION.Text = aGENT.AGENTLOCATION;
              txtAGENTADDRESS.Text = aGENT.AGENTADDRESS;
              txtAGENTCITY.Text = aGENT.AGENTCITY;
              txtAGENTSTATE.Text = aGENT.AGENTSTATE;
              txtAGENTZIP.Text = aGENT.AGENTZIP;
              txtAGENTPHONE.Text = aGENT.AGENTPHONE;
              txtAGENTACC.Text = aGENT.AGENTACC;
        }



    }
    private void LoadAgent()
    {
        //ListItem li = new ListItem("-Select-", "0");
        //ddlAgent.Items.Add(li);
        //List<UserInfo> userInfos = new List<UserInfo>();
        //userInfos = UserInfoManager.GetAllUserInfosByType("Agent");
        //foreach (UserInfo userInfo in userInfos)
        //{
        //    ListItem litems = new ListItem(userInfo.FirstName.ToString(), userInfo.UserInfoID.ToString());
        //    ddlAgent.Items.Add(litems);
        //}
        //ddlAgent.DataBind();
    }

    private void LoadCountry()
    {
        //ListItem li = new ListItem("-Select-", "0");
        //ddlCountry.Items.Add(li);
        //List<Country> countrys = new List<Country>();
        //countrys = CountryManager.GetAllCountries();
        //foreach (Country country in countrys)
        //{
        //    ListItem litems = new ListItem(country.CountryName.ToString(), country.CountryID.ToString());
        //    ddlCountry.Items.Add(litems);
        //}
        //ddlCountry.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
    public string GetErrorMessage(MembershipCreateStatus status)
    {
        switch (status)
        {
            case MembershipCreateStatus.DuplicateUserName:
                return "Username already exists. Please enter a different user name.";

            case MembershipCreateStatus.DuplicateEmail:
                return "A username for that e-mail address already exists. Please enter a different e-mail address.";

            case MembershipCreateStatus.InvalidPassword:
                return "The password provided is invalid. Please enter a valid password value.";

            case MembershipCreateStatus.InvalidEmail:
                return "The e-mail address provided is invalid. Please check the value and try again.";

            case MembershipCreateStatus.InvalidAnswer:
                return "The password retrieval answer provided is invalid. Please check the value and try again.";

            case MembershipCreateStatus.InvalidQuestion:
                return "The password retrieval question provided is invalid. Please check the value and try again.";

            case MembershipCreateStatus.InvalidUserName:
                return "The user name provided is invalid. Please check the value and try again.";

            case MembershipCreateStatus.ProviderError:
                return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

            case MembershipCreateStatus.UserRejected:
                return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

            default:
                return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
        }
    }


    private void InsertAgentInfo()
    {
        try
        {
        AGENT aGENT = new AGENT();

        aGENT.AGENTNAME = txtAGENTNAME.Text;
        aGENT.USERNAME = txtUserName.Text;
        aGENT.AGENTLOCATION = txtAGENTLOCATION.Text;
        aGENT.AGENTADDRESS = txtAGENTADDRESS.Text;
        aGENT.AGENTCITY = txtAGENTCITY.Text;
        aGENT.AGENTSTATE = txtAGENTSTATE.Text;
        aGENT.AGENTZIP = txtAGENTZIP.Text;
        aGENT.AGENTPHONE = txtAGENTPHONE.Text;
        aGENT.AGENTACC = txtAGENTACC.Text;
        aGENT.CREATEDBY = 1;
        aGENT.CREATEDON = DateTime.Now;
        aGENT.UPDATEDBY = 1;
        aGENT.UPDATEDON = DateTime.Now;
        int resutl = AGENTManager.InsertAGENT(aGENT);

        if (resutl > 0)
        {
            lblregistrationError.Text = "Successfully Submitted!";
            ClearData();
        }

        }
        catch (Exception ex)
        {
            lblregistrationError.Text = ex.Message;
        }
    }

    private void UpdateUserInfo()
    {
        AGENT aGENT = new AGENT();
        aGENT = AGENTManager.GetAGENTByID(Int32.Parse(lblUserInfoID.Text));
        AGENT tempAGENT = new AGENT();
        tempAGENT.AGENTID = aGENT.AGENTID;

        tempAGENT.AGENTNAME = txtAGENTNAME.Text;
        tempAGENT.USERNAME = txtUserName.Text;
        tempAGENT.AGENTLOCATION = txtAGENTLOCATION.Text;
        tempAGENT.AGENTADDRESS = txtAGENTADDRESS.Text;
        tempAGENT.AGENTCITY = txtAGENTCITY.Text;
        tempAGENT.AGENTSTATE = txtAGENTSTATE.Text;
        tempAGENT.AGENTZIP = txtAGENTZIP.Text;
        tempAGENT.AGENTPHONE = txtAGENTPHONE.Text;
        tempAGENT.AGENTACC = txtAGENTACC.Text;
        tempAGENT.CREATEDBY = 1;
        tempAGENT.CREATEDON = aGENT.CREATEDON;
        tempAGENT.UPDATEDBY = 1;
        tempAGENT.UPDATEDON = DateTime.Now;
        bool result = AGENTManager.UpdateAGENT(tempAGENT);

        ClearData();

        showUserInfoGrid();
    }
    private void ClearData()
    {
        txtAGENTNAME.Text="";
        txtUserName.Text = "";
        txtAGENTADDRESS.Text = "";
        txtPassword.Text = "";
        txtAGENTZIP.Text = "";
        txtEmail.Text = "";
        txtConfirmPassword.Text = "";
        txtAGENTLOCATION.Text = "";
        txtAGENTACC.Text = "";

        txtAGENTCITY.Text = "";
        
        txtAGENTSTATE.Text = "";
        txtAGENTPHONE.Text = "";
        txtSecurityAnswer.Text = "";
        txtSecurityQuestion.Text = "";
    }

    //private string getcode(object _code)
    //{
    //    string _agcode = "";
    //    Agent agent = AgentManager.GetMaxAgentCode();
    //    if (agent != null)
    //    {
    //        string exist_code = agent.AgentCode;
    //        string[] codes = exist_code.Split('-');
    //        int code = int.Parse(codes[1].ToString()) + 1;
    //        _agcode = codes[0] + "-" + code.ToString();

    //    }
    //    else
    //    {
    //        _agcode = "ME-1";
    //    }
    //    return _agcode;
    //}



    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

        //loadCityByState();
    }

    protected void loadStateByCountry()
    {



        //ddlState.Items.Clear();
        //ListItem li = new ListItem("-Select-", "0");
        //ddlState.Items.Add(li);
        //List<State> states = new List<State>();
        //states = StateManager.GetAllStatesByCountryID(int.Parse(ddlCountry.SelectedValue));
        //foreach (State state in states)
        //{
        //    ListItem litems = new ListItem(state.StateName.ToString(), state.StateID.ToString());
        //    ddlState.Items.Add(litems);
        //}
        //ddlState.DataBind();
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        //loadStateByCountry();
    }

    protected void loadCityByState()
    {
        //ddlCity.Items.Clear();
        //ListItem li = new ListItem("-Select-", "0");
        //ddlCity.Items.Add(li);
        //List<City> citys = new List<City>();
        //citys = CityManager.GetAllCitiesByState(int.Parse(ddlState.SelectedValue));
        //foreach (City city in citys)
        //{
        //    ListItem litems = new ListItem(city.CityName.ToString(), city.CityID.ToString());
        //    ddlCity.Items.Add(litems);
        //}
        //ddlCity.DataBind();
    }


    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlUserType.SelectedItem.Value == "User")
        //{
        //    lblError.Text = "Please select agent";
        //    panAgent.Visible = true;
        //}
        //else
        //{
        //    panAgent.Visible = false;
        //}
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        //LinkButton linkButton = new LinkButton();
        //linkButton = (LinkButton)sender;
        //int id;
        //id = Convert.ToInt32(linkButton.CommandArgument);
        //Response.Redirect("AdminUserInfoInsertUpdate.aspx?userInfoID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        //LinkButton linkButton = new LinkButton();
        //linkButton = (LinkButton)sender;
        //bool result = UserInfoManager.DeleteUserInfo(Convert.ToInt32(linkButton.CommandArgument));
        //showUserInfoGrid();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        //Session.RemoveAll(); Response.Redirect("LogInPage.aspx"); 
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
        showUserInfoGrid();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        lblregistrationError.Text = "";
        lblError.Text = "";

        panAspUserName.Visible = false;
        panAspSecurity.Visible = false;
        int checkSelect = 0;
        checkSelect = selecetedGridRow();

        if (checkSelect == 0)
        {
            lblMessage.Text = "Please Select Agent";
        }
        else
        {
            showAgentInfoData();
            lblMessage.Text = "";
        }

        showUserInfoGrid();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        lblregistrationError.Text = "";
        lblError.Text = "";
        if (lblUserInfoID.Text == "")
        {
            try
            {
                InsertAgentInfo();
                return;
                
                MembershipCreateStatus status;

                MembershipUser muser = Membership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text, "a", "a", true, out status);

                if (muser == null)
                {
                    lblregistrationError.Text = GetErrorMessage(status);
                }

                else if (status == MembershipCreateStatus.Success)
                {
                    if (Roles.RoleExists("Agent"))
                        {
                            Roles.AddUserToRole(txtUserName.Text, "Agent");
                            FormsAuthentication.SetAuthCookie(txtUserName.Text, true);
                            InsertAgentInfo();
                        }
                        else
                        {
                            Roles.CreateRole("Agent");
                            Roles.AddUserToRole(txtUserName.Text, "Agent");
                            InsertAgentInfo();
                        }
                    //}

                    //if (ddlUserType.SelectedItem.Value == "User")
                    //{
                    //    if (Roles.RoleExists("User"))
                    //    {
                    //        Roles.AddUserToRole(txtUserName.Text, "User");
                    //        FormsAuthentication.SetAuthCookie(txtUserName.Text, true);
                    //        InsertUserInfo();
                    //    }
                    //    else
                    //    {
                    //        Roles.CreateRole("User");
                    //        Roles.AddUserToRole(txtUserName.Text, "User");
                    //        InsertUserInfo();
                    //    }
                    //}
                }

                //Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                lblregistrationError.Text = ex.Message;
            }


            lblMessage.Text = "Insert Agent Successfully";
        }
        else
        {

            UpdateUserInfo();
            lblMessage.Text = "Update Agent Successfully";
        }

        showUserInfoGrid();

    }



    protected int selecetedGridRow()
    {
        int rowCount = 0;
        int id = 0;
        rowCount = gvAGENT.Rows.Count;

        for (int i = 0; i < rowCount; i++)
        {
            RadioButton rbtSelect = (RadioButton)gvAGENT.Rows[i].FindControl("rbtSelect");
            if (rbtSelect.Checked == true)
            {
                Label lblAGENTID = (Label)gvAGENT.Rows[i].FindControl("lblAGENTID");
                id = int.Parse(lblAGENTID.Text);
            }
        }

        return id;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int aGENTID = 0;
        aGENTID = selecetedGridRow();
        gvwSearch.DataSource = AGENTManager.GetAllAGENTsForSearchByID(aGENTID);
        gvwSearch.DataBind();

        ModalPopupExtender1.Show();
    }


    protected void btnOk_Click(object sender, EventArgs e)
    {

        bool result = TRANSManager.UpdateTRANSByAgentID(selecetedGridRow(), selecetedSearchGridRow());

        ModalPopupExtender1.Hide();
        showUserInfoGrid();

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Hide();
        showUserInfoGrid();
    }


    protected int selecetedSearchGridRow()
    {
        int rowCount = 0;
        int id = 0;
        rowCount = gvwSearch.Rows.Count;

        for (int i = 0; i < rowCount; i++)
        {
            RadioButton rbtSelect = (RadioButton)gvwSearch.Rows[i].FindControl("rbtSelect");
            if (rbtSelect.Checked == true)
            {
                Label lblAGENTID = (Label)gvwSearch.Rows[i].FindControl("lblAGENTID");
                id = int.Parse(lblAGENTID.Text);
            }
        }

        return id;
    }
}