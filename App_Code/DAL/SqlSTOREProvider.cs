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

public class SqlSTOREProvider:DataAccessObject
{
	public SqlSTOREProvider()
    {
    }


    public bool DeleteSTORE(int sTOREID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteSTORE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STOREID", SqlDbType.Int).Value = sTOREID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<STORE> GetAllSTOREs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllSTOREs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSTOREsFromReader(reader);
        }
    }
    public List<STORE> GetSTOREsFromReader(IDataReader reader)
    {
        List<STORE> sTOREs = new List<STORE>();

        while (reader.Read())
        {
            sTOREs.Add(GetSTOREFromReader(reader));
        }
        return sTOREs;
    }

    public STORE GetSTOREFromReader(IDataReader reader)
    {
        try
        {
            STORE sTORE = new STORE
                (
                    (int)reader["STOREID"],
                    reader["STORENAME"].ToString(),
                    reader["COMPANYNAME"].ToString(),
                    reader["ADDRESS"].ToString(),
                    reader["CITY"].ToString(),
                    reader["STATE"].ToString(),
                    reader["ZIP"].ToString(),
                    reader["PHONE"].ToString(),
                    reader["ACCOUNTNO"].ToString(),
                    reader["ROUTINGNO"].ToString(),
                    reader["SSN"].ToString(),
                    reader["FTPSERVER"].ToString(),
                    (int)reader["CREATEDBY"],
                    (DateTime)reader["CREATEDON"],
                    (int)reader["UPDATEDBY"],
                    (DateTime)reader["UPDATEDON"]
                );
             return sTORE;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STORE GetSTOREByID(int sTOREID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetSTOREByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@STOREID", SqlDbType.Int).Value = sTOREID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetSTOREFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSTORE(STORE sTORE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertSTORE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STOREID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@STORENAME", SqlDbType.VarChar).Value = sTORE.STORENAME;
            cmd.Parameters.Add("@COMPANYNAME", SqlDbType.VarChar).Value = sTORE.COMPANYNAME;
            cmd.Parameters.Add("@ADDRESS", SqlDbType.VarChar).Value = sTORE.ADDRESS;
            cmd.Parameters.Add("@CITY", SqlDbType.VarChar).Value = sTORE.CITY;
            cmd.Parameters.Add("@STATE", SqlDbType.VarChar).Value = sTORE.STATE;
            cmd.Parameters.Add("@ZIP", SqlDbType.VarChar).Value = sTORE.ZIP;
            cmd.Parameters.Add("@PHONE", SqlDbType.VarChar).Value = sTORE.PHONE;
            cmd.Parameters.Add("@ACCOUNTNO", SqlDbType.VarChar).Value = sTORE.ACCOUNTNO;
            cmd.Parameters.Add("@ROUTINGNO", SqlDbType.VarChar).Value = sTORE.ROUTINGNO;
            cmd.Parameters.Add("@SSN", SqlDbType.VarChar).Value = sTORE.SSN;
            cmd.Parameters.Add("@FTPSERVER", SqlDbType.VarChar).Value = sTORE.FTPSERVER;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = sTORE.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = sTORE.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = sTORE.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = sTORE.UPDATEDON;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@STOREID"].Value;
        }
    }

    public bool UpdateSTORE(STORE sTORE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateSTORE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STOREID", SqlDbType.Int).Value = sTORE.STOREID;
            cmd.Parameters.Add("@STORENAME", SqlDbType.VarChar).Value = sTORE.STORENAME;
            cmd.Parameters.Add("@COMPANYNAME", SqlDbType.VarChar).Value = sTORE.COMPANYNAME;
            cmd.Parameters.Add("@ADDRESS", SqlDbType.VarChar).Value = sTORE.ADDRESS;
            cmd.Parameters.Add("@CITY", SqlDbType.VarChar).Value = sTORE.CITY;
            cmd.Parameters.Add("@STATE", SqlDbType.VarChar).Value = sTORE.STATE;
            cmd.Parameters.Add("@ZIP", SqlDbType.VarChar).Value = sTORE.ZIP;
            cmd.Parameters.Add("@PHONE", SqlDbType.VarChar).Value = sTORE.PHONE;
            cmd.Parameters.Add("@ACCOUNTNO", SqlDbType.VarChar).Value = sTORE.ACCOUNTNO;
            cmd.Parameters.Add("@ROUTINGNO", SqlDbType.VarChar).Value = sTORE.ROUTINGNO;
            cmd.Parameters.Add("@SSN", SqlDbType.VarChar).Value = sTORE.SSN;
            cmd.Parameters.Add("@FTPSERVER", SqlDbType.VarChar).Value = sTORE.FTPSERVER;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = sTORE.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = sTORE.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = sTORE.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = sTORE.UPDATEDON;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
