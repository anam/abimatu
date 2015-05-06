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

public class SqlSUPPLIERProvider:DataAccessObject
{
	public SqlSUPPLIERProvider()
    {
    }


    public bool DeleteSUPPLIER(int sUPPLIERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteSUPPLIER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SUPPLIERID", SqlDbType.Int).Value = sUPPLIERID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<SUPPLIER> GetAllSUPPLIERs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllSUPPLIERs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSUPPLIERsFromReader(reader);
        }
    }
    public List<SUPPLIER> GetSUPPLIERsFromReader(IDataReader reader)
    {
        List<SUPPLIER> sUPPLIERs = new List<SUPPLIER>();

        while (reader.Read())
        {
            sUPPLIERs.Add(GetSUPPLIERFromReader(reader));
        }
        return sUPPLIERs;
    }

    public SUPPLIER GetSUPPLIERFromReader(IDataReader reader)
    {
        try
        {
            SUPPLIER sUPPLIER = new SUPPLIER
                (
                    (int)reader["SUPPLIERID"],
                    reader["SUPPLIERNAME"].ToString(),
                    reader["SUPPLIERADDRESS1"].ToString(),
                    reader["SUPPLIERADDRESS2"].ToString(),
                    reader["SUPPLIERCITY"].ToString(),
                    (char)reader["SUPPLIERSTATE"],
                    reader["SUPPLIERZIP"].ToString(),
                    reader["SUPPLIERPHONE"].ToString(),
                    (DateTime)reader["CREATED_ON"],
                    reader["CREATED_BY"].ToString(),
                    (DateTime)reader["UPDATED_ON"],
                    reader["UPDATED_BY"].ToString()
                );
             return sUPPLIER;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public SUPPLIER GetSUPPLIERByID(int sUPPLIERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetSUPPLIERByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SUPPLIERID", SqlDbType.Int).Value = sUPPLIERID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetSUPPLIERFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSUPPLIER(SUPPLIER sUPPLIER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertSUPPLIER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SUPPLIERID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SUPPLIERNAME", SqlDbType.VarChar).Value = sUPPLIER.SUPPLIERNAME;
            cmd.Parameters.Add("@SUPPLIERADDRESS1", SqlDbType.VarChar).Value = sUPPLIER.SUPPLIERADDRESS1;
            cmd.Parameters.Add("@SUPPLIERADDRESS2", SqlDbType.VarChar).Value = sUPPLIER.SUPPLIERADDRESS2;
            cmd.Parameters.Add("@SUPPLIERCITY", SqlDbType.VarChar).Value = sUPPLIER.SUPPLIERCITY;
            cmd.Parameters.Add("@SUPPLIERSTATE", SqlDbType.Char).Value = sUPPLIER.SUPPLIERSTATE;
            cmd.Parameters.Add("@SUPPLIERZIP", SqlDbType.VarChar).Value = sUPPLIER.SUPPLIERZIP;
            cmd.Parameters.Add("@SUPPLIERPHONE", SqlDbType.VarChar).Value = sUPPLIER.SUPPLIERPHONE;
            cmd.Parameters.Add("@CREATED_ON", SqlDbType.DateTime).Value = sUPPLIER.CREATED_ON;
            cmd.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = sUPPLIER.CREATED_BY;
            cmd.Parameters.Add("@UPDATED_ON", SqlDbType.DateTime).Value = sUPPLIER.UPDATED_ON;
            cmd.Parameters.Add("@UPDATED_BY", SqlDbType.VarChar).Value = sUPPLIER.UPDATED_BY;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SUPPLIERID"].Value;
        }
    }

    public bool UpdateSUPPLIER(SUPPLIER sUPPLIER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateSUPPLIER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SUPPLIERID", SqlDbType.Int).Value = sUPPLIER.SUPPLIERID;
            cmd.Parameters.Add("@SUPPLIERNAME", SqlDbType.VarChar).Value = sUPPLIER.SUPPLIERNAME;
            cmd.Parameters.Add("@SUPPLIERADDRESS1", SqlDbType.VarChar).Value = sUPPLIER.SUPPLIERADDRESS1;
            cmd.Parameters.Add("@SUPPLIERADDRESS2", SqlDbType.VarChar).Value = sUPPLIER.SUPPLIERADDRESS2;
            cmd.Parameters.Add("@SUPPLIERCITY", SqlDbType.VarChar).Value = sUPPLIER.SUPPLIERCITY;
            cmd.Parameters.Add("@SUPPLIERSTATE", SqlDbType.Char).Value = sUPPLIER.SUPPLIERSTATE;
            cmd.Parameters.Add("@SUPPLIERZIP", SqlDbType.VarChar).Value = sUPPLIER.SUPPLIERZIP;
            cmd.Parameters.Add("@SUPPLIERPHONE", SqlDbType.VarChar).Value = sUPPLIER.SUPPLIERPHONE;
            cmd.Parameters.Add("@CREATED_ON", SqlDbType.DateTime).Value = sUPPLIER.CREATED_ON;
            cmd.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = sUPPLIER.CREATED_BY;
            cmd.Parameters.Add("@UPDATED_ON", SqlDbType.DateTime).Value = sUPPLIER.UPDATED_ON;
            cmd.Parameters.Add("@UPDATED_BY", SqlDbType.VarChar).Value = sUPPLIER.UPDATED_BY;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
