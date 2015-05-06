using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using Microsoft.ApplicationBlocks.Data;
using Microsoft.Reporting.WebForms;

public partial class TestReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource();
        //rds.DataSourceId = "AbiMatuEnterprise_GetAllAGENTs";
        //rds.Name = "dsReceipt";
        //rvProducts.LocalReport.DataSources.Clear();
        //rvProducts.Reset();
        //rvProducts.LocalReport.Refresh();

        //rvProducts.LocalReport.ReportPath = "Report.rdlc";
        //rvProducts.LocalReport.DataSources.Add(rds);
        //rvProducts.LocalReport.Refresh();


        //Fill the datasource from DB
        //AdventureWorksTableAdapters.vProductAndDescriptionTableAdapter ta = new AdventureWorksTableAdapters.vProductAndDescriptionTableAdapter();
        //AdventureWorks.vProductAndDescriptionDataTable dt = new AdventureWorks.vProductAndDescriptionDataTable();
        //ta.Fill(dt);

        ////Create an instance of Barcode Professional
        //Neodynamic.WebControls.BarcodeProfessional.BarcodeProfessional bcp = new Neodynamic.WebControls.BarcodeProfessional.BarcodeProfessional();
        ////Barcode settings
        //bcp.Symbology = Neodynamic.WebControls.BarcodeProfessional.Symbology.Code128;
        //bcp.BarHeight = 0.25f;

        ////Update DataTable with barcode image
        //foreach (AdventureWorks.vProductAndDescriptionRow row in dt.Rows)
        //{
        //    //Set the value to encode
        //    bcp.Code = row.ProductID.ToString();
        //    //Generate the barcode image and store it into the Barcode Column
        //    row.Barcode = bcp.GetBarcodeImage(System.Drawing.Imaging.ImageFormat.Png);
        //}

        ////Create ReportViewer
        //Microsoft.Reporting.WebForms.ReportViewer viewer = new Microsoft.Reporting.WebForms.ReportViewer();

        ////Create Report Data Source
        //Microsoft.Reporting.WebForms.ReportDataSource rptDataSource = new Microsoft.Reporting.WebForms.ReportDataSource("AdventureWorks_vProductAndDescription", dt);

        //viewer.LocalReport.DataSources.Add(rptDataSource);
        //viewer.LocalReport.ReportPath = Server.MapPath("BarcodeReport.rdlc");

        ////Export to PDF
        //string mimeType;
        //string encoding;
        //string fileNameExtension;
        //string[] streams;
        //Microsoft.Reporting.WebForms.Warning[] warnings;

        //byte[] pdfContent = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

        ////Return PDF
        //this.Response.Clear();
        //this.Response.ContentType = "application/pdf";
        //this.Response.AddHeader("Content-disposition", "attachment; filename=BarcodeReport.pdf");
        //this.Response.BinaryWrite(pdfContent);
        //this.Response.End();

        SqlLOCATIONProvider sqlLOCATIONProvider=new SqlLOCATIONProvider();
        DataTable dt = new DataTable();

        dt = sqlLOCATIONProvider.GetAllLOCATIONsForReport();

        //GridView1.DataSource = dt;
        //GridView1.DataBind();


        //Create ReportViewer
        Microsoft.Reporting.WebForms.ReportViewer viewer = new Microsoft.Reporting.WebForms.ReportViewer();

        //Create Report Data Source
        Microsoft.Reporting.WebForms.ReportDataSource rptDataSource = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", dt);

        viewer.LocalReport.DataSources.Add(rptDataSource);
        viewer.LocalReport.ReportPath = Server.MapPath("Report.rdlc");

        
    }
}