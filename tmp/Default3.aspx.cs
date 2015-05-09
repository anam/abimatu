using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class tmp_Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sql = @"SELECT T.SL,T.Sura,S.txt as suraname,T.Verse,A.txt as Arabic,T.txt as English,B.txt as Bangla
  FROM [TaqiUsmaniTafsir].[dbo].[zkr_TQ] as T
  inner join [TaqiUsmaniTafsir].[dbo].zkr_Arabic as A on A.SL=T.SL
  inner join [TaqiUsmaniTafsir].[dbo].zkr_Bangla as B on B.SL=T.SL
  inner join [TaqiUsmaniTafsir].[dbo].[TQ_Shahjalal_SuraName] as S on S.sura=T.sura
  order by t.SL";

            DataSet ds = MSSQL.SQLExec(sql);
            string html = @"<table border='1' cellpadding='5' cellspacing='0'>
            
            ";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                
                    html += @"<tr>
            <td>
                " + dr["SL"].ToString() + @"<hr/>(" + dr["sura"].ToString() + @")" + dr["suraname"].ToString() + @"<hr/>" + dr["verse"].ToString() + @"</td>
            <td>
                 <b style='font-size:30px;font-weight:bold;'>" + dr["Arabic"].ToString() + @"</b><hr/>" + dr["Bangla"].ToString() + @"<hr/>" + dr["English"].ToString() + @"</td>
        </tr>
    ";
            }
            Label1.Text = html + "</table>";
        }
    }
}