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
SELECT Distinct CUSTOMER.CUSTFNAME+' '+CUSTOMER.CUSTMNAME+' '+CUSTOMER.CUSTLNAME +'@'+
CUSTOMER.CUSTADDRESS1+'@'+CUSTOMER.CUSTCITY+'@'+CUSTOMER.CUSTSTATE+'@'+CUSTOMER.[CUSTZIP] as eachLine
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
        /*
        sql += @"
order by
LOCATION.COUNTRY,LOCATION.CITY,LOCATION.BRANCH, TRANS.REFCODE, TRANS.CREATEDON  desc

";
         */ 
        /*
         " + (Session["LocationID"].ToString() == "0" ? "" : (" and LOCATION.LOCATIONID in (" + Session["LocationID"].ToString() + ")")) + @"
        " + (Session["Status"].ToString() == "" ? "" : (" and TRANS.[TRANSSTATUS] in (" + Session["Status"].ToString() + ")")) + @"

         */
        DataSet ds = MSSQL.SQLExec(sql);
        string ofac_file = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            string tmp = dr["eachLine"].ToString().Trim().Replace("  ", " ");
            for (;true; )
            {
                tmp = tmp.Replace("  ", " ");
                if (!tmp.Contains("  ")) break;
            }
            ofac_file += (ofac_file == "" ? "" : "\n") + tmp;

        }


        System.IO.File.WriteAllText(@"C:\website\abimatu.info\v1\OFAC_File.txt", ofac_file);
        Response.Redirect("OFAC_File.txt");
    }
}