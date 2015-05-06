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

public class SqlGLOBALPAYMENTProvider:DataAccessObject
{
	public SqlGLOBALPAYMENTProvider()
    {
    }


    public bool DeleteGLOBALPAYMENT(int gLOBALPAYMENTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteGLOBALPAYMENT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GLOBALPAYMENTID", SqlDbType.Int).Value = gLOBALPAYMENTID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<GLOBALPAYMENT> GetAllGLOBALPAYMENTs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllGLOBALPAYMENTs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetGLOBALPAYMENTsFromReader(reader);
        }
    }
    public List<GLOBALPAYMENT> GetGLOBALPAYMENTsFromReader(IDataReader reader)
    {
        List<GLOBALPAYMENT> gLOBALPAYMENTs = new List<GLOBALPAYMENT>();

        while (reader.Read())
        {
            gLOBALPAYMENTs.Add(GetGLOBALPAYMENTFromReader(reader));
        }
        return gLOBALPAYMENTs;
    }

    public GLOBALPAYMENT GetGLOBALPAYMENTFromReader(IDataReader reader)
    {
        try
        {
            GLOBALPAYMENT gLOBALPAYMENT = new GLOBALPAYMENT
                (
                    (int)reader["GLOBALPAYMENTID"],
                    reader["ID"].ToString(),
                    reader["UTILITYNAME"].ToString(),
                    (int)reader["UTILITYFEES"],
                    (int)reader["STORECOMM"],
                    (int)reader["GLOBALCOMM"],
                    (int)reader["ACCOUNTLENGTH"],
                    (int)reader["ACCOUNTSTART"],
                    (int)reader["SCALELINEFROMBOTTON"],
                    (int)reader["SCALELINEWIDTH"]
                );
             return gLOBALPAYMENT;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public GLOBALPAYMENT GetGLOBALPAYMENTByID(int gLOBALPAYMENTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetGLOBALPAYMENTByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@GLOBALPAYMENTID", SqlDbType.Int).Value = gLOBALPAYMENTID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetGLOBALPAYMENTFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertGLOBALPAYMENT(GLOBALPAYMENT gLOBALPAYMENT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertGLOBALPAYMENT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GLOBALPAYMENTID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = gLOBALPAYMENT.ID;
            cmd.Parameters.Add("@UTILITYNAME", SqlDbType.VarChar).Value = gLOBALPAYMENT.UTILITYNAME;
            cmd.Parameters.Add("@UTILITYFEES", SqlDbType.Int).Value = gLOBALPAYMENT.UTILITYFEES;
            cmd.Parameters.Add("@STORECOMM", SqlDbType.Int).Value = gLOBALPAYMENT.STORECOMM;
            cmd.Parameters.Add("@GLOBALCOMM", SqlDbType.Int).Value = gLOBALPAYMENT.GLOBALCOMM;
            cmd.Parameters.Add("@ACCOUNTLENGTH", SqlDbType.Int).Value = gLOBALPAYMENT.ACCOUNTLENGTH;
            cmd.Parameters.Add("@ACCOUNTSTART", SqlDbType.Int).Value = gLOBALPAYMENT.ACCOUNTSTART;
            cmd.Parameters.Add("@SCALELINEFROMBOTTON", SqlDbType.Int).Value = gLOBALPAYMENT.SCALELINEFROMBOTTON;
            cmd.Parameters.Add("@SCALELINEWIDTH", SqlDbType.Int).Value = gLOBALPAYMENT.SCALELINEWIDTH;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@GLOBALPAYMENTID"].Value;
        }
    }

    public bool UpdateGLOBALPAYMENT(GLOBALPAYMENT gLOBALPAYMENT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateGLOBALPAYMENT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GLOBALPAYMENTID", SqlDbType.Int).Value = gLOBALPAYMENT.GLOBALPAYMENTID;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = gLOBALPAYMENT.ID;
            cmd.Parameters.Add("@UTILITYNAME", SqlDbType.VarChar).Value = gLOBALPAYMENT.UTILITYNAME;
            cmd.Parameters.Add("@UTILITYFEES", SqlDbType.Int).Value = gLOBALPAYMENT.UTILITYFEES;
            cmd.Parameters.Add("@STORECOMM", SqlDbType.Int).Value = gLOBALPAYMENT.STORECOMM;
            cmd.Parameters.Add("@GLOBALCOMM", SqlDbType.Int).Value = gLOBALPAYMENT.GLOBALCOMM;
            cmd.Parameters.Add("@ACCOUNTLENGTH", SqlDbType.Int).Value = gLOBALPAYMENT.ACCOUNTLENGTH;
            cmd.Parameters.Add("@ACCOUNTSTART", SqlDbType.Int).Value = gLOBALPAYMENT.ACCOUNTSTART;
            cmd.Parameters.Add("@SCALELINEFROMBOTTON", SqlDbType.Int).Value = gLOBALPAYMENT.SCALELINEFROMBOTTON;
            cmd.Parameters.Add("@SCALELINEWIDTH", SqlDbType.Int).Value = gLOBALPAYMENT.SCALELINEWIDTH;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
