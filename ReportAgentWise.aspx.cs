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
public partial class AgentWiseReport : System.Web.UI.Page
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

            AGENT aGENT = (AGENT)Session["aGENT"];
            hfAgentID.Value = aGENT.AGENTID.ToString();

            if (Request.QueryString["Daily"] != null)
            {
                trFromDate.Visible = false;
                trToDate.Visible = false;
            }

            txtFromDate.Text = DateTime.Today.ToShortDateString();
            txtToDate.Text = DateTime.Today.ToShortDateString();
            tblTotal.Visible = false;
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
        if (hfAgentID.Value == "4")//main office will c all the report
        {
            locations = LOCATIONManager.GetAllLOCATIONs();
        }
        else
        {
            locations = LOCATIONManager.GetAllLOCATIONsByAgentID(int.Parse(hfAgentID.Value));
        }
        
        dlLocation.DataSource = locations;
        dlLocation.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblSubTotalSendingAmountTotal.Text = "0";
        lblSubTotalFeesTotal.Text = "0";
        lblSubTotalDiscountTotal.Text = "0";
        lblSubTotalTotalAmountTotal.Text = "0";

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
                else locationIDs +=","+ hfLocationID.Value;
            }
        }
        return locationIDs;
    }

    private void loadReport()
    {
        List<AGENT> aGENTs = new List<AGENT>();
        List<AGENT> aGENTstmp = new List<AGENT>();
        aGENTstmp = AGENTManager.GetAllAGENTsForReportByDatenAmountnLocations(getLocationIDs(), txtFromDate.Text, txtToDate.Text, int.Parse(txtMoney.Text == "" ? "0" : txtMoney.Text));

        if (((AGENT)Session["aGENT"]).AGENTID != 4)//if not the admin
        {
            foreach (AGENT aGENT in aGENTstmp)
            {
                if (aGENT.AGENTID == ((AGENT)Session["aGENT"]).AGENTID)
                {
                    aGENTs.Add(aGENT);
                    break;
                }
            }
        }
        else
        {
            aGENTs = aGENTstmp;
        }        

        gvAgent.DataSource = aGENTs;
        gvAgent.DataBind();

        lblSubTotalSendingAmountTotal.Text = string.Format("{0:C}", double.Parse(lblSubTotalSendingAmountTotal.Text));
        lblSubTotalFeesTotal.Text = string.Format("{0:C}", double.Parse(lblSubTotalFeesTotal.Text) );
        lblSubTotalDiscountTotal.Text = string.Format("{0:C}", double.Parse(lblSubTotalDiscountTotal.Text) );
        lblSubTotalTotalAmountTotal.Text = string.Format("{0:C}", double.Parse(lblSubTotalTotalAmountTotal.Text));
    }
    protected void gvLocation_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hfAgnetID = (HiddenField)e.Row.FindControl("hfAgnetID");
            
            GridView gvTRANS = (GridView)e.Row.FindControl("gvTRANS");

            List<TRANS> tRANSs = new List<TRANS>();
            tRANSs = TRANSManager.GetTRANSByAgnetIDnLocationIDsByDateNAmount(getLocationIDs(),int.Parse(hfAgnetID.Value), txtFromDate.Text, txtToDate.Text, int.Parse(txtMoney.Text == "" ? "0" : txtMoney.Text));



            decimal sendingAmount = 0;
            decimal fees = 0;
            decimal discount = 0;
            decimal Total = 0;

            foreach (TRANS tRANS in tRANSs)
            {
                sendingAmount += tRANS.TRANSAMOUNT;
               
                fees += tRANS.TRANSFEES;//+ tRANS.TRANSOTHERFEES; because in the sp we have added already
                discount += tRANS.TRANSPROMO;
                Total += tRANS.TRANSTOTALAMOUNT;

                //if (Session["userType"].ToString() != "Location")
                //{
                //    if (((AGENT)Session["aGENT"]).AGENTID == 4)//if the admin
                //    {
                //        tRANS.IsEdit = true;                        
                //    }
                //    else
                //    {
                //        tRANS.IsEdit = false;
                //    }
                //}
            }

            gvTRANS.DataSource = tRANSs;
            gvTRANS.DataBind();

            Label lblSubTotalSendingAmount = (Label)e.Row.FindControl("lblSubTotalSendingAmount");
            Label lblSubTotalFees = (Label)e.Row.FindControl("lblSubTotalFees");
            Label lblSubTotalDiscount = (Label)e.Row.FindControl("lblSubTotalDiscount");
            Label lblSubTotalTotalAmount = (Label)e.Row.FindControl("lblSubTotalTotalAmount");

            lblSubTotalSendingAmount.Text = string.Format("{0:C}", double.Parse(sendingAmount.ToString()));
            lblSubTotalFees.Text = string.Format("{0:C}",  double.Parse(fees.ToString()));
            lblSubTotalDiscount.Text = string.Format("{0:C}",  double.Parse(discount.ToString()));
            lblSubTotalTotalAmount.Text = string.Format("{0:C}", double.Parse(Total.ToString()));

            lblSubTotalSendingAmountTotal.Text = string.Format("{0}", double.Parse(lblSubTotalSendingAmountTotal.Text) + double.Parse(sendingAmount.ToString()));
            lblSubTotalFeesTotal.Text = string.Format("{0}", double.Parse(lblSubTotalFeesTotal.Text) + double.Parse(fees.ToString()));
            lblSubTotalDiscountTotal.Text = string.Format("{0}", double.Parse(lblSubTotalDiscountTotal.Text) + double.Parse(discount.ToString()));
            lblSubTotalTotalAmountTotal.Text = string.Format("{0}", double.Parse(lblSubTotalTotalAmountTotal.Text) + double.Parse(Total.ToString()));

            if (Total > 0) tblTotal.Visible = true;
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

            iTextSharp.text.Table datatable = new iTextSharp.text.Table(6);

            datatable.Padding = 2;
            datatable.Spacing = 0;

            float[] headerwidths = { 15, 15, 15, 15, 15, 25 };
            datatable.Widths = headerwidths;

            // the first cell spans 7 columns
            Cell cell = new Cell(new Phrase("Agent Wise Report", FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Leading = 30;
            cell.Colspan = 6;
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
                cell1.Colspan = 6;
                cell1.Border = Rectangle.NO_BORDER;
                cell1.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.WhiteSmoke);
                datatable.AddCell(cell1);

                datatable.DefaultCellBorderWidth = 1;
                datatable.DefaultHorizontalAlignment = 1;
                datatable.DefaultRowspan = 2;
                datatable.AddCell("Date");
                datatable.AddCell("Ref Code");
                datatable.AddCell("Amount");
                datatable.AddCell("Fees");
                datatable.AddCell("Discount");
                datatable.AddCell("Total Amount");



                GridView gvTRANS = (GridView)gvAgent.Rows[i].FindControl("gvTRANS");



                for (int j = 0; j < gvTRANS.Rows.Count; j++)
                {
                    datatable.DefaultHorizontalAlignment = Element.ALIGN_LEFT;



                    Label lblTransactionDate = (Label)gvTRANS.Rows[j].FindControl("lblTransactionDate");
                    Label lblReferenceCode = (Label)gvTRANS.Rows[j].FindControl("lblReferenceCode");
                    Label lblSendingAmount = (Label)gvTRANS.Rows[j].FindControl("lblSendingAmount");
                    Label lblServiceCharge = (Label)gvTRANS.Rows[j].FindControl("lblServiceCharge");
                    Label lblDiscount = (Label)gvTRANS.Rows[j].FindControl("lblDiscount");
                    Label lblTotalCharge = (Label)gvTRANS.Rows[j].FindControl("lblTotalCharge");

                    datatable.Alignment = Element.ALIGN_CENTER;
                    datatable.AddCell(lblTransactionDate.Text);
                    datatable.AddCell(lblReferenceCode.Text);
                    datatable.AddCell(lblSendingAmount.Text);
                    datatable.AddCell(lblServiceCharge.Text);
                    datatable.AddCell(lblDiscount.Text);
                    datatable.AddCell(lblTotalCharge.Text);
                }





                Label lblSubTotalTotalAmount = (Label)gvAgent.Rows[i].FindControl("lblSubTotalTotalAmount");


                Cell cell2 = new Cell(new Phrase("Sub Total : " + lblSubTotalTotalAmount.Text, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD)));
                cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell2.Leading = 30;
                cell2.Colspan = 6;
                cell2.Border = Rectangle.NO_BORDER;
                cell2.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                datatable.AddCell(cell2);

            }



            Cell cell3 = new Cell(new Phrase("Total : " + lblSubTotalTotalAmountTotal.Text, FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.BOLD)));
            cell3.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell3.Leading = 30;
            cell3.Colspan = 6;
            cell3.Border = Rectangle.NO_BORDER;
            cell3.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.Gray);
            datatable.AddCell(cell3);

            document.Add(datatable);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);
        }

        // we close the document 
        document.Close();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=AgentWiseReport.pdf");
        Response.ContentType = "application/pdf";
        Response.BinaryWrite(msReport.ToArray());
        Response.End();
    }
    
}