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
public partial class ReceiverInsertUpdate : System.Web.UI.Page
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
            
                if (Session["snsenderID"] != null)
                {
                    if (Request.QueryString["rECEIVERID"] != null)
                    {
                        int rECEIVERID = Int32.Parse(Request.QueryString["rECEIVERID"]);
                        if (rECEIVERID == -1)
                        {
                            btnUpdate.Enabled = false;
                            btnSave.Enabled = true;

                            List<RECEIVER> RECEIVERs = new List<RECEIVER>();
                            RECEIVERs = RECEIVERManager.GetAllRECEIVERs();
                            txtMemberID.Text = (int.Parse(RECEIVERs[RECEIVERs.Count - 1].RECEIVERID.ToString()) + 1).ToString();

                        }
                        else
                        {
                            btnSave.Enabled = false;
                            btnUpdate.Enabled = true;
                            showRECEIVERData();
                        }
                    }
                }
                else
                {
                    Response.Redirect("SearchSenderPage.aspx");
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        RECEIVER rECEIVER = new RECEIVER();
        rECEIVER = RECEIVERManager.GetRECEIVERByID(Int32.Parse(Request.QueryString["rECEIVERID"]));
        RECEIVER tempRECEIVER = new RECEIVER();
        tempRECEIVER.RECEIVERID = rECEIVER.RECEIVERID;

        tempRECEIVER.USERNAME = User.Identity.Name.ToString();
        tempRECEIVER.RECEIVERFNAME = txtRECEIVERFNAME.Text;
        tempRECEIVER.RECEIVERMNAME = txtRECEIVERMNAME.Text;
        tempRECEIVER.RECEIVERLNAME = txtRECEIVERLNAME.Text;
        tempRECEIVER.RECEIVERADDRESS1 = txtRECEIVERADDRESS1.Text;
        tempRECEIVER.RECEIVERADDRESS2 = txtRECEIVERADDRESS2.Text;
        tempRECEIVER.RECEIVERCITY = txtRECEIVERCITY.Text;
        tempRECEIVER.RECEIVERSTATE = txtRECEIVERSTATE.Text;
        tempRECEIVER.RECEIVERZIP = txtRECEIVERZIP.Text;
        tempRECEIVER.RECEIVERPHONE = txtRECEIVERPHONE.Text;
        tempRECEIVER.SCANURL = "";
        tempRECEIVER.CREATEDBY = 1;
        tempRECEIVER.CREATEDON = rECEIVER.CREATEDON;
        tempRECEIVER.UPDATEDBY = int.Parse(Session["userInfoID"].ToString());
        tempRECEIVER.UPDATEDON = DateTime.Now;

        if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
        {
            try
            {
                string dirUrl = "~/Uploads/Receiver";
                string dirPath = Server.MapPath(dirUrl);

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                string fileName = Path.GetFileName(uplFile.PostedFile.FileName);
                string fileUrl = dirUrl + "/" + Path.GetFileName(uplFile.PostedFile.FileName);
                string filePath = Server.MapPath(fileUrl);
                uplFile.PostedFile.SaveAs(filePath);

                tempRECEIVER.SCANURL = dirUrl + "/" + fileName;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();

            }
        }
        else
        {

            tempRECEIVER.SCANURL = rECEIVER.SCANURL;
        }
        bool result = RECEIVERManager.UpdateRECEIVER(tempRECEIVER);

        Session["snreceiverID"] = Request.QueryString["rECEIVERID"];
        Response.Redirect("SearchLocation.aspx");

    }

    private void showRECEIVERData()
    {
        RECEIVER rECEIVER = new RECEIVER();
        rECEIVER = RECEIVERManager.GetRECEIVERByID(Int32.Parse(Request.QueryString["rECEIVERID"]));

        txtMemberID.Text = rECEIVER.RECEIVERID.ToString();
        txtRECEIVERFNAME.Text = rECEIVER.RECEIVERFNAME;
        txtRECEIVERMNAME.Text = rECEIVER.RECEIVERMNAME;
        txtRECEIVERLNAME.Text = rECEIVER.RECEIVERLNAME;
        txtRECEIVERADDRESS1.Text = rECEIVER.RECEIVERADDRESS1;
        txtRECEIVERADDRESS2.Text = rECEIVER.RECEIVERADDRESS2;
        txtRECEIVERCITY.Text = rECEIVER.RECEIVERCITY;
        txtRECEIVERSTATE.Text = rECEIVER.RECEIVERSTATE;
        txtRECEIVERZIP.Text = rECEIVER.RECEIVERZIP;
        txtRECEIVERPHONE.Text = rECEIVER.RECEIVERPHONE;

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchReceiverPage.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtRECEIVERFNAME.Text != "" && txtRECEIVERLNAME.Text != "")
        {
            RECEIVER rECEIVER = new RECEIVER();

            rECEIVER.USERNAME = User.Identity.Name.ToString();
            rECEIVER.RECEIVERFNAME = txtRECEIVERFNAME.Text;
            rECEIVER.RECEIVERMNAME = txtRECEIVERMNAME.Text;
            rECEIVER.RECEIVERLNAME = txtRECEIVERLNAME.Text;
            rECEIVER.RECEIVERADDRESS1 = txtRECEIVERADDRESS1.Text;
            rECEIVER.RECEIVERADDRESS2 = txtRECEIVERADDRESS2.Text;
            rECEIVER.RECEIVERCITY = txtRECEIVERCITY.Text;
            rECEIVER.RECEIVERSTATE = txtRECEIVERSTATE.Text;
            rECEIVER.RECEIVERZIP = txtRECEIVERZIP.Text;
            rECEIVER.RECEIVERPHONE = txtRECEIVERPHONE.Text;
            rECEIVER.SCANURL = "";
            rECEIVER.CREATEDBY = 1;
            rECEIVER.CREATEDON = DateTime.Now;
            rECEIVER.UPDATEDBY = 1;
            rECEIVER.UPDATEDON = DateTime.Now;

            if (uplFile.PostedFile != null && uplFile.PostedFile.ContentLength > 0)
            {
                try
                {
                    string dirUrl = "~/Uploads/Receiver";
                    string dirPath = Server.MapPath(dirUrl);

                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    string fileName = Path.GetFileName(uplFile.PostedFile.FileName);
                    string fileUrl = dirUrl + "/" + Path.GetFileName(uplFile.PostedFile.FileName);
                    string filePath = Server.MapPath(fileUrl);
                    uplFile.PostedFile.SaveAs(filePath);

                    rECEIVER.SCANURL = dirUrl + "/" + fileName;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message.ToString();

                }
            }
            else
            {

                rECEIVER.SCANURL = "~/Uploads/Receiver/no_image.jpeg";
            }

            int resutl = RECEIVERManager.InsertRECEIVER(rECEIVER);
            if (resutl > 0)
            {
                Session["snreceiverID"] = resutl.ToString();
                Response.Redirect("SearchLocation.aspx");
            }
        }
        else
        {
            lblMessage.Text = "Please enter the First Name and Last Name...";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }

    }
    protected void btnScanID_Click(object sender, EventArgs e)
    {

    }
}