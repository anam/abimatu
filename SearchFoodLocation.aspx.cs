using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SearchFoodLocation : System.Web.UI.Page
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
            
                if (Session["snFoodreceiverID"] != null && Session["snFoodreceiverID"] != null)
                {
                    AGENT aGENT = (AGENT)Session["aGENT"];
                    hfAgentID.Value = aGENT.AGENTID.ToString();
                    LoadBranch(aGENT.AGENTID);
                    LoadCountry(aGENT.AGENTID);
                }
                else
                {
                    Response.Redirect("SearchFoodReceiverPage.aspx");
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

        gvLocationInfo.DataSource = LOCATIONManager.GetAllLOCATIONsForSearch(int.Parse(hfAgentID.Value), country, city, branch).FindAll(x => x.SEQUENCE == 0);
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
        countrys = LOCATIONManager.GetAllLOCATIONsByAgentID(agentID).FindAll(x => x.SEQUENCE == 0); ;

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
        LOCATIONs = LOCATIONManager.GetAllLOCATIONsByAgentID(agentID).FindAll(x => x.SEQUENCE == 0); ;


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
        LOCATIONs = LOCATIONManager.GetAllLOCATIONs().FindAll(x => x.COUNTRY == ddlCountry.SelectedItem.Value).FindAll(x => x.SEQUENCE == 0); ;


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
            Session["snFoodlocationID"] = locationID.ToString();
            Response.Redirect("FoodTransactionPage.aspx");
        }
        else
        {
            lblMessage.Text = "Please Select Location";
        }
    }
}