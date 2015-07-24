using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CustomerSign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();

        }
    }

    private void loadData()
    {
        string sql = @"SELECT  [REFCODE],C.CUSTFNAME,C.CUSTMNAME,C.CUSTLNAME,C.CUSTSSN,C.CUSTIDNUMBER
,C.CUSTDOB,C.CUSTEXPIREDATE,C.CUSTADDRESS1,C.CUSTCITY,C.CUSTSTATE,C.CUSTZIP
,C.CUSTHPHONE,C.CUSTWPHONE,C.CUSTCPHONE
,R.RECEIVERFNAME,R.RECEIVERMNAME,R.RECEIVERLNAME,L.COUNTRY
,T.TRANSAMOUNT,T.TRANSFEES
  FROM [TRANS] as T
  inner join CUSTOMER as C on C.CUSTOMERID =T.CUSTID
  inner join RECEIVER as R on R.RECEIVERID =T.RECEIVERID
  inner join LOCATION as L on L.LOCATIONID =T.LOCATIONID
  where T.TRANSSTATUS in ('PENDING','PAID') and  T.CREATEDON =(select CREATEDON from TRANS where [REFCODE]='" + Request.QueryString["REFCODE"] + @"') and T.CUSTID=(select top 1 CUSTID from TRANS where  [REFCODE]='" + Request.QueryString["REFCODE"] + @"' order by CREATEDON desc)
  order by T.CreateDON desc";

        DataSet ds = MSSQL.SQLExec(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];

            lblCellPhone.Text = dr["CUSTCPHONE"].ToString();
            lblCity.Text = dr["CUSTCITY"].ToString();
            lblDOB.Text = DateTime.Parse(dr["CUSTDOB"].ToString()).ToString("dd MMM yyyy");
            lblExpireDate.Text = DateTime.Parse(dr["CUSTEXPIREDATE"].ToString()).ToString("dd MMM yyyy");
            lblFName.Text = dr["CUSTFNAME"].ToString();
            lblHomePhone.Text = dr["CUSTHPHONE"].ToString();
            lblIDNo.Text = dr["CUSTIDNUMBER"].ToString();
            lblLName.Text = dr["CUSTLNAME"].ToString();
            lblMName.Text = dr["CUSTMNAME"].ToString();
            //lblPlaceOfBirth.Text = dr["CUSTMNAME"].ToString();
            lblSSN.Text = dr["CUSTSSN"].ToString();
            lblStateAddress.Text = dr["CUSTSTATE"].ToString();
            //lblStateID.Text = dr["CUSTSTATE"].ToString();
            lblStreetAddress.Text = dr["CUSTADDRESS1"].ToString();
            lblWorkPhone.Text = dr["CUSTWPHONE"].ToString();
            lblZip.Text = dr["CUSTZIP"].ToString();

        }
        string html = "";
        int i=1;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            html += (html == "" ? "" : "</hr>");
            html += @"
<table cellspacing='5' cellpadding='2' width='100%' style='text-align:left;'>
<tr>
    <td><b>(" + (i++) + @") Full Name</b></td>
    <td colspan='5' class='underlineBorder'>" + dr["RECEIVERFNAME"].ToString() + " " + dr["RECEIVERMNAME"].ToString() + " " + dr["RECEIVERLNAME"].ToString()+ @"</td>
</tr>
<tr>
    <td>Transaction Amount:</td>
    <td class='underlineBorder'>$" + decimal.Parse(dr["TRANSAMOUNT"].ToString()).ToString("0,0.00") + @"</td>
    <td>Transaction Fee</td>
    <td class='underlineBorder'>$" + decimal.Parse(dr["TRANSFEES"].ToString()).ToString("0,0.00") + @"</td>
    <td>Destination Counry</td>
    <td class='underlineBorder'>" + dr["COUNTRY"].ToString() + @"</td>
</tr>
<tr>
    <td>Purpose of money trasfer</td>
    <td colspan='5' class='underlineBorder'>
    <input type='text' style='width:550px' name='firstname'>
</td>
</tr>
</table>
";

        }
        lblReceiver.Text = html;
    }
}