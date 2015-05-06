using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchFoodReceiverPage : System.Web.UI.Page
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


            if (User.Identity.IsAuthenticated)
            {
                if (Session["snFoodsenderID"] != null)
                {
                    //searchMemberInfo();

                    GetAllReceiverByCustID();
                }
                else
                {
                    Response.Redirect("SearchFoodSenderPage.aspx");
                }

            }
            else
            {
                Session.RemoveAll(); Response.Redirect("LogInPage.aspx");
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
        Response.Redirect("SearchFoodSenderPage.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        searchMemberInfo();

    }

    protected void GetAllReceiverByCustID()
    {
        gvRECEIVER.DataSource = RECEIVERManager.GetAllRECEIVERsFoodForSearch(int.Parse(Session["snFoodsenderID"].ToString()), -1, "-1", "-1", "-1", "-1", "-1", "-1").FindAll(x => (x.AgentID == ((AGENT)Session["aGENT"]).AGENTID));
        gvRECEIVER.DataBind();
    }
    protected void searchMemberInfo()
    {
        try
        {
            int memberID = 0;
            string membername = "";
            string address = "";
            string state = "";
            string city = "";
            string zip = "";
            string phonenumber = "";

            if (txtMemberID.Text == "")
            {
                memberID = -1;
            }
            else
            {
                memberID = int.Parse(txtMemberID.Text);
            }

            if (txtName.Text == "")
            {
                membername = "-1";
            }
            else
            {
                membername = txtName.Text;
            }

            if (txtAddress.Text == "")
            {
                address = "-1";
            }
            else
            {
                address = txtAddress.Text;
            }

            if (txtState.Text == "")
            {
                state = "-1";
            }
            else
            {
                state = txtState.Text;
            }

            if (txtCity.Text == "")
            {
                city = "-1";
            }
            else
            {
                city = txtCity.Text;
            }

            if (txtZIP.Text == "")
            {
                zip = "-1";
            }
            else
            {
                zip = txtZIP.Text;
            }

            if (txtPhoneNumber.Text == "")
            {
                phonenumber = "-1";
            }
            else
            {
                phonenumber = txtPhoneNumber.Text;
            }


            List<RECEIVER> receivers = RECEIVERManager.GetAllRECEIVERsFoodForSearch(-1, memberID, membername, address, city, state, zip, phonenumber);//.FindAll(x => (x.AgentID == ((AGENT)Session["aGENT"]).AGENTID));
            gvRECEIVER.DataSource = receivers;
            gvRECEIVER.DataBind();
        }

        catch (Exception ex)
        {
        }

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {

    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        int receiverID = -1;
        int locationID = 0;
        receiverID = selecetedGridRow();
        if (receiverID == -1) return;
        Session["snFoodreceiverID"] = receiverID.ToString();

        locationID = selecetedGridRowLocation();

        if (locationID == 0) return;
        Session["snFoodlocationID"] = locationID.ToString();

        Response.Redirect("FoodTransactionPage.aspx");

    }
    protected void btnSAR_Click(object sender, EventArgs e)
    {

    }
    protected void btnHistory_Click(object sender, EventArgs e)
    {

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int rECEIVERID = 0;
        rECEIVERID = selecetedGridRow();
        gvwSearch.DataSource = RECEIVERManager.GetAllRECEIVERsForSearchByID(rECEIVERID);
        gvwSearch.DataBind();

        ModalPopupExtender1.Show();
    }
    protected void btnEditSender_Click(object sender, EventArgs e)
    {
        int memberInfoID = 0;
        //int locationID = 0;
        memberInfoID = selecetedGridRow();

        Response.Redirect("ReceiverInsertUpdateFood.aspx?rECEIVERID=" + memberInfoID.ToString());
    }
    protected void btnNewSender_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReceiverInsertUpdateFood.aspx?rECEIVERID=-1");
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //Response.Redirect("AdminMemberInfoInsertUpdate.aspx?memberInfoID=0");
    }





    protected int selecetedGridRowLocation()
    {
        int rowCount = 0;
        int id = 0;
        //locationID = 0;
        rowCount = gvRECEIVER.Rows.Count;

        for (int i = 0; i < rowCount; i++)
        {
            RadioButton rbtSelect = (RadioButton)gvRECEIVER.Rows[i].FindControl("rbtSelect");
            if (rbtSelect.Checked == true)
            {
                Label lblLOCATIONID = (Label)gvRECEIVER.Rows[i].FindControl("lblLOCATIONID");
                //Label lblLocationID = (Label)gvRECEIVER.Rows[i].FindControl("lblLocationID");
                //locationID = int.Parse(lblLocationID.Text);
                id = int.Parse(lblLOCATIONID.Text);
            }
        }

        return id;
    }



    protected int selecetedGridRow()
    {
        int rowCount = 0;
        int id = 0;
        //locationID = 0;
        rowCount = gvRECEIVER.Rows.Count;

        for (int i = 0; i < rowCount; i++)
        {
            RadioButton rbtSelect = (RadioButton)gvRECEIVER.Rows[i].FindControl("rbtSelect");
            if (rbtSelect.Checked == true)
            {
                Label lblRECEIVERID = (Label)gvRECEIVER.Rows[i].FindControl("lblRECEIVERID");
                //Label lblLocationID = (Label)gvRECEIVER.Rows[i].FindControl("lblLocationID");
                //locationID = int.Parse(lblLocationID.Text);
                id = int.Parse(lblRECEIVERID.Text);
            }
        }

        return id;
    }

    protected void gvRECEIVER_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        gvRECEIVER.PageIndex = e.NewPageIndex;
        searchMemberInfo();
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        //lblPreviousID.Text = selecetedGridRow().ToString();
        //lblNewID.Text = selecetedSearchGridRow().ToString();


        bool result = TRANSManager.UpdateTRANSByReceiverID(selecetedGridRow(), selecetedSearchGridRow());

        ModalPopupExtender1.Hide();

        searchMemberInfo();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //ModalPopupExtender1.Hide();
        //searchMemberInfo();
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
                Label lblRECEIVERID = (Label)gvwSearch.Rows[i].FindControl("lblRECEIVERID");
                id = int.Parse(lblRECEIVERID.Text);
            }
        }

        return id;
    }
}