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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Collections;
using System.Net;
using iTextSharp;


public partial class TestPrint1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ExportToPDF();
    }


    private void ExportToPDF()
    {
        Document document = new Document(PageSize.A4, 0, 0, 10, 10);
        System.IO.MemoryStream msReport = new System.IO.MemoryStream();

        try
        {
            // creation of the different writers
            PdfWriter writer = PdfWriter.GetInstance(document, msReport);

            // we add some meta information to the document
            document.AddAuthor("Maruf");
            document.AddSubject("Report");

            document.Open();

            iTextSharp.text.Table datatable = new iTextSharp.text.Table(7);

            datatable.Padding = 2;
            datatable.Spacing = 0;

            float[] headerwidths = { 15, 15, 15, 15, 10, 15, 15 };
            datatable.Widths = headerwidths;

            // the first cell spans 7 columns
            Cell cell = new Cell(new Phrase("Location Wise Report", FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Leading = 30;
            cell.Colspan = 7;
            cell.Border = Rectangle.NO_BORDER;
            cell.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.Gray);
            datatable.AddCell(cell);

            //gvLocation.AllowPaging = false;
            //gvLocation.DataBind();

            int parentGridCount = 0;
            parentGridCount = 5;


            //int rowCount = gvFoodTransactionItemRelation.Rows.Count;

            for (int i = 0; i < parentGridCount; i++)
            {


                Cell cellCountry = new Cell(new Phrase("Country : " + "Demo Text", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));
                cellCountry.HorizontalAlignment = Element.ALIGN_LEFT;
                cellCountry.Leading = 30;
                cellCountry.Colspan = 7;
                cellCountry.Border = Rectangle.NO_BORDER;
                cellCountry.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.WhiteSmoke);

                Cell cellCity = new Cell(new Phrase("City : " + "Demo Text", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));
                cellCity.HorizontalAlignment = Element.ALIGN_LEFT;
                cellCity.Leading = 30;
                cellCity.Colspan = 7;
                cellCity.Border = Rectangle.NO_BORDER;
                cellCity.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.WhiteSmoke);

                Cell cell1 = new Cell(new Phrase("Branch : " + "Demo Text", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));
                cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                cell1.Leading = 30;
                cell1.Colspan = 7;
                cell1.Border = Rectangle.NO_BORDER;
                cell1.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.WhiteSmoke);

                datatable.AddCell(cell1);
                datatable.AddCell(cellCountry);
                datatable.AddCell(cellCity);

                datatable.DefaultCellBorderWidth = 1;
                datatable.DefaultHorizontalAlignment = 1;
                datatable.DefaultRowspan = 2;
                datatable.AddCell("Date");
                datatable.AddCell("Ref Code");
                datatable.AddCell("Amount");
                datatable.AddCell("Fees");
                datatable.AddCell("Discount");
                datatable.AddCell("Total Amount");
                datatable.AddCell("Status");



                //GridView gvTRANS = (GridView)gvLocation.Rows[i].FindControl("gvTRANS");



                for (int j = 0; j < 2; j++)
                {
                    datatable.DefaultHorizontalAlignment = Element.ALIGN_LEFT;





                    datatable.Alignment = Element.ALIGN_CENTER;

                    datatable.AddCell(new Phrase("Demo Text", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL)));
                    datatable.AddCell(new Phrase("Demo Text", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL)));
                    datatable.AddCell(new Phrase("Demo Text", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL)));
                    datatable.AddCell(new Phrase("Demo Text", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL)));
                    datatable.AddCell(new Phrase("Demo Text", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL)));
                    datatable.AddCell(new Phrase("Demo Text", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL)));
                    datatable.AddCell(new Phrase("Demo Text", FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL)));
                }







            }





            document.Add(datatable);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);
        }

        // we close the document 
        document.Close();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=LocationWiseReport.pdf");
        Response.ContentType = "application/pdf";
        Response.BinaryWrite(msReport.ToArray());
        Response.End();
    }
}