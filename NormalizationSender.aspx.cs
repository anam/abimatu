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
            loadData();
        }
    }

    private void loadData()
    {
        DataSet ds = MSSQL.SQLExec(@"
SELECT [CUSTOMERID]
      ,[CUSTFNAME]
      ,[CUSTMNAME]
      ,[CUSTLNAME]
      ,[CUSTIDNUMBER]
      
  FROM [CUSTOMER]
order by CUSTFNAME,CUSTMNAME,CUSTLNAME
");
        chklUniversity.Items.Clear();
        rbtnlUniversity.Items.Clear();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            chklUniversity.Items.Add(new ListItem(dr["CUSTFNAME"].ToString(), dr["CUSTOMERID"].ToString()));
            rbtnlUniversity.Items.Add(new ListItem(dr["CUSTFNAME"].ToString(), dr["CUSTOMERID"].ToString()));
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (rbtnlUniversity.SelectedValue != null)
        {
            string ids = "";

            foreach (ListItem item in chklUniversity.Items)
            {
                if (item.Selected)
                    ids += (ids == "" ? "" : ",") + item.Value;
            }

            string sql = @"update TRANS set CUSTID=" + rbtnlUniversity.SelectedValue + " where CUSTID in (" + ids + @");";
            sql += "Delete CUSTOMER where  CUSTOMERID in (" + ids + @") and CUSTOMERID<>" + rbtnlUniversity.SelectedValue + ";";
            MSSQL.SQLExec(sql);
            loadData();
        }
    }
    
    protected void btnTransferToForeign_Click(object sender, EventArgs e)
    {
        string ids = "";

        foreach (ListItem item in chklUniversity.Items)
        {
            if (item.Selected)
                ids += (ids == "" ? "" : ",") + item.Value;
        }

        string sql = @"update Comn_University set Fax='" + txtCountryName.Text + "' where Comn_UniversityID in (" + ids + @");";
        MSSQL.SQLExec(sql);
        loadData();
    }
    protected void btnUpdateToBangladesh_Click(object sender, EventArgs e)
    {
        string ids = "";

        foreach (ListItem item in chklUniversity.Items)
        {
            if (item.Selected)
                ids += (ids == "" ? "" : ",") + item.Value;
        }

        string sql = @"update Comn_University set Fax='BANGLADESH' where Comn_UniversityID in (" + ids + @");";
        MSSQL.SQLExec(sql);
        loadData();
    }
}