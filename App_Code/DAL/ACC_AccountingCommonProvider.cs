using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_AccountingCommonProvider:DataAccessObject
{
    

    public string ProcessDataBackup()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("Create_DB_Backup_download", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds.Tables[0].Rows[0][0].ToString();
            }
        }
    }

    }

