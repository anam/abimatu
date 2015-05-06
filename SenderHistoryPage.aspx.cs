using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.Data;
public partial class SenderHistoryPage : System.Web.UI.Page
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
                
                if ( Request.QueryString["cUSTID"]  != null)
                {
                    showTRANSGrid();
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
    private void showTRANSGrid()
    {
        gvTRANS.DataSource = TRANSManager.GetAllTRANSsByCustomerID(int.Parse(Request.QueryString["cUSTID"].ToString()));
        gvTRANS.DataBind();
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        printReport();
    }
    protected void gvTRANS_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        gvTRANS.PageIndex = e.NewPageIndex;
        showTRANSGrid();
    }
    protected void gvTRANS_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblCUSTID = (Label)e.Row.FindControl("lblCUSTID");
            Label lblRECEIVERID = (Label)e.Row.FindControl("lblRECEIVERID");
            Label lblLOCATIONID = (Label)e.Row.FindControl("lblLOCATIONID");
            Label lblCustName = (Label)e.Row.FindControl("lblCustName");
            Label lblreceiverName = (Label)e.Row.FindControl("lblreceiverName");
            Label lblLocationName = (Label)e.Row.FindControl("lblLocationName");


            CUSTOMER cUSTOMER = new CUSTOMER();
            cUSTOMER = CUSTOMERManager.GetCUSTOMERByID(int.Parse(lblCUSTID.Text));

            if (cUSTOMER != null)
            {
                lblCustName.Text = cUSTOMER.CUSTFNAME + " " + cUSTOMER.CUSTMNAME + " " + cUSTOMER.CUSTLNAME;
            }

            RECEIVER rECEIVER = new RECEIVER();
            rECEIVER = RECEIVERManager.GetRECEIVERByID(int.Parse(lblRECEIVERID.Text));

            if (rECEIVER != null)
            {
                lblreceiverName.Text = rECEIVER.RECEIVERFNAME + " " + rECEIVER.RECEIVERMNAME + " " + rECEIVER.RECEIVERLNAME;
            }

            LOCATION lOCATION = new LOCATION();
            lOCATION = LOCATIONManager.GetLOCATIONByID(int.Parse(lblLOCATIONID.Text));

            if (lOCATION != null)
            {
                lblLocationName.Text = lOCATION.BRANCH.ToString();
            }

        }
    }

    protected void printReport()
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "dsCustHistory_dtHistory";
        rds.Value = GetAllTransInfoByCustID();
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/rptCustHistory.rdlc");
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
        this.Response.AddHeader("Content-disposition", "attachment; filename=HistoryReport.pdf");
        this.Response.BinaryWrite(pdfContent);
        this.Response.End();
    }

    protected DataTable GetAllTransInfoByCustID()
    {
        dt = new DataTable();
        dt = sqlTRANSProvider.GetAllTransInfoByCustID(int.Parse(Request.QueryString["cUSTID"].ToString()));
        return dt;
    }

}