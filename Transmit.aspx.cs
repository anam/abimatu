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

public partial class SearchLocation : System.Web.UI.Page
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
            }


            if (Session["ssReferenceCode"] != null)
            {
                List<string> ssReferenceCodeFINAL = new List<string>();
                ssReferenceCodeFINAL = (List<string>)Session["ssReferenceCode"];

                string stReferenceCode = string.Empty;
                for (int i = 0; i < ssReferenceCodeFINAL.Count; i++)
                {
                    lblReferenceCODE.Text = stReferenceCode.ToString() + "<br/><a href='EditPayment.aspx?REFCODE=" + ssReferenceCodeFINAL[i].ToString() + "' target='_blank'>" + ssReferenceCodeFINAL[i].ToString()+"</a>";

                    stReferenceCode = lblReferenceCODE.Text;

                }



            }
            else
            {
                Response.Redirect("SearchSenderPage.aspx");
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

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session.Remove("ssReferenceCode");
        Session.Remove("snlocationID");
        Session.Remove("snsenderID");
        Response.Redirect("Default.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        if (Session["ssReferenceCode"] != null)
        {
            printReport();


        }
        else
        {
            Response.Redirect("SearchSenderPage.aspx");
        }
    }

    protected void btnReceipt_Click(object sender, EventArgs e)
    {

        
        if (Session["ssReferenceCode"] != null)
        {
            printReport();


        }
        else
        {
            Response.Redirect("SearchSenderPage.aspx");
        }
    }


    #region Added By Maruf (Export PDF)
 
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
        List<string> ssReferenceCodeFINAL = new List<string>();
        ssReferenceCodeFINAL = (List<string>)Session["ssReferenceCode"];
        string stReferenceCode1 = string.Empty;
        string stReferenceCode2 = string.Empty;
        for (int i = 0; i < ssReferenceCodeFINAL.Count; i++)
        {
            if (i == 0)
            {
                stReferenceCode2 = stReferenceCode1.ToString() + ssReferenceCodeFINAL[i].ToString();
            }
            else
            {
                stReferenceCode2 = stReferenceCode1.ToString() + "," + ssReferenceCodeFINAL[i].ToString();
            }
            stReferenceCode1 = stReferenceCode2;

        }
        dt = new DataTable();
        dt = sqlTRANSProvider.GetAllTransInfoByReferenceCodeForReport(stReferenceCode1);
        return dt;
    }

#endregion

    protected void btnAnotherTransaction_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchReceiverPage.aspx");
    }
}