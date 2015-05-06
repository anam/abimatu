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

public class SqlRATEProvider:DataAccessObject
{
	public SqlRATEProvider()
    {
    }


    public bool DeleteRATE(int rATEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteRATE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RATEID", SqlDbType.Int).Value = rATEID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<RATE> GetAllRATEs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllRATEs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetRATEsFromReader(reader);
        }
    }
    public List<RATE> GetRATEsFromReader(IDataReader reader)
    {
        List<RATE> rATEs = new List<RATE>();

        while (reader.Read())
        {
            rATEs.Add(GetRATEFromReader(reader));
        }
        return rATEs;
    }

    public RATE GetRATEFromReader(IDataReader reader)
    {
        try
        {
            RATE rATE = new RATE
                (
                    (int)reader["RATEID"],
                    (int)reader["MINAMT"],
                    (int)reader["MAXAMT"],
                    (int)reader["RATEVALUE"],
                    (int)reader["POINTS"],
                    (int)reader["POINTSVALUE"]
                );
             return rATE;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public RATE GetRATEByID(int rATEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetRATEByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RATEID", SqlDbType.Int).Value = rATEID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetRATEFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertRATE(RATE rATE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertRATE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RATEID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MINAMT", SqlDbType.Int).Value = rATE.MINAMT;
            cmd.Parameters.Add("@MAXAMT", SqlDbType.Int).Value = rATE.MAXAMT;
            cmd.Parameters.Add("@RATEVALUE", SqlDbType.Int).Value = rATE.RATEVALUE;
            cmd.Parameters.Add("@POINTS", SqlDbType.Int).Value = rATE.POINTS;
            cmd.Parameters.Add("@POINTSVALUE", SqlDbType.Int).Value = rATE.POINTSVALUE;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RATEID"].Value;
        }
    }

    public bool UpdateRATE(RATE rATE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateRATE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RATEID", SqlDbType.Int).Value = rATE.RATEID;
            cmd.Parameters.Add("@MINAMT", SqlDbType.Int).Value = rATE.MINAMT;
            cmd.Parameters.Add("@MAXAMT", SqlDbType.Int).Value = rATE.MAXAMT;
            cmd.Parameters.Add("@RATEVALUE", SqlDbType.Int).Value = rATE.RATEVALUE;
            cmd.Parameters.Add("@POINTS", SqlDbType.Int).Value = rATE.POINTS;
            cmd.Parameters.Add("@POINTSVALUE", SqlDbType.Int).Value = rATE.POINTSVALUE;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
