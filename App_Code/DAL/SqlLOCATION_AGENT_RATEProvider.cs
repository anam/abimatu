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

public class SqlLOCATION_AGENT_RATEProvider:DataAccessObject
{
	public SqlLOCATION_AGENT_RATEProvider()
    {
    }


    public bool DeleteLOCATION_AGENT_RATE(int lOCATION_AGENT_RATEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteLOCATION_AGENT_RATE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LOCATION_AGENT_RATEID", SqlDbType.Int).Value = lOCATION_AGENT_RATEID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<LOCATION_AGENT_RATE> GetAllLOCATION_AGENT_RATEs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATION_AGENT_RATEs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATION_AGENT_RATEsFromReader(reader);
        }
    }

    public List<LOCATION_AGENT_RATE> GetAllLOCATION_AGENT_RATEsByAGENTID(int agentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATION_AGENT_RATEByAGENTID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = agentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATION_AGENT_RATEsFromReader(reader);
        }
    }

    public List<LOCATION_AGENT_RATE> GetAllLOCATION_AGENT_RATEsByLOCATIONID(int locationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATION_AGENT_RATEByLOCATIONID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = locationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATION_AGENT_RATEsFromReader(reader);
        }
    }

    public List<LOCATION_AGENT_RATE> GetLOCATION_AGENT_RATEsFromReader(IDataReader reader)
    {
        List<LOCATION_AGENT_RATE> lOCATION_AGENT_RATEs = new List<LOCATION_AGENT_RATE>();

        while (reader.Read())
        {
            lOCATION_AGENT_RATEs.Add(GetLOCATION_AGENT_RATEFromReader(reader));
        }
        return lOCATION_AGENT_RATEs;
    }

    public LOCATION_AGENT_RATE GetLOCATION_AGENT_RATEFromReader(IDataReader reader)
    {
        try
        {
            LOCATION_AGENT_RATE lOCATION_AGENT_RATE = new LOCATION_AGENT_RATE
                (
                    (int)reader["LOCATION_AGENT_RATEID"],
                    (int)reader["LOCATIONID"],
                    (int)reader["AGENTID"],
                    (decimal)reader["RATE"],
                    reader["BRANCH"].ToString(),
                    reader["AGENTNAME"].ToString()
                );
             return lOCATION_AGENT_RATE;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public LOCATION_AGENT_RATE GetLOCATION_AGENT_RATEByID(int lOCATION_AGENT_RATEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetLOCATION_AGENT_RATEByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LOCATION_AGENT_RATEID", SqlDbType.Int).Value = lOCATION_AGENT_RATEID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLOCATION_AGENT_RATEFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLOCATION_AGENT_RATE(LOCATION_AGENT_RATE lOCATION_AGENT_RATE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertLOCATION_AGENT_RATE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LOCATION_AGENT_RATEID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = lOCATION_AGENT_RATE.LOCATIONID;
            cmd.Parameters.Add("@AGENTID", SqlDbType.Int).Value = lOCATION_AGENT_RATE.AGENTID;
            cmd.Parameters.Add("@RATE", SqlDbType.Decimal).Value = lOCATION_AGENT_RATE.RATE;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LOCATION_AGENT_RATEID"].Value;
        }
    }

    public bool UpdateLOCATION_AGENT_RATE(LOCATION_AGENT_RATE lOCATION_AGENT_RATE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateLOCATION_AGENT_RATE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LOCATION_AGENT_RATEID", SqlDbType.Int).Value = lOCATION_AGENT_RATE.LOCATION_AGENT_RATEID;
            cmd.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = lOCATION_AGENT_RATE.LOCATIONID;
            cmd.Parameters.Add("@AGENTID", SqlDbType.Int).Value = lOCATION_AGENT_RATE.AGENTID;
            cmd.Parameters.Add("@RATE", SqlDbType.Decimal).Value = lOCATION_AGENT_RATE.RATE;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
