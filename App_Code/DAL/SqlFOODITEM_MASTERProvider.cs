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

public class SqlFOODITEM_MASTERProvider:DataAccessObject
{
	public SqlFOODITEM_MASTERProvider()
    {
    }


    public bool DeleteFOODITEM_MASTER(int fOODITEM_MASTERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteFOODITEM_MASTER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FOODITEM_MASTERID", SqlDbType.Int).Value = fOODITEM_MASTERID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<FOODITEM_MASTER> GetAllFOODITEM_MASTERs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllFOODITEM_MASTERs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetFOODITEM_MASTERsFromReader(reader);
        }
    }
    public List<FOODITEM_MASTER> GetFOODITEM_MASTERsFromReader(IDataReader reader)
    {
        List<FOODITEM_MASTER> fOODITEM_MASTERs = new List<FOODITEM_MASTER>();

        while (reader.Read())
        {
            fOODITEM_MASTERs.Add(GetFOODITEM_MASTERFromReader(reader));
        }
        return fOODITEM_MASTERs;
    }

    public FOODITEM_MASTER GetFOODITEM_MASTERFromReader(IDataReader reader)
    {
        try
        {
            FOODITEM_MASTER fOODITEM_MASTER = new FOODITEM_MASTER
                (
                    (int)reader["FOODITEM_MASTERID"],
                    reader["ITEMCODE"].ToString(),
                    reader["ITEMNAME"].ToString(),
                    (decimal)reader["RATE"],
                    (int)reader["AGENTID"],
                    (int)reader["SEQ"]
                );
             return fOODITEM_MASTER;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public FOODITEM_MASTER GetFOODITEM_MASTERByID(int fOODITEM_MASTERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetFOODITEM_MASTERByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FOODITEM_MASTERID", SqlDbType.Int).Value = fOODITEM_MASTERID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetFOODITEM_MASTERFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertFOODITEM_MASTER(FOODITEM_MASTER fOODITEM_MASTER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertFOODITEM_MASTER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FOODITEM_MASTERID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ITEMCODE", SqlDbType.VarChar).Value = fOODITEM_MASTER.ITEMCODE;
            cmd.Parameters.Add("@ITEMNAME", SqlDbType.VarChar).Value = fOODITEM_MASTER.ITEMNAME;
            cmd.Parameters.Add("@RATE", SqlDbType.Decimal).Value = fOODITEM_MASTER.RATE;
            cmd.Parameters.Add("@AGENTID", SqlDbType.Int).Value = fOODITEM_MASTER.AGENTID;
            cmd.Parameters.Add("@SEQ", SqlDbType.Int).Value = fOODITEM_MASTER.SEQ;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@FOODITEM_MASTERID"].Value;
        }
    }

    public bool UpdateFOODITEM_MASTER(FOODITEM_MASTER fOODITEM_MASTER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateFOODITEM_MASTER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FOODITEM_MASTERID", SqlDbType.Int).Value = fOODITEM_MASTER.FOODITEM_MASTERID;
            cmd.Parameters.Add("@ITEMCODE", SqlDbType.VarChar).Value = fOODITEM_MASTER.ITEMCODE;
            cmd.Parameters.Add("@ITEMNAME", SqlDbType.VarChar).Value = fOODITEM_MASTER.ITEMNAME;
            cmd.Parameters.Add("@RATE", SqlDbType.Decimal).Value = fOODITEM_MASTER.RATE;
            cmd.Parameters.Add("@AGENTID", SqlDbType.Int).Value = fOODITEM_MASTER.AGENTID;
            cmd.Parameters.Add("@SEQ", SqlDbType.Int).Value = fOODITEM_MASTER.SEQ;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
