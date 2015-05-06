using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Data;
public partial class FoodTransactionPage : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    SqlFOODITEM_TRANSMASTERProvider sqlFOODITEM_TRANSMASTERProvider = new SqlFOODITEM_TRANSMASTERProvider();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Remove("sessionFOODITEM_TRANSMASTERDETAIL");
            if (!User.Identity.IsAuthenticated)
            {
                Session.RemoveAll(); Response.Redirect("LogInPage.aspx");
            }
            else
            {
                reLoadSession();
            
                if (Session["snFoodsenderID"] != null && Session["snFoodreceiverID"] != null)// && Session["snFoodlocationID"] != null)
                {
                    loadLocation();
                    
                    loadAllData();
                    loadItemGrid();
                    //loadFoodTransSession();
                }
                else
                {
                    Response.Redirect("SearchFoodSenderPage.aspx");
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
        Session.Remove("snFoodsenderID");
        Session.Remove("snFoodreceiverID");
        Session.Remove("snFoodlocationID");
        Session.Remove("sessionFOODITEM_TRANSMASTERDETAIL");
        Response.Redirect("SearchFoodSenderPage.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }

    protected void loadAllData()
    {
        GetlocationInfo();
        loadSenderInfo();
        loadReceiverInfo();
        
        
    }

    protected void loadItemGrid()
    {
        if (Session["sessionFOODITEM_TRANSMASTERDETAIL"] != null)
        {

            List<FOODITEM_TRANSMASTERDETAIL> ssFOODITEM_TRANSMASTERDETAIL = new List<FOODITEM_TRANSMASTERDETAIL>();
            ssFOODITEM_TRANSMASTERDETAIL = (List<FOODITEM_TRANSMASTERDETAIL>)Session["sessionFOODITEM_TRANSMASTERDETAIL"];

            gvFoodTransactionItemRelation.DataSource = ssFOODITEM_TRANSMASTERDETAIL;
            gvFoodTransactionItemRelation.DataBind();

            for (int i = 0; i < gvFoodTransactionItemRelation.Rows.Count;i++ )
            {
                
                Label lblTOTALAMT = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblTOTALAMT");
                Label lblCUSTID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblCUSTID");
                Label lblLOCATIONID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblLOCATIONID");
                Label lblRECEIVERID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblRECEIVERID");


                List<FOODITEM_TRANSMASTERDETAIL> ssFOODITEM_TRANSMASTERDETAIL1 = new List<FOODITEM_TRANSMASTERDETAIL>();
                ssFOODITEM_TRANSMASTERDETAIL1 = ssFOODITEM_TRANSMASTERDETAIL.FindAll(x => x.CUSTID == int.Parse(lblCUSTID.Text) && x.LOCATIONID == int.Parse(lblLOCATIONID.Text) && x.RECEIVERID == int.Parse(lblRECEIVERID.Text));

                lblTOTALAMT.Text = ssFOODITEM_TRANSMASTERDETAIL1.Sum(x => x.SUBTOTAL).ToString();
            }

            CalculateTotalAmount();
        }
    }

    protected void loadFoodTransSession()
    {
        if (Session["snFoodsenderID"] != null && Session["snFoodreceiverID"] != null && Session["snFoodlocationID"] != null)
        {
        int foodItemID = int.Parse(ddlFoodItem.SelectedItem.Value.ToString());
        decimal foodItemPrice = decimal.Parse(txtFoodRate.Text);
        int foodItemQty = int.Parse(txtFoodQuantity.Text);
        int FoodsenderID = int.Parse(Session["snFoodsenderID"].ToString() );
        int FoodreceiverID= int.Parse(Session["snFoodreceiverID"].ToString() );
        int FoodlocationID = int.Parse(Session["snFoodlocationID"].ToString());

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
        Session["sessionFOODITEM_TRANSMASTERDETAIL"] = foodTransactionItemRelation;

        loadItemGrid();
                }
    }
    

    protected void loadSenderInfo()
    {

        CUSTOMER cUSTOMER = new CUSTOMER();
        cUSTOMER = CUSTOMERManager.GetCUSTOMERByID(int.Parse(Session["snFoodsenderID"].ToString()));
        txtCustFirstName.Text = cUSTOMER.CUSTFNAME.ToString();
        txtCustMiddleName.Text = cUSTOMER.CUSTMNAME.ToString();
        txtCustLastName.Text = cUSTOMER.CUSTLNAME.ToString();

    }

    protected void loadReceiverInfo()
    {
        RECEIVER rECEIVER = new RECEIVER();
        rECEIVER = RECEIVERManager.GetRECEIVERByID(int.Parse(Session["snFoodreceiverID"].ToString()));
        txtReceiverFirstName.Text = rECEIVER.RECEIVERFNAME.ToString();
        txtReceiverMiddleName.Text = rECEIVER.RECEIVERMNAME.ToString();
        txtReceiverLastName.Text = rECEIVER.RECEIVERLNAME.ToString();

    }
    protected void loadLocation()
    {
        ddlLoction.Items.Clear();
        ListItem li = new ListItem("Select Loction", "0");
        ddlLoction.Items.Add(li);


        List<LOCATION> lOCATIONS = new List<LOCATION>();
        lOCATIONS = LOCATIONManager.GetAllLOCATIONsFood().FindAll(x => x.AGENTID == ((AGENT)Session["aGENT"]).AGENTID);

        foreach (LOCATION location in lOCATIONS)
        {
            if (location.SEQUENCE == 0)
            {
                ListItem listItems = new ListItem(location.COUNTRY.ToString() + "--" + location.CITY.ToString() + "--" + location.BRANCH.ToString(), location.LOCATIONID.ToString());

                ddlLoction.Items.Add(listItems);
            }
        }

        ddlLoction.DataBind();

        ddlLoction.SelectedValue = Session["snFoodlocationID"].ToString();
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

            
            //if (txtCity.Text == "GUI-FOOD")
            //{
                loadFoodItem(LOCATIONMAPPINGManager.GetLOCATIONMAPPINGByLOCATIONID(int.Parse(ddlLoction.SelectedItem.Value.ToString()))[0].LOCATIONGROUPID);
            //}
            //else
            //{
            //    loadFoodItem(1);
            //}

            Session["snFoodlocationID"] = ddlLoction.SelectedItem.Value.ToString();
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

    }
    protected void btnSaveTransaction_Click(object sender, EventArgs e)
     {
        try
        {
            if(Session["sessionFOODITEM_TRANSMASTERDETAIL"] !=null)
            {
            AGENT aGENT = (AGENT)Session["aGENT"];
            DateTime nullDate = DateTime.Parse(ConfigurationManager.AppSettings["NULL_DATE"].ToString());

            List<FOODITEM_TRANSMASTERDETAIL> fOODITEM_TRANSMASTERDETAIL_Ori = new List<FOODITEM_TRANSMASTERDETAIL>();
            fOODITEM_TRANSMASTERDETAIL_Ori=(List<FOODITEM_TRANSMASTERDETAIL>)Session["sessionFOODITEM_TRANSMASTERDETAIL"];
            List<FOODITEM_TRANSMASTERDETAIL> fOODITEM_TRANSMASTERDETAIL_Distinct = new List<FOODITEM_TRANSMASTERDETAIL>();
            int count = 0;
            for (int i = 0; i < fOODITEM_TRANSMASTERDETAIL_Ori.Count; i++)
            {
                count = fOODITEM_TRANSMASTERDETAIL_Distinct.FindAll(x => x.CUSTID == fOODITEM_TRANSMASTERDETAIL_Ori[i].CUSTID && x.LOCATIONID == fOODITEM_TRANSMASTERDETAIL_Ori[i].LOCATIONID && x.RECEIVERID == fOODITEM_TRANSMASTERDETAIL_Ori[i].RECEIVERID).Count;

                if (count == 0)
                {
                    fOODITEM_TRANSMASTERDETAIL_Distinct.Add(fOODITEM_TRANSMASTERDETAIL_Ori[i]);
                }

            }

            string refCode = string.Empty;

            for (int j = 0; j < fOODITEM_TRANSMASTERDETAIL_Distinct.Count; j++)
            {

                #region FoodItemTransMaster

                FOODITEM_TRANSMASTER fOODITEM_TRANSMASTER = new FOODITEM_TRANSMASTER();

                fOODITEM_TRANSMASTER.TDATE = DateTime.Now;
                fOODITEM_TRANSMASTER.CID = fOODITEM_TRANSMASTERDETAIL_Distinct[j].CUSTID;
                fOODITEM_TRANSMASTER.LID = int.Parse(Session["snFoodlocationID"].ToString());
                fOODITEM_TRANSMASTER.AID = aGENT.AGENTID;
                //fOODITEM_TRANSMASTER.TOTALAMT = fOODITEM_TRANSMASTERDETAIL_Distinct[j].TOTALAMT;
                fOODITEM_TRANSMASTER.TOTALAMT = decimal.Parse(lblTotalAmount.Text);
                fOODITEM_TRANSMASTER.TRANSSTATUS = "PENDING";
                fOODITEM_TRANSMASTER.REFCODE = txtReferenceCode.Text;
                fOODITEM_TRANSMASTER.RECID = fOODITEM_TRANSMASTERDETAIL_Distinct[j].RECEIVERID;
                fOODITEM_TRANSMASTER.RECDATE = nullDate;
                fOODITEM_TRANSMASTER.STOREID = 1;
                fOODITEM_TRANSMASTER.CREATEDON = DateTime.Now;
                fOODITEM_TRANSMASTER.CREATEDBY = aGENT.AGENTID;
                fOODITEM_TRANSMASTER.UPDATEDON = DateTime.Now;
                fOODITEM_TRANSMASTER.UPDATEDBY = aGENT.AGENTID;
                int resutlfOODITEM_TRANSMASTER = FOODITEM_TRANSMASTERManager.InsertFOODITEM_TRANSMASTER(fOODITEM_TRANSMASTER);

                #endregion


                FOODITEM_TRANSDETAIL fOODITEM_TRANSDETAIL = new FOODITEM_TRANSDETAIL();

                for (int i = 0; i < gvFoodTransactionItemRelation.Rows.Count; i++)
                {


                    Label lblfID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblfID");
                    Label lblfRATE = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblfRATE");
                    Label lblfQTY = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblfQTY");


                    Label lblCUSTID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblCUSTID");
                    Label lblLOCATIONID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblLOCATIONID");
                    Label lblRECEIVERID = (Label)gvFoodTransactionItemRelation.Rows[i].FindControl("lblRECEIVERID");

                    if (int.Parse(lblCUSTID.Text) == fOODITEM_TRANSMASTERDETAIL_Distinct[j].CUSTID && int.Parse(lblLOCATIONID.Text) == fOODITEM_TRANSMASTERDETAIL_Distinct[j].LOCATIONID && int.Parse(lblRECEIVERID.Text) == fOODITEM_TRANSMASTERDETAIL_Distinct[j].RECEIVERID)
                    {
                    fOODITEM_TRANSDETAIL.TID = resutlfOODITEM_TRANSMASTER;
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




                lblReferenceCODE.Text =FOODITEM_TRANSMASTERManager.GetFOODITEM_TRANSMASTERByID(resutlfOODITEM_TRANSMASTER).REFCODE.ToString();// +"<br/>" + refCode.ToString();
                refCode = lblReferenceCODE.Text;

            }





            //lblmessage.Text = resutlfOODITEM_TRANSMASTER.ToString();
            lblmessage.Text = "Food Transfer Successfully.. ";
            lblText.Text = "Reference CODE: ";
            //lblReferenceCODE.Text= FOODITEM_TRANSMASTERManager.GetFOODITEM_TRANSMASTERByID(resutlfOODITEM_TRANSMASTER).REFCODE ;
            
        }
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.ToString();
        }
    
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


    protected void gvFoodTransactionItemRelation_RowDataBound(object sender,GridViewRowEventArgs e)
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
            lblSubTotal.Text = (decimal.Parse(lblfRATE.Text) * int.Parse(lblfQTY.Text)).ToString();

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


        }
    }
    protected void btnAnotherTransaction_Click(object sender, EventArgs e)
    {
        Session.Remove("snFoodreceiverID");
        Session.Remove("snFoodlocationID");
        Session.Remove("sessionFOODITEM_TRANSMASTERDETAIL");
        Response.Redirect("SearchFoodReceiverPage.aspx");
       
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (lblReferenceCODE.Text != "")
        {
            printReport();
        }
    }

    protected void printReport()
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "dsFoodReceipt_dtFoodReceipt";
        rds.Value = GetAllFOODITEM_TRANSMASTERByREFCODE();
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/rptFoodItemReceipt.rdlc");
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
        dt = sqlFOODITEM_TRANSMASTERProvider.GetAllFOODITEM_TRANSMASTERByREFCODEForReport(lblReferenceCODE.Text);
        return dt;
    }
}