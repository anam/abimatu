using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
public partial class ReportFoodLocationWise : System.Web.UI.Page
{
    public string status = "";
    DataTable dt = new DataTable();
    SqlFOODITEM_TRANSMASTERProvider sqlFOODITEM_TRANSMASTERProvider = new SqlFOODITEM_TRANSMASTERProvider();

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

            if (Request.QueryString["Daily"] != null)
            {
                trFromDate.Visible = false;
                trToDate.Visible = false;
            }

            LoadAgent();



            txtFromDate.Text = DateTime.Today.ToShortDateString();
            txtToDate.Text = DateTime.Today.ToShortDateString();
            tblTotal.Visible = false;
            loadLocation();
        }
        reLoadSession();
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

    private void loadLocation()
    {
        List<LOCATION> locations = new List<LOCATION>();
        if (Session["userType"] != null && (Session["lOCATION"] != null || Session["aGENT"] != null))
        {
            if (Session["userType"].ToString() == "Location")
            {
                LOCATIONGROUP lOCATIONGROUP = new LOCATIONGROUP();
                lOCATIONGROUP = (LOCATIONGROUP)Session["lOCATION"];

                hfLoggedinLocationID.Value = lOCATIONGROUP.LOCATIONGROUPID.ToString();

                if (ddlAgent.SelectedItem.Text != "All Agents")
                {
                    locations = LOCATIONManager.GetAllLOCATIONsByAgentIDnGroupID(int.Parse(ddlAgent.SelectedItem.Value), int.Parse(hfLoggedinLocationID.Value)).FindAll(x => x.SEQUENCE == 0);
                }
                else
                {
                    locations = LOCATIONManager.GetAllLOCATIONsByGroupID(int.Parse(hfLoggedinLocationID.Value)).FindAll(x => x.SEQUENCE == 0);
                }
                //locations = LOCATIONManager.GetAllLOCATIONsByGroupID(int.Parse(hfLoggedinLocationID.Value));
                //trLocation.Visible = false;
            }
            else if (Session["userType"].ToString() == "Agent")
            {
                AGENT aGENT = (AGENT)Session["aGENT"];
                hfAgentID.Value = aGENT.AGENTID.ToString();

                trLocation.Visible = true;
                if (hfAgentID.Value == "4")
                {
                    if (ddlAgent.SelectedItem.Text != "All Agents")
                    {
                        locations = LOCATIONManager.GetAllLOCATIONsByAgentID(int.Parse(ddlAgent.SelectedItem.Value)).FindAll(x => x.SEQUENCE == 0);
                    }
                    else
                    {
                        locations = LOCATIONManager.GetAllLOCATIONs().FindAll(x => x.SEQUENCE == 0);
                    }
                }
                else
                {
                    locations = LOCATIONManager.GetAllLOCATIONsByAgentID(int.Parse(hfAgentID.Value)).FindAll(x => x.SEQUENCE == 0);
                }
            }

            dlLocation.DataSource = locations;
            dlLocation.DataBind();
            tblSearchByRefCode.Visible = false;

        }
        else
        {
            Session.RemoveAll(); Response.Redirect("LogInPage.aspx");
        }

    }

    private string getLocationIDs()
    {
        string locationIDs = "0";

        //if (!trLocation.Visible)
        //{
        //    locationIDs = hfLoggedinLocationID.Value;
        //}
        //else
        //{
        foreach (GridViewRow gr in dlLocation.Rows)
        {
            CheckBox chkSelect = (CheckBox)gr.FindControl("chkSelect");

            HiddenField hfLocationID = (HiddenField)gr.FindControl("hfLocationID");

            if (chkSelect.Checked || chkAllLocations.Checked)
            {
                if (locationIDs == "") locationIDs = hfLocationID.Value;
                else locationIDs += "," + hfLocationID.Value;
            }
        }
        //}
        return locationIDs;
    }

    private void LoadAgent()
    {


        List<AGENT> aGENTs = new List<AGENT>();

        if (Session["aGENT"] != null)
        {
            if (((AGENT)Session["aGENT"]).AGENTID != 4)//if not the admin
            {
                aGENTs.Add((AGENT)Session["aGENT"]);
            }
            else
            {
                aGENTs = AGENTManager.GetAllAGENTs();
            }
        }
        else
        {
            aGENTs = AGENTManager.GetAllAGENTs();
        }

        foreach (AGENT aGENT in aGENTs)
        {
            System.Web.UI.WebControls.ListItem litems = new System.Web.UI.WebControls.ListItem(aGENT.AGENTNAME.ToString(), aGENT.AGENTID.ToString());
            ddlAgent.Items.Add(litems);


        }


        if (Session["aGENT"] != null)
        {
            if (((AGENT)Session["aGENT"]).AGENTID == 4)//if not the admin
            {
                System.Web.UI.WebControls.ListItem litem = new System.Web.UI.WebControls.ListItem("All Agents", "0");
                ddlAgent.Items.Add(litem);
            }
        }
        else
        {
            hfIsLocation.Value = "1";
            System.Web.UI.WebControls.ListItem litem = new System.Web.UI.WebControls.ListItem("All Agents", "0");
            ddlAgent.Items.Add(litem);
        }



        ddlAgent.DataBind();
    }

    private string loadStatus()
    {
        #region Status
        //basically cancel is the RETURN in db

        status = "";

        status = chkCanceled.Checked ? "'RETURN'" : "";
        status += chkPending.Checked ? (status == "" ? "'PENDING'" : ",'PENDING'") : "";
        status += chkPaid.Checked ? (status == "" ? "'PAID'" : ",'PAID'") : "";
        status += chkPartiallyPaid.Checked ? (status == "" ? "'PARTIALLY-PAID'" : ",'PARTIALLY-PAID'") : "";
        status = (status == "" ? "'PENDING','PAID','PARTIALLY-PAID'" : status);
        #endregion
        return status;

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblSubTotalSendingAmountTotal.Text = "0";
        lblSubTotalFeesTotal.Text = "0";
        lblSubTotalDiscountTotal.Text = "0";
        lblSubTotalTotalAmountTotal.Text = "0";
        lblTotalno.Text = "0";
        txtRefCodeForSearch.Text = "";
        //lblmessage.Text = "";


        loadReport();

        gvLocation.Visible = true;
        tblTotal.Visible = true;
        //gvRECEIVER.Visible = true;

        divListOfAllTransaction.Visible = true;
        tblTotal.Visible = true;
        //divPayment.Visible = false;
    }


    private void loadReport()
    {
        List<FOODITEM_TRANSMASTER> fOODITEM_TRANSMASTER = new List<FOODITEM_TRANSMASTER>();
        fOODITEM_TRANSMASTER = FOODITEM_TRANSMASTERManager.GetAllFOODITEM_TRANSMASTERsForReport(loadStatus(), getLocationIDs(), int.Parse(ddlAgent.SelectedValue), txtFromDate.Text, txtToDate.Text, int.Parse(txtMoney.Text == "" ? "0" : txtMoney.Text));

        List<FOODITEM_TRANSMASTER> fOODITEM_TRANSMASTERFinal = new List<FOODITEM_TRANSMASTER>();
        int count = 0;
        for (int i = 0; i < fOODITEM_TRANSMASTER.Count; i++)
        {
            count = fOODITEM_TRANSMASTERFinal.FindAll(x => x.LID == fOODITEM_TRANSMASTER[i].LID).Count;

            if (count == 0)
            {
                fOODITEM_TRANSMASTERFinal.Add(fOODITEM_TRANSMASTER[i]);
            }

        }

        gvLocation.DataSource = fOODITEM_TRANSMASTERFinal;
        gvLocation.DataBind();

        calculateTotalAmount();
    }

    public void calculateTotalAmount()
    {
        decimal totalAmount = 0;
        for (int i = 0; i < gvLocation.Rows.Count; i++)
        {
            Label lblSubTotalSendingAmount = (Label)gvLocation.Rows[i].FindControl("lblSubTotalSendingAmount");

            totalAmount = decimal.Parse(lblSubTotalSendingAmount.Text) + totalAmount;
        }

        if (hfIsLocation.Value == "1")
        {
            lblSubTotalTotalAmountTotal.Visible = false;

        }

        lblSubTotalTotalAmountTotal.Text = totalAmount.ToString();
        lblSubTotalFeesTotal.Text = "";
        lblSubTotalSendingAmountTotal.Text = "";
        lblSubTotalFeesTotal.Text = "";
        lblSubTotalDiscountTotal.Text = "";
    }
    protected void gvLocation_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hfLocationID = (HiddenField)e.Row.FindControl("hfLocationID");
            GridView gvTRANS = (GridView)e.Row.FindControl("gvTRANS");
            List<FOODITEM_TRANSMASTER> fOODITEM_TRANSMASTER = new List<FOODITEM_TRANSMASTER>();
            fOODITEM_TRANSMASTER = FOODITEM_TRANSMASTERManager.GetAllFOODITEM_TRANSMASTERsForReport(loadStatus(), getLocationIDs(), int.Parse(ddlAgent.SelectedValue), txtFromDate.Text, txtToDate.Text, int.Parse(txtMoney.Text == "" ? "0" : txtMoney.Text)).FindAll(x => x.LID == int.Parse(hfLocationID.Value));

            foreach (FOODITEM_TRANSMASTER item in fOODITEM_TRANSMASTER)
            {
                if (hfIsLocation.Value == "1")
                {
                    item.IsAmountVisible = false;

                }
                else
                {
                    item.IsAmountVisible = true;
                }
            }


            gvTRANS.DataSource = fOODITEM_TRANSMASTER;
            gvTRANS.DataBind();
            Label lblSubTotalSendingAmount = (Label)e.Row.FindControl("lblSubTotalSendingAmount");
            lblSubTotalSendingAmount.Text = fOODITEM_TRANSMASTER.Sum(x => x.TOTALAMT).ToString();

            if (hfIsLocation.Value == "1")
            {
                lblSubTotalSendingAmount.Visible = false;

            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void ddlAgent_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadLocation();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        int searchAmount = 0;
        searchAmount = int.Parse(txtMoney.Text == "" ? "0" : txtMoney.Text);
        Response.Redirect("ReportViewFoodLocation.aspx?status=" + loadStatus() + "&locationID=" + getLocationIDs() + "&fromDate=" + txtFromDate.Text + "&toDate=" + txtToDate.Text + "&amount=" + searchAmount.ToString() + "&agentID=" + ddlAgent.SelectedValue + "");

        //Session["status"] = loadStatus().ToString();
        //Session["locationID"] = getLocationIDs().ToString();
        //Session["fromDate"] = txtFromDate.Text.ToString();
        //Session["toDate"] = txtToDate.Text;
        //Session["amount"] = searchAmount.ToString();
        //Session["agentID"] = ddlAgent.SelectedValue.ToString();
        //Response.Redirect("ReportViewFoodLocation.aspx");

    }
    protected void btnSearchByRefCode_Click(object sender, EventArgs e)
    {

    }

    protected void btnIsPending_Click(object sender, EventArgs e)
    {


    }



}