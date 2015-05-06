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

public class SqlVAULTProvider:DataAccessObject
{
	public SqlVAULTProvider()
    {
    }


    public bool DeleteVAULT(int vAULTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteVAULT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VAULTID", SqlDbType.Int).Value = vAULTID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<VAULT> GetAllVAULTs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllVAULTs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetVAULTsFromReader(reader);
        }
    }
    public List<VAULT> GetVAULTsFromReader(IDataReader reader)
    {
        List<VAULT> vAULTs = new List<VAULT>();

        while (reader.Read())
        {
            vAULTs.Add(GetVAULTFromReader(reader));
        }
        return vAULTs;
    }

    public VAULT GetVAULTFromReader(IDataReader reader)
    {
        try
        {
            VAULT vAULT = new VAULT
                (
                    (int)reader["VAULTID"],
                    (int)reader["VAULTAMOUNT"]
                );
             return vAULT;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public VAULT GetVAULTByID(int vAULTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetVAULTByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@VAULTID", SqlDbType.Int).Value = vAULTID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetVAULTFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertVAULT(VAULT vAULT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertVAULT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VAULTID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@VAULTAMOUNT", SqlDbType.Int).Value = vAULT.VAULTAMOUNT;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@VAULTID"].Value;
        }
    }

    public bool UpdateVAULT(VAULT vAULT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateVAULT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VAULTID", SqlDbType.Int).Value = vAULT.VAULTID;
            cmd.Parameters.Add("@VAULTAMOUNT", SqlDbType.Int).Value = vAULT.VAULTAMOUNT;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
