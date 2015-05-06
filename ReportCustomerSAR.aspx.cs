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

public partial class ReportCustomerSAR : System.Web.UI.Page
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
            
                txtFromDate.Text = DateTime.Now.ToShortDateString();
                txtToDate.Text = DateTime.Now.ToShortDateString();
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetCustomerForSARSearch();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ExportToPDF();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }


    protected void gvCustomer_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblCUSTID = (Label)e.Row.FindControl("lblCUSTID");
            Label lblTRANSDT = (Label)e.Row.FindControl("lblTRANSDT");
            Label lblCUSTNAME = (Label)e.Row.FindControl("lblCUSTNAME");
            Label lblReceiver = (Label)e.Row.FindControl("lblReceiver");
            Label lblLocation = (Label)e.Row.FindControl("lblLocation");

            Label lblRECEIVERID = (Label)e.Row.FindControl("lblRECEIVERID");
            Label lblLOCATIONID = (Label)e.Row.FindControl("lblLOCATIONID");

            
                
            CUSTOMER cUSTOMER = new CUSTOMER();
            cUSTOMER = CUSTOMERManager.GetCUSTOMERByID(int.Parse(lblCUSTID.Text));


            if (cUSTOMER != null)
            {
                lblCUSTNAME.Text = cUSTOMER.CUSTFNAME + " " + cUSTOMER.CUSTMNAME + " " + cUSTOMER.CUSTLNAME;
            }


            //RECEIVER rECEIVER = new RECEIVER();
            //rECEIVER = RECEIVERManager.GetRECEIVERByID(int.Parse(lblRECEIVERID.Text));

            //if (rECEIVER != null)
            //{
            //    lblReceiver.Text = rECEIVER.RECEIVERFNAME.ToString();
            //}

            //LOCATION lOCATION = new LOCATION();
            //lOCATION = LOCATIONManager.GetLOCATIONByID(int.Parse(lblLOCATIONID.Text));

            //if (lOCATION != null)
            //{
            //    lblLocation.Text = lOCATION.BRANCH.ToString();
            //}



            GridView gvTRANS = (GridView)e.Row.FindControl("gvTRANS");

            gvTRANS.DataSource = TRANSManager.GetAllTRANSsByTRANSDT_CUSTOMER(int.Parse(lblCUSTID.Text), DateTime.Parse(lblTRANSDT.Text));
            gvTRANS.DataBind();



        }
    }

    protected void gvTRANS_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblReceiver = (Label)e.Row.FindControl("lblReceiver");
            Label lblLocation = (Label)e.Row.FindControl("lblLocation");

            Label lblRECEIVERID = (Label)e.Row.FindControl("lblRECEIVERID");
            Label lblLOCATIONID = (Label)e.Row.FindControl("lblLOCATIONID");

            RECEIVER rECEIVER = new RECEIVER();
            rECEIVER = RECEIVERManager.GetRECEIVERByID(int.Parse(lblRECEIVERID.Text));

            if (rECEIVER != null)
            {
                lblReceiver.Text = rECEIVER.RECEIVERFNAME.ToString();
            }

            LOCATION lOCATION = new LOCATION();
            lOCATION = LOCATIONManager.GetLOCATIONByID(int.Parse(lblLOCATIONID.Text));

            if (lOCATION != null)
            {
                lblLocation.Text = lOCATION.BRANCH.ToString();
            }

        }
    }
    protected void GetCustomerForSARSearch()
    {
        gvCustomer.DataSource = TRANSManager.GetAllSARFromTransBYDate(DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text));
        gvCustomer.DataBind();
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

            iTextSharp.text.Table datatable = new iTextSharp.text.Table(8);

            datatable.Padding = 2;
            datatable.Spacing = 0;

            float[] headerwidths = { 12, 12, 12, 16, 12, 12, 12, 12 };
            datatable.Widths = headerwidths;

            // the first cell spans 7 columns
            Cell cell = new Cell(new Phrase("Customer Wise SAR Report", FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Leading = 30;
            cell.Colspan = 8;
            cell.Border = Rectangle.NO_BORDER;
            cell.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.Gray);
            datatable.AddCell(cell);


            int parentGridCount = 0;
            parentGridCount = gvCustomer.Rows.Count;


            //int rowCount = gvFoodTransactionItemRelation.Rows.Count;

            for (int i = 0; i < parentGridCount; i++)
            {

                Label lblCUSTNAME = (Label)gvCustomer.Rows[i].FindControl("lblCUSTNAME");
                Label lblTRANSTOTALAMOUNT = (Label)gvCustomer.Rows[i].FindControl("lblTRANSTOTALAMOUNT");

                Cell cell1 = new Cell(new Phrase("Customer Name : " + lblCUSTNAME.Text, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));
                cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                cell1.Leading = 30;
                cell1.Colspan = 4;
                cell1.Border = Rectangle.NO_BORDER;
                cell1.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.WhiteSmoke);
                datatable.AddCell(cell1);



                Cell cell4 = new Cell(new Phrase("Total Amount : " + lblTRANSTOTALAMOUNT.Text, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));
                cell4.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell4.Leading = 30;
                cell4.Colspan = 4;
                cell4.Border = Rectangle.NO_BORDER;
                cell4.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.WhiteSmoke);
                datatable.AddCell(cell4);

                datatable.DefaultCellBorderWidth = 1;
                datatable.DefaultHorizontalAlignment = 1;
                datatable.DefaultRowspan = 2;
                datatable.AddCell("Date");
                datatable.AddCell("Ref Code");
                datatable.AddCell("Receiver");
                datatable.AddCell("Location");
                datatable.AddCell("Amount");
                datatable.AddCell("Fees");
                datatable.AddCell("Discount");
                datatable.AddCell("Amount");



                GridView gvTRANS = (GridView)gvCustomer.Rows[i].FindControl("gvTRANS");



                for (int j = 0; j < gvTRANS.Rows.Count; j++)
                {
                    datatable.DefaultHorizontalAlignment = Element.ALIGN_LEFT;
                    


                    Label lblTransactionDate = (Label)gvTRANS.Rows[j].FindControl("lblTransactionDate");
                    Label lblReferenceCode = (Label)gvTRANS.Rows[j].FindControl("lblReferenceCode");
                    Label lblReceiver = (Label)gvTRANS.Rows[j].FindControl("lblReceiver");
                    Label lblLocation = (Label)gvTRANS.Rows[j].FindControl("lblLocation");
                    Label lblSendingAmount = (Label)gvTRANS.Rows[j].FindControl("lblSendingAmount");
                    Label lblServiceCharge = (Label)gvTRANS.Rows[j].FindControl("lblServiceCharge");
                    Label lblDiscount = (Label)gvTRANS.Rows[j].FindControl("lblDiscount");
                    Label lblTotalCharge = (Label)gvTRANS.Rows[j].FindControl("lblTotalCharge");

                    datatable.Alignment = Element.ALIGN_CENTER;

                    //Cell celllblTransactionDate = new Cell(new Phrase(lblTransactionDate.Text, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL)));
                    datatable.AddCell(new Phrase(lblTransactionDate.Text, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL)));
                    datatable.AddCell(new Phrase(lblReferenceCode.Text, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL)));
                    datatable.AddCell(new Phrase(lblReceiver.Text, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL)));
                    datatable.AddCell(new Phrase(lblLocation.Text, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL)));
                    datatable.AddCell(new Phrase(lblSendingAmount.Text, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL)));
                    datatable.AddCell(new Phrase(lblServiceCharge.Text, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL)));
                    datatable.AddCell(new Phrase(lblDiscount.Text, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL)));
                    datatable.AddCell(new Phrase(lblTotalCharge.Text, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL)));
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
        Response.AddHeader("content-disposition", "attachment;filename=CustomerSARReport.pdf");
        Response.ContentType = "application/pdf";
        Response.BinaryWrite(msReport.ToArray());
        Response.End();
    }

}