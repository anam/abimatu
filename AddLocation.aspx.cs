using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddLocation : System.Web.UI.Page
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
            //loadLogin();
            LoadAllLocation();
            LoadAgent();
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

    protected void LoadAgent()
    {
        ddlAGENT.Items.Clear();
        ListItem li = new ListItem();
        ddlAGENT.Items.Add(new ListItem("Select","0"));


        List<AGENT> aGENTS = new List<AGENT>();
        aGENTS = AGENTManager.GetAllAGENTs();

        foreach (AGENT aGENT in aGENTS)
        {
            ListItem lItems = new ListItem();
            ddlAGENT.Items.Add(new ListItem(aGENT.AGENTNAME.ToString(),aGENT.AGENTID.ToString()));

        }
        ddlAGENT.DataBind();


    }
    protected void LoadAllLocation()
    {
        gvLocationInfo.DataSource = LOCATIONManager.GetAllLOCATIONs();
        gvLocationInfo.DataBind();
        txtNumberOfBranch.Text = gvLocationInfo.Rows.Count.ToString();

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        lblLocationID.Text = "";
        ClearData();
        lblMessage.Text = "";

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        showLocationData();
        lblMessage.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (lblLocationID.Text == "")
        {
            InsertlocationInfo();
        }
        else
        {
            UpdateLocationInfo();
        }

        LoadAllLocation();

    }

    protected void ClearData()
    {
        //txtLocationName.Text = "";
        //ddlCity.SelectedValue = "0";
        //ddlState.SelectedValue = "0";
        //txtZIP.Text = "";
        //ddlCountry.SelectedValue = "0";
        //txtRate.Text = "";
        //txtBranchCode.Text = "";

    }



    

    


    protected void InsertlocationInfo()
    {
        LOCATION lOCATION = new LOCATION();

        lOCATION.COUNTRY = txtCOUNTRY.Text;
        lOCATION.CITY = txtCITY.Text;
        lOCATION.BRANCH = txtBRANCH.Text;
        lOCATION.BRANCH_CODE = txtBRANCH_CODE.Text;
        lOCATION.SEQUENCE = Int32.Parse(txtSEQUENCE.Text);
        lOCATION.AGENTID = Int32.Parse(ddlAGENT.SelectedValue);
        lOCATION.AGENTRATE = decimal.Parse(txtAGENTRATE.Text);
        int resutl = LOCATIONManager.InsertLOCATION(lOCATION);

        lblMessage.Text = "Saved Successfully";
    }

    protected void UpdateLocationInfo()
    {
        int locationID = 0;
        locationID = selecetedGridRow();

        lblLocationID.Text = locationID.ToString();

        LOCATION tempLOCATION = new LOCATION();
        tempLOCATION.LOCATIONID = locationID;

        tempLOCATION.COUNTRY = txtCOUNTRY.Text;
        tempLOCATION.CITY = txtCITY.Text;
        tempLOCATION.BRANCH = txtBRANCH.Text;
        tempLOCATION.BRANCH_CODE = txtBRANCH_CODE.Text;
        tempLOCATION.SEQUENCE = Int32.Parse(txtSEQUENCE.Text);
        tempLOCATION.AGENTID = Int32.Parse(ddlAGENT.SelectedValue);
        tempLOCATION.AGENTRATE = decimal.Parse(txtAGENTRATE.Text);
        bool result = LOCATIONManager.UpdateLOCATION(tempLOCATION);
        lblMessage.Text = "Update Sucessfully";
    }
    private void showLocationData()
    {
        int locationID = 0;
        locationID = selecetedGridRow();

        LOCATION lOCATION = new LOCATION();
        lOCATION = LOCATIONManager.GetLOCATIONByID(locationID);


        lblLocationID.Text = locationID.ToString();
        txtCOUNTRY.Text = lOCATION.COUNTRY;
        txtCITY.Text = lOCATION.CITY;
        txtBRANCH.Text = lOCATION.BRANCH;
        txtBRANCH_CODE.Text = lOCATION.BRANCH_CODE;
        txtSEQUENCE.Text = lOCATION.SEQUENCE.ToString();
        ddlAGENT.SelectedValue = lOCATION.AGENTID.ToString();
        txtAGENTRATE.Text = lOCATION.AGENTRATE.ToString();
        

    }


    protected int selecetedGridRow()
    {
        int rowCount = 0;
        int id = 0;
        rowCount = gvLocationInfo.Rows.Count;

        for (int i = 0; i < rowCount; i++)
        {
            RadioButton rbtSelect = (RadioButton)gvLocationInfo.Rows[i].FindControl("rbtSelect");
            if (rbtSelect.Checked == true)
            {
                Label lblLOCATIONID = (Label)gvLocationInfo.Rows[i].FindControl("lblLOCATIONID");
                id = int.Parse(lblLOCATIONID.Text);
            }
        }

        return id;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int lOCATIONID = 0;
        lOCATIONID = selecetedGridRow();
        gvwSearch.DataSource = LOCATIONManager.GetAllLOCATIONsForSearchByID(lOCATIONID);
        gvwSearch.DataBind();

        ModalPopupExtender1.Show();
    }


    protected void btnOk_Click(object sender, EventArgs e)
    {

        bool result = TRANSManager.UpdateTRANSByLocationID(selecetedGridRow(), selecetedSearchGridRow());

        ModalPopupExtender1.Hide();
        LoadAllLocation();

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Hide();
        LoadAllLocation();
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
                Label lblLOCATIONID = (Label)gvwSearch.Rows[i].FindControl("lblLOCATIONID");
                id = int.Parse(lblLOCATIONID.Text);
            }
        }

        return id;
    }
}