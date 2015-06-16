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
	TRANS.TRANSTOTALAMOUNT, TRANS.REFCODE, TRANS.CREATEDON as TRANSDT, 
CUSTOMER.CUSTFNAME+' '+CUSTOMER.CUSTMNAME+' '+CUSTOMER.CUSTLNAME as SenderName,
CUSTOMER.CUSTADDRESS1 +', '+CUSTOMER.CUSTCITY+', '+CUSTOMER.CUSTSTATE+', '+CUSTOMER.CUSTZIP as Address,
CUSTOMER.CUSTSSN +' / '+CUSTOMER.CUSTIDNUMBER as SSN
RECEIVER.RECEIVERFNAME+' '+RECEIVER.RECEIVERMNAME+' '+RECEIVER.RECEIVERLNAME as ReceiverName,
LOCATION.COUNTRY, LOCATION.CITY, LOCATION.BRANCH,TRANS.[TRANSSTATUS]
FROM         TRANS INNER JOIN
	LOCATION ON TRANS.LOCATIONID = LOCATION.LOCATIONID INNER JOIN
	CUSTOMER ON TRANS.CUSTID = CUSTOMER.CUSTOMERID INNER JOIN
	RECEIVER ON TRANS.RECEIVERID = RECEIVER.RECEIVERID
where 1=1 
and TRANS.TRANSTOTALAMOUNT >=" + Request.QueryString["MinMax"].Split('-')[0].Trim() + @" 
and TRANS.TRANSTOTALAMOUNT <=" + Request.QueryString["MinMax"].Split('-')[1].Trim() + @" 

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
        html = @"<table border='1' cellspacing='0' cellpadding='5'>
<tr><td colspan='11' align='center'>
<center>";
        if (Request.QueryString["fromDate"] != null)
        {
            html += DateTime.Parse(Request.QueryString["fromDate"]).ToString("dd MMM yyyy") + " to " + DateTime.Parse(Request.QueryString["toDate"]).ToString("dd MMM yyyy");
           
        }

        if (Request.QueryString["Code"] != null)
        {
            html += Request.QueryString["Code"]; 

        }
        string header = @"<tr class='colorbackground' >
                <td>SI.
                    </td>
                <td>Date
                    </td>
                <td>Code
                    </td>
                <td>Sender
                    </td>
<td>Address
                    </td>
<td>SSN/ID
                    </td>
                <td>Receiver
                    </td>
                <td style='display:none;'>Location
                    </td>
                <td>Amount
                    </td>
                <td>Fees
                    </td>
                <td>Total
                    </td>
                <td>Edit
                    </td>
            </tr>";
html += @"</center> 
</td></tr>
";

        decimal transferAmountSubtotal = 0;
        decimal transferAmountTotal = 0;

        decimal feesSubtotal = 0;
        decimal feesTotal = 0;

        decimal payableSubtotal = 0;
        decimal payableTotal = 0;


        string lastLocationID = "";
        int SI = 1;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            
            if (lastLocationID != dr["LOCATIONID"].ToString())
            {

                if (lastLocationID != "")
                {
                    //subtotal
                    html += @"
            <tr>
                <td>
                    </td>
                <td>
                    </td>
                <td>
                    </td>
                <td>
                    </td>
                <td>
<td>
                    </td>
                <td>
                    </td>
                <td>
                    </td>
                <td style='display:none;'>
                    </td>
                <td class='ar'>$" + transferAmountSubtotal.ToString("0,0.00") + @"
                    </td>
                <td class='ar'>$" + feesSubtotal.ToString("0,0.00") + @"
                    </td>
                <td class='ar'>$" + payableSubtotal.ToString("0,0.00") + @"
                    </td>
                <td>
                    </td>
            </tr>
";
                    transferAmountSubtotal = 0;
                    feesSubtotal = 0;
                    payableSubtotal = 0;
                }
                //else
                //{
                //    html += header;
                //}

                html += "<tr   class='colorbackground'><td colspan='9'>" + dr["COUNTRY"].ToString() + " - " + dr["CITY"].ToString() + " - " + dr["BRANCH"].ToString() + @"</td></tr>
<tr class='colorbackground'  >
                <td>SI.
                    </td>
                <td>Date
                    </td>
                <td>Code
                    </td>
                <td>Sender
                    </td>
<td>Address
                    </td>
                <td>SSN/ID
                    </td>
                <td>
                <td>Receiver
                    </td>
                <td style='display:none;'>Location
                    </td>
                <td>Amount
                    </td>
                <td>Fees
                    </td>
                <td>Total
                    </td>
                <td>Edit
                    </td>
            </tr>
";
                lastLocationID = dr["LOCATIONID"].ToString();
            }
            

            html += @"
            <tr>
                <td>"+(SI++)+@"
                    </td>
                <td>"+DateTime.Parse(dr["TRANSDT"].ToString()).ToString("MM/dd/yyyy")+@"
                    </td>
                <td>"+dr["REFCODE"].ToString()+@"
                    </td>
                <td>" + dr["SenderName"].ToString() + @"
                    </td>
<td>" + dr["Address"].ToString() + @"
                    </td>
<td>" + dr["SSN"].ToString() + @"
                    </td>
                <td>" + dr["ReceiverName"].ToString() + @"
                    </td>
                <td style='display:none;'>" + dr["BRANCH"].ToString() + @"
                    </td>
                <td class='ar'>$" + decimal.Parse(dr["TRANSAMOUNT"].ToString()).ToString("0,0.00") + @"
                    </td>
                <td class='ar'>$" + decimal.Parse(dr["TRANSFEES"].ToString()).ToString("0,0.00") + @"
                    </td>
                <td class='ar'>$" + decimal.Parse(dr["TRANSTOTALAMOUNT"].ToString()).ToString("0,0.00") + @"
                    </td>
                <td><a href='EditPayment.aspx?TRANSID=" + dr["TRANSID"].ToString() + @"' target='_blank'>Edit</a>
                    </td>
            </tr>
";
            transferAmountSubtotal += decimal.Parse(dr["TRANSAMOUNT"].ToString());
            feesSubtotal += decimal.Parse(dr["TRANSFEES"].ToString()); 
            payableSubtotal += decimal.Parse(dr["TRANSTOTALAMOUNT"].ToString()); 

            transferAmountTotal += decimal.Parse(dr["TRANSAMOUNT"].ToString()); 
            feesTotal += decimal.Parse(dr["TRANSFEES"].ToString()); 
            payableTotal += decimal.Parse(dr["TRANSTOTALAMOUNT"].ToString()); 
       
        }

        html += @"
            <tr>
                <td>
                    </td>
                <td>
                    </td>
                <td>
                    </td>
                <td>
                    </td>
<td>
                    </td>
                <td>
                    </td>
                <td>
                    </td>
                <td style='display:none;'>
                    </td>
                <td class='ar'>$" + transferAmountSubtotal.ToString("0,0.00") + @"
                    </td>
                <td class='ar'>$" + feesSubtotal.ToString("0,0.00") + @"
                    </td>
                <td class='ar'>$" + payableSubtotal.ToString("0,0.00") + @"
                    </td>
                <td>
                    </td>
            </tr>
";

        html += @"
            <tr>
                <td>
                    </td>
                <td>
                    </td>
                <td>
                    </td>
                <td>
                    </td>
<td>
                    </td>
                <td>
                    </td>
                <td>
                    </td>
                <td style='display:none;'>
                    </td>
                <td class='ar'>$" + transferAmountTotal.ToString("0,0.00") + @"
                    </td>
                <td class='ar'>$" + feesTotal.ToString("0,0.00") + @"
                    </td>
                <td class='ar'>$" + payableTotal.ToString("0,0.00") + @"
                    </td>
                <td>
                    </td>
            </tr>
";
        /*<img src='App_Themes/Default/images/interface/bg_logo.png' />*/
        lblPrint.Text =  html + "</table>";
    }
}