using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Data;
public partial class EditPayment : System.Web.UI.Page
{
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
                if (Request.QueryString["login"] != null)
                {
                    btnPaid.Visible = true;
                    btnPending.Visible = true;
                }

                if (Session["aGENT"] != null)
                {
                    if (Session["userType"].ToString() == "Agent")//&& ((AGENT)Session["aGENT"]).AGENTID == 4)
                    {
                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnReturn.Visible = true;
                        btnHOLDING.Visible = true;
                    }
                    else
                    {
                        btnUpdate.Visible = true;
                    }
                }
                if (Request.QueryString["REFCODE"] != null)
                {
                    showTRANSData(Request.QueryString["REFCODE"]);
                    txtReferenceCode.Text = Request.QueryString["REFCODE"];
                    hfReferenceCode.Value = Request.QueryString["REFCODE"];
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

    private void showTRANSData(string refCode)
    {


        TRANS tRANS = new TRANS();
        tRANS = TRANSManager.GetTRANSByRefCode(refCode);

        if (tRANS == null)
        {
            panData.Visible = false;
            panSearch.Visible = true;
        }
        else
        {
            panData.Visible = true;
            panSearch.Visible = true;

            int senderID = 0;
            int receiverID = 0;
            int locationID = 0;

            senderID = tRANS.CUSTID;
            receiverID = tRANS.RECEIVERID;
            locationID = tRANS.LOCATIONID;



            loadSenderInfo(senderID);
            loadReceiverInfo(receiverID);
            loadLocationInfo(locationID);




            txtSendingAmount.Text = tRANS.TRANSAMOUNT.ToString();
            txtServiceCharge.Text = tRANS.TRANSFEES.ToString();
            txtOtherServiceCharge.Text = tRANS.TRANSOTHERFEES.ToString();
            txtCauseOtherServiceCharges.Text = tRANS.CAUSETRANSOTHERFEES.ToString();
            txtDiscount.Text = tRANS.TRANSPROMOCODE.ToString();
            txtTotalCharge.Text = tRANS.TRANSTOTALAMOUNT.ToString();

            txtTestQuestion.Text = tRANS.TESTQUESTION.ToString();
            txtTestAnswer.Text = tRANS.TESTANSWER.ToString();
            lblStatus.Text = tRANS.TRANSSTATUS == "VOID" ? "Deleted" : tRANS.TRANSSTATUS.ToString();
            lblStatus.ForeColor = tRANS.TRANSSTATUS == "PAID" ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            calculateTotal();
        }






    }
    protected void loadSenderInfo(int senderID)
    {
        CUSTOMER cUSTOMER = new CUSTOMER();
        cUSTOMER = CUSTOMERManager.GetCUSTOMERByID(senderID);

        if (cUSTOMER != null)
        {
            txtName.Text = cUSTOMER.CUSTFNAME.ToString() + " " + cUSTOMER.CUSTMNAME.ToString() + " " + cUSTOMER.CUSTLNAME.ToString();
            txtAddress1.Text = cUSTOMER.CUSTADDRESS1.ToString();
            txtAddress2.Text = cUSTOMER.CUSTADDRESS2.ToString();
            txtCity.Text = cUSTOMER.CUSTCITY.ToString();
            txtState.Text = cUSTOMER.CUSTSTATE.ToString();
            txtZIP.Text = cUSTOMER.CUSTZIP.ToString();
            txtPhoneNumber.Text = cUSTOMER.CUSTWPHONE.ToString();

        }

    }

    protected void loadReceiverInfo(int receiverID)
    {

        RECEIVER rECEIVER = new RECEIVER();
        rECEIVER = RECEIVERManager.GetRECEIVERByID(receiverID);

        txtFirstName.Text = rECEIVER.RECEIVERFNAME.ToString();
        txtMiddleName.Text = rECEIVER.RECEIVERMNAME.ToString();
        txtLastName.Text = rECEIVER.RECEIVERLNAME.ToString();
        txtReceiverCity.Text = rECEIVER.RECEIVERCITY.ToString();

    }

    protected void loadLocationInfo(int locationID)
    {
        LOCATION lOCATION = new LOCATION();
        lOCATION = LOCATIONManager.GetLOCATIONByID(locationID);
        txtBranch.Text = lOCATION.BRANCH.ToString();
        lblRate.Text = lOCATION.AGENTRATE.ToString();

    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        //Response.Redirect("SearchReceiverPage.aspx");
    }

    private void calculateTotal()
    {
        txtTotalCharge.Text = String.Format("{0:0.00}", double.Parse(txtSendingAmount.Text) + double.Parse(txtServiceCharge.Text) + double.Parse(txtOtherServiceCharge.Text) - double.Parse(txtDiscount.Text));
        lblAmountReceived.Text = String.Format("{0:0.00}", double.Parse(txtTotalCharge.Text) * double.Parse(lblRate.Text));
    }

    protected void txtSendingAmount_TextChanged(object sender, EventArgs e)
    {
        calculateTotal();
    }
    protected void txtServiceCharge_TextChanged(object sender, EventArgs e)
    {
        calculateTotal();
    }
    protected void txtOtherServiceCharge_TextChanged(object sender, EventArgs e)
    {
        calculateTotal();
    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        calculateTotal();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        showTRANSData(txtReferenceCode.Text);
        hfReferenceCode.Value = txtReferenceCode.Text;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        updateTRANS("SAME");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        updateTRANS("VOID");
        panData.Visible = false;
        lblMessage.Text = "Return Successfully..";
        lblMessage.ForeColor = System.Drawing.Color.Red;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        updateTRANS("RETURN");
        panData.Visible = false;
        lblMessage.Text = "Delete Successfully..";
        lblMessage.ForeColor = System.Drawing.Color.Red;
    }
    private void updateTRANS(string status)
    {
        if (hfReferenceCode.Value == txtReferenceCode.Text)
        {
            int agnetID = 4;
            if (Session["role"].ToString() == "Agent")
            {
                agnetID = ((AGENT)Session["aGENT"]).AGENTID;
            }
            else if (Session["role"].ToString() == "Location")
            {
                agnetID = (-1) * ((LOCATIONGROUP)Session["lOCATION"]).LOCATIONGROUPID;
            }


            calculateTotal();
            DateTime nullDate = DateTime.Parse(ConfigurationManager.AppSettings["NULL_DATE"].ToString());

            TRANS tRANS = new TRANS();
            tRANS = TRANSManager.GetTRANSByRefCode(txtReferenceCode.Text);
            TRANS tempTRANS = new TRANS();
            tempTRANS.TRANSID = tRANS.TRANSID;

            #region Edit Receiver info
            if (!btnEditReceiver.Visible) //it it invisible that means the Receiver is going to be edited
            {
                txtFirstName.Enabled = true;
                txtMiddleName.Enabled = true;
                txtLastName.Enabled = true;
                txtReceiverCity.Enabled = true;
                txtReceiverCountry.Enabled = true;

                RECEIVER rECEIVER = new RECEIVER();

                rECEIVER.USERNAME = User.Identity.Name.ToString();
                rECEIVER.RECEIVERFNAME = txtFirstName.Text;
                rECEIVER.RECEIVERMNAME = txtMiddleName.Text;
                rECEIVER.RECEIVERLNAME = txtLastName.Text;
                rECEIVER.RECEIVERADDRESS1 = "";
                rECEIVER.RECEIVERADDRESS2 = "";
                rECEIVER.RECEIVERCITY = txtReceiverCity.Text;
                rECEIVER.RECEIVERSTATE = txtReceiverCountry.Text;
                rECEIVER.RECEIVERZIP = "";
                rECEIVER.RECEIVERPHONE = "";
                rECEIVER.SCANURL = "";
                rECEIVER.CREATEDBY = int.Parse(Session["userInfoID"].ToString());
                rECEIVER.CREATEDON = DateTime.Now;
                rECEIVER.UPDATEDBY = int.Parse(Session["userInfoID"].ToString());
                rECEIVER.UPDATEDON = DateTime.Now;

                rECEIVER.SCANURL = "~/Uploads/Receiver/no_image.jpeg";

                tRANS.RECEIVERID = RECEIVERManager.InsertRECEIVER(rECEIVER);
                editReceiver(false);
            }
            #endregion

            tempTRANS.CUSTID = tRANS.CUSTID;
            tempTRANS.RECEIVERID = tRANS.RECEIVERID;
            tempTRANS.LOCATIONID = tRANS.LOCATIONID;
            tempTRANS.TRANSDT = tRANS.TRANSDT;
            tempTRANS.TRANSAMOUNT = Decimal.Parse(txtSendingAmount.Text);
            tempTRANS.TRANSFEES = Decimal.Parse(txtServiceCharge.Text);
            tempTRANS.TRANSOTHERFEES = Decimal.Parse(txtOtherServiceCharge.Text);
            tempTRANS.CAUSETRANSOTHERFEES = txtCauseOtherServiceCharges.Text;
            tempTRANS.TRANSPROMOCODE = txtDiscount.Text;
            tempTRANS.TRANSPROMO = 0;
            tempTRANS.TRANSTOTALAMOUNT = Decimal.Parse(txtTotalCharge.Text);
            tempTRANS.FLAG_SM_RECEIVER = 'N';
            tempTRANS.SM_RECEIVER = "";
            tempTRANS.FLAG_CALL_RECEIVER = 'N';
            tempTRANS.RECEIVERPHONENO = tRANS.RECEIVERPHONENO;
            tempTRANS.FLAG_DD = 'N';
            tempTRANS.FLAG_TESTQUESTION = 'N';
            tempTRANS.TESTQUESTION = txtTestQuestion.Text;
            tempTRANS.TESTANSWER = txtTestAnswer.Text;
            tempTRANS.FLAG_CALLSENDER = 'N';
            tempTRANS.FLAG_SMSSENDER = 'N';
            tempTRANS.FLAG_EMAILSENDER = 'N';
            tempTRANS.SENDEREMAILADDRESS = "";
            tempTRANS.TRANSSTATUS = status != "SAME" ? status : tRANS.TRANSSTATUS;
            tempTRANS.TRANSRECEIVEDID = "";
            tempTRANS.TRANSRECEIVEDATE = nullDate;
            tempTRANS.CREATEDBY = tRANS.CREATEDBY;
            tempTRANS.CREATEDON = tRANS.CREATEDON;
            tempTRANS.UPDATEDBY = int.Parse(Session["userInfoID"].ToString()); //agnetID; //for location it will be -ve
            tempTRANS.UPDATEDON = DateTime.Now;
            tempTRANS.AGENTID = tRANS.AGENTID;
            tempTRANS.REFCODE = tRANS.REFCODE;
            bool result = TRANSManager.UpdateTRANS(tempTRANS);

            lblMessage.Text = "Update Successfully";
            lblMessage.ForeColor = System.Drawing.Color.Green;
            //divEditTrans.Visible = false;
        }
        else
        {
            lblMessage.Text = "Update Error: You should not change the Ref Code.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (txtReferenceCode.Text != "")
        {
            printReport();
        }
    }


    protected void printReport()
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "dsReceipt_dtReport";
        rds.Value = GetAllTransInfoByReferenceCode();
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/rptReceipt.rdlc");
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

    protected DataTable GetAllTransInfoByReferenceCode()
    {
        dt = new DataTable();
        dt = sqlTRANSProvider.GetAllTransInfoByReferenceCodeForReport(txtReferenceCode.Text);
        return dt;
    }
    protected void btnEditReceiver_Click(object sender, EventArgs e)
    {
        editReceiver(true);
    }

    private void editReceiver(bool isWantToEdit)
    {
        btnEditReceiver.Visible = !isWantToEdit;
        txtFirstName.Enabled = isWantToEdit;
        txtMiddleName.Enabled = isWantToEdit;
        txtLastName.Enabled = isWantToEdit;
        txtReceiverCity.Enabled = isWantToEdit;
        txtReceiverCountry.Enabled = isWantToEdit;
    }
    protected void btnFullPayment_Click(object sender, EventArgs e)
    {
        TRANS tRANS = new TRANS();
        tRANS = TRANSManager.GetTRANSByRefCode(txtReferenceCode.Text);

        TRANS tempTRANS = new TRANS();
        tempTRANS = tRANS;
        
        tempTRANS.TRANSSTATUS = "PAID";
        
        tempTRANS.TRANSRECEIVEDATE = DateTime.Now;
        tempTRANS.SENDEREMAILADDRESS = txtReceiverEmail.Text;
        tempTRANS.UPDATEDBY = int.Parse(Session["userInfoID"].ToString());//Session["lOCATION"] != null ? ((LOCATIONGROUP)Session["lOCATION"]).LOCATIONGROUPID : ((AGENT)Session["aGENT"]).AGENTID;
        tempTRANS.UPDATEDON = DateTime.Now;
        if (TRANSManager.UpdateTRANS_Paid(tempTRANS))
        {
            lblMessage.Text = "Paid Successfully";
            lblMessage.ForeColor = System.Drawing.Color.Green;
            showTRANSData(txtReferenceCode.Text);
        }
    }

    protected void btnPending_Click(object sender, EventArgs e)
    {
        updateTRANS("PENDING");
    }


    protected void btnHOLDING_Click(object sender, EventArgs e)
    {
        updateTRANS("HOLDING");
    }

    protected void btnPaid_Click(object sender, EventArgs e)
    {
        updateTRANS("PAID");
    }
    protected void btnComplianceForm_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerSign.aspx?refcode="+txtReferenceCode.Text);
    }
}
