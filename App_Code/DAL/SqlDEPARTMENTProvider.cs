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

public class SqlDEPARTMENTProvider:DataAccessObject
{
	public SqlDEPARTMENTProvider()
    {
    }


    public bool DeleteDEPARTMENT(int dEPARTMENTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteDEPARTMENT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DEPARTMENTID", SqlDbType.Int).Value = dEPARTMENTID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<DEPARTMENT> GetAllDEPARTMENTs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllDEPARTMENTs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetDEPARTMENTsFromReader(reader);
        }
    }
    public List<DEPARTMENT> GetDEPARTMENTsFromReader(IDataReader reader)
    {
        List<DEPARTMENT> dEPARTMENTs = new List<DEPARTMENT>();

        while (reader.Read())
        {
            dEPARTMENTs.Add(GetDEPARTMENTFromReader(reader));
        }
        return dEPARTMENTs;
    }

    public DEPARTMENT GetDEPARTMENTFromReader(IDataReader reader)
    {
        try
        {
            DEPARTMENT dEPARTMENT = new DEPARTMENT
                (
                    (int)reader["DEPARTMENTID"],
                    reader["DEPTNAME"].ToString()
                );
             return dEPARTMENT;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public DEPARTMENT GetDEPARTMENTByID(int dEPARTMENTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetDEPARTMENTByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DEPARTMENTID", SqlDbType.Int).Value = dEPARTMENTID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetDEPARTMENTFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertDEPARTMENT(DEPARTMENT dEPARTMENT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertDEPARTMENT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DEPARTMENTID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DEPTNAME", SqlDbType.VarChar).Value = dEPARTMENT.DEPTNAME;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DEPARTMENTID"].Value;
        }
    }

    public bool UpdateDEPARTMENT(DEPARTMENT dEPARTMENT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateDEPARTMENT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DEPARTMENTID", SqlDbType.Int).Value = dEPARTMENT.DEPARTMENTID;
            cmd.Parameters.Add("@DEPTNAME", SqlDbType.VarChar).Value = dEPARTMENT.DEPTNAME;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
