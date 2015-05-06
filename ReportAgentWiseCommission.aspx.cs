using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Collections;
using System.Net;
using iTextSharp;

public partial class ReportAgentWiseCommission : System.Web.UI.Page
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
            }


            txtFromDate.Text = DateTime.Today.ToShortDateString();
            txtToDate.Text = DateTime.Today.ToShortDateString();
            //loadReport();
            loadLocation();
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

    private void loadLocation()
    {
        List<LOCATION> locations = new List<LOCATION>();
        locations = LOCATIONManager.GetAllLOCATIONs();
        dlLocation.DataSource = locations;
        dlLocation.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //lblSubTotalSendingAmountTotal.Text = "0";
        //lblSubTotalFeesTotal.Text = "0";
        //lblSubTotalDiscountTotal.Text = "0";
        //lblSubTotalTotalAmountTotal.Text = "0";

        loadReport();
    }

    private string getLocationIDs()
    {
        string locationIDs="0";
        foreach (GridViewRow gr in dlLocation.Rows)
        {
            CheckBox chkSelect = (CheckBox)gr.FindControl("chkSelect");

            HiddenField hfLocationID = (HiddenField)gr.FindControl("hfLocationID");

            if (chkSelect.Checked || chkAllLocations.Checked)
            {
                if (locationIDs == "") locationIDs = hfLocationID.Value;
                else locationIDs += "," + hfLocationID.Value;
            }
        }
        return locationIDs;
    }

    private void loadReport()
    {
        gvAgent.DataSource = AGENTManager.GetAllAGENTsForReportByDatenAmountnLocations(getLocationIDs(), txtFromDate.Text, txtToDate.Text, int.Parse(txtMoney.Text == "" ? "0" : txtMoney.Text));
        gvAgent.DataBind();

        //lblSubTotalSendingAmountTotal.Text = string.Format("{0:C}", double.Parse(lblSubTotalSendingAmountTotal.Text));
        //lblSubTotalFeesTotal.Text = string.Format("{0:C}", double.Parse(lblSubTotalFeesTotal.Text));
        //lblSubTotalDiscountTotal.Text = string.Format("{0:C}", double.Parse(lblSubTotalDiscountTotal.Text));
        //lblSubTotalTotalAmountTotal.Text = string.Format("{0:C}", double.Parse(lblSubTotalTotalAmountTotal.Text));
    }
    protected void gvLocation_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hfAgnetID = (HiddenField)e.Row.FindControl("hfAgnetID");
            GridView gvPayment = (GridView)e.Row.FindControl("gvPayment");

            List<TRANS> tRANSs = new List<TRANS>();
            tRANSs = TRANSManager.GetTRANSByAgnetIDnLocationIDsByDateNAmount(getLocationIDs(), int.Parse(hfAgnetID.Value), txtFromDate.Text, txtToDate.Text, int.Parse(txtMoney.Text == "" ? "0" : txtMoney.Text));

            List<TRANS> tRANSsDistinct = new List<TRANS>();
            
            int count = 0;

            for (int i = 0; i < tRANSs.Count; i++)
            {
                count = tRANSsDistinct.FindAll(x => x.LOCATIONID == tRANSs[i].LOCATIONID).Count;

                if (count == 0)
                {
                    tRANSsDistinct.Add(tRANSs[i]);
                }

            }
            gvPayment.DataSource = tRANSsDistinct;
            gvPayment.DataBind();


            decimal totalAgentCommision = 0;
            for (int i = 0; i < gvPayment.Rows.Count; i++)
            {
                Label lblAgentID = (Label)gvPayment.Rows[i].FindControl("lblAgentID");
                lblAgentID.Text = hfAgnetID.Value.ToString();

                Label lblLocationID = (Label)gvPayment.Rows[i].FindControl("lblLocationID");
                Label lblPayAgentID = (Label)gvPayment.Rows[i].FindControl("lblAgentID");
                Label lblTransCount = (Label)gvPayment.Rows[i].FindControl("lblTransCount");
                Label lblRate = (Label)gvPayment.Rows[i].FindControl("lblRate");
                Label lblFees = (Label)gvPayment.Rows[i].FindControl("lblFees");
                Label lblAgentCommision = (Label)gvPayment.Rows[i].FindControl("lblAgentCommision");

                Label lbllocationName = (Label)gvPayment.Rows[i].FindControl("lbllocationName");

                lblPayAgentID.Text = hfAgnetID.Value.ToString();

                if (lblPayAgentID.Text != "")
                {
                    List<TRANS> tRANSsTransactionCount = new List<TRANS>();
                    foreach (TRANS tRANS in tRANSs)
                    {
                        if (tRANS.LOCATIONID == int.Parse(lblLocationID.Text))
                        {
                            tRANSsTransactionCount.Add(tRANS);
                        }
                    }

                    lblTransCount.Text = tRANSsTransactionCount.Count.ToString();

                    LOCATION lOCATION = new LOCATION();
                    lOCATION = LOCATIONManager.GetLOCATIONByID(int.Parse(lblLocationID.Text));

                    lblRate.Text = lOCATION.AGENTRATE.ToString();
                    lbllocationName.Text = lOCATION.BRANCH.ToString();

                    List<decimal> fees = new List<decimal>();
                    for (int j = 0; j < tRANSsTransactionCount.Count; j++)
                    {
                        fees.Add(tRANSsTransactionCount[j].TRANSFEES + tRANSsTransactionCount[j].TRANSOTHERFEES);
                    }

                    lblFees.Text = fees.Sum().ToString();


                    lblAgentCommision.Text =((decimal.Parse(lblRate.Text) * decimal.Parse(lblFees.Text)) / 100).ToString();
                    totalAgentCommision = decimal.Parse(lblAgentCommision.Text) + totalAgentCommision;
                    //just formating the currency
                    lblAgentCommision.Text = String.Format("{0:C}", decimal.Parse(lblAgentCommision.Text));


                    lblRate.Text = lOCATION.AGENTRATE.ToString()+"%";
                }
            }
            
            Label lblTotalAgentCommission = (Label)gvPayment.FooterRow.FindControl("lblTotalAgentCommission");

            lblTotalAgentCommission.Text = String.Format("{0:C}",totalAgentCommision);               
        }
    }



    protected void gvPayment_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ExportToPDF();
    }

    //private void ExportToPDF()
    //{
    //    Document document = new Document(PageSize.A4, 0, 0, 10, 10);
    //    System.IO.MemoryStream msReport = new System.IO.MemoryStream();

    //    try
    //    {
    //        // creation of the different writers
    //        PdfWriter writer = PdfWriter.GetInstance(document, msReport);

    //        // we add some meta information to the document
    //        document.AddAuthor("Maruf");
    //        document.AddSubject("Report");

    //        document.Open();

    //        iTextSharp.text.Table datatable = new iTextSharp.text.Table(5);

    //        datatable.Padding = 2;
    //        datatable.Spacing = 0;

    //        float[] headerwidths = { 30, 15, 15, 15,25 };
    //        datatable.Widths = headerwidths;

    //        // the first cell spans 7 columns
    //        Cell cell = new Cell(new Phrase("Agent Wise Commission", FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD)));
    //        cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //        cell.Leading = 30;
    //        cell.Colspan = 5;
    //        cell.Border = Rectangle.NO_BORDER;
    //        cell.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.Gray);
    //        datatable.AddCell(cell);


    //        int parentGridCount = 0;
    //        parentGridCount = gvAgent.Rows.Count;


    //        //int rowCount = gvFoodTransactionItemRelation.Rows.Count;

    //        for (int i = 0; i < parentGridCount; i++)
    //        {

    //            Label lblLocationName = (Label)gvAgent.Rows[i].FindControl("lblLocationName");

    //            Cell cell1 = new Cell(new Phrase("Agent Name : " + lblLocationName.Text, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));
    //            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
    //            cell1.Leading = 30;
    //            cell1.Colspan = 5;
    //            cell1.Border = Rectangle.NO_BORDER;
    //            cell1.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.WhiteSmoke);
    //            datatable.AddCell(cell1);

    //            datatable.DefaultCellBorderWidth = 1;
    //            datatable.DefaultHorizontalAlignment = 1;
    //            datatable.DefaultRowspan = 2;
    //            datatable.AddCell("Location");
    //            datatable.AddCell("Trans Count");
    //            datatable.AddCell("Rate");
    //            datatable.AddCell("Fees");

    //            datatable.AddCell("Agent Commision");



    //            GridView gvTRANS = (GridView)gvAgent.Rows[i].FindControl("gvPayment");



    //            for (int j = 0; j < gvTRANS.Rows.Count; j++)
    //            {
    //                datatable.DefaultHorizontalAlignment = Element.ALIGN_LEFT;



    //                Label lbllocationName = (Label)gvTRANS.Rows[j].FindControl("lbllocationName");
    //                Label lblTransCount = (Label)gvTRANS.Rows[j].FindControl("lblTransCount");
    //                Label lblRate = (Label)gvTRANS.Rows[j].FindControl("lblRate");
    //                Label lblFees = (Label)gvTRANS.Rows[j].FindControl("lblFees");
                    
    //                Label lblAgentCommision = (Label)gvTRANS.Rows[j].FindControl("lblAgentCommision");

    //                datatable.Alignment = Element.ALIGN_CENTER;
    //                datatable.AddCell(lbllocationName.Text);
    //                datatable.AddCell(lblTransCount.Text);
    //                datatable.AddCell(lblRate.Text);
    //                datatable.AddCell(lblFees.Text);

    //                datatable.AddCell(lblAgentCommision.Text);


    //                //Label lblTotalAgentCommission = (Label)gvTRANS.Rows[0].FindControl("lblTotalAgentCommission");



    //                Cell cell2 = new Cell(new Phrase("Sub Total : $999999 ", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD)));
    //                cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
    //                cell2.Leading = 30;
    //                cell2.Colspan = 6;
    //                cell2.Border = Rectangle.NO_BORDER;
    //                cell2.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.White);
    //                datatable.AddCell(cell2);


    //            }


    //            //Label lblSubTotalTotalAmount = (Label)gvAgent.Rows[i].FindControl("lblSubTotalTotalAmount");



               

    //        }

    //        document.Add(datatable);
    //    }
    //    catch (Exception e)
    //    {
    //        Console.Error.WriteLine(e.Message);
    //    }

    //    // we close the document 
    //    document.Close();

    //    Response.Clear();
    //    Response.AddHeader("content-disposition", "attachment;filename=AgentWiseCommissionReport.pdf");
    //    Response.ContentType = "application/pdf";
    //    Response.BinaryWrite(msReport.ToArray());
    //    Response.End();
    //}


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

            iTextSharp.text.Table datatable = new iTextSharp.text.Table(5);

            datatable.Padding = 2;
            datatable.Spacing = 0;

            float[] headerwidths = { 30, 15, 15, 15, 25 };
            datatable.Widths = headerwidths;

            // the first cell spans 7 columns
            Cell cell = new Cell(new Phrase("Agent Wise Commission Report", FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Leading = 30;
            cell.Colspan = 5;
            cell.Border = Rectangle.NO_BORDER;
            cell.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.Gray);
            datatable.AddCell(cell);


            int parentGridCount = 0;
            parentGridCount = gvAgent.Rows.Count;


            //int rowCount = gvFoodTransactionItemRelation.Rows.Count;

            for (int i = 0; i < parentGridCount; i++)
            {

                Label lblLocationName = (Label)gvAgent.Rows[i].FindControl("lblLocationName");

                Cell cell1 = new Cell(new Phrase("Agent Name : " + lblLocationName.Text, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD)));
                cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                cell1.Leading = 30;
                cell1.Colspan = 5;
                cell1.Border = Rectangle.NO_BORDER;
                cell1.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.WhiteSmoke);
                datatable.AddCell(cell1);

                datatable.DefaultCellBorderWidth = 1;
                datatable.DefaultHorizontalAlignment = 1;
                datatable.DefaultRowspan = 2;
                datatable.AddCell("Location");
                datatable.AddCell("Trans Count");
                datatable.AddCell("Rate");
                datatable.AddCell("Fees");
                datatable.AddCell("Agent Commision");



                GridView gvPayment = (GridView)gvAgent.Rows[i].FindControl("gvPayment");



                for (int j = 0; j < gvPayment.Rows.Count; j++)
                {
                    datatable.DefaultHorizontalAlignment = Element.ALIGN_LEFT;



                    Label lbllocationName = (Label)gvPayment.Rows[j].FindControl("lbllocationName");
                    Label lblTransCount = (Label)gvPayment.Rows[j].FindControl("lblTransCount");
                    Label lblRate = (Label)gvPayment.Rows[j].FindControl("lblRate");
                    Label lblFees = (Label)gvPayment.Rows[j].FindControl("lblFees");
                    Label lblAgentCommision = (Label)gvPayment.Rows[j].FindControl("lblAgentCommision");

                    datatable.Alignment = Element.ALIGN_CENTER;
                    datatable.AddCell(lbllocationName.Text);
                    datatable.AddCell(lblTransCount.Text);
                    datatable.AddCell(lblRate.Text);
                    datatable.AddCell(lblFees.Text);
                    datatable.AddCell(lblAgentCommision.Text);





                }

                //gvPayment.FooterRow.FindControl
                Label lblTotalAgentCommission = (Label)gvPayment.FooterRow.FindControl("lblTotalAgentCommission");


                Cell cell2 = new Cell(new Phrase("Sub Total : " + lblTotalAgentCommission.Text, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD)));
                cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell2.Leading = 30;
                cell2.Colspan = 5;
                cell2.Border = Rectangle.NO_BORDER;
                cell2.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                datatable.AddCell(cell2);




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
        Response.AddHeader("content-disposition", "attachment;filename=AgentWiseCommissionReport.pdf");
        Response.ContentType = "application/pdf";
        Response.BinaryWrite(msReport.ToArray());
        Response.End();
    }
}