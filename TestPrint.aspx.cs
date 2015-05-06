using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Collections;
using System.Net;
using iTextSharp;
using System.Data;
public partial class TestPrint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
            showLOCATIONGrid();
        //}
    }

    private void showLOCATIONGrid()
    {
        GridView1.DataSource = LOCATIONManager.GetAllLOCATIONs().FindAll(x => x.COUNTRY == "GUINEA");
        GridView1.DataBind();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //Response.ContentType = "application/pdf";

        //Response.AddHeader("content-disposition",

        // "attachment;filename=GridViewExport.pdf");

        //Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //StringWriter sw = new StringWriter();

        //HtmlTextWriter hw = new HtmlTextWriter(sw);

        //gvLOCATION.AllowPaging = false;

        //gvLOCATION.DataBind();

        //gvLOCATION.RenderControl(hw);

        //StringReader sr = new StringReader(sw.ToString());

        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

        //pdfDoc.Open();

        //htmlparser.Parse(sr);

        //pdfDoc.Close();

        //Response.Write(pdfDoc);

        //Response.End();  


        //Total no of columns to be displayed
        //int columnCount = 3;

        //Total no of records in gridview
        //int rowCount = GridView1.Rows.Count;

        //int tableRows = rowCount;

        //Creating Dynamic Table using iTextSharp namespace

        //iTextSharp.text.Table grdTable = new iTextSharp.text.Table(columnCount, tableRows);

        //Giving Bordor to the Table
        //grdTable.BorderWidth = 1;

        //Creating First Row that will contain the Title

        //iTextSharp.text.Font fontIstRow = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 8);
        //iTextSharp.text.Cell c1 = new iTextSharp.text.Cell("");
        //c1.Add(new iTextSharp.text.Chunk("Student Result Card", fontIstRow));
        //c1.SetHorizontalAlignment("center");
        //c1.Colspan = 4;
        //c1.Header = true;
        //grdTable.AddCell(c1);
        //c1.UseBorderPadding = false;
        //grdTable.BorderColor = System.Drawing.Color();

        //Creating Sec Row that will contain 4 cells containing columns name

        //iTextSharp.text.Font fontSecRow = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 7);
        //iTextSharp.text.Cell c2 = new iTextSharp.text.Cell("");
        //c2.Add(new iTextSharp.text.Chunk("Sr No.", fontSecRow));
        //c2.SetHorizontalAlignment("center");
        //grdTable.AddCell(c2);

        //iTextSharp.text.Cell c3 = new iTextSharp.text.Cell("");
        //c3.Add(new iTextSharp.text.Chunk("First Name", fontSecRow));
        //c3.SetHorizontalAlignment("center");
        //grdTable.AddCell(c3);

        //iTextSharp.text.Cell c4 = new iTextSharp.text.Cell("");
        //c4.Add(new iTextSharp.text.Chunk("Last Name", fontSecRow));
        //c4.SetHorizontalAlignment("center");
        //grdTable.AddCell(c4);

        //iTextSharp.text.Cell c5 = new iTextSharp.text.Cell("");
        //c5.Add(new iTextSharp.text.Chunk("Result", fontSecRow));
        //c5.SetHorizontalAlignment("center");
        //grdTable.AddCell(c5);

        //Now creating Dynmaic Rows that will contain the gridview data

        //iTextSharp.text.Font fontDynmaicRows = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 6);

        //for (int rowCounter = 0; rowCounter < rowCount; rowCounter++)
        //{
        //    for (int columnCounter = 0; columnCounter < columnCount; columnCounter++)
        //    {
        //        string strValue = "";
        //        if (columnCounter == 0)
        //        {
        //            if (GridView1.Rows[rowCounter].Visible == true)
        //            {

        //                Label SerialNo = GridView1.Rows[rowCounter].Cells[0].FindControl("lblSrNo") as Label;
        //                strValue = SerialNo.Text;
        //                iTextSharp.text.Cell c6 = new iTextSharp.text.Cell("");
        //                c6.Add(new iTextSharp.text.Chunk(strValue, fontDynmaicRows));
        //                c6.SetHorizontalAlignment("center");
        //                grdTable.AddCell(c6);
        //            }
        //        }
        //        else if (columnCounter == 1)
        //        {
        //            if (GridView1.Rows[rowCounter].Visible == true)
        //            {

        //                Label FirstName = GridView1.Rows[rowCounter].Cells[1].FindControl("lblFirstName") as Label;
        //                strValue = FirstName.Text;
        //                iTextSharp.text.Cell c6 = new iTextSharp.text.Cell("");
        //                c6.Add(new iTextSharp.text.Chunk(strValue, fontDynmaicRows));
        //                grdTable.AddCell(c6);
        //            }
        //        }
        //        else if (columnCounter == 2)
        //        {
        //            if (GridView1.Rows[rowCounter].Visible == true)
        //            {

        //                Label LastName = GridView1.Rows[rowCounter].Cells[2].FindControl("lblLastName") as Label;
        //                strValue = LastName.Text;
        //                iTextSharp.text.Cell c6 = new iTextSharp.text.Cell("");
        //                c6.Add(new iTextSharp.text.Chunk(strValue, fontDynmaicRows));
        //                grdTable.AddCell(c6);
        //            }
        //        }
        //        else if (columnCounter == 3)
        //        {
        //            if (GridView1.Rows[rowCounter].Visible == true)
        //            {
        //                strValue = GridView1.Rows[rowCounter].Cells[3].Text; //For Data Bound Field
        //                Label Status = GridView1.Rows[rowCounter].Cells[3].FindControl("lblStatus") as Label;
        //                strValue = Status.Text;
        //                iTextSharp.text.Cell c6 = new iTextSharp.text.Cell("");
        //                c6.Add(new iTextSharp.text.Chunk(strValue, fontDynmaicRows));
        //                grdTable.AddCell(c6);
        //            }
        //        }
        //    }
        //}
        //Giving Cell Padding and Cell Spacing to the Dynamic Table
        //grdTable.Cellpadding = 1;
        //grdTable.Cellspacing = 1;

        //iTextSharp.text.Document Doc = new iTextSharp.text.Document();
        //iTextSharp.text.pdf.PdfWriter.GetInstance(Doc, Response.OutputStream);
        //Doc.Open();
        //Doc.Add(grdTable);
        //Doc.Close();
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment; filename=ViewResult.pdf");
        //Response.End();


        ExportToPDF("Test", GridView1, false, "Test1.pdf");
    }



    public void ExportToPDF(string ReportName, GridView grdPDF, bool isLandscape, string Filename)
    {
        int noOfColumns = 0, noOfRows = 0;
        DataTable tbl = null;
        if (grdPDF.AutoGenerateColumns)
        {
            tbl = grdPDF.DataSource as DataTable; // Gets the DataSource of the GridView Control.
            noOfColumns = tbl.Columns.Count;
            noOfRows = tbl.Rows.Count;
        }
        else
        {
            noOfColumns = grdPDF.Columns.Count;
            noOfRows = grdPDF.Rows.Count;
        }
        float HeaderTextSize = 8;
        float ReportNameSize = 10;
        float ReportTextSize = 8;
        float ApplicationNameSize = 7;

        // Creates a PDF document
        Document document = null;
        if (isLandscape == true)
        {
            // Sets the document to A4 size and rotates it so that the orientation of the page is Landscape.
            document = new Document(PageSize.A4.Rotate(), 0, 0, 15, 5);
        }
        else
        {
            document = new Document(PageSize.A4, 0, 0, 15, 5);
        }

        PdfPTable mainTable = new iTextSharp.text.pdf.PdfPTable(noOfColumns);
        // Sets the first 4 rows of the table as the header rows which will be repeated in all the pages.
        mainTable.HeaderRows = 4;

        // Creates a PdfPTable with 2 columns to hold the header in the exported PDF.
        PdfPTable headerTable = new iTextSharp.text.pdf.PdfPTable(2);
        //iTextSharp.text.Image imgLogo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("../Images/medtech_logo.jpg"));
        //imgLogo.ScaleToFit(100, 25);

        //PdfPCell clApplicationName = new PdfPCell(imgLogo);
        //clApplicationName.Border = PdfPCell.NO_BORDER;
        //clApplicationName.HorizontalAlignment = Element.ALIGN_LEFT;

        // Creates a phrase to show the current date at the right hand side of the header.
        Phrase phDate = new Phrase(DateTime.Now.Date.ToString("dd-MMM-yyyy"), FontFactory.GetFont("Arial", ApplicationNameSize, iTextSharp.text.Font.NORMAL));
        // Creates a PdfPCell which accepts the date phrase as a parameter.
        PdfPCell clDate = new PdfPCell(phDate);
        // Sets the Horizontal Alignment of the PdfPCell to right.
        clDate.HorizontalAlignment = Element.ALIGN_RIGHT;
        // Sets the border of the cell to zero.
        clDate.Border = PdfPCell.NO_BORDER;

        //headerTable.AddCell(clApplicationName);
        headerTable.AddCell(clDate);
        headerTable.DefaultCell.Border = PdfPCell.NO_BORDER;

        // Creates a PdfPCell that accepts the headerTable as a parameter and then adds that cell to the main PdfPTable.
        PdfPCell cellHeader = new PdfPCell(headerTable);
        cellHeader.Border = PdfPCell.NO_BORDER;
        // Sets the column span of the header cell to noOfColumns.
        cellHeader.Colspan = noOfColumns;
        // Adds the above header cell to the table.
        mainTable.AddCell(cellHeader);

        // Creates a phrase which holds the file name.
        //Phrase phHeader = new Phrase(sApplicationName, FontFactory.GetFont("Arial", ReportNameSize, iTextSharp.text.Font.BOLD));
        //PdfPCell clHeader = new PdfPCell(phHeader);
        //clHeader.Colspan = noOfColumns;
        //clHeader.Border = PdfPCell.NO_BORDER;
        //clHeader.HorizontalAlignment = Element.ALIGN_CENTER;
        //mainTable.AddCell(clHeader);

        // Creates a phrase for a new line.
        Phrase phSpace = new Phrase("\n");
        PdfPCell clSpace = new PdfPCell(phSpace);
        clSpace.Border = PdfPCell.NO_BORDER;
        clSpace.Colspan = noOfColumns;
        mainTable.AddCell(clSpace);

        // Sets the gridview column names as table headers.
        for (int i = 0; i < noOfColumns; i++)
        {
            Phrase ph = null;
            if (grdPDF.AutoGenerateColumns)
                ph = new Phrase(tbl.Columns[i].ColumnName, FontFactory.GetFont("Arial", HeaderTextSize, iTextSharp.text.Font.BOLD));
            else
                ph = new Phrase(grdPDF.Columns[i].HeaderText, FontFactory.GetFont("Arial", HeaderTextSize, iTextSharp.text.Font.BOLD));
            mainTable.AddCell(ph);
        }

        // Reads the gridview rows and adds them to the mainTable
        for (int rowNo = 0; rowNo < noOfRows; rowNo++)
        {
            for (int columnNo = 0; columnNo < noOfColumns; columnNo++)
            {
                if (grdPDF.AutoGenerateColumns)
                {
                    string s = grdPDF.Rows[rowNo].Cells[columnNo].Text.Trim();
                    Phrase ph = new Phrase(s, FontFactory.GetFont("Arial", ReportTextSize, iTextSharp.text.Font.NORMAL));
                    mainTable.AddCell(ph);
                }
                else
                {
                    string s = "";
                    if (grdPDF.Columns[columnNo] is TemplateField)
                    {
                        DataBoundLiteralControl lc = grdPDF.Rows[rowNo].Cells[columnNo].Controls[0] as DataBoundLiteralControl;
                        if (lc != null)
                        {
                            s = lc.Text.Trim();
                        }
                        else
                        {
                            for (int i = 0; i < grdPDF.Rows[rowNo].Cells[columnNo].Controls.Count; i++)
                            {
                                if (grdPDF.Rows[rowNo].Cells[columnNo].Controls[i].GetType() == typeof(TextBox))
                                {
                                    s = (grdPDF.Rows[rowNo].Cells[columnNo].Controls[i] as TextBox).Text;
                                }
                                else if (grdPDF.Rows[rowNo].Cells[columnNo].Controls[i].GetType() == typeof(Label))
                                {
                                    s = (grdPDF.Rows[rowNo].Cells[columnNo].Controls[i] as Label).Text;
                                }
                                else if (grdPDF.Rows[rowNo].Cells[columnNo].Controls[i].GetType() == typeof(System.Web.UI.WebControls.Image))
                                {
                                    s = (grdPDF.Rows[rowNo].Cells[columnNo].Controls[i] as System.Web.UI.WebControls.Image).ToolTip;
                                }
                            }
                        }
                        Phrase ph = new Phrase(s, FontFactory.GetFont("Arial", ReportTextSize, iTextSharp.text.Font.NORMAL));
                        mainTable.AddCell(ph);
                    }
                    else
                    {
                        s = grdPDF.Rows[rowNo].Cells[columnNo].Text.Trim();
                        Phrase ph = new Phrase(s, FontFactory.GetFont("Arial", ReportTextSize, iTextSharp.text.Font.NORMAL));
                        mainTable.AddCell(ph);
                    }
                }
            }
            mainTable.CompleteRow();
        }

        PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
        //HeaderFooter pdfFooter = new HeaderFooter(new Phrase(), true);
        //pdfFooter.Alignment = Element.ALIGN_CENTER;
        //pdfFooter.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //document.Footer = pdfFooter;
        document.Open();
        document.Add(mainTable);
        document.Close();

        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename= " + Filename + "_" + DateTime.Now.ToString("dd_MMM_yyyy") + ".pdf");
        HttpContext.Current.Response.End();
    }
}