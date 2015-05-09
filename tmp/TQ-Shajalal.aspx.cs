using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class tmp_TQ_Shajalal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //procssing1();
            procssing2();
            //procesing3();
            //procesing4();
            //procesing5();
        }
    }

    private void procesing5()
    {
        string sql = @"SELECT  [SL]
      ,[txt]
  FROM [TaqiUsmaniTafsir].[dbo].[zkr_TQ]
  order by SL";

        DataSet ds = MSSQL.SQLExec(sql);
        int sura = 0;
        int verse = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (dr["txt"].ToString().Substring(0, 1) == " ")
            {
                verse++;
                MSSQL.SQLExec("update [TaqiUsmaniTafsir].[dbo].[zkr_TQ] set sura=" + sura + ",verse=" + verse + " where SL=" + dr["SL"].ToString());
            }
            else
            {
                sura++;
                verse = 1;
                MSSQL.SQLExec("update [TaqiUsmaniTafsir].[dbo].[zkr_TQ] set sura=" + sura + ",verse=" + verse + " where SL=" + dr["SL"].ToString());
            }
        }
    }

    private void procesing4()
    {
        string sql = @"select SL,txt1 FROM [TaqiUsmaniTafsir].[dbo].[Table_1] where txt1 is not NULL and SL>=9144";
        DataSet ds = MSSQL.SQLExec(sql);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            MSSQL.SQLExec("update [TaqiUsmaniTafsir].[dbo].[Table_1] set txt1=N'" + dr["txt1"].ToString().Trim() + "' where SL=" + dr["SL"].ToString());
        }
    }

    private void procesing3()
    {
        string sql = @"SELECT [NoInBangla]
  FROM [TaqiUsmaniTafsir].[dbo].[Table_3]";

        DataSet ds = MSSQL.SQLExec(sql);
        
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            Label1.Text += "," + dr["NoInBangla"].ToString();    
        }

    }
    private void procssing1()
    {
        string sql = @"
SELECT TOP 1000 [SL]
      ,[txt]
      ,[sura]
      ,[para]
      ,[no]
      ,[noInbangla]
      ,[NoInEnglish]
      ,[RowStatus]
      ,[txt1]
      ,[txt2]
  FROM [TaqiUsmaniTafsir].[dbo].[Table_1]
  where SL>=9144 and txt1 is null
  order by SL desc
/*
SELECT  [SL]
      ,[txt]
      ,[sura]
      ,[para]
      ,[no]
      ,[noInbangla]
      ,[NoInEnglish]
      ,[RowStatus]
  FROM [TaqiUsmaniTafsir].[dbo].[Table_1]
where SL not in (SELECT [SL]
  FROM [TaqiUsmaniTafsir].[dbo].[TQ_Shahjalal_SuraName])
and 
 SL not in (SELECT [SL]
  FROM [TaqiUsmaniTafsir].[dbo].[TQ_Shahjalal_Tika])
and
    RowStatus<>0 
*/
  --where Sura=2 order by SL";
        DataSet ds = MSSQL.SQLExec(sql);
        string html = @"<table border='1'>
            <tr>
                <td>
                    SL</td>
                <td>
                    Sura</td>
                <td>
                    part</td>
                <td>
                    txt</td>
            </tr>
            ";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            /*
            if (!dr["txt"].ToString().Contains("{") && !dr["txt"].ToString().Contains("*"))
            {
                html += @"<tr>
            <td>
                " + dr["SL"].ToString() + @"</td>
            <td>
                 " + dr["sura"].ToString() + @"</td>
            <td>
                 " + dr["para"].ToString() + @"</td>
            <td>
                 " + dr["txt"].ToString() + @"</td>
        </tr>
    ";
             * */
            /*
            if (!dr["txt"].ToString().Contains("{") && !dr["txt"].ToString().Contains("*")) //&& dr["txt"].ToString().Contains("সূরা") )
            {
                html += @"<tr>
            <td>
                " + dr["SL"].ToString() + @"</td>
            <td>
                 " + dr["sura"].ToString() + @"</td>
            <td>
                 " + dr["para"].ToString() + @"</td>
            <td>
                 " + dr["txt"].ToString() + @"</td>
        </tr>";
            }
            */
            //if (dr["txt"].ToString().Contains("*১*"))
            //{
            //    Label1.Text = dr["txt"].ToString().Split('*')[1];
            //    break;
            //}

            if (dr["txt"].ToString().Contains("{") || dr["txt"].ToString().Contains("*")) //&& dr["txt"].ToString().Contains("সূরা") )
            {
                if (dr["txt"].ToString().Contains("{"))
                {
                    try
                    {
                        string txt1 = dr["txt"].ToString().Replace("{" + dr["noInbangla"].ToString() + "}", "");
                        MSSQL.SQLExec("update [TaqiUsmaniTafsir].[dbo].[Table_1] set txt1=N'" + txt1 + "' where SL=" + dr["SL"].ToString());
                    }
                    catch (Exception ex)
                    { }

                }

                if (dr["txt"].ToString().Contains("*"))
                {
                    try
                    {
                        string txt1 = dr["txt"].ToString().Replace("*" + dr["noInbangla"].ToString() + "*", "");
                        MSSQL.SQLExec("update [TaqiUsmaniTafsir].[dbo].[Table_1] set txt1=N'" + txt1 + "' where SL=" + dr["SL"].ToString());
                    }
                    catch (Exception ex)
                    { }

                }
            }

        }
        //Label1.Text = html + "</table>";
    }
    private void procssing2()
    {
        string sql = @"SELECT  [SL]
      ,[txt1]
      ,[sura]
      ,[para]
      ,[no]
      ,[noInbangla]
      ,[NoInEnglish]
      ,[RowStatus]
  FROM [TaqiUsmaniTafsir].[dbo].[Table_1]
where SL not in (SELECT [SL]
  FROM [TaqiUsmaniTafsir].[dbo].[TQ_Shahjalal_SuraName])
and 
 SL not in (SELECT [SL]
  FROM [TaqiUsmaniTafsir].[dbo].[TQ_Shahjalal_Tika])
and
    RowStatus<>0 
and txt1 is not null and txt2 is null
and no=1
";
        DataSet ds = MSSQL.SQLExec(sql);
        
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (dr["txt1"].ToString().Contains("["))
            {
                try
                {
                    string nos = findCommentsNos(dr);
                    DataSet ds1 =new DataSet();
                    if (nos != "")
                    {
                        ds1 = MSSQL.SQLExec("select * from [TaqiUsmaniTafsir].[dbo].[Table_1] where sura=" + dr["sura"].ToString() + " and no=2 and NoInEnglish in (" + nos + ") order by NoInEnglish");
                    }

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        string txt2 = dr["txt1"].ToString() + " {";
                        foreach (DataRow dr1 in ds1.Tables[0].Rows)
                        {
                            txt2 += "[" + dr1["NoInEnglish"].ToString() + "]" + dr1["txt1"].ToString();
                        }
                        MSSQL.SQLExec("update [TaqiUsmaniTafsir].[dbo].[Table_1] set txt2=N'" + txt2 + "}' where SL=" + dr["SL"].ToString());
                    }
                }
                catch (Exception ex)
                { }

            }
        }
    }

    private string findCommentsNos(DataRow dr)
    {
        string returnValue="";
        string b = "০,১,২,৩,৪,৫,৬,৭,৮,৯,১০,১১,১২,১৩,১৪,১৫,১৬,১৭,১৮,১৯,২০,২১,২২,২৩,২৪,২৫,২৬,২৭,২৮,২৯,৩০,৩১,৩২,৩৩,৩৪,৩৫,৩৬,৩৭,৩৮,৩৯,৪০,৪১,৪২,৪৩,৪৪,৪৫,৪৬,৪৭,৪৮,৪৯,৫০,৫১,৫২,৫৩,৫৪,৫৫,৫৬,৫৭,৫৮,৫৯,৬০,৬১,৬২,৬৩,৬৪,৬৫,৬৬,৬৭,৬৮,৬৯,৭০,৭১,৭২,৭৩,৭৪,৭৫,৭৬,৭৭,৭৮,৭৯,৮০,৮১,৮২,৮৩,৮৪,৮৫,৮৬,৮৭,৮৮,৮৯,৯০,৯১,৯২,৯৩,৯৪,৯৫,৯৬,৯৭,৯৮,৯৯,১০০,১০১,১০২,১০৩,১০৪,১০৫,১০৬,১০৭,১০৮,১০৯,১১০,১১১,১১২,১১৩,১১৪,১১৫,১১৬,১১৭,১১৮,১১৯,১২০,১২১,১২২,১২৩,১২৪,১২৫,১২৬,১২৭,১২৮,১২৯,১৩০,১৩১,১৩২,১৩৩,১৩৪,১৩৫,১৩৬,১৩৭,১৩৮,১৩৯,১৪০,১৪১,১৪২,১৪৩,১৪৪,১৪৫,১৪৬,১৪৭,১৪৮,১৪৯,১৫০,১৫১,১৫২,১৫৩,১৫৪,১৫৫,১৫৬,১৫৭,১৫৮,১৫৯,১৬০,১৬১,১৬২,১৬৩,১৬৪,১৬৫,১৬৬,১৬৭,১৬৮,১৬৯,১৭০,১৭১,১৭২,১৭৩,১৭৪,১৭৫,১৭৬,১৭৭,১৭৮,১৭৯,১৮০,১৮১,১৮২,১৮৩,১৮৪,১৮৫,১৮৬,১৮৭,১৮৮,১৮৯,১৯০,১৯১,১৯২,১৯৩,১৯৪,১৯৫,১৯৬,১৯৭,১৯৮,১৯৯,২০০,২০১,২০২,২০৩,২০৪,২০৫,২০৬,২০৭,২০৮,২০৯,২১০,২১১,২১২,২১৩,২১৪,২১৫,২১৬,২১৭,২১৮,২১৯,২২০,২২১,২২২,২২৩,২২৪,২২৫,২২৬,২২৭,২২৮,২২৯,২৩০,২৩১,২৩২,২৩৩,২৩৪,২৩৫,২৩৬,২৩৭,২৩৮,২৩৯,২৪০,২৪১,২৪২,২৪৩,২৪৪,২৪৫,২৪৬,২৪৭,২৪৮,২৪৯,২৫০,২৫১,২৫২,২৫৩,২৫৪,২৫৫,২৫৬,২৫৭,২৫৮,২৫৯,২৬০,২৬১,২৬২,২৬৩,২৬৪,২৬৫,২৬৬,২৬৭,২৬৮,২৬৯,২৭০,২৭১,২৭২,২৭৩,২৭৪,২৭৫,২৭৬,২৭৭,২৭৮,২৭৯,২৮০,২৮১,২৮২,২৮৩,২৮৪,২৮৫,২৮৬";
        for (int i = 0; i < 287; i++)
        {
            if (dr["txt1"].ToString().Contains("[" + b.Split(',')[i] + "]"))
            {
                returnValue += (returnValue == "" ? "" : ",") + i.ToString();
            }
        }
        return returnValue;
    }
}