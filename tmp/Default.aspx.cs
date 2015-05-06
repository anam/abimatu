using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class tmp_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sql = @"
SELECT     TOP (1000) TRANSID, TRANSDT, CREATEDON, UPDATEDON, REFCODE
FROM         TRANS
WHERE     (TRANSID <= 108635) AND (TRANSID >= 108605)
ORDER BY TRANSID DESC
";

            DataSet ds = MSSQL.SQLExec(sql);
            sql = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string correctDate = DateTime.Parse(dr["TRANSDT"].ToString()).AddHours(-11).ToString("yyyy-MM-dd hh:mm:ss tt");
                sql += @"
                    update TRANS set TRANSDT='" + correctDate + "', CREATEDON='" + correctDate + "', UPDATEDON='" + correctDate + "' where TRANSID=" + dr["TRANSID"].ToString()+";";
            }

            ds = MSSQL.SQLExec(sql + ";select 1");
        }
    }
}