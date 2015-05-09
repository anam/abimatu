using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class tmp_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sql = @"SELECT distinct O.noInbangla
      ,T.NoInEnglish
  FROM [TaqiUsmaniTafsir].[dbo].[Table_1] as O
  inner join [TaqiUsmaniTafsir].[dbo].Table_3 as T on T.NoInBangla=O.[noInbangla]";

            DataSet ds = MSSQL.SQLExec(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                try
                {
                    MSSQL.SQLExec("update [TaqiUsmaniTafsir].[dbo].[Table_1]  set NoInEnglish=" + dr["NoInEnglish"].ToString() + " where noInbangla=N'" + dr["noInbangla"].ToString() + "'");     
                }
                catch (Exception ex)
                {
                   
                }
                  
            }
        }
    }
}