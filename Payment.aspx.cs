using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

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
           
                if (Session["snsenderID"] != null && Session["snreceiverID"] != null && Session["snlocationID"] != null)
                {
                    loadSenderInfo();
                    loadReceiverInfo();
                    loadLocationInfo();
                    //loadTransSession();
                    txtDate.Text = DateTime.Today.ToShortDateString();

                }
                else
                {
                    //Response.Redirect("SearchSenderPage.aspx");
                }
            }
            
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

    protected void loadSenderInfo()
    {
        CUSTOMER cUSTOMER = new CUSTOMER();
        cUSTOMER = CUSTOMERManager.GetCUSTOMERByID(int.Parse(Session["snsenderID"].ToString()));

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

    protected void loadReceiverInfo()
    {

        RECEIVER rECEIVER = new RECEIVER();
        rECEIVER = RECEIVERManager.GetRECEIVERByID(int.Parse(Session["snreceiverID"].ToString()));

        txtFirstName.Text = rECEIVER.RECEIVERFNAME.ToString();
        txtMiddleName.Text = rECEIVER.RECEIVERMNAME.ToString();
        txtLastName.Text = rECEIVER.RECEIVERLNAME.ToString();
        txtReceiverCity.Text = rECEIVER.RECEIVERCITY.ToString();

    }

    protected void loadLocationInfo()
    {
        LOCATION lOCATION = new LOCATION();
        lOCATION = LOCATIONManager.GetLOCATIONByID(int.Parse(Session["snlocationID"].ToString()));
        txtBranch.Text = lOCATION.BRANCH.ToString();
        lblRate.Text = lOCATION.AGENTRATE.ToString();

    }

    protected void loadTransSession()
    {
        try
        {


            AGENT aGENT = (AGENT)Session["aGENT"];
            DateTime nullDate = DateTime.Parse(ConfigurationManager.AppSettings["NULL_DATE"].ToString());

            TRANS tRANS = new TRANS();

            tRANS.CUSTID = int.Parse(Session["snsenderID"].ToString());
            tRANS.RECEIVERID = int.Parse(Session["snreceiverID"].ToString());
            tRANS.LOCATIONID = int.Parse(Session["snlocationID"].ToString());
            tRANS.TRANSDT = DateTime.Now;
            tRANS.TRANSAMOUNT = decimal.Parse(txtSendingAmount.Text);
            tRANS.TRANSFEES = decimal.Parse(txtServiceCharge.Text);
            tRANS.TRANSOTHERFEES = decimal.Parse(txtOtherServiceCharge.Text);
            tRANS.CAUSETRANSOTHERFEES = txtCauseOtherServiceCharges.Text;
            tRANS.TRANSPROMOCODE = txtDiscount.Text;
            tRANS.TRANSPROMO = 0;
            tRANS.TRANSTOTALAMOUNT = decimal.Parse(txtTotalCharge.Text);
            tRANS.FLAG_SM_RECEIVER = 'N';
            tRANS.SM_RECEIVER = "";
            tRANS.FLAG_CALL_RECEIVER = 'N';
            tRANS.RECEIVERPHONENO = "";
            tRANS.FLAG_DD = 'N';
            tRANS.FLAG_TESTQUESTION = 'N';
            tRANS.TESTQUESTION = txtTestQuestion.Text;
            tRANS.TESTANSWER = txtTestAnswer.Text;
            tRANS.FLAG_CALLSENDER = 'N';
            tRANS.FLAG_SMSSENDER = 'N';
            tRANS.FLAG_EMAILSENDER = 'N';
            tRANS.SENDEREMAILADDRESS = "";
            tRANS.TRANSSTATUS = "PENDING";
            tRANS.TRANSRECEIVEDID = "";
            tRANS.TRANSRECEIVEDATE = nullDate;
            tRANS.CREATEDBY = int.Parse(Session["userInfoID"].ToString());
            tRANS.CREATEDON = DateTime.Parse(txtDate.Text);
            tRANS.UPDATEDBY = int.Parse(Session["userInfoID"].ToString());
            tRANS.UPDATEDON = DateTime.Parse(txtDate.Text);
            tRANS.AGENTID = aGENT.AGENTID;
            tRANS.REFCODE = lblReferenceCode.Text;



            if (Session["sessionTRANS"] == null)
            {
                List<TRANS> SSTRANS = new List<TRANS>();

                SSTRANS.Add(tRANS);
                Session.Remove("sessionTRANS");
                Session["sessionTRANS"] = SSTRANS;
            }


            else
            {
                ((List<TRANS>)Session["sessionTRANS"]).Add(tRANS);



            }

            //List<TRANS> SSTRANSFINAL = new List<TRANS>();
            //SSTRANSFINAL = (List<TRANS>)Session["sessionTRANS"];

            //gvTRANS.DataSource = SSTRANSFINAL;
            //gvTRANS.DataBind();

        }

        catch (Exception EX)
        {
            lblmessage.Text = EX.ToString();
        }
    }


    protected void btnProcessTransaction_Click(object sender, EventArgs e)
    {
        //try
        //{
            loadTransSession();

            if (Session["sessionTRANS"] != null)
            {
                int resutl1 = 0;
                //Session.Remove("ssReferenceCode");
                List<TRANS> SSTRANSFINAL = new List<TRANS>();
                SSTRANSFINAL = (List<TRANS>)Session["sessionTRANS"];
                TRANS tRANS1 = new TRANS();


                for (int i = 0; i < SSTRANSFINAL.Count; i++)
                {
                    if (SSTRANSFINAL[i].CUSTID > 0)
                    {
                        tRANS1.CUSTID = SSTRANSFINAL[i].CUSTID;
                    }
                    else
                    {
                        continue;
                    }
                    tRANS1.RECEIVERID = SSTRANSFINAL[i].RECEIVERID;
                    tRANS1.LOCATIONID = SSTRANSFINAL[i].LOCATIONID;
                    tRANS1.TRANSDT = SSTRANSFINAL[i].TRANSDT;
                    tRANS1.TRANSAMOUNT = SSTRANSFINAL[i].TRANSAMOUNT;
                    tRANS1.TRANSFEES = SSTRANSFINAL[i].TRANSFEES;
                    tRANS1.TRANSOTHERFEES = SSTRANSFINAL[i].TRANSOTHERFEES;
                    tRANS1.CAUSETRANSOTHERFEES = SSTRANSFINAL[i].CAUSETRANSOTHERFEES;
                    tRANS1.TRANSPROMOCODE = SSTRANSFINAL[i].TRANSPROMOCODE;
                    tRANS1.TRANSPROMO = SSTRANSFINAL[i].TRANSPROMO;
                    tRANS1.TRANSTOTALAMOUNT = SSTRANSFINAL[i].TRANSTOTALAMOUNT;
                    tRANS1.FLAG_SM_RECEIVER = SSTRANSFINAL[i].FLAG_SM_RECEIVER;
                    tRANS1.SM_RECEIVER = SSTRANSFINAL[i].SM_RECEIVER;
                    tRANS1.FLAG_CALL_RECEIVER = SSTRANSFINAL[i].FLAG_CALL_RECEIVER;
                    tRANS1.RECEIVERPHONENO = SSTRANSFINAL[i].RECEIVERPHONENO;
                    tRANS1.FLAG_DD = SSTRANSFINAL[i].FLAG_DD;
                    tRANS1.FLAG_TESTQUESTION = SSTRANSFINAL[i].FLAG_TESTQUESTION;
                    tRANS1.TESTQUESTION = SSTRANSFINAL[i].TESTQUESTION;
                    tRANS1.TESTANSWER = SSTRANSFINAL[i].TESTANSWER;
                    tRANS1.FLAG_CALLSENDER = SSTRANSFINAL[i].FLAG_CALLSENDER;
                    tRANS1.FLAG_SMSSENDER = SSTRANSFINAL[i].FLAG_SMSSENDER;
                    tRANS1.FLAG_EMAILSENDER = SSTRANSFINAL[i].FLAG_EMAILSENDER;
                    tRANS1.SENDEREMAILADDRESS = SSTRANSFINAL[i].SENDEREMAILADDRESS;
                    tRANS1.TRANSSTATUS = SSTRANSFINAL[i].TRANSSTATUS;
                    tRANS1.TRANSRECEIVEDID = SSTRANSFINAL[i].TRANSRECEIVEDID;
                    tRANS1.TRANSRECEIVEDATE = SSTRANSFINAL[i].TRANSRECEIVEDATE;
                    tRANS1.CREATEDBY = SSTRANSFINAL[i].CREATEDBY;
                    tRANS1.CREATEDON = SSTRANSFINAL[i].CREATEDON;
                    tRANS1.UPDATEDBY = SSTRANSFINAL[i].UPDATEDBY;
                    tRANS1.UPDATEDON = SSTRANSFINAL[i].UPDATEDON;
                    tRANS1.AGENTID = SSTRANSFINAL[i].AGENTID;
                    tRANS1.REFCODE = SSTRANSFINAL[i].REFCODE;

                    resutl1 = TRANSManager.InsertTRANS(tRANS1);

                    List<string> ReferenceCodeLst = new List<string>();

                    TRANS tRANSReferenceCode = new TRANS();
                    tRANSReferenceCode = TRANSManager.GetTRANSByID(resutl1);

                    if (Session["ssReferenceCode"] == null)
                    {

                        ReferenceCodeLst.Add(tRANSReferenceCode.REFCODE.ToString());

                        if (tRANSReferenceCode != null)
                        {
                            Session["ssReferenceCode"] = ReferenceCodeLst;
                        }
                    }


                    else
                    {
                        //TRANS tRANSReferenceCode = new TRANS();
                        //tRANSReferenceCode = TRANSManager.GetTRANSByID(resutl1);
                        ////((List<string>)Session["ssReferenceCode"]).Add(tRANSReferenceCode.REFCODE);

                        //if (tRANSReferenceCode != null)
                        //{
                        ((List<string>)Session["ssReferenceCode"]).Add(tRANSReferenceCode.REFCODE.ToString());
                        //}
                    }

                }
                if (resutl1 > 0)
                {
                    //Session.Remove("snlocationID");
                    //Session.Remove("snsenderID");
                    Session.Remove("snreceiverID");
                    Session.Remove("sessionTRANS");
                    Response.Redirect("Transmit.aspx");
                }
            }
            else
            {
                Response.Redirect("SearchSenderPage.aspx");
            }
        //}

        //catch (Exception Ex)
        //{
        //    lblmessage.Text = Ex.ToString();
        //}

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchReceiverPage.aspx");
    }

    //private void calculateTotal()
    //{

    //    txtServiceCharge.Text = String.Format("{0:0}", double.Parse(txtSendingAmount.Text) * 0.1);
    //    txtTotalCharge.Text = String.Format("{0:0}", double.Parse(txtSendingAmount.Text) + double.Parse(txtServiceCharge.Text) + double.Parse(txtOtherServiceCharge.Text) - double.Parse(txtDiscount.Text));
    //    lblAmountReceived.Text = String.Format("{0:0}", double.Parse(txtTotalCharge.Text) * double.Parse(lblRate.Text));
    //}

    //protected void txtSendingAmount_TextChanged(object sender, EventArgs e)
    //{
    //    //calculateTotal();

    //    txtTotalCharge.Text = txtSendingAmount.Text;
    //}
    //protected void txtServiceCharge_TextChanged(object sender, EventArgs e)
    //{
    //    calculateTotal();
    //}
    //protected void txtOtherServiceCharge_TextChanged(object sender, EventArgs e)
    //{
    //    calculateTotal();
    //}
    //protected void txtDiscount_TextChanged(object sender, EventArgs e)
    //{
    //    calculateTotal();
    //}
    protected void btnAnotherTransaction_Click(object sender, EventArgs e)
    {
            loadTransSession();
            Response.Redirect("SearchReceiverPage.aspx");

    }
}