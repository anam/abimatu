using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.Data;

public partial class ReportSARPage : System.Web.UI.Page
{
    DataTable dt = new DataTable();
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

            BindReport();
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
    public void BindReport()
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "dsSAR_dtSAR";
        rds.Value = FetchCustomer();



        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/rptSAR.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);

        //ReportViewer1.LocalReport.EnableExternalImages = true;

        //ReportParameter rptParam1 = new ReportParameter("ReportTitle", "Asp.Net Local Report Demo");
        //ReportParameter rptParam2 = new ReportParameter("ReportLogo",
        //      "http://" + Request.Url.Host + "/" + ResolveUrl("aspdotnetcodes.gif"));
        //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptParam1, rptParam2 });

        //ReportViewer1.LocalReport.Refresh();
    }

    public DataTable FetchCustomer()
    {

        dt = new DataTable();

        dt.Columns.Add(new DataColumn("Test", typeof(String)));

        DataRow dr = dt.NewRow();

        for (int i = 0; i <= 5; i++)
        {
            dr = dt.NewRow();
            dr[0] = "Name_" + i.ToString();

            dt.Rows.Add(dr);
            dr = dt.NewRow();
        }


        return dt;




        //dt = new DataTable();
        //DataRow dr = dt.NewRow();
        ////dt = postalCodeManager.GetAllDistinctState();
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    dr = dt.NewRow();
        //    dr[0] = dt.Rows[i]["ProvinceName"].ToString();
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();

        //}
        //return dt;
    }
}