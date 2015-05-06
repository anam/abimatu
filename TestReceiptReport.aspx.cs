using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.Data;
public partial class TestReceiptReport : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    SqlTRANSProvider sqlTRANSProvider = new SqlTRANSProvider();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
        this.Response.AddHeader("Content-disposition", "attachment; filename=HistoryReport.pdf");
        this.Response.BinaryWrite(pdfContent);
        this.Response.End();
    }

    protected DataTable GetAllTransInfoByReferenceCode()
    {
        dt = new DataTable();
        dt = sqlTRANSProvider.GetAllTransInfoByReferenceCodeForReport("11AFS140,11AFS141,11AFS142");
        return dt;
    }
}