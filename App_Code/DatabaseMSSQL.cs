using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;


public class MSSQL
{
    public MSSQL()
    {
    }

    public static DataSet SQLExec(string sql)
    {
        DataSet sql_CommonDS = new DataSet();
        DatabaseMSSQL sql_Common = new DatabaseMSSQL();
        sql_CommonDS = sql_Common.getDataSet(sql);
        return sql_CommonDS;
    }
}

    public class DatabaseMSSQL
	{
		public SqlConnection conn;

        public DatabaseMSSQL()
		{
		}

		public void Open() 
		{
			if (conn == null) 
			{
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AbiMatuEnterpriseConnectionString"].ToString());
                
                conn.Open();
			}				
		}

		public void Close() 
		{
			if (conn != null)
			{
				conn.Close();
				conn.Dispose();
				conn = null;
			}
		}

        

		public DataSet getDataSet(string strSQL)
		{
			Open();

            SqlCommand cmd = new  SqlCommand(strSQL,conn);

			SqlDataAdapter da = new SqlDataAdapter();
			da.SelectCommand = cmd;

			DataSet ds = new DataSet();
			da.Fill(ds, "dataset");

			Close();
			return ds;
		}

		

       

		public bool executeNonQry (string strSQL)
		{
			Open();
            SqlCommand cmd = new SqlCommand(strSQL, this.conn);
			try 
			{
				if ( cmd.ExecuteNonQuery() > 0 )
					return true;
				else
					return false ;
			}
			catch(Exception ex)
			{
				string err ;
				err = ex.ToString();
				return false;
			}
			finally
			{
				cmd.Dispose() ;
				Close() ;
			}
		}

        

	}

