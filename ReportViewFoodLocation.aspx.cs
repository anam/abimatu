using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;

public partial class ReportViewFoodLocation : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    SqlFOODITEM_TRANSMASTERProvider sqlFOODITEM_TRANSMASTERProvider = new SqlFOODITEM_TRANSMASTERProvider();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        {
            if (Request.QueryString["status"] != null && Request.QueryString["locationID"] != null && Request.QueryString["fromDate"] != null && Request.QueryString["toDate"] != null && Request.QueryString["amount"] != null && Request.QueryString["agentID"] != null)
            {
                lblStatus.Text = Request.QueryString["status"].ToString();
                lblLocation.Text = Request.QueryString["locationID"].ToString();
                lblFromDate.Text = Request.QueryString["fromDate"].ToString();
                lblToDate.Text = Request.QueryString["toDate"].ToString();
                lblAmount.Text = Request.QueryString["amount"].ToString();
                lblagentID.Text = Request.QueryString["agentID"].ToString();

                //lblStatus.Text = Session["status"].ToString();
                //lblLocation.Text = Session["locationID"].ToString();
                //lblFromDate.Text = Session["fromDate"].ToString();
                //lblToDate.Text = Session["toDate"].ToString();
                //lblAmount.Text = Session["amount"].ToString();
                //lblagentID.Text = Session["agentID"].ToString();

                ReportDocument rptDoc = new ReportDocument();
                dt = new DataTable();
                dt.TableName = "Crystal Report";
                dt = getReport();
                rptDoc.Load(Server.MapPath("Reports/rptLocationWiseFoodTrans.rpt"));
                rptDoc.SetDataSource(dt);
                CrystalReportViewer1.ReportSource = rptDoc;


            }

        }
    }
    //protected void OnPreRender(object sender, EventArgs e)
    //{
    //    lblStatus.Text = Session["status"].ToString();
    //    lblLocation.Text = Session["locationID"].ToString();
    //    lblFromDate.Text = Session["fromDate"].ToString();
    //    lblToDate.Text = Session["toDate"].ToString();
    //    lblAmount.Text = Session["amount"].ToString();
    //    lblagentID.Text = Session["agentID"].ToString();

    //    ReportDocument rptDoc = new ReportDocument();
    //    dt = new DataTable();
    //    dt.TableName = "Crystal Report";
    //    dt = getReport();
    //    rptDoc.Load(Server.MapPath("~/Reports/rptLocationWiseFoodTrans.rpt"));
    //    rptDoc.SetDataSource(dt);
    //    CrystalReportViewer1.ReportSource = rptDoc;
    //}
    public DataTable getReport()
    {
        dt = new DataTable();
        dt = sqlFOODITEM_TRANSMASTERProvider.GetAllFoodTransForLocationWiseForReport(lblStatus.Text, lblLocation.Text, int.Parse(lblagentID.Text), lblFromDate.Text, lblToDate.Text, int.Parse(lblAmount.Text));

        return dt;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        //lblStatus.Text = Session["status"].ToString();
        //lblLocation.Text = Session["locationID"].ToString();
        //lblFromDate.Text = Session["fromDate"].ToString();
        //lblToDate.Text = Session["toDate"].ToString();
        //lblAmount.Text = Session["amount"].ToString();
        //lblagentID.Text = Session["agentID"].ToString();

        //ReportDocument rptDoc = new ReportDocument();
        //dt = new DataTable();
        //dt.TableName = "Crystal Report";
        //dt = getReport();
        //rptDoc.Load(Server.MapPath("~/Reports/rptLocationWiseFoodTrans.rpt"));
        //rptDoc.SetDataSource(dt);
        //CrystalReportViewer1.ReportSource = rptDoc;

        Response.Redirect("ReportFoodLocationWise.aspx");
    }
}