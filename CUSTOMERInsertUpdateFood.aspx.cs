using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Xml;
public partial class CUSTOMERInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ((ASP.membermaster_master)Page.Master).RegisterPostbackTrigger(btnSave);

                ((ASP.membermaster_master)Page.Master).RegisterPostbackTrigger(btnUpdate);
            }
            catch
            {
            }

            if (!User.Identity.IsAuthenticated)
            {
                Session.RemoveAll(); Response.Redirect("LogInPage.aspx");
            }
            else
            {
                reLoadSession();
            }

            if (Request.QueryString["cUSTOMERID"] != null)
            {
                loadCustomerIDType();

                int cUSTOMERID = Int32.Parse(Request.QueryString["cUSTOMERID"]);
                if (cUSTOMERID == -1)
                {
                    btnUpdate.Enabled = false;
                    btnSave.Enabled = true;

                    List<CUSTOMER> CUSTOMERs = new List<CUSTOMER>();
                    CUSTOMERs = CUSTOMERManager.GetAllCUSTOMERs();



                    txtMemberID.Text = (int.Parse(CUSTOMERs[CUSTOMERs.Count - 1].CUSTOMERID.ToString()) + 1).ToString();
                    txtCUSTDOB.Text = DateTime.Now.ToShortDateString();
                    txtCUSTISSUEDATE.Text = DateTime.Now.ToShortDateString();
                    txtCUSTEXPIREDATE.Text = DateTime.Now.ToShortDateString();
                }
                else
                {
                    btnUpdate.Enabled = true;
                    btnSave.Enabled = false;
                    showCUSTOMERData();
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {

    }

    private void loadCustomerIDType()
    {
        ddlCUST.DataSource = CUSTIDTYPEManager.GetAllCUSTIDTYPEs();
        ddlCUST.DataTextField = "CUSTIDTYPEName";
        ddlCUST.DataValueField = "CUSTIDTYPEID";
        ddlCUST.DataBind();

        ddlCUST.Items.Insert(0, new ListItem("Select ID Type", "0"));
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtCUSTFNAME.Text != "" && txtCUSTCPHONE.Text != "")
        {
            

            CUSTOMER cUSTOMER = new CUSTOMER();
            cUSTOMER = CUSTOMERManager.GetCUSTOMERByID(Int32.Parse(Request.QueryString["cUSTOMERID"]));


            CUSTOMER tempCUSTOMER = new CUSTOMER();
            tempCUSTOMER.CUSTOMERID = cUSTOMER.CUSTOMERID;

            tempCUSTOMER.EMTID = "";
            tempCUSTOMER.USERNAME = "";
            tempCUSTOMER.CUSTFNAME = txtCUSTFNAME.Text;
            tempCUSTOMER.CUSTMNAME = txtCUSTMNAME.Text;
            tempCUSTOMER.CUSTLNAME = txtCUSTLNAME.Text;
            tempCUSTOMER.CUSTADDRESS1 = txtCUSTADDRESS1.Text;
            tempCUSTOMER.CUSTADDRESS2 = txtCUSTADDRESS2.Text;
            tempCUSTOMER.CUSTCITY = txtCUSTCITY.Text;
            tempCUSTOMER.CUSTSTATE = txtCUSTSTATE.Text;
            tempCUSTOMER.CUSTZIP = txtCUSTZIP.Text;
            tempCUSTOMER.CUSTHPHONE = txtCUSTHPHONE.Text;
            tempCUSTOMER.CUSTCPHONE = txtCUSTCPHONE.Text;
            tempCUSTOMER.CUSTWPHONE = txtCUSTWPHONE.Text;
            tempCUSTOMER.CUSTSSN = txtCUSTSSN.Text;
            tempCUSTOMER.CUSTDRIVINGLICENSE = txtDrivingLicense.Text;
            tempCUSTOMER.CUSTIDTYPE = Int32.Parse(ddlCUST.SelectedValue);
            tempCUSTOMER.CUSTIDNUMBER = txtCUSTIDNUMBER.Text;
            tempCUSTOMER.CUSTDOB = DateTime.Parse(txtCUSTDOB.Text);
            tempCUSTOMER.CUSTISSUEDATE = DateTime.Parse(txtCUSTISSUEDATE.Text);
            tempCUSTOMER.CUSTEXPIREDATE = DateTime.Parse(txtCUSTEXPIREDATE.Text);
            tempCUSTOMER.ISOFACVERIFIED = "Y";
            tempCUSTOMER.CUSTREMARKS = txtCUSTREMARKS.Text;
            tempCUSTOMER.SCANURL = cUSTOMER.SCANURL;
            tempCUSTOMER.CREATEDBY = 1;
            tempCUSTOMER.CREATEDON = cUSTOMER.CREATEDON;
            tempCUSTOMER.UPDATEDBY = 1;
            tempCUSTOMER.UPDATEDON = DateTime.Now;


            if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
            {
                try
                {
                    string dirUrl = "~/Uploads/Customer";
                    string dirPath = Server.MapPath(dirUrl);

                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    string fileName = Path.GetFileName(uplFile.PostedFile.FileName);
                    string fileUrl = dirUrl + "/" + Path.GetFileName(uplFile.PostedFile.FileName);
                    string filePath = Server.MapPath(fileUrl);
                    uplFile.PostedFile.SaveAs(filePath);

                    tempCUSTOMER.SCANURL = dirUrl + "/" + fileName;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message.ToString();

                }
            }
            else
            {

                tempCUSTOMER.SCANURL = cUSTOMER.SCANURL;
            }

            bool result = CUSTOMERManager.UpdateCUSTOMER(tempCUSTOMER);


            if (result == true)
            {
                lblMessage.Text = "Update Successfully";

                Session["snFoodsenderID"] = Request.QueryString["cUSTOMERID"];
                Response.Redirect("SearchFoodReceiverPage.aspx");
            }


        }
        else
        {
            lblMessage.Text = "Please enter the First Name and Cell #.";
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        //ddlEMT.SelectedIndex = 0;
        //txtUSERNAME.Text = "";
        txtCUSTFNAME.Text = "";
        txtCUSTMNAME.Text = "";
        txtCUSTLNAME.Text = "";
        txtCUSTADDRESS1.Text = "";
        txtCUSTADDRESS2.Text = "";
        txtCUSTCITY.Text = "";
        txtCUSTSTATE.Text = "";
        txtCUSTZIP.Text = "";
        txtCUSTHPHONE.Text = "";
        txtCUSTCPHONE.Text = "";
        txtCUSTWPHONE.Text = "";
        txtCUSTSSN.Text = "";
        ddlCUST.SelectedIndex = 0;
        ddlCUST.SelectedIndex = 0;
        txtCUSTDOB.Text = "";
        txtCUSTISSUEDATE.Text = "";
        txtCUSTEXPIREDATE.Text = "";
        //txtISOFACVERIFIED.Text = "";
        txtCUSTREMARKS.Text = "";
        //txtCREATEDBY.Text = "";
        //txtCREATEDON.Text = "";
        //txtUPDATEDBY.Text = "";
        //txtUPDATEDON.Text = "";
    }
    private void showCUSTOMERData()
    {
        CUSTOMER cUSTOMER = new CUSTOMER();
        cUSTOMER = CUSTOMERManager.GetCUSTOMERByID(Int32.Parse(Request.QueryString["cUSTOMERID"]));
        txtMemberID.Text = cUSTOMER.CUSTOMERID.ToString();
        //ddlEMT.SelectedValue = cUSTOMER.EMTID.ToString();
        //txtUSERNAME.Text = cUSTOMER.USERNAME;
        txtCUSTFNAME.Text = cUSTOMER.CUSTFNAME;
        txtCUSTMNAME.Text = cUSTOMER.CUSTMNAME;
        txtCUSTLNAME.Text = cUSTOMER.CUSTLNAME;
        txtCUSTADDRESS1.Text = cUSTOMER.CUSTADDRESS1;
        txtCUSTADDRESS2.Text = cUSTOMER.CUSTADDRESS2;
        txtCUSTCITY.Text = cUSTOMER.CUSTCITY;
        txtCUSTSTATE.Text = cUSTOMER.CUSTSTATE;
        txtCUSTZIP.Text = cUSTOMER.CUSTZIP;
        txtCUSTHPHONE.Text = cUSTOMER.CUSTHPHONE;
        txtCUSTCPHONE.Text = cUSTOMER.CUSTCPHONE;
        txtCUSTWPHONE.Text = cUSTOMER.CUSTWPHONE;
        txtCUSTSSN.Text = cUSTOMER.CUSTSSN;
        txtDrivingLicense.Text = cUSTOMER.CUSTDRIVINGLICENSE;
        ddlCUST.SelectedValue = cUSTOMER.CUSTIDTYPE.ToString();
        ddlCUST.SelectedValue = cUSTOMER.CUSTIDNUMBER.ToString();
        txtCUSTDOB.Text = cUSTOMER.CUSTDOB.ToShortDateString();
        txtCUSTISSUEDATE.Text = cUSTOMER.CUSTISSUEDATE.ToShortDateString();
        txtCUSTEXPIREDATE.Text = cUSTOMER.CUSTEXPIREDATE.ToShortDateString();
        //txtISOFACVERIFIED.Text = cUSTOMER.ISOFACVERIFIED.ToString();
        txtCUSTREMARKS.Text = cUSTOMER.CUSTREMARKS;
        //txtCREATEDBY.Text = cUSTOMER.CREATEDBY.ToString();
        //txtCREATEDON.Text = cUSTOMER.CREATEDON;
        //txtUPDATEDBY.Text = cUSTOMER.UPDATEDBY.ToString();
        //txtUPDATEDON.Text = cUSTOMER.UPDATEDON;
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchSenderPage.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtCUSTFNAME.Text != "" && txtCUSTCPHONE.Text != "")
        {
            lblOfacMessage.Text = "";
            //lblCheckSus.Text = "";
            lblMessage.Text = "";

            CUSTOMER cUSTOMER = new CUSTOMER();

            cUSTOMER.EMTID = "";
            cUSTOMER.USERNAME = "";
            cUSTOMER.CUSTFNAME = txtCUSTFNAME.Text;
            cUSTOMER.CUSTMNAME = txtCUSTMNAME.Text;
            cUSTOMER.CUSTLNAME = txtCUSTLNAME.Text;
            cUSTOMER.CUSTADDRESS1 = txtCUSTADDRESS1.Text;
            cUSTOMER.CUSTADDRESS2 = txtCUSTADDRESS2.Text;
            cUSTOMER.CUSTCITY = txtCUSTCITY.Text;
            cUSTOMER.CUSTSTATE = txtCUSTSTATE.Text;
            cUSTOMER.CUSTZIP = txtCUSTZIP.Text;
            cUSTOMER.CUSTHPHONE = txtCUSTHPHONE.Text;
            cUSTOMER.CUSTCPHONE = txtCUSTCPHONE.Text;
            cUSTOMER.CUSTWPHONE = txtCUSTWPHONE.Text;
            cUSTOMER.CUSTSSN = txtCUSTSSN.Text;
            cUSTOMER.CUSTDRIVINGLICENSE = txtDrivingLicense.Text;
            cUSTOMER.CUSTIDTYPE = Int32.Parse(ddlCUST.SelectedValue);
            cUSTOMER.CUSTIDNUMBER = txtCUSTIDNUMBER.Text;
            cUSTOMER.CUSTDOB = DateTime.Parse(txtCUSTDOB.Text);
            cUSTOMER.CUSTISSUEDATE = DateTime.Parse(txtCUSTISSUEDATE.Text);
            cUSTOMER.CUSTEXPIREDATE = DateTime.Parse(txtCUSTEXPIREDATE.Text);
            cUSTOMER.ISOFACVERIFIED = "Y";
            cUSTOMER.CUSTREMARKS = txtCUSTREMARKS.Text;
            cUSTOMER.SCANURL = "";
            cUSTOMER.CREATEDBY = 1;
            cUSTOMER.CREATEDON = DateTime.Now;
            cUSTOMER.UPDATEDBY = 1;
            cUSTOMER.UPDATEDON = DateTime.Now;

            if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
            {
                try
                {
                    string dirUrl = "~/Uploads/Customer";
                    string dirPath = Server.MapPath(dirUrl);

                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    string fileName = Path.GetFileName(uplFile.PostedFile.FileName);
                    string fileUrl = dirUrl + "/" + Path.GetFileName(uplFile.PostedFile.FileName);
                    string filePath = Server.MapPath(fileUrl);
                    uplFile.PostedFile.SaveAs(filePath);

                    cUSTOMER.SCANURL = dirUrl + "/" + fileName;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message.ToString();

                }
            }
            else
            {

                cUSTOMER.SCANURL = "~/Uploads/Customer/no_image.jpeg";
            }

            int resutl = 0;

            try
            {
                string ofacVerify = string.Empty;
                ofacservice.OFACService service;
                service = new ofacservice.OFACService();
                string token = service.Logon(1881, "abimatu", "b3t5vi113");
                string xml = service.OFACScanName(token, txtCUSTFNAME.Text + " " + txtCUSTMNAME.Text + " " + txtCUSTLNAME.Text);

                if (xml != "")
                {
                    ofacVerify = ProcessXML(xml);
                    //ofacVerify = "N";
                    if (ofacVerify == "Y")
                    {
                        cUSTOMER.ISOFACVERIFIED = ofacVerify;
                        lblOfacMessage.Text = "Suspecious Activity Found.";
                        //lblOfacMessage.Text = ofacVerify.ToString();

                        List<CUSTOMER> cUSTOMER1 = new List<CUSTOMER>();
                        cUSTOMER1 = CUSTOMERManager.GetAllCUSTOMERsByCUSTIDNUMBER_CUSTDOB(txtCUSTIDNUMBER.Text, DateTime.Parse(txtCUSTDOB.Text));

                        //lblMessage.Text = cUSTOMER1.Count.ToString();

                        if (cUSTOMER1.Count == 0)
                        {
                            panlIFrame.Visible = true;


                            if (lblCheckSus.Text == "1")
                            {
                                if (chkSuspicious.Checked == true)
                                {
                                    cUSTOMER.ISOFACVERIFIED = "N";
                                }
                                else
                                {
                                    cUSTOMER.ISOFACVERIFIED = "Y";
                                }

                                resutl = CUSTOMERManager.InsertCUSTOMER(cUSTOMER);
                            }
                        }
                        else
                        {
                            panlIFrame.Visible = false;
                            cUSTOMER.ISOFACVERIFIED = "N";
                            resutl = CUSTOMERManager.InsertCUSTOMER(cUSTOMER);
                        }
                    }
                    else
                    {
                        lblOfacMessage.Text = "Suspecious Activity Not Found.";
                        //lblOfacMessage.Text = ofacVerify.ToString();

                        panlIFrame.Visible = false;
                        cUSTOMER.ISOFACVERIFIED = "Y";
                        resutl = CUSTOMERManager.InsertCUSTOMER(cUSTOMER);
                    }
                }
                //int resutl = CUSTOMERManager.InsertCUSTOMER(cUSTOMER);

                if (resutl > 0)
                {
                    lblMessage.Text = "Saved Successfully .<br/><a href='SearchFoodReceiverPage.aspx'>Next</a>";
                    Session["snFoodsenderID"] = resutl.ToString();
                    //Response.Redirect("SearchReceiverPage.aspx");
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "OFAC Login Problem...<br/> So without Checking OFAC we are adding this Customer.<br/>Please Contact with OFAC Office or better the Develeoper of this software(Anam)";
                cUSTOMER.ISOFACVERIFIED = "Y";
                resutl = CUSTOMERManager.InsertCUSTOMER(cUSTOMER);
                if (resutl > 0)
                {
                    lblMessage.Text += "<br/>Saved Successfully .<br/>Go for <a href='SearchFoodReceiverPage.aspx' style='font-size:30px;'>Next  >></a>";
                    Session["snFoodsenderID"] = resutl.ToString();
                    //Response.Redirect("SearchReceiverPage.aspx");
                }
            }

            //if (resutl > 0)
            //{
            //    lblMessage.Text = "Saved Successfully";
            //    Session["snFoodsenderID"] = resutl.ToString();
            //    Response.Redirect("SearchFoodReceiverPage.aspx");
            //}
        }
        else
        {
            lblMessage.Text = "Please enter the First Name and Cell #...";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
    private string ProcessXML(string xml)
    {
        string isOfaceVerify = string.Empty;
        try
        {
            //comboBanks.Items.Clear();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNodeList nodeList = xmlDoc.SelectNodes("//OFACMatch");

            string srchFirstName = txtCUSTFNAME.Text.ToLower();
            string srchMiddleName = txtCUSTMNAME.Text.ToLower();
            string srchLastName = txtCUSTLNAME.Text.ToLower();


            int countFirstName = 0;
            int countMiddleName = 0;
            int countLastName = 0;


            for (int i = 0; i < nodeList.Count; i++)
            {

                string strOriginal = string.Empty;
                strOriginal = nodeList[i].ChildNodes[2].InnerText.ToLower();

                System.Text.RegularExpressions.Regex rexFirst = new System.Text.RegularExpressions.Regex(srchFirstName);
                countFirstName = rexFirst.Matches(strOriginal).Count;

                System.Text.RegularExpressions.Regex rexMiddle = new System.Text.RegularExpressions.Regex(srchMiddleName);
                countMiddleName = rexMiddle.Matches(strOriginal).Count;

                System.Text.RegularExpressions.Regex rexLast = new System.Text.RegularExpressions.Regex(srchLastName);
                countLastName = rexLast.Matches(strOriginal).Count;
                if (countFirstName >= 1 && countMiddleName >= 1 && countLastName >= 1)
                {
                    //lblMessage.Text = srchString + " occurs " + count + " times";

                    isOfaceVerify = "N";
                    i = nodeList.Count;
                    //lblOfacMessage.Text = "Suspecious Activity Found";
                }

                else
                {
                    isOfaceVerify = "Y";
                    //lblOfacMessage.Text = "Suspecious Activity Not Found";
                }

            }


        }
        catch (Exception)
        {
        }


        return isOfaceVerify;
    }

    protected void btnScanID_Click(object sender, EventArgs e)
    {

    }

    protected void btnSaveSA_Click(object sender, EventArgs e)
    {
        CUSTOMER cUSTOMER = new CUSTOMER();

        cUSTOMER.EMTID = "";
        cUSTOMER.USERNAME = "";
        cUSTOMER.CUSTFNAME = txtCUSTFNAME.Text;
        cUSTOMER.CUSTMNAME = txtCUSTMNAME.Text;
        cUSTOMER.CUSTLNAME = txtCUSTLNAME.Text;
        cUSTOMER.CUSTADDRESS1 = txtCUSTADDRESS1.Text;
        cUSTOMER.CUSTADDRESS2 = txtCUSTADDRESS2.Text;
        cUSTOMER.CUSTCITY = txtCUSTCITY.Text;
        cUSTOMER.CUSTSTATE = txtCUSTSTATE.Text;
        cUSTOMER.CUSTZIP = txtCUSTZIP.Text;
        cUSTOMER.CUSTHPHONE = txtCUSTHPHONE.Text;
        cUSTOMER.CUSTCPHONE = txtCUSTCPHONE.Text;
        cUSTOMER.CUSTWPHONE = txtCUSTWPHONE.Text;
        cUSTOMER.CUSTSSN = txtCUSTSSN.Text;
        cUSTOMER.CUSTDRIVINGLICENSE = txtDrivingLicense.Text;
        cUSTOMER.CUSTIDTYPE = Int32.Parse(ddlCUST.SelectedValue);
        cUSTOMER.CUSTIDNUMBER = txtCUSTIDNUMBER.Text;
        cUSTOMER.CUSTDOB = DateTime.Parse(txtCUSTDOB.Text);
        cUSTOMER.CUSTISSUEDATE = DateTime.Parse(txtCUSTISSUEDATE.Text);
        cUSTOMER.CUSTEXPIREDATE = DateTime.Parse(txtCUSTEXPIREDATE.Text);
        cUSTOMER.ISOFACVERIFIED = "Y";
        cUSTOMER.CUSTREMARKS = txtCUSTREMARKS.Text;
        cUSTOMER.SCANURL = "";
        cUSTOMER.CREATEDBY = 1;
        cUSTOMER.CREATEDON = DateTime.Now;
        cUSTOMER.UPDATEDBY = 1;
        cUSTOMER.UPDATEDON = DateTime.Now;

        if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
        {
            try
            {
                string dirUrl = "~/Uploads/Customer";
                string dirPath = Server.MapPath(dirUrl);

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                string fileName = Path.GetFileName(uplFile.PostedFile.FileName);
                string fileUrl = dirUrl + "/" + Path.GetFileName(uplFile.PostedFile.FileName);
                string filePath = Server.MapPath(fileUrl);
                uplFile.PostedFile.SaveAs(filePath);

                cUSTOMER.SCANURL = dirUrl + "/" + fileName;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
        }
        else
        {
            cUSTOMER.SCANURL = "~/Uploads/Customer/no_image.jpeg";
        }

        if (chkSuspicious.Checked)
        {
            cUSTOMER.ISOFACVERIFIED = "Y";
        }
        else
        {
            cUSTOMER.ISOFACVERIFIED = "N";
        }

        int resutl = CUSTOMERManager.InsertCUSTOMER(cUSTOMER);

        if (resutl > 0)
        {
            lblMessage.Text = "Saved Successfully .<br/><a href='SearchReceiverPage.aspx'>Next</a>";
            Session["snsenderID"] = resutl.ToString();
            panlIFrame.Visible = false;
            //Response.Redirect("SearchReceiverPage.aspx");
        }
    }
}