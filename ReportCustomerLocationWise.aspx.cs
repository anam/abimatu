//using System;
//using System.Data;
//using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Collections.Generic;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.html;
//using System.IO;
//using System.Collections;
//using System.Net;
//using iTextSharp;

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections;
using System.Net;
using Microsoft.Reporting.WebForms;

public partial class AgentWiseReport : System.Web.UI.Page
{
    public string status = "";
    
    DataTable dt = new DataTable();
    SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
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
            loadReceiver();

            

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
                    locations = LOCATIONManager.GetAllLOCATIONsByAgentIDnGroupID(int.Parse(ddlAgent.SelectedItem.Value), int.Parse(hfLoggedinLocationID.Value));
                }
                else
                {
                    locations = LOCATIONManager.GetAllLOCATIONsByGroupID(int.Parse(hfLoggedinLocationID.Value));
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
                        locations = LOCATIONManager.GetAllLOCATIONsByAgentID(int.Parse(ddlAgent.SelectedItem.Value));
                    }
                    else
                    {
                        locations = LOCATIONManager.GetAllLOCATIONs();
                    }
                }
                else
                {
                    locations = LOCATIONManager.GetAllLOCATIONsByAgentID(int.Parse(hfAgentID.Value));
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

    private string getReceiverIDs()
    {
        string receiverIDs = "";

        foreach (GridViewRow gr in gvReciver.Rows)
        {
            CheckBox chkSelect = (CheckBox)gr.FindControl("chkSelect");

            HiddenField hfReceiverID = (HiddenField)gr.FindControl("hfReceiverID");

            if (chkSelect.Checked || chkAllReceivers.Checked)
            {
                if (receiverIDs == "") receiverIDs = hfReceiverID.Value;
                else receiverIDs += "," + hfReceiverID.Value;
            }
        }
        //}
        return receiverIDs;
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
        lblmessage.Text = "";

        
        loadReport();

        gvLocation.Visible = true;
        tblTotal.Visible = true;
        gvRECEIVER.Visible = true;

        divListOfAllTransaction.Visible = true;
        tblTotal.Visible = true;
        divPayment.Visible = false;
    }

    protected void btnSearchByRefCode_Click(object sender, EventArgs e)
    {

        gvLocation.Visible = false;
        tblTotal.Visible = false;
        gvRECEIVER.Visible = true;
        
        if (txtRefCodeForSearch.Text == "")
        {
            return;
        }

        TRANS tRANS = TRANSManager.GetTRANSByRefCode(txtRefCodeForSearch.Text);

        if (tRANS == null)
        {
            lblmessage.Text = "No Trasaction Found for that Ref. Code<br/>Please give correct Ref. Code";
            lblmessage.ForeColor = System.Drawing.Color.Red;

            divListOfAllTransaction.Visible = false;
            tblTotal.Visible = false;
            divPayment.Visible = false;

            return;
        }
        else
        {
            if (tRANS.TRANSSTATUS != "PENDING")
            {
                lblmessage.Text = "This trasaction already Paid.<br/>Please give another Ref. Code";
                lblmessage.ForeColor = System.Drawing.Color.Red;
                
                divListOfAllTransaction.Visible = false;
                tblTotal.Visible = false;
                divPayment.Visible = false;

                return;
            }
        }

        //Load Transfer info
        lblTransavtionAmount.Text = tRANS.TRANSAMOUNT.ToString();
        lblREFCODE.Text = txtRefCodeForSearch.Text;
        lblFees.Text = tRANS.TRANSFEES.ToString();
        lblOtherFees.Text = tRANS.TRANSOTHERFEES.ToString();
        lblDiscount.Text = tRANS.TRANSPROMOCODE.ToString();
        lblTotalAmount.Text = tRANS.TRANSTOTALAMOUNT.ToString();

        
        divPayment.Visible = true;

        int tRANSID;
        tRANSID = tRANS.TRANSID;

        txtTestAnswer.Text = tRANS.TESTANSWER;
        txtTestQuestion.Text = tRANS.TESTQUESTION;

        hfTransID.Value = tRANS.TRANSID.ToString();

        txtMemberID.Text = tRANS.RECEIVERID.ToString();
        txtMemberID.Enabled = false;

        cleanElements();
        List<RECEIVER> receivers = new List<RECEIVER>();
        receivers = searchMemberInfo();

        txtAddress.Text = receivers[0].RECEIVERADDRESS1;
        txtRECEIVERFNAME.Text = receivers[0].RECEIVERFNAME;
        txtRECEIVERMNAME.Text = receivers[0].RECEIVERMNAME;
        txtRECEIVERLNAME.Text = receivers[0].RECEIVERLNAME;
        txtCity.Text = receivers[0].RECEIVERCITY;
        txtPhoneNumber.Text = receivers[0].RECEIVERPHONE;
        txtState.Text = receivers[0].RECEIVERSTATE;
        txtZIP.Text = receivers[0].RECEIVERZIP; 
    }
    private void loadReport()
    {

        gvLocation.DataSource = LOCATIONManager.GetAllLOCATIONsForReportByDatenAmountCustomerIDs(Request.QueryString["CUSTIDs"], getReceiverIDs(), int.Parse(ddlAgent.SelectedValue), txtFromDate.Text, txtToDate.Text, int.Parse(txtMoney.Text == "" ? "0" : txtMoney.Text));
        gvLocation.DataBind();

        lblSubTotalSendingAmountTotal.Text = string.Format("{0:C}", double.Parse(lblSubTotalSendingAmountTotal.Text));
        lblSubTotalFeesTotal.Text = string.Format("{0:C}", double.Parse(lblSubTotalFeesTotal.Text));
        lblSubTotalDiscountTotal.Text = string.Format("{0:C}", double.Parse(lblSubTotalDiscountTotal.Text));
        lblSubTotalTotalAmountTotal.Text = string.Format("{0:C}", double.Parse(lblSubTotalTotalAmountTotal.Text));
    }
    protected void gvLocation_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hfLocationID = (HiddenField)e.Row.FindControl("hfLocationID");
            GridView gvTRANS = (GridView)e.Row.FindControl("gvTRANS");

            List<TRANS> tRANSs = new List<TRANS>();
            tRANSs = TRANSManager.GetTRANSByAgnetIDnLocationIDByDateNAmountCustomerID(Request.QueryString["CUSTIDs"], getReceiverIDs(), int.Parse(hfLocationID.Value), int.Parse(ddlAgent.SelectedValue), txtFromDate.Text, txtToDate.Text, int.Parse(txtMoney.Text == "" ? "0" : txtMoney.Text));

            decimal sendingAmount = 0;
            decimal fees = 0;
            decimal discount = 0;
            decimal Total = 0;

            foreach (TRANS tRANS in tRANSs)
            {

                sendingAmount += tRANS.TRANSAMOUNT;
              
                fees += tRANS.TRANSFEES;//+ tRANS.TRANSOTHERFEES; because in the sp we have added already
                discount += decimal.Parse(tRANS.TRANSPROMOCODE);
                Total += tRANS.TRANSTOTALAMOUNT;

                if (Session["userType"].ToString() != "Location")
                {
                    tRANS.IsPending = false;
                    //if (((AGENT)Session["aGENT"]).AGENTID == 4)//if the admin
                    //{
                    tRANS.IsEdit = true;
                    //}
                    //else
                    //{
                    //    tRANS.IsEdit = false;
                    //}

                }
                else
                {
                    tRANS.IsEdit = false;
                }
            }

            gvTRANS.DataSource = tRANSs;
            gvTRANS.DataBind();

            

            Label lblSubTotalSendingAmount = (Label)e.Row.FindControl("lblSubTotalSendingAmount");
            Label lblSubTotalFees = (Label)e.Row.FindControl("lblSubTotalFees");
            Label lblSubTotalDiscount = (Label)e.Row.FindControl("lblSubTotalDiscount");
            Label lblSubTotalTotalAmount = (Label)e.Row.FindControl("lblSubTotalTotalAmount");

            lblSubTotalSendingAmount.Text = string.Format("{0:C}", double.Parse(sendingAmount.ToString()));
            lblSubTotalFees.Text = string.Format("{0:C}", double.Parse(fees.ToString()));
            lblSubTotalDiscount.Text = string.Format("{0:C}", double.Parse(discount.ToString()));
            lblSubTotalTotalAmount.Text = string.Format("{0:C}", double.Parse(Total.ToString()));

            lblSubTotalSendingAmountTotal.Text = string.Format("{0}", double.Parse(lblSubTotalSendingAmountTotal.Text) + double.Parse(sendingAmount.ToString()));
            lblSubTotalFeesTotal.Text = string.Format("{0}", double.Parse(lblSubTotalFeesTotal.Text) + double.Parse(fees.ToString()));
            lblSubTotalDiscountTotal.Text = string.Format("{0}", double.Parse(lblSubTotalDiscountTotal.Text) + double.Parse(discount.ToString()));
            lblSubTotalTotalAmountTotal.Text = string.Format("{0}", double.Parse(lblSubTotalTotalAmountTotal.Text) + double.Parse(Total.ToString()));

            lblTotalno.Text = (tRANSs.Count + int.Parse(lblTotalno.Text)).ToString();

            if (Total > 0) tblTotal.Visible = true;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void btnIsPending_Click(object sender, EventArgs e)
    {
        divPayment.Visible = true;

        Button linkButton = new Button();
        linkButton = (Button)sender;
        int tRANSID;
        tRANSID = Convert.ToInt32(linkButton.CommandArgument);

        TRANS tRANS = TRANSManager.GetTRANSByID(tRANSID);
        
        txtTestAnswer.Text = tRANS.TESTANSWER;
        txtTestQuestion.Text = tRANS.TESTQUESTION;

        hfTransID.Value = tRANS.TRANSID.ToString();
        
        txtMemberID.Text = tRANS.RECEIVERID.ToString();
        txtMemberID.Enabled = false;

        //Load Transfer info
        lblTransavtionAmount.Text = tRANS.TRANSAMOUNT.ToString();
        hfCauseOtherServiceChages.Value = tRANS.CAUSETRANSOTHERFEES;
        lblREFCODE.Text = tRANS.REFCODE.ToString();
        lblFees.Text = tRANS.TRANSFEES.ToString();
        lblOtherFees.Text = tRANS.TRANSOTHERFEES.ToString();
        lblDiscount.Text = tRANS.TRANSPROMOCODE.ToString();
        lblTotalAmount.Text = tRANS.TRANSTOTALAMOUNT.ToString();

        cleanElements();
        List<RECEIVER> receivers = new List<RECEIVER>();
        receivers=searchMemberInfo();

        txtAddress.Text = receivers[0].RECEIVERADDRESS1;
        txtRECEIVERFNAME.Text = receivers[0].RECEIVERFNAME;
        txtRECEIVERMNAME.Text = receivers[0].RECEIVERMNAME;
        txtRECEIVERLNAME.Text= receivers[0].RECEIVERLNAME;
        txtCity.Text = receivers[0].RECEIVERCITY;
        txtPhoneNumber.Text = receivers[0].RECEIVERPHONE;
        txtState.Text = receivers[0].RECEIVERSTATE;
        txtZIP.Text = receivers[0].RECEIVERZIP;

        CUSTOMER cUSTOMER = new CUSTOMER();
        cUSTOMER = CUSTOMERManager.GetCUSTOMERByID(tRANS.CUSTID);

        if (cUSTOMER != null)
        {
            txtCUSName.Text = cUSTOMER.CUSTFNAME.ToString() + " " + cUSTOMER.CUSTMNAME.ToString() + " " + cUSTOMER.CUSTLNAME.ToString();
            txtCUSAddress1.Text = cUSTOMER.CUSTADDRESS1.ToString();
            txtCUSAddress2.Text = cUSTOMER.CUSTADDRESS2.ToString();
            txtCUSCity.Text = cUSTOMER.CUSTCITY.ToString();
            txtCUSState.Text = cUSTOMER.CUSTSTATE.ToString();
            txtCUSZIP.Text = cUSTOMER.CUSTZIP.ToString();
            txtCUSPhoneNumber.Text = cUSTOMER.CUSTWPHONE.ToString();

        }

    }

    private void cleanElements()
    {
        txtAddress.Text = "";
        txtRECEIVERFNAME.Text ="";
        txtRECEIVERMNAME.Text = "";
        txtRECEIVERLNAME.Text = "";
        txtCity.Text = "";
        txtPhoneNumber.Text = "";
        txtState.Text = "";
        txtZIP.Text = "";

        lblmessage.Text = "";
    }
    protected void btnSearchReceiver_Click(object sender, EventArgs e)
    {
        txtMemberID.Text = "";
        searchMemberInfo();
        gvRECEIVER.Visible = true;
    }

    protected void gvRECEIVER_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        gvRECEIVER.PageIndex = e.NewPageIndex;
        searchMemberInfo();
    }

    protected List<RECEIVER> searchMemberInfo()
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

        if (txtRECEIVERFNAME.Text == "")
        {
            membername = "-1";
        }
        else
        {
            membername = txtRECEIVERFNAME.Text;
            memberID = -1;
        }

        if (txtAddress.Text == "")
        {
            address = "-1";
        }
        else
        {
            address = txtAddress.Text;
            memberID = -1;
        }

        if (txtState.Text == "")
        {
            state = "-1";
        }
        else
        {
            state = txtState.Text;
            memberID = -1;
        }

        if (txtCity.Text == "")
        {
            city = "-1";
        }
        else
        {
            city = txtCity.Text;
            memberID = -1;
        }

        if (txtZIP.Text == "")
        {
            zip = "-1";
        }
        else
        {
            zip = txtZIP.Text;
            memberID = -1;
        }

        if (txtPhoneNumber.Text == "")
        {
            phonenumber = "-1";
        }
        else
        {
            phonenumber = txtPhoneNumber.Text;
            memberID = -1;
        }

        List<RECEIVER> receivers = new List<RECEIVER>();
        receivers = memberID != -1 ? RECEIVERManager.GetAllRECEIVERsForSearchByIDNew(memberID) : RECEIVERManager.GetAllRECEIVERsForSearch(-1, memberID, membername,address,city,state,zip,phonenumber);

        gvRECEIVER.DataSource = receivers;
        gvRECEIVER.DataBind();

        return receivers;
    }

    protected void btnProcessPaymentPartial_Click(object sender, EventArgs e)
    {
        processPayemnt("PARTIALLY-PAID");
    }

    private void processPayemnt(string status)
    {

        int receiverID = 0;
        receiverID = selecetedGridRow();

        if (gvRECEIVER.Visible)
        {
            //update the sender
            RECEIVER tempRECEIVER = new RECEIVER();
            tempRECEIVER.RECEIVERID = int.Parse(txtMemberID.Text);

            tempRECEIVER.USERNAME = "";
            tempRECEIVER.RECEIVERFNAME = txtRECEIVERFNAME.Text;
            tempRECEIVER.RECEIVERMNAME = txtRECEIVERMNAME.Text;
            tempRECEIVER.RECEIVERLNAME = txtRECEIVERLNAME.Text;
            tempRECEIVER.RECEIVERADDRESS1 = txtAddress.Text;
            tempRECEIVER.RECEIVERADDRESS2 = "";
            tempRECEIVER.RECEIVERCITY = txtCity.Text;
            tempRECEIVER.RECEIVERSTATE = txtState.Text;
            tempRECEIVER.RECEIVERZIP = txtZIP.Text;
            tempRECEIVER.RECEIVERPHONE = txtPhoneNumber.Text;
            tempRECEIVER.CREATEDBY = 1;
            tempRECEIVER.SCANURL = "";
            tempRECEIVER.CREATEDON = DateTime.Now;
            tempRECEIVER.UPDATEDBY = int.Parse(Session["userInfoID"].ToString());
            tempRECEIVER.UPDATEDON = DateTime.Now;
            bool result = RECEIVERManager.UpdateRECEIVER(tempRECEIVER);
        }
        else
        {
            //add receiver
            RECEIVER rECEIVER = new RECEIVER();

            rECEIVER.USERNAME = User.Identity.Name.ToString();
            rECEIVER.RECEIVERFNAME = txtRECEIVERFNAME.Text;
            rECEIVER.RECEIVERMNAME = txtRECEIVERMNAME.Text;
            rECEIVER.RECEIVERLNAME = txtRECEIVERLNAME.Text;
            rECEIVER.RECEIVERADDRESS1 = txtAddress.Text;
            rECEIVER.RECEIVERADDRESS2 = "";
            rECEIVER.RECEIVERCITY = txtCity.Text;
            rECEIVER.RECEIVERSTATE = txtState.Text;
            rECEIVER.RECEIVERZIP = txtZIP.Text;
            rECEIVER.RECEIVERPHONE = txtPhoneNumber.Text;
            rECEIVER.CREATEDBY = int.Parse(Session["userInfoID"].ToString());
            rECEIVER.CREATEDON = DateTime.Now;
            rECEIVER.UPDATEDBY = int.Parse(Session["userInfoID"].ToString());
            rECEIVER.UPDATEDON = DateTime.Now;
            rECEIVER.SCANURL = "";
            txtMemberID.Text = RECEIVERManager.InsertRECEIVER(rECEIVER).ToString();
        }

        //Process payment
        TRANS tempTRANS = new TRANS();
        tempTRANS.TRANSID = int.Parse(hfTransID.Value);

        tempTRANS.RECEIVERPHONENO = txtPhoneNumber.Text;
        tempTRANS.SENDEREMAILADDRESS = txtReceiverEmail.Text; //basically in DB there is no Receiver email id that is why we have given that here it will be the receiver id
        tempTRANS.CAUSETRANSOTHERFEES = hfCauseOtherServiceChages.Value + "\n" + txtCauseOtherServiceCharges.Text;
        tempTRANS.TRANSSTATUS = status;
        tempTRANS.TRANSRECEIVEDID = txtMemberID.Text;
        tempTRANS.TRANSRECEIVEDATE = DateTime.Now;
        tempTRANS.UPDATEDBY = int.Parse(Session["userInfoID"].ToString());//Session["lOCATION"] != null ? ((LOCATIONGROUP)Session["lOCATION"]).LOCATIONGROUPID : ((AGENT)Session["aGENT"]).AGENTID;
        tempTRANS.UPDATEDON = DateTime.Now;
        if (TRANSManager.UpdateTRANS_Paid(tempTRANS))
        {
            lblmessage.Text = "Payment done successfully...";
            lblmessage.ForeColor = System.Drawing.Color.Green;

            lblSubTotalSendingAmountTotal.Text = "0";
            lblSubTotalFeesTotal.Text = "0";
            lblSubTotalDiscountTotal.Text = "0";
            lblSubTotalTotalAmountTotal.Text = "0";
            if (txtRefCodeForSearch.Text != "")
            {
                txtRefCodeForSearch.Text = "";
                return;
            }
            loadReport();

            txtReceiverEmail.Text = "";
            divPayment.Visible = false;
        }
        else
        {
            lblmessage.Text = "Error found..";
            lblmessage.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnProcessPayment_Click(object sender, EventArgs e)
    {

        processPayemnt("PAID");

    }
    protected int selecetedGridRow()
    {
        int rowCount = 0;
        int id = 0;
        rowCount = gvRECEIVER.Rows.Count;

        for (int i = 0; i < rowCount; i++)
        {
            RadioButton rbtSelect = (RadioButton)gvRECEIVER.Rows[i].FindControl("rbtSelect");
            if (rbtSelect.Checked == true)
            {
                Label lblRECEIVERID = (Label)gvRECEIVER.Rows[i].FindControl("lblRECEIVERID");
                id = int.Parse(lblRECEIVERID.Text);
            }
        }

        return id;
    }
    protected void btnSelectReciver_Click(object sender, EventArgs e)
    {
        int receiverID = 0;
        receiverID = selecetedGridRow();

        txtMemberID.Text = receiverID.ToString();
        txtMemberID.Enabled = false;

        cleanElements();
        RECEIVER receiver = new RECEIVER();
        receiver = RECEIVERManager.GetRECEIVERByID(receiverID);

        txtAddress.Text = receiver.RECEIVERADDRESS1;
        txtRECEIVERFNAME.Text = receiver.RECEIVERFNAME;
        txtRECEIVERMNAME.Text = receiver.RECEIVERMNAME;
        txtRECEIVERLNAME.Text = receiver.RECEIVERLNAME;
        txtCity.Text = receiver.RECEIVERCITY;
        txtPhoneNumber.Text = receiver.RECEIVERPHONE;
        txtState.Text = receiver.RECEIVERSTATE;
        txtZIP.Text = receiver.RECEIVERZIP;
    }

    protected void btnNewReceiver_Click(object sener, EventArgs e)
    {
        cleanElements();
        txtMemberID.Text = "";
        gvRECEIVER.Visible = false;


    }


    protected void btnPrint_Click(object sender, EventArgs e)
    {
        printReport();
    }
    protected void ddlAgent_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadLocation();
        loadReceiver();
    }

    private void loadReceiver()
    {
        List<RECEIVER> receivers = RECEIVERManager.GetAllRECEIVERByAgentID(int.Parse(ddlAgent.SelectedValue), int.Parse(Request.QueryString["CUSTIDs"]));
        gvReciver.DataSource = receivers;
        gvReciver.DataBind();        
    }
    protected DataTable GetAllTransForLocationWise()
    {
        dt = new DataTable();
        dt = sqlTRANSProvider.GetAllTransForLocationWiseForReport(loadStatus(), getLocationIDs(), int.Parse(ddlAgent.SelectedValue), txtFromDate.Text, txtToDate.Text, int.Parse(txtMoney.Text == "" ? "0" : txtMoney.Text));
        //Label1.Text = dt.Rows.Count.ToString();
        //sqlTRANSProvider.GetAllTransForLocationWiseForReport("0", "0", 0, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString(), 0);
        return dt;
    }

    protected void printReport()
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "dsAllTrans_dtAllTrans";
        rds.Value = GetAllTransForLocationWise();
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/rptLocationWise.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);



        ////Export to PDF
        //string mimeType;
        //string encoding;
        //string fileNameExtension;
        //string[] streams;
        //Microsoft.Reporting.WebForms.Warning[] warnings;

        //byte[] pdfContent = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

        ////Return PDF
        //this.Response.Clear();
        //this.Response.ContentType = "application/pdf";
        //this.Response.AddHeader("Content-disposition", "attachment; filename=ReceiptReport.pdf");
        //this.Response.BinaryWrite(pdfContent);
        //this.Response.End();

        //lblMessage.Text = "sidguahduasudh";

    }
}