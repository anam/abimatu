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

public class SqlCUSTOMERUTILITYPAYMENTProvider:DataAccessObject
{
	public SqlCUSTOMERUTILITYPAYMENTProvider()
    {
    }


    public bool DeleteCUSTOMERUTILITYPAYMENT(int cUSTOMERUTILITYPAYMENTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteCUSTOMERUTILITYPAYMENT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CUSTOMERUTILITYPAYMENTID", SqlDbType.Int).Value = cUSTOMERUTILITYPAYMENTID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<CUSTOMERUTILITYPAYMENT> GetAllCUSTOMERUTILITYPAYMENTs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllCUSTOMERUTILITYPAYMENTs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCUSTOMERUTILITYPAYMENTsFromReader(reader);
        }
    }
    public List<CUSTOMERUTILITYPAYMENT> GetCUSTOMERUTILITYPAYMENTsFromReader(IDataReader reader)
    {
        List<CUSTOMERUTILITYPAYMENT> cUSTOMERUTILITYPAYMENTs = new List<CUSTOMERUTILITYPAYMENT>();

        while (reader.Read())
        {
            cUSTOMERUTILITYPAYMENTs.Add(GetCUSTOMERUTILITYPAYMENTFromReader(reader));
        }
        return cUSTOMERUTILITYPAYMENTs;
    }

    public CUSTOMERUTILITYPAYMENT GetCUSTOMERUTILITYPAYMENTFromReader(IDataReader reader)
    {
        try
        {
            CUSTOMERUTILITYPAYMENT cUSTOMERUTILITYPAYMENT = new CUSTOMERUTILITYPAYMENT
                (
                    (int)reader["CUSTOMERUTILITYPAYMENTID"],
                    reader["CUSTID"].ToString(),
                    reader["UTILITYID"].ToString(),
                    reader["ACCOUNTNUMBER"].ToString()
                );
             return cUSTOMERUTILITYPAYMENT;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public CUSTOMERUTILITYPAYMENT GetCUSTOMERUTILITYPAYMENTByID(int cUSTOMERUTILITYPAYMENTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetCUSTOMERUTILITYPAYMENTByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CUSTOMERUTILITYPAYMENTID", SqlDbType.Int).Value = cUSTOMERUTILITYPAYMENTID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetCUSTOMERUTILITYPAYMENTFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertCUSTOMERUTILITYPAYMENT(CUSTOMERUTILITYPAYMENT cUSTOMERUTILITYPAYMENT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertCUSTOMERUTILITYPAYMENT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CUSTOMERUTILITYPAYMENTID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CUSTID", SqlDbType.VarChar).Value = cUSTOMERUTILITYPAYMENT.CUSTID;
            cmd.Parameters.Add("@UTILITYID", SqlDbType.VarChar).Value = cUSTOMERUTILITYPAYMENT.UTILITYID;
            cmd.Parameters.Add("@ACCOUNTNUMBER", SqlDbType.VarChar).Value = cUSTOMERUTILITYPAYMENT.ACCOUNTNUMBER;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CUSTOMERUTILITYPAYMENTID"].Value;
        }
    }

    public bool UpdateCUSTOMERUTILITYPAYMENT(CUSTOMERUTILITYPAYMENT cUSTOMERUTILITYPAYMENT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateCUSTOMERUTILITYPAYMENT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CUSTOMERUTILITYPAYMENTID", SqlDbType.Int).Value = cUSTOMERUTILITYPAYMENT.CUSTOMERUTILITYPAYMENTID;
            cmd.Parameters.Add("@CUSTID", SqlDbType.VarChar).Value = cUSTOMERUTILITYPAYMENT.CUSTID;
            cmd.Parameters.Add("@UTILITYID", SqlDbType.VarChar).Value = cUSTOMERUTILITYPAYMENT.UTILITYID;
            cmd.Parameters.Add("@ACCOUNTNUMBER", SqlDbType.VarChar).Value = cUSTOMERUTILITYPAYMENT.ACCOUNTNUMBER;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
