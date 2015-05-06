using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class EditFoodPayment : System.Web.UI.Page
{
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


                if (Session["aGENT"] != null)
                {
                    if (Session["userType"].ToString() == "Agent")//&& ((AGENT)Session["aGENT"]).AGENTID == 4)
                    {
                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnReturn.Visible = true;
                    }
                    else
                    {
                        btnUpdate.Visible = true;
                        hfIsLocation.Value = "1";
                    }
                }
                else
                if (Session["lOCATION"] != null)
                {
                    hfIsLocation.Value = "1";
                }
                if (Request.QueryString["REFCODE"] != null)
                {
                    showFoodTRANSData(Request.QueryString["REFCODE"]);
                    txtReferenceCode.Text = Request.QueryString["REFCODE"];
                    hfReferenceCode.Value = Request.QueryString["REFCODE"];
                }
            }

        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            updateFoodItemMaster("SAME");
            updateFoodItemDetails();
            lblMessage.Text = "Update Successfully.....";
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.ToString();
        }
    }

    protected void updateFoodItemMaster(string transStatus)
    {

        //    FOODITEM_TRANSMASTER fOODITEM_TRANSMASTER = new FOODITEM_TRANSMASTER();
        //fOODITEM_TRANSMASTER = FOODITEM_TRANSMASTERManager.GetFOODITEM_TRANSMASTERByID(Int32.Parse(Request.QueryString["fOODITEM_TRANSMASTERID"]));
        AGENT aGENT = (AGENT)Session["aGENT"];
        DateTime nullDate = DateTime.Parse(ConfigurationManager.AppSettings["NULL_DATE"].ToString());

        FOODITEM_TRANSMASTER fOODITEM_TRANSMASTER = new FOODITEM_TRANSMASTER();
        fOODITEM_TRANSMASTER = FOODITEM_TRANSMASTERManager.GetFOODITEM_TRANSMASTERByRefCode(hfReferenceCode.Value);


        FOODITEM_TRANSMASTER tempFOODITEM_TRANSMASTER = new FOODITEM_TRANSMASTER();
        tempFOODITEM_TRANSMASTER.FOODITEM_TRANSMASTERID = fOODITEM_TRANSMASTER.FOODITEM_TRANSMASTERID;

        tempFOODITEM_TRANSMASTER.TDATE = fOODITEM_TRANSMASTER.TDATE;
        tempFOODITEM_TRANSMASTER.CID = fOODITEM_TRANSMASTER.CID;
        tempFOODITEM_TRANSMASTER.LID = fOODITEM_TRANSMASTER.LID;
        tempFOODITEM_TRANSMASTER.AID = fOODITEM_TRANSMASTER.AID;
        tempFOODITEM_TRANSMASTER.TOTALAMT = decimal.Parse(lblTotalAmount.Text);
        if (transStatus == "SAME") tempFOODITEM_TRANSMASTER.TRANSSTATUS = fOODITEM_TRANSMASTER.TRANSSTATUS;
        else
        {
            tempFOODITEM_TRANSMASTER.TRANSSTATUS = transStatus;
        }
        tempFOODITEM_TRANSMASTER.REFCODE = fOODITEM_TRANSMASTER.REFCODE;
        tempFOODITEM_TRANSMASTER.RECID = fOODITEM_TRANSMASTER.RECID;
        tempFOODITEM_TRANSMASTER.RECDATE = fOODITEM_TRANSMASTER.RECDATE;
        tempFOODITEM_TRANSMASTER.STOREID = fOODITEM_TRANSMASTER.STOREID;
        tempFOODITEM_TRANSMASTER.CREATEDON = fOODITEM_TRANSMASTER.CREATEDON;
        tempFOODITEM_TRANSMASTER.CREATEDBY = fOODITEM_TRANSMASTER.CREATEDBY;
        tempFOODITEM_TRANSMASTER.UPDATEDON = DateTime.Now;

        tempFOODITEM_TRANSMASTER.UPDATEDBY = aGENT.AGENTID;
        bool result = FOODITEM_TRANSMASTERManager.UpdateFOODITEM_TRANSMASTER(tempFOODITEM_TRANSMASTER);
    }

    protected void updateFoodItemDetails()
    {


        bool result = FOODITEM_TRANSDETAILManager.DeleteFOODITEM_TRANSDETAILByTID(Convert.ToInt32(hfFOODTRANSID.Value.ToString()));

        //if (result == true)
        {
            FOODITEM_TRANSDETAIL fOODITEM_TRANSDETAIL = new FOODITEM_TRANSDETAIL();
            for (int i = 0; i < gvFoodTransactionItemRelation.Rows.Count; i++)
            {


                Label lblfID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblfID");
                Label lblfRATE = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblfRATE");
                Label lblfQTY = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblfQTY");


                Label lblCUSTID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblCUSTID");
                Label lblLOCATIONID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblLOCATIONID");
                Label lblRECEIVERID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblRECEIVERID");


                fOODITEM_TRANSDETAIL.TID = int.Parse(hfFOODTRANSID.Value.ToString());
                fOODITEM_TRANSDETAIL.FID = Int32.Parse(lblfID.Text);
                fOODITEM_TRANSDETAIL.FRATE = decimal.Parse(lblfRATE.Text);
                fOODITEM_TRANSDETAIL.FQTY = Int32.Parse(lblfQTY.Text);
                fOODITEM_TRANSDETAIL.CREATEDON = DateTime.Now;
                fOODITEM_TRANSDETAIL.CREATEDBY = 1;
                fOODITEM_TRANSDETAIL.UPDATEDON = DateTime.Now;
                fOODITEM_TRANSDETAIL.UPDATEDBY = 1;
                int resutl = FOODITEM_TRANSDETAILManager.InsertFOODITEM_TRANSDETAIL(fOODITEM_TRANSDETAIL);

            }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            //bool result = FOODITEM_TRANSMASTERManager.DeleteFOODITEM_TRANSMASTER(Convert.ToInt32(hfFOODTRANSID.Value.ToString()));
            //bool result1 = FOODITEM_TRANSDETAILManager.DeleteFOODITEM_TRANSDETAILByTID(Convert.ToInt32(hfFOODTRANSID.Value.ToString()));

            updateFoodItemMaster("VOID");
            updateFoodItemDetails();

            //Response.Redirect("~/Default.aspx");
            //lblMessage.Text = "Delete Successfully..........";
        }

        catch (Exception ex)
        {
            lblMessage.Text = ex.ToString();
        }

    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        updateFoodItemMaster("RETURN");
        updateFoodItemDetails();

        lblMessage.Text = "Canceled Successfully..........";
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (hfReferenceCode.Value != "")
        {
            printReport();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        showFoodTRANSData(txtReferenceCode.Text);
        hfReferenceCode.Value = txtReferenceCode.Text;
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

    private void showFoodTRANSData(string refCode)
    {

        FOODITEM_TRANSMASTER fOODITEM_TRANSMASTER = new FOODITEM_TRANSMASTER();
        fOODITEM_TRANSMASTER = FOODITEM_TRANSMASTERManager.GetFOODITEM_TRANSMASTERByRefCode(refCode);


        if (fOODITEM_TRANSMASTER == null)
        {
            panData.Visible = false;
            panSearch.Visible = true;
        }
        else
        {
            panData.Visible = true;
            panSearch.Visible = true;

            int senderID = fOODITEM_TRANSMASTER.CID;
            int receiverID = fOODITEM_TRANSMASTER.RECID;
            int locationID = fOODITEM_TRANSMASTER.LID;
            int fOODITEM_TRANSMASTERID = fOODITEM_TRANSMASTER.FOODITEM_TRANSMASTERID;

            hfCUSTID.Value = senderID.ToString();
            hfRECID.Value = receiverID.ToString();
            hfFOODTRANSID.Value = fOODITEM_TRANSMASTERID.ToString();







            loadSenderInfo(senderID);
            loadReceiverInfo(receiverID);
            loadLocation(locationID);
            GetlocationInfo();

            loadFoodItemGrid(fOODITEM_TRANSMASTERID);
            CalculateTotalAmount();
        }

    }

    protected void loadFoodItemGrid(int fOODITEM_TRANSMASTERID)
    {
        List<FOODITEM_TRANSMASTERDETAIL> fOODITEM_TRANSMASTERDETAIL = new List<FOODITEM_TRANSMASTERDETAIL>();
        fOODITEM_TRANSMASTERDETAIL = FOODITEM_TRANSDETAILManager.GetAllFOODITEM_TRANSDETAILByFoodTransID(fOODITEM_TRANSMASTERID);

        //Label1.Text = fOODITEM_TRANSMASTERDETAIL.Count.ToString();

        foreach (FOODITEM_TRANSMASTERDETAIL item in fOODITEM_TRANSMASTERDETAIL)
        {
            if (hfIsLocation.Value == "1")
            {
                item.IsAgent = false;
                trTotalAmount.Visible = false;
            }
            else
            {
                item.IsAgent = true;
            }
        }

        gvFoodTransactionItemRelation.DataSource = fOODITEM_TRANSMASTERDETAIL;
        gvFoodTransactionItemRelation.DataBind();

        //Label1.Text = fOODITEM_TRANSMASTERDETAIL[0].LOCATIONID.ToString();

    }

    protected void loadSenderInfo(int senderID)
    {

        CUSTOMER cUSTOMER = new CUSTOMER();
        cUSTOMER = CUSTOMERManager.GetCUSTOMERByID(senderID);
        txtCustFirstName.Text = cUSTOMER.CUSTFNAME.ToString();
        txtCustMiddleName.Text = cUSTOMER.CUSTMNAME.ToString();
        txtCustLastName.Text = cUSTOMER.CUSTLNAME.ToString();

    }

    protected void loadReceiverInfo(int receiverID)
    {
        RECEIVER rECEIVER = new RECEIVER();
        rECEIVER = RECEIVERManager.GetRECEIVERByID(receiverID);
        txtReceiverFirstName.Text = rECEIVER.RECEIVERFNAME.ToString();
        txtReceiverMiddleName.Text = rECEIVER.RECEIVERMNAME.ToString();
        txtReceiverLastName.Text = rECEIVER.RECEIVERLNAME.ToString();

    }
    protected void loadLocation(int locationID)
    {
        ddlLoction.Items.Clear();
        ListItem li = new ListItem("Select Loction", "0");
        ddlLoction.Items.Add(li);


        List<LOCATION> lOCATIONS = new List<LOCATION>();
        if (Session["aGENT"] != null)
        {
            lOCATIONS = LOCATIONManager.GetAllLOCATIONs().FindAll(x => x.AGENTID == ((AGENT)Session["aGENT"]).AGENTID);
        }
        else
        {
            lOCATIONS = LOCATIONManager.GetAllLOCATIONs();
        }
        foreach (LOCATION location in lOCATIONS)
        {
            if (location.SEQUENCE == 0)
            {
                ListItem listItems = new ListItem(location.COUNTRY.ToString() + "--" + location.CITY.ToString() + "--" + location.BRANCH.ToString(), location.LOCATIONID.ToString());

                ddlLoction.Items.Add(listItems);
            }
        }

        ddlLoction.DataBind();

        ddlLoction.SelectedValue = locationID.ToString();
    }


    protected void ddlLoction_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetlocationInfo();
    }


    protected void GetlocationInfo()
    {
        LOCATION lOCATION = new LOCATION();

        lOCATION = LOCATIONManager.GetLOCATIONByID(int.Parse(ddlLoction.SelectedItem.Value.ToString()));
        if (lOCATION != null)
        {
            txtCountry.Text = lOCATION.COUNTRY.ToString();
            txtCity.Text = lOCATION.CITY.ToString();
            txtBranch.Text = lOCATION.BRANCH.ToString();
            loadFoodItem(LOCATIONMAPPINGManager.GetLOCATIONMAPPINGByLOCATIONID(int.Parse(ddlLoction.SelectedItem.Value.ToString()))[0].LOCATIONGROUPID);
        }
    }
    protected void ddlFoodItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        FOODITEM_MASTER foodItem = new FOODITEM_MASTER();
        foodItem = FOODITEM_MASTERManager.GetFOODITEM_MASTERByID(int.Parse(ddlFoodItem.SelectedItem.Value.ToString()));

        if (foodItem != null)
        {
            txtFoodRate.Text = foodItem.RATE.ToString();
        }
        txtFoodQuantity.Text = "1";
    }

    protected void loadFoodItem(int locationID)
    {
        ddlFoodItem.Items.Clear();
        ListItem li = new ListItem("Select Food Item", "0");
        ddlFoodItem.Items.Add(li);

        List<FOODITEM_MASTER> foodItems = new List<FOODITEM_MASTER>();
        foodItems = FOODITEM_MASTERManager.GetAllFOODITEM_MASTERs();
        foreach (FOODITEM_MASTER foodItem in foodItems)
        {
            if (foodItem.SEQ == locationID)
            {
                ListItem items = new ListItem(foodItem.ITEMNAME.ToString(), foodItem.FOODITEM_MASTERID.ToString());

                ddlFoodItem.Items.Add(items);
            }
        }

        ddlFoodItem.DataBind();
    }
    protected void btnAddItem_Click(object sender, EventArgs e)
    {

        loadFoodTransSession();
        CalculateTotalAmount();
    }

    protected void gvFoodTransactionItemRelation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblfID = (Label)e.Row.FindControl("lblfID");
            Label lblFoodItem = (Label)e.Row.FindControl("lblFoodItem");

            Label lblfRATE = (Label)e.Row.FindControl("lblfRATE");
            Label lblfQTY = (Label)e.Row.FindControl("lblfQTY");
            Label lblSubTotal = (Label)e.Row.FindControl("lblSubTotal");
            Label lblTOTALAMT = (Label)e.Row.FindControl("lblTOTALAMT");


            Label lblCUSTID = (Label)e.Row.FindControl("lblCUSTID");
            Label lblLOCATIONID = (Label)e.Row.FindControl("lblLOCATIONID");
            Label lblRECEIVERID = (Label)e.Row.FindControl("lblRECEIVERID");

            Label lblCUSTFname = (Label)e.Row.FindControl("lblCUSTFname");
            Label lblLOCATIONName = (Label)e.Row.FindControl("lblLOCATIONName");
            Label lblRECEIVERFname = (Label)e.Row.FindControl("lblRECEIVERFname");

            FOODITEM_MASTER foodItems = new FOODITEM_MASTER();
            foodItems = FOODITEM_MASTERManager.GetFOODITEM_MASTERByID(int.Parse(lblfID.Text));

            if (Items != null)
            {
                lblFoodItem.Text = foodItems.ITEMNAME.ToString();
            }



            //lblSubTotal.Text = (decimal.Parse(lblfRATE.Text) * int.Parse(lblfQTY.Text)).ToString();

            CUSTOMER cUSTOMER = new CUSTOMER();
            cUSTOMER = CUSTOMERManager.GetCUSTOMERByID(int.Parse(lblCUSTID.Text));
            if (cUSTOMER != null)
            {
                lblCUSTFname.Text = cUSTOMER.CUSTFNAME.ToString();
            }

            LOCATION lOCATION = new LOCATION();
            lOCATION = LOCATIONManager.GetLOCATIONByID(int.Parse(lblLOCATIONID.Text));

            if (lOCATION != null)
            {
                lblLOCATIONName.Text = lOCATION.BRANCH.ToString();
            }

            RECEIVER rECEIVER = new RECEIVER();
            rECEIVER = RECEIVERManager.GetRECEIVERByID(int.Parse(lblRECEIVERID.Text));

            if (rECEIVER != null)
            {
                lblRECEIVERFname.Text = rECEIVER.RECEIVERFNAME.ToString();
            }

            lblTOTALAMT.Text = lblTOTALAMT.Text;
        }
    }


    protected void loadFoodTransSession()
    {
        if (hfCUSTID.Value != "" && hfRECID.Value != "" && hfFOODTRANSID.Value != "")
        {
            int foodItemID = int.Parse(ddlFoodItem.SelectedItem.Value.ToString());
            decimal foodItemPrice = decimal.Parse(txtFoodRate.Text);
            int foodItemQty = int.Parse(txtFoodQuantity.Text);
            int FoodsenderID = int.Parse(hfCUSTID.Value.ToString());
            int FoodreceiverID = int.Parse(hfRECID.Value.ToString());
            int FoodlocationID = int.Parse(ddlLoction.SelectedItem.Value.ToString());

            List<FOODITEM_TRANSMASTERDETAIL> foodTransactionItemRelation = new List<FOODITEM_TRANSMASTERDETAIL>();

            if (gvFoodTransactionItemRelation.Rows.Count == 0)
            {
                foodTransactionItemRelation.Add(new FOODITEM_TRANSMASTERDETAIL(foodItemID, foodItemPrice, foodItemQty, foodItemPrice * foodItemQty, FoodsenderID, FoodlocationID, FoodreceiverID, foodItemPrice * foodItemQty));
            }
            else
            {
                int rowCount = gvFoodTransactionItemRelation.Rows.Count;

                for (int i = 0; i < rowCount; i++)
                {
                    Label lblfID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblfID");
                    Label lblfRATE = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblfRATE");
                    Label lblfQTY = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblfQTY");
                    Label lblSubTotal = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblSubTotal");
                    Label lblCUSTID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblCUSTID");
                    Label lblLOCATIONID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblLOCATIONID");
                    Label lblRECEIVERID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblRECEIVERID");
                    Label lblTOTALAMT = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblTOTALAMT");
                    foodTransactionItemRelation.Add(new FOODITEM_TRANSMASTERDETAIL(int.Parse(lblfID.Text), decimal.Parse(lblfRATE.Text), int.Parse(lblfQTY.Text), decimal.Parse(lblSubTotal.Text), int.Parse(lblCUSTID.Text), int.Parse(lblLOCATIONID.Text), int.Parse(lblRECEIVERID.Text), decimal.Parse(lblTOTALAMT.Text)));


                }

                foodTransactionItemRelation.Add(new FOODITEM_TRANSMASTERDETAIL(foodItemID, foodItemPrice, foodItemQty, foodItemPrice * foodItemQty, FoodsenderID, FoodlocationID, FoodreceiverID, foodItemPrice * foodItemQty));

            }

            loadFoodItemGrid(foodTransactionItemRelation);
        }
    }


    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;

        List<FOODITEM_TRANSMASTERDETAIL> foodTransactionItemRelation = new List<FOODITEM_TRANSMASTERDETAIL>();

        int rowCount = gvFoodTransactionItemRelation.Rows.Count;

        for (int i = 0; i < rowCount; i++)
        {
            Label lblfID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblfID");
            Label lblfRATE = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblfRATE");
            Label lblfQTY = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblfQTY");
            Label lblSubTotal = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblSubTotal");
            Label lblCUSTID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblCUSTID");
            Label lblLOCATIONID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblLOCATIONID");
            Label lblRECEIVERID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblRECEIVERID");
            Label lblTOTALAMT = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblTOTALAMT");

            if (lblfID.Text != linkButton.CommandArgument.ToString())
            {
                foodTransactionItemRelation.Add(new FOODITEM_TRANSMASTERDETAIL(int.Parse(lblfID.Text), decimal.Parse(lblfRATE.Text), int.Parse(lblfQTY.Text), decimal.Parse(lblSubTotal.Text), int.Parse(lblCUSTID.Text), int.Parse(lblLOCATIONID.Text), int.Parse(lblRECEIVERID.Text), decimal.Parse(lblTOTALAMT.Text)));

            }


        }
        loadFoodItemGrid(foodTransactionItemRelation);

    }


    protected void loadFoodItemGrid(List<FOODITEM_TRANSMASTERDETAIL> fOODITEM_TRANSMASTERDETAIL)
    {
        gvFoodTransactionItemRelation.DataSource = fOODITEM_TRANSMASTERDETAIL;
        gvFoodTransactionItemRelation.DataBind();

        for (int i = 0; i < gvFoodTransactionItemRelation.Rows.Count; i++)
        {

            Label lblTOTALAMT = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblTOTALAMT");
            Label lblCUSTID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblCUSTID");
            Label lblLOCATIONID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblLOCATIONID");
            Label lblRECEIVERID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblRECEIVERID");

            lblTOTALAMT.Text = fOODITEM_TRANSMASTERDETAIL.Sum(x => x.SUBTOTAL).ToString();
        }

        CalculateTotalAmount();
    }


    protected void CalculateTotalAmount()
    {
        int rowCount = gvFoodTransactionItemRelation.Rows.Count;
        decimal totalAmount = 0;
        for (int i = 0; i < rowCount; i++)
        {

            Label lblSubTotal = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblSubTotal");

            totalAmount = totalAmount + decimal.Parse(lblSubTotal.Text);

        }
        lblTotalAmount.Text = totalAmount.ToString();
    }


    protected void printReport()
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "dsFoodReceipt_dtFoodReceipt";
        rds.Value = GetAllFOODITEM_TRANSMASTERByREFCODE();
        if (hfIsLocation.Value == "1")
        {
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/rptFoodItemReceiptLocation.rdlc");
        }
        else
        {
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/rptFoodItemReceipt.rdlc");
        }
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);



        //Export to PDF
        string mimeType;
        string encoding;
        string fileNameExtension;
        string[] streams;
        Microsoft.Reporting.WebForms.Warning[] warnings;

        byte[] pdfContent = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

        //Return PDF
        this.Response.Clear();
        this.Response.ContentType = "application/pdf";
        this.Response.AddHeader("Content-disposition", "attachment; filename=ReceiptReport.pdf");
        this.Response.BinaryWrite(pdfContent);
        this.Response.End();

        //lblMessage.Text = "sidguahduasudh";

    }

    protected DataTable GetAllFOODITEM_TRANSMASTERByREFCODE()
    {

        dt = new DataTable();
        dt = sqlFOODITEM_TRANSMASTERProvider.GetAllFOODITEM_TRANSMASTERByREFCODEForReport(hfReferenceCode.Value);
        return dt;
    }
}