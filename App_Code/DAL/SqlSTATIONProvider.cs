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

public class SqlSTATIONProvider:DataAccessObject
{
	public SqlSTATIONProvider()
    {
    }


    public bool DeleteSTATION(int sTATIONID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteSTATION", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STATIONID", SqlDbType.Int).Value = sTATIONID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<STATION> GetAllSTATIONs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllSTATIONs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSTATIONsFromReader(reader);
        }
    }
    public List<STATION> GetSTATIONsFromReader(IDataReader reader)
    {
        List<STATION> sTATIONs = new List<STATION>();

        while (reader.Read())
        {
            sTATIONs.Add(GetSTATIONFromReader(reader));
        }
        return sTATIONs;
    }

    public STATION GetSTATIONFromReader(IDataReader reader)
    {
        try
        {
            STATION sTATION = new STATION
                (
                    (int)reader["STATIONID"],
                    reader["STATIONNAME"].ToString(),
                    reader["STATIONLOCATION"].ToString()
                );
             return sTATION;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STATION GetSTATIONByID(int sTATIONID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetSTATIONByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@STATIONID", SqlDbType.Int).Value = sTATIONID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetSTATIONFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSTATION(STATION sTATION)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertSTATION", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STATIONID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@STATIONNAME", SqlDbType.VarChar).Value = sTATION.STATIONNAME;
            cmd.Parameters.Add("@STATIONLOCATION", SqlDbType.VarChar).Value = sTATION.STATIONLOCATION;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@STATIONID"].Value;
        }
    }

    public bool UpdateSTATION(STATION sTATION)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateSTATION", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STATIONID", SqlDbType.Int).Value = sTATION.STATIONID;
            cmd.Parameters.Add("@STATIONNAME", SqlDbType.VarChar).Value = sTATION.STATIONNAME;
            cmd.Parameters.Add("@STATIONLOCATION", SqlDbType.VarChar).Value = sTATION.STATIONLOCATION;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
