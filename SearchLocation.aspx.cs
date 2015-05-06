using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SearchLocation : System.Web.UI.Page
{
    DataTable dt = new DataTable();
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
            
                if (Session["snreceiverID"] != null && Session["snreceiverID"] != null)
                {
                    AGENT aGENT = (AGENT)Session["aGENT"];
                    hfAgentID.Value = aGENT.AGENTID.ToString();
                    LoadBranch(aGENT.AGENTID);
                    LoadCountry(aGENT.AGENTID);

                }
                else
                {
                    Response.Redirect("SearchReceiverPage.aspx");
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
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        SearchLocationInfo();
        
    }

    protected void SearchLocationInfo()
    {
        string country = "";
        string city = "";
        string branch = "";

        if (ddlCountry.SelectedItem.Value == "0")
        {
            country = "-1";
        }
        else
        {
            country = ddlCountry.SelectedItem.Value;
        }

        if (ddlCity.SelectedItem.Value == "0")
        {
            city = "-1";
        }
        else
        {
            city = ddlCity.SelectedItem.Value;
        }

        if (ddlBranch.SelectedItem.Value == "0")
        {
            branch = "-1";
        }
        else
        {
            branch = ddlBranch.SelectedItem.Value;
        }

        gvLocationInfo.DataSource = LOCATIONManager.GetAllLOCATIONsForSearch(int.Parse(hfAgentID.Value), country, city, branch);
        gvLocationInfo.DataBind();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {

    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadLocationByBranchID();
    }
    protected void LoadCountry(int agentID)
    {
        ddlCountry.Items.Clear();


        ListItem li = new ListItem("-Select-", "0");
        ddlCountry.Items.Add(li);
        List<LOCATION> countrys = new List<LOCATION>();
        countrys = LOCATIONManager.GetAllLOCATIONsByAgentID(agentID);

        List<string> onlyCountry = new List<string>();
        string allCountry = " ";

        foreach (LOCATION country in countrys)
        {
            onlyCountry.Add(country.COUNTRY.ToString());            

        }

        List<string> distinctCountry = new List<string>();

        distinctCountry = onlyCountry.Distinct().ToList();



        for (int i = 0; i < distinctCountry.Count; i++)
        {
            ListItem litems = new ListItem(distinctCountry[i].ToString(), distinctCountry[i].ToString());
            ddlCountry.Items.Add(litems);
        }

        ddlCountry.DataBind();

        loadCityByCountry();
    }
    protected void LoadBranch(int agentID)
    {
        ddlBranch.Items.Clear();
        ListItem li = new ListItem("-Select-", "0");
        ddlBranch.Items.Add(li);


        List<LOCATION> LOCATIONs = new List<LOCATION>();
        LOCATIONs = LOCATIONManager.GetAllLOCATIONsByAgentID(agentID);


        List<string> onlyBranch = new List<string>();
        foreach (LOCATION location in LOCATIONs)
        {
            onlyBranch.Add(location.BRANCH);
        }

        List<string> distinctBranch = new List<string>();

        distinctBranch = onlyBranch.Distinct().ToList();


        for (int i = 0; i < distinctBranch.Count; i++)
        {
            ListItem litems = new ListItem(distinctBranch[i].ToString(), distinctBranch[i].ToString());
            ddlBranch.Items.Add(litems);
        }

        ddlBranch.DataBind();
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadCityByCountry();
    }


    protected void loadCityByCountry()
    {
        ddlCity.Items.Clear();
        ListItem li = new ListItem("-Select-", "0");
        ddlCity.Items.Add(li);


        List<LOCATION> LOCATIONs = new List<LOCATION>();
        LOCATIONs = LOCATIONManager.GetAllLOCATIONs().FindAll(x => x.COUNTRY == ddlCountry.SelectedItem.Value);


        List<string> onlyCity = new List<string>();
        foreach (LOCATION location in LOCATIONs)
        {
            onlyCity.Add(location.CITY);
        }

        List<string> distinctCity = new List<string>();

        distinctCity = onlyCity.Distinct().ToList();


        for (int i = 0; i < distinctCity.Count; i++)
        {
            ListItem litems = new ListItem(distinctCity[i].ToString(), distinctCity[i].ToString());
            ddlCity.Items.Add(litems);
        }

        ddlCity.DataBind();

    }


    protected void LoadLocationByBranchID()
    {
        gvLocationInfo.DataSource = LOCATIONManager.GetAllLOCATIONs().FindAll(x => x.BRANCH == ddlBranch.SelectedItem.Value);
        gvLocationInfo.DataBind();

        
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

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        int locationID = 0;
        locationID = selecetedGridRow();

        if (locationID != 0)
        {
            //bool result = MemberInfoManager.UpdateMemberLocationInfo(int.Parse(Session["snreceiverID"].ToString()), locationID);

            //Session["snlocationID"] = locationID.ToString();
            //Response.Redirect("SearchReceiverPage.aspx");
            Session["snlocationID"] = locationID.ToString();
            Response.Redirect("Payment.aspx");
        }
        else
        {
            lblMessage.Text = "Please Select Location";
        }
    }
    protected void btnSAR_Click(object sender, EventArgs e)
    {

    }
    protected void btnHistory_Click(object sender, EventArgs e)
    {

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int lOCATIONID = 0;
        lOCATIONID = selecetedGridRow();
        gvwSearch.DataSource = LOCATIONManager.GetAllLOCATIONsForSearchByID(lOCATIONID);
        gvwSearch.DataBind();

        ModalPopupExtender1.Show();
    }
    protected void btnEditLocation_Click(object sender, EventArgs e)
    {

    }
    protected void btnNewLocation_Click(object sender, EventArgs e)
    {

    }
    protected void btnOk_Click(object sender, EventArgs e)
    {

        bool result = TRANSManager.UpdateTRANSByLocationID(selecetedGridRow(), selecetedSearchGridRow());

        ModalPopupExtender1.Hide();
        SearchLocationInfo();
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Hide();
        SearchLocationInfo();
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