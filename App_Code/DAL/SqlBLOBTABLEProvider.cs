using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class SqlBLOBTABLEProvider:DataAccessObject
{
	public SqlBLOBTABLEProvider()
    {
    }


    public bool DeleteBLOBTABLE(int bLOBTABLEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteBLOBTABLE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BLOBTABLEID", SqlDbType.Int).Value = bLOBTABLEID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<BLOBTABLE> GetAllBLOBTABLEs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllBLOBTABLEs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetBLOBTABLEsFromReader(reader);
        }
    }
    public List<BLOBTABLE> GetBLOBTABLEsFromReader(IDataReader reader)
    {
        List<BLOBTABLE> bLOBTABLEs = new List<BLOBTABLE>();

        while (reader.Read())
        {
            bLOBTABLEs.Add(GetBLOBTABLEFromReader(reader));
        }
        return bLOBTABLEs;
    }

    public BLOBTABLE GetBLOBTABLEFromReader(IDataReader reader)
    {
        try
        {
            BLOBTABLE bLOBTABLE = new BLOBTABLE
                (
                    (int)reader["BLOBTABLEID"],
                    reader["T"].ToString()
                );
             return bLOBTABLE;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public BLOBTABLE GetBLOBTABLEByID(int bLOBTABLEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetBLOBTABLEByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BLOBTABLEID", SqlDbType.Int).Value = bLOBTABLEID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetBLOBTABLEFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertBLOBTABLE(BLOBTABLE bLOBTABLE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertBLOBTABLE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BLOBTABLEID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@T", SqlDbType.VarChar).Value = bLOBTABLE.T;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BLOBTABLEID"].Value;
        }
    }

    public bool UpdateBLOBTABLE(BLOBTABLE bLOBTABLE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateBLOBTABLE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BLOBTABLEID", SqlDbType.Int).Value = bLOBTABLE.BLOBTABLEID;
            cmd.Parameters.Add("@T", SqlDbType.VarChar).Value = bLOBTABLE.T;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
