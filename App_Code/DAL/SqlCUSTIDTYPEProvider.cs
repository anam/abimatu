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

public class SqlCUSTIDTYPEProvider:DataAccessObject
{
	public SqlCUSTIDTYPEProvider()
    {
    }


    public bool DeleteCUSTIDTYPE(int cUSTIDTYPEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteCUSTIDTYPE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CUSTIDTYPEID", SqlDbType.Int).Value = cUSTIDTYPEID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<CUSTIDTYPE> GetAllCUSTIDTYPEs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllCUSTIDTYPEs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCUSTIDTYPEsFromReader(reader);
        }
    }
    public List<CUSTIDTYPE> GetCUSTIDTYPEsFromReader(IDataReader reader)
    {
        List<CUSTIDTYPE> cUSTIDTYPEs = new List<CUSTIDTYPE>();

        while (reader.Read())
        {
            cUSTIDTYPEs.Add(GetCUSTIDTYPEFromReader(reader));
        }
        return cUSTIDTYPEs;
    }

    public CUSTIDTYPE GetCUSTIDTYPEFromReader(IDataReader reader)
    {
        try
        {
            CUSTIDTYPE cUSTIDTYPE = new CUSTIDTYPE
                (
                    (int)reader["CUSTIDTYPEID"],
                    reader["CUSTIDTYPEName"].ToString()
                );
             return cUSTIDTYPE;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public CUSTIDTYPE GetCUSTIDTYPEByID(int cUSTIDTYPEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetCUSTIDTYPEByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CUSTIDTYPEID", SqlDbType.Int).Value = cUSTIDTYPEID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetCUSTIDTYPEFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertCUSTIDTYPE(CUSTIDTYPE cUSTIDTYPE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertCUSTIDTYPE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CUSTIDTYPEID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CUSTIDTYPEName", SqlDbType.NChar).Value = cUSTIDTYPE.CUSTIDTYPEName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CUSTIDTYPEID"].Value;
        }
    }

    public bool UpdateCUSTIDTYPE(CUSTIDTYPE cUSTIDTYPE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateCUSTIDTYPE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CUSTIDTYPEID", SqlDbType.Int).Value = cUSTIDTYPE.CUSTIDTYPEID;
            cmd.Parameters.Add("@CUSTIDTYPEName", SqlDbType.NChar).Value = cUSTIDTYPE.CUSTIDTYPEName;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
