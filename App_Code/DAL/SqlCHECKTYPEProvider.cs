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

public class SqlCHECKTYPEProvider:DataAccessObject
{
	public SqlCHECKTYPEProvider()
    {
    }


    public bool DeleteCHECKTYPE(int cHECKTYPEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteCHECKTYPE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CHECKTYPEID", SqlDbType.Int).Value = cHECKTYPEID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<CHECKTYPE> GetAllCHECKTYPEs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllCHECKTYPEs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCHECKTYPEsFromReader(reader);
        }
    }
    public List<CHECKTYPE> GetCHECKTYPEsFromReader(IDataReader reader)
    {
        List<CHECKTYPE> cHECKTYPEs = new List<CHECKTYPE>();

        while (reader.Read())
        {
            cHECKTYPEs.Add(GetCHECKTYPEFromReader(reader));
        }
        return cHECKTYPEs;
    }

    public CHECKTYPE GetCHECKTYPEFromReader(IDataReader reader)
    {
        try
        {
            CHECKTYPE cHECKTYPE = new CHECKTYPE
                (
                    (int)reader["CHECKTYPEID"],
                    reader["CHKTYPE"].ToString(),
                    (int)reader["CHKRATE"],
                    reader["CHKROUTING"].ToString(),
                    reader["CHKACCOUNT"].ToString()
                );
             return cHECKTYPE;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public CHECKTYPE GetCHECKTYPEByID(int cHECKTYPEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetCHECKTYPEByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CHECKTYPEID", SqlDbType.Int).Value = cHECKTYPEID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetCHECKTYPEFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertCHECKTYPE(CHECKTYPE cHECKTYPE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertCHECKTYPE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CHECKTYPEID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CHKTYPE", SqlDbType.VarChar).Value = cHECKTYPE.CHKTYPE;
            cmd.Parameters.Add("@CHKRATE", SqlDbType.Int).Value = cHECKTYPE.CHKRATE;
            cmd.Parameters.Add("@CHKROUTING", SqlDbType.VarChar).Value = cHECKTYPE.CHKROUTING;
            cmd.Parameters.Add("@CHKACCOUNT", SqlDbType.VarChar).Value = cHECKTYPE.CHKACCOUNT;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CHECKTYPEID"].Value;
        }
    }

    public bool UpdateCHECKTYPE(CHECKTYPE cHECKTYPE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateCHECKTYPE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CHECKTYPEID", SqlDbType.Int).Value = cHECKTYPE.CHECKTYPEID;
            cmd.Parameters.Add("@CHKTYPE", SqlDbType.VarChar).Value = cHECKTYPE.CHKTYPE;
            cmd.Parameters.Add("@CHKRATE", SqlDbType.Int).Value = cHECKTYPE.CHKRATE;
            cmd.Parameters.Add("@CHKROUTING", SqlDbType.VarChar).Value = cHECKTYPE.CHKROUTING;
            cmd.Parameters.Add("@CHKACCOUNT", SqlDbType.VarChar).Value = cHECKTYPE.CHKACCOUNT;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
