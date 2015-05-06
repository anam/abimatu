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

public class SqlAGENTProvider:DataAccessObject
{
	public SqlAGENTProvider()
    {
    }


    public bool DeleteAGENT(int aGENTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteAGENT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AGENTID", SqlDbType.Int).Value = aGENTID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
   
    public List<AGENT> GetAllAGENTs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllAGENTs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAGENTsFromReader(reader);
        }
    }

    public List<AGENT> GetAllAGENTsForSearchByID(int agentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllAGENTsForSearchByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = agentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAGENTsFromReader(reader);
        }
    }

    public List<AGENT> GetAllAGENTsForReport()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbuMatu_GetAllUserInfosForReport", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAGENTsFromReader(reader);
        }
    }


    public List<AGENT> GetAllAGENTsForReportByDatenAmount(string fromDate, string toDate, int amount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbuMatu_GetAllUserInfosForReportByDatenAmount", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FROMDATE", SqlDbType.DateTime).Value = DateTime.Parse(fromDate);
            command.Parameters.Add("@TODATE", SqlDbType.DateTime).Value = DateTime.Parse(toDate);;
            command.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = amount;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAGENTsFromReader(reader);
        }
    }

    public List<AGENT> GetAllAGENTsForReportByDatenAmountnLocationIDs(string locationIDs, string fromDate, string toDate, int amount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbuMatu_GetAllAgentsForReportByDatenAmountnLocationIDs", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FROMDATE", SqlDbType.DateTime).Value = DateTime.Parse(fromDate);
            command.Parameters.Add("@TODATE", SqlDbType.DateTime).Value = DateTime.Parse(toDate);;
            command.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = amount;
            command.Parameters.Add("@LOCATIONIDS", SqlDbType.NVarChar).Value = locationIDs;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAGENTsFromReader(reader);
        }
    }

    public List<AGENT> GetAGENTsFromReader(IDataReader reader)
    {
        List<AGENT> aGENTs = new List<AGENT>();

        while (reader.Read())
        {
            aGENTs.Add(GetAGENTFromReader(reader));
        }
        return aGENTs;
    }

    public AGENT GetAGENTFromReader(IDataReader reader)
    {
        DateTime nullDate = DateTime.Parse(ConfigurationManager.AppSettings["NULL_DATE"].ToString());
        try
        {
            AGENT aGENT = new AGENT
                (
                    reader["AGENTID"] != DBNull.Value? (int)reader["AGENTID"]:0,
                    reader["AGENTNAME"] != DBNull.Value? reader["AGENTNAME"].ToString(): "",
                    reader["USERNAME"] != DBNull.Value? reader["USERNAME"].ToString(): "",
                    reader["AGENTLOCATION"] != DBNull.Value? reader["AGENTLOCATION"].ToString(): "",
                    reader["AGENTADDRESS"] != DBNull.Value? reader["AGENTADDRESS"].ToString(): "",
                    reader["AGENTCITY"] != DBNull.Value? reader["AGENTCITY"].ToString(): "",
                    reader["AGENTSTATE"] != DBNull.Value? reader["AGENTSTATE"].ToString(): "",
                    reader["AGENTZIP"] != DBNull.Value? reader["AGENTZIP"].ToString(): "",
                    reader["AGENTPHONE"] != DBNull.Value? reader["AGENTPHONE"].ToString(): "",
                    reader["AGENTACC"] != DBNull.Value? reader["AGENTACC"].ToString(): "",
                    reader["CREATEDBY"] != DBNull.Value? (int)reader["CREATEDBY"]:0,
                    reader["CREATEDON"] != DBNull.Value? (DateTime)reader["CREATEDON"]: nullDate,
                    reader["UPDATEDBY"] != DBNull.Value? (int)reader["UPDATEDBY"]:0,
                    reader["UPDATEDON"] != DBNull.Value? (DateTime)reader["UPDATEDON"]: nullDate
                );
             return aGENT;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public AGENT GetAGENTByID(int aGENTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAGENTByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = aGENTID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetAGENTFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public AGENT GetAGENTByUserName(string userName)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAGENTByUserName", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = userName;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetAGENTFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }
    public int InsertAGENT(AGENT aGENT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertAGENT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AGENTID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AGENTNAME", SqlDbType.VarChar).Value = aGENT.AGENTNAME;
            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = aGENT.USERNAME;
            cmd.Parameters.Add("@AGENTLOCATION", SqlDbType.VarChar).Value = aGENT.AGENTLOCATION;
            cmd.Parameters.Add("@AGENTADDRESS", SqlDbType.VarChar).Value = aGENT.AGENTADDRESS;
            cmd.Parameters.Add("@AGENTCITY", SqlDbType.VarChar).Value = aGENT.AGENTCITY;
            cmd.Parameters.Add("@AGENTSTATE", SqlDbType.VarChar).Value = aGENT.AGENTSTATE;
            cmd.Parameters.Add("@AGENTZIP", SqlDbType.VarChar).Value = aGENT.AGENTZIP;
            cmd.Parameters.Add("@AGENTPHONE", SqlDbType.VarChar).Value = aGENT.AGENTPHONE;
            cmd.Parameters.Add("@AGENTACC", SqlDbType.VarChar).Value = aGENT.AGENTACC;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = aGENT.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = aGENT.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = aGENT.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = aGENT.UPDATEDON;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AGENTID"].Value;
        }
    }

    public bool UpdateAGENT(AGENT aGENT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateAGENT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AGENTID", SqlDbType.Int).Value = aGENT.AGENTID;
            cmd.Parameters.Add("@AGENTNAME", SqlDbType.VarChar).Value = aGENT.AGENTNAME;
            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = aGENT.USERNAME;
            cmd.Parameters.Add("@AGENTLOCATION", SqlDbType.VarChar).Value = aGENT.AGENTLOCATION;
            cmd.Parameters.Add("@AGENTADDRESS", SqlDbType.VarChar).Value = aGENT.AGENTADDRESS;
            cmd.Parameters.Add("@AGENTCITY", SqlDbType.VarChar).Value = aGENT.AGENTCITY;
            cmd.Parameters.Add("@AGENTSTATE", SqlDbType.VarChar).Value = aGENT.AGENTSTATE;
            cmd.Parameters.Add("@AGENTZIP", SqlDbType.VarChar).Value = aGENT.AGENTZIP;
            cmd.Parameters.Add("@AGENTPHONE", SqlDbType.VarChar).Value = aGENT.AGENTPHONE;
            cmd.Parameters.Add("@AGENTACC", SqlDbType.VarChar).Value = aGENT.AGENTACC;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = aGENT.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = aGENT.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = aGENT.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = aGENT.UPDATEDON;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
