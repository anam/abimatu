using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class LocationWiseReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadReport();
        }
    }

    private void loadReport()
    {
        string html = "";
        DataSet session = MSSQL.SQLExec(@"Select [SessionName]
      ,[SessionValue]
  FROM [AbiMatuEnterpriseDB].[dbo].[SessionTable]");


        string sql = @"
SELECT     TRANS.LOCATIONID, TRANS.CUSTID, TRANS.RECEIVERID, TRANS.TRANSID, 
TRANS.TRANSAMOUNT, TRANS.TRANSFEES, 
	TRANS.TRANSTOTALAMOUNT, TRANS.REFCODE, TRANS.CREATEDON, 
CUSTOMER.CUSTFNAME+' '+CUSTOMER.CUSTMNAME+' '+CUSTOMER.CUSTLNAME as CUSTDETAIL,
RECEIVER.RECEIVERFNAME+' '+RECEIVER.RECEIVERMNAME+' '+RECEIVER.RECEIVERLNAME as RECEIVERDETAIL,
LOCATION.COUNTRY, LOCATION.CITY, LOCATION.BRANCH,TRANS.[TRANSSTATUS]
FROM         TRANS INNER JOIN
	LOCATION ON TRANS.LOCATIONID = LOCATION.LOCATIONID INNER JOIN
	CUSTOMER ON TRANS.CUSTID = CUSTOMER.CUSTOMERID INNER JOIN
	RECEIVER ON TRANS.RECEIVERID = RECEIVER.RECEIVERID
where 1=1 


";
        foreach (DataRow dr in session.Tables[0].Rows)
        {
            if (dr["SessionName"].ToString() == "LocationIDs")
            {
                sql += @"
               and TRANS.LOCATIONID in (" + dr["SessionValue"].ToString() + @")
                ";
            }
            else
                if (dr["SessionName"].ToString() == "Status")
                {
                    sql += @"
               and TRANS.[TRANSSTATUS] in (" + dr["SessionValue"].ToString() + @")
                ";
                }
        }

        if (Request.QueryString["fromDate"] != null)
        {
            sql += @"
               and TRANS.CREATEDON between '" + DateTime.Parse(Request.QueryString["fromDate"]).ToString("yyyy-MM-dd") + @" 00:00:00 AM' and '" + DateTime.Parse(Request.QueryString["toDate"]).ToString("yyyy-MM-dd") + @" 11:59:59 PM'
                ";
        }
        
        if (Request.QueryString["Code"] != null)
        {
            sql += @"
               and REFCODE ='" + Request.QueryString["Code"] + @"'
                ";
        }
        sql += @"
order by
LOCATION.COUNTRY,LOCATION.CITY,LOCATION.BRANCH, TRANS.REFCODE, TRANS.CREATEDON  desc


";
        /*
         " + (Session["LocationID"].ToString() == "0" ? "" : (" and LOCATION.LOCATIONID in (" + Session["LocationID"].ToString() + ")")) + @"
        " + (Session["Status"].ToString() == "" ? "" : (" and TRANS.[TRANSSTATUS] in (" + Session["Status"].ToString() + ")")) + @"

         */
        DataSet ds = MSSQL.SQLExec(sql);
        gvTRANS.DataSource = ds.Tables[0];
        gvTRANS.DataBind();
    }
    protected void btnPaid_Click(object sender, EventArgs e)
    {
        string ids = "";
        foreach (GridViewRow gvr in gvTRANS.Rows)
        {
            CheckBox chkSelect = (CheckBox)gvr.FindControl("chkSelect");
            if (chkSelect.Checked)
            {
                ids += (ids == "" ? "" : ",") + chkSelect.ToolTip;
            }
        }

        MSSQL.SQLExec("Update TRANS set TRANSSTATUS ='PAID' where TRANSID in ("+ids+")");
        loadReport();
    }
}