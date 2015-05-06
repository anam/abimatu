using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Drawing;
public partial class SearchSenderPage : System.Web.UI.Page
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
        Response.Redirect("Default.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        searchMemberInfo();
        
    }

    protected void searchMemberInfo()
    {
        try
        {

            int customerID1 = 0;
            string phoneNumber1 = "";
            string drivingLicense1 = "";
            string ssn1 = "";
            string customerFName1 = "";
            string customerMName1 = "";
            string customerLName1 = "";


            if (txtMemberID.Text == "")
            {
                customerID1 = 0;
            }

            else
            {
                customerID1 = int.Parse(txtMemberID.Text);
            }
            if (txtPhoneNumber.Text == "")
            {
                phoneNumber1 = "0";
            }
            else
            {
                phoneNumber1 = txtPhoneNumber.Text;
            }
            if (txtDrivingLicense.Text == "")
            {
                drivingLicense1 = "0";
            }
            else
            {
                drivingLicense1 = txtDrivingLicense.Text;
            }
            if (txtSSN.Text == "")
            {
                ssn1 = "0";
            }
            else
            {
                ssn1 = txtSSN.Text;
            }
            if (txtFirstName.Text == "")
            {
                customerFName1 = "0";
            }
            else
            {
                customerFName1 = txtFirstName.Text;
            }
            if (txtMiddleName.Text == "")
            {
                customerMName1 = "0";
            }
            else
            {
                customerMName1 = txtMiddleName.Text;
            }
            if (txtLastName.Text == "")
            {
                customerLName1 = "0";
            }
            else
            {
                customerLName1 = txtLastName.Text;
            }

            gvCUSTOMER.DataSource = CUSTOMERManager.GetAllCUSTOMERsForSearch(customerID1, phoneNumber1, drivingLicense1, ssn1, customerFName1, customerMName1, customerLName1);
            gvCUSTOMER.DataBind();
        }

        catch (Exception ex)
        {
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtDrivingLicense.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtMemberID.Text = "";
        txtMiddleName.Text = "";
        txtPhoneNumber.Text = "";
        txtSSN.Text = "";
    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        int senderID=-1;
        senderID = selecetedGridRow();
        if (senderID == -1) return;
        Session["snsenderID"] = senderID.ToString();
        Response.Redirect("SearchReceiverPage.aspx");
    }
    protected void btnSAR_Click(object sender, EventArgs e)
    {
        int cUSTOMERID=0;
        cUSTOMERID = selecetedGridRow();
        Response.Redirect("SuspiciousActivityPage.aspx?cUSTOMERID=" + cUSTOMERID.ToString());
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        int cUSTOMERID = 0;
        cUSTOMERID = selecetedGridRow();
        Response.Redirect("ReportCustomerLocationWise.aspx?CUSTIDs=" + cUSTOMERID.ToString());
    }
    protected void btnHistory_Click(object sender, EventArgs e)
    {
        int senderID = 0;
        senderID = selecetedGridRow();
        Response.Redirect("ReportCustomerLocationWise.aspx?CUSTIDs=" + senderID.ToString());
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int cUSTOMERID = 0;
        cUSTOMERID = selecetedGridRow();
        gvwSearch.DataSource = CUSTOMERManager.GetAllCUSTOMERsForSearchByID(cUSTOMERID);
        gvwSearch.DataBind();

        ModalPopupExtender1.Show();
    }
    protected void btnEditSender_Click(object sender, EventArgs e)
    {


        int senderID = 0;
        senderID = selecetedGridRow();
        Response.Redirect("CUSTOMERInsertUpdate.aspx?cUSTOMERID="+senderID.ToString());
    }
    protected void btnNewSender_Click(object sender, EventArgs e)
    {
        Response.Redirect("CUSTOMERInsertUpdate.aspx?cUSTOMERID=-1");
    }
    protected int selecetedGridRow()
    {
        int rowCount = 0;
        int id = 0;
        rowCount = gvCUSTOMER.Rows.Count;

        for (int i = 0; i < rowCount; i++)
        {
            RadioButton rbtSelect = (RadioButton)gvCUSTOMER.Rows[i].FindControl("rbtSelect");
            if (rbtSelect.Checked == true)
            {
                Label lblMemberID = (Label)gvCUSTOMER.Rows[i].FindControl("lblCUSTOMERID");
                id = int.Parse(lblMemberID.Text);
            }
        }

        return id;
    }

    protected void gvCUSTOMER_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        gvCUSTOMER.PageIndex = e.NewPageIndex;
        searchMemberInfo();
    }


    protected void btnOk_Click(object sender, EventArgs e)
    {
        //lblPreviousID.Text = selecetedGridRow().ToString();
        //lblNewID.Text = selecetedSearchGridRow().ToString();


        bool result = TRANSManager.UpdateTRANSByCustomerID(selecetedGridRow(), selecetedSearchGridRow());

        ModalPopupExtender1.Hide();

        searchMemberInfo();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Hide();
        searchMemberInfo();
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
                Label lblMemberID = (Label)gvwSearch.Rows[i].FindControl("lblCUSTOMERID");
                id = int.Parse(lblMemberID.Text);
            }
        }

        return id;
    }


    protected void gvCUSTOMER_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblISOFACVERIFIED = (Label)e.Row.FindControl("lblISOFACVERIFIED");
            RadioButton rbtSelect = (RadioButton)e.Row.FindControl("rbtSelect");


            
            if (lblISOFACVERIFIED.Text == "N")
            {
                e.Row.BackColor = System.Drawing.Color.Red;
                e.Row.ForeColor = System.Drawing.Color.White;

                //rbtSelect.Enabled = false;
                rbtSelect.Enabled = true;
            }

        }
    }
}