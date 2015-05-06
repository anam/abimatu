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

public class SqlCUSTOMERACCOUNTProvider:DataAccessObject
{
	public SqlCUSTOMERACCOUNTProvider()
    {
    }


    public bool DeleteCUSTOMERACCOUNT(int cUSTOMERACCOUNTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteCUSTOMERACCOUNT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CUSTOMERACCOUNTID", SqlDbType.Int).Value = cUSTOMERACCOUNTID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<CUSTOMERACCOUNT> GetAllCUSTOMERACCOUNTs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllCUSTOMERACCOUNTs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCUSTOMERACCOUNTsFromReader(reader);
        }
    }
    public List<CUSTOMERACCOUNT> GetCUSTOMERACCOUNTsFromReader(IDataReader reader)
    {
        List<CUSTOMERACCOUNT> cUSTOMERACCOUNTs = new List<CUSTOMERACCOUNT>();

        while (reader.Read())
        {
            cUSTOMERACCOUNTs.Add(GetCUSTOMERACCOUNTFromReader(reader));
        }
        return cUSTOMERACCOUNTs;
    }

    public CUSTOMERACCOUNT GetCUSTOMERACCOUNTFromReader(IDataReader reader)
    {
        try
        {
            CUSTOMERACCOUNT cUSTOMERACCOUNT = new CUSTOMERACCOUNT
                (
                    (int)reader["CUSTOMERACCOUNTID"],
                    reader["ACCOUNTNO"].ToString(),
                    (int)reader["SERVICEID"],
                    (int)reader["CUST_ID"]
                );
             return cUSTOMERACCOUNT;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public CUSTOMERACCOUNT GetCUSTOMERACCOUNTByID(int cUSTOMERACCOUNTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetCUSTOMERACCOUNTByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CUSTOMERACCOUNTID", SqlDbType.Int).Value = cUSTOMERACCOUNTID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetCUSTOMERACCOUNTFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertCUSTOMERACCOUNT(CUSTOMERACCOUNT cUSTOMERACCOUNT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertCUSTOMERACCOUNT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CUSTOMERACCOUNTID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ACCOUNTNO", SqlDbType.VarChar).Value = cUSTOMERACCOUNT.ACCOUNTNO;
            cmd.Parameters.Add("@SERVICEID", SqlDbType.Int).Value = cUSTOMERACCOUNT.SERVICEID;
            cmd.Parameters.Add("@CUST_ID", SqlDbType.Int).Value = cUSTOMERACCOUNT.CUST_ID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CUSTOMERACCOUNTID"].Value;
        }
    }

    public bool UpdateCUSTOMERACCOUNT(CUSTOMERACCOUNT cUSTOMERACCOUNT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateCUSTOMERACCOUNT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CUSTOMERACCOUNTID", SqlDbType.Int).Value = cUSTOMERACCOUNT.CUSTOMERACCOUNTID;
            cmd.Parameters.Add("@ACCOUNTNO", SqlDbType.VarChar).Value = cUSTOMERACCOUNT.ACCOUNTNO;
            cmd.Parameters.Add("@SERVICEID", SqlDbType.Int).Value = cUSTOMERACCOUNT.SERVICEID;
            cmd.Parameters.Add("@CUST_ID", SqlDbType.Int).Value = cUSTOMERACCOUNT.CUST_ID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
