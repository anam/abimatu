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

public class SqlEMPLOYEEProvider:DataAccessObject
{
	public SqlEMPLOYEEProvider()
    {
    }


    public bool DeleteEMPLOYEE(int eMPLOYEEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteEMPLOYEE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EMPLOYEEID", SqlDbType.Int).Value = eMPLOYEEID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<EMPLOYEE> GetAllEMPLOYEEs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllEMPLOYEEs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetEMPLOYEEsFromReader(reader);
        }
    }
    public List<EMPLOYEE> GetEMPLOYEEsFromReader(IDataReader reader)
    {
        List<EMPLOYEE> eMPLOYEEs = new List<EMPLOYEE>();

        while (reader.Read())
        {
            eMPLOYEEs.Add(GetEMPLOYEEFromReader(reader));
        }
        return eMPLOYEEs;
    }

    public EMPLOYEE GetEMPLOYEEFromReader(IDataReader reader)
    {
        try
        {
            EMPLOYEE eMPLOYEE = new EMPLOYEE
                (
                    (int)reader["EMPLOYEEID"],
                    reader["EMPNAME"].ToString(),
                    reader["EMPADDRESS1"].ToString(),
                    reader["EMPADDRESS2"].ToString(),
                    reader["EMPCITY"].ToString(),
                    reader["EMPSTATE"].ToString(),
                    reader["EMPZIP"].ToString(),
                    reader["EMPHPHONE"].ToString(),
                    reader["EMPCPHONE"].ToString(),
                    reader["EMPSTORE"].ToString(),
                    reader["EMPPASSWORD"].ToString(),
                    reader["ISACTIVE"].ToString(),
                    reader["ISMANAGER"].ToString(),
                    reader["ISCOMPLIANCEOFFICER"].ToString(),
                    (int)reader["CREATEDBY"],
                    (DateTime)reader["CREATEDON"],
                    (int)reader["UPDATEDBY"],
                    (DateTime)reader["UPDATEDON"]
                );
             return eMPLOYEE;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public EMPLOYEE GetEMPLOYEEByID(int eMPLOYEEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetEMPLOYEEByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EMPLOYEEID", SqlDbType.Int).Value = eMPLOYEEID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetEMPLOYEEFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertEMPLOYEE(EMPLOYEE eMPLOYEE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertEMPLOYEE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EMPLOYEEID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EMPNAME", SqlDbType.VarChar).Value = eMPLOYEE.EMPNAME;
            cmd.Parameters.Add("@EMPADDRESS1", SqlDbType.VarChar).Value = eMPLOYEE.EMPADDRESS1;
            cmd.Parameters.Add("@EMPADDRESS2", SqlDbType.VarChar).Value = eMPLOYEE.EMPADDRESS2;
            cmd.Parameters.Add("@EMPCITY", SqlDbType.VarChar).Value = eMPLOYEE.EMPCITY;
            cmd.Parameters.Add("@EMPSTATE", SqlDbType.VarChar).Value = eMPLOYEE.EMPSTATE;
            cmd.Parameters.Add("@EMPZIP", SqlDbType.VarChar).Value = eMPLOYEE.EMPZIP;
            cmd.Parameters.Add("@EMPHPHONE", SqlDbType.VarChar).Value = eMPLOYEE.EMPHPHONE;
            cmd.Parameters.Add("@EMPCPHONE", SqlDbType.VarChar).Value = eMPLOYEE.EMPCPHONE;
            cmd.Parameters.Add("@EMPSTORE", SqlDbType.VarChar).Value = eMPLOYEE.EMPSTORE;
            cmd.Parameters.Add("@EMPPASSWORD", SqlDbType.VarChar).Value = eMPLOYEE.EMPPASSWORD;
            cmd.Parameters.Add("@ISACTIVE", SqlDbType.VarChar).Value = eMPLOYEE.ISACTIVE;
            cmd.Parameters.Add("@ISMANAGER", SqlDbType.VarChar).Value = eMPLOYEE.ISMANAGER;
            cmd.Parameters.Add("@ISCOMPLIANCEOFFICER", SqlDbType.VarChar).Value = eMPLOYEE.ISCOMPLIANCEOFFICER;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = eMPLOYEE.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = eMPLOYEE.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = eMPLOYEE.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = eMPLOYEE.UPDATEDON;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EMPLOYEEID"].Value;
        }
    }

    public bool UpdateEMPLOYEE(EMPLOYEE eMPLOYEE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateEMPLOYEE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EMPLOYEEID", SqlDbType.Int).Value = eMPLOYEE.EMPLOYEEID;
            cmd.Parameters.Add("@EMPNAME", SqlDbType.VarChar).Value = eMPLOYEE.EMPNAME;
            cmd.Parameters.Add("@EMPADDRESS1", SqlDbType.VarChar).Value = eMPLOYEE.EMPADDRESS1;
            cmd.Parameters.Add("@EMPADDRESS2", SqlDbType.VarChar).Value = eMPLOYEE.EMPADDRESS2;
            cmd.Parameters.Add("@EMPCITY", SqlDbType.VarChar).Value = eMPLOYEE.EMPCITY;
            cmd.Parameters.Add("@EMPSTATE", SqlDbType.VarChar).Value = eMPLOYEE.EMPSTATE;
            cmd.Parameters.Add("@EMPZIP", SqlDbType.VarChar).Value = eMPLOYEE.EMPZIP;
            cmd.Parameters.Add("@EMPHPHONE", SqlDbType.VarChar).Value = eMPLOYEE.EMPHPHONE;
            cmd.Parameters.Add("@EMPCPHONE", SqlDbType.VarChar).Value = eMPLOYEE.EMPCPHONE;
            cmd.Parameters.Add("@EMPSTORE", SqlDbType.VarChar).Value = eMPLOYEE.EMPSTORE;
            cmd.Parameters.Add("@EMPPASSWORD", SqlDbType.VarChar).Value = eMPLOYEE.EMPPASSWORD;
            cmd.Parameters.Add("@ISACTIVE", SqlDbType.VarChar).Value = eMPLOYEE.ISACTIVE;
            cmd.Parameters.Add("@ISMANAGER", SqlDbType.VarChar).Value = eMPLOYEE.ISMANAGER;
            cmd.Parameters.Add("@ISCOMPLIANCEOFFICER", SqlDbType.VarChar).Value = eMPLOYEE.ISCOMPLIANCEOFFICER;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = eMPLOYEE.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = eMPLOYEE.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = eMPLOYEE.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = eMPLOYEE.UPDATEDON;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
