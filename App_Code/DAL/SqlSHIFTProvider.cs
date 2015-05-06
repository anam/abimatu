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

public class SqlSHIFTProvider:DataAccessObject
{
	public SqlSHIFTProvider()
    {
    }


    public bool DeleteSHIFT(int sHIFTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteSHIFT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SHIFTID", SqlDbType.Int).Value = sHIFTID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<SHIFT> GetAllSHIFTs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllSHIFTs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSHIFTsFromReader(reader);
        }
    }
    public List<SHIFT> GetSHIFTsFromReader(IDataReader reader)
    {
        List<SHIFT> sHIFTs = new List<SHIFT>();

        while (reader.Read())
        {
            sHIFTs.Add(GetSHIFTFromReader(reader));
        }
        return sHIFTs;
    }

    public SHIFT GetSHIFTFromReader(IDataReader reader)
    {
        try
        {
            SHIFT sHIFT = new SHIFT
                (
                    (int)reader["SHIFTID"],
                    reader["SHIFTNAME"].ToString(),
                    (DateTime)reader["SHIFTSTART"],
                    (DateTime)reader["SHIFTEND"],
                    (DateTime)reader["CREATEDON"],
                    reader["CREATEDBY"].ToString(),
                    (DateTime)reader["UPDATEDON"],
                    reader["UPDATEDBY"].ToString(),
                    reader["SHIFTTIME"].ToString()
                );
             return sHIFT;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public SHIFT GetSHIFTByID(int sHIFTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetSHIFTByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SHIFTID", SqlDbType.Int).Value = sHIFTID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetSHIFTFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSHIFT(SHIFT sHIFT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertSHIFT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SHIFTID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SHIFTNAME", SqlDbType.VarChar).Value = sHIFT.SHIFTNAME;
            cmd.Parameters.Add("@SHIFTSTART", SqlDbType.DateTime).Value = sHIFT.SHIFTSTART;
            cmd.Parameters.Add("@SHIFTEND", SqlDbType.DateTime).Value = sHIFT.SHIFTEND;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = sHIFT.CREATEDON;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = sHIFT.CREATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = sHIFT.UPDATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.VarChar).Value = sHIFT.UPDATEDBY;
            cmd.Parameters.Add("@SHIFTTIME", SqlDbType.VarChar).Value = sHIFT.SHIFTTIME;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SHIFTID"].Value;
        }
    }

    public bool UpdateSHIFT(SHIFT sHIFT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateSHIFT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SHIFTID", SqlDbType.Int).Value = sHIFT.SHIFTID;
            cmd.Parameters.Add("@SHIFTNAME", SqlDbType.VarChar).Value = sHIFT.SHIFTNAME;
            cmd.Parameters.Add("@SHIFTSTART", SqlDbType.DateTime).Value = sHIFT.SHIFTSTART;
            cmd.Parameters.Add("@SHIFTEND", SqlDbType.DateTime).Value = sHIFT.SHIFTEND;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = sHIFT.CREATEDON;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = sHIFT.CREATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = sHIFT.UPDATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.VarChar).Value = sHIFT.UPDATEDBY;
            cmd.Parameters.Add("@SHIFTTIME", SqlDbType.VarChar).Value = sHIFT.SHIFTTIME;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
