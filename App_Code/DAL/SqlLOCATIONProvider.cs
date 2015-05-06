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

public class SqlLOCATIONProvider : DataAccessObject
{
    public SqlLOCATIONProvider()
    {
    }


    public bool DeleteLOCATION(int lOCATIONID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteLOCATION", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = lOCATIONID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public List<LOCATION> GetAllLOCATIONs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATIONs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONsFromReader(reader);
        }
    }

    public List<LOCATION> GetAllLOCATIONsFood()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATIONsFood", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONsFromReader(reader);
        }
    }


    public List<LOCATION> GetAllLOCATIONsNotInGroup()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATIONsNotInGroup", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONsFromReader(reader);
        }
    }

    public DataTable GetAllLOCATIONsForReport()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATIONs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            command.ExecuteNonQuery();
            connection.Close();
            return dt;

        }
    }

    public List<LOCATION> GetAllLOCATIONsByAgentID(int agentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATIONByAgentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = agentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONsFromReader(reader);
        }
    }

    public List<LOCATION> GetAllLOCATIONsByAgentIDnGroupID(int agentID, int groupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATIONByAgentIDnGroupID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = agentID;
            command.Parameters.Add("@GroupID", SqlDbType.Int).Value = groupID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONsFromReader(reader);
        }
    }


    public List<LOCATION> GetAllLOCATIONsByGroupID(int groupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATIONByGroupID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@GroupID", SqlDbType.Int).Value = groupID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONsFromReader(reader);
        }
    }

    public List<LOCATION> GetAllLOCATIONsNotInGroupByGroupID(int groupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATION_NotInGroupByGroupID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@GroupID", SqlDbType.Int).Value = groupID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONsFromReader(reader);
        }
    }

    public List<LOCATION> GetAllLOCATIONsForSearchByID(int lOCATIONID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATIONForSearchByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = lOCATIONID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONsFromReader(reader);
        }
    }

    public List<LOCATION> GetAllLOCATIONsCountry()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATIONsCountry", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONsFromReader(reader);
        }
    }

    public List<LOCATION> GetAllLOCATIONsForSearch(int agentID, string country, string city, string branch)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLocationForSearch", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = country;
            command.Parameters.Add("@CITY", SqlDbType.VarChar).Value = city;
            command.Parameters.Add("@BRANCH", SqlDbType.VarChar).Value = branch;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = agentID;

            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONsFromReader(reader);
        }
    }

    public List<LOCATION> GetAllLOCATIONsByDatenAmount(int agentID, string fromDate, string toDate, int amount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbuMatu_GetAllLOCATIONForReportByDatenAmount", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = agentID;
            command.Parameters.Add("@FROMDATE", SqlDbType.DateTime).Value = DateTime.Parse(fromDate);
            command.Parameters.Add("@TODATE", SqlDbType.DateTime).Value = DateTime.Parse(toDate);;
            command.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = amount;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONsFromReader(reader);
        }
    }

    public List<LOCATION> GetAllLOCATIONsByDatenAmountLocationIDs(string locationIDs, int agentID, string fromDate, string toDate, int amount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbuMatu_GetAllLOCATIONForReportByDatenAmountLocationIDs", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = agentID;
            command.Parameters.Add("@FROMDATE", SqlDbType.DateTime).Value = DateTime.Parse(fromDate);
            command.Parameters.Add("@TODATE", SqlDbType.DateTime).Value = DateTime.Parse(toDate);;
            command.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = amount;
            command.Parameters.Add("@LOCATIONIDs", SqlDbType.NVarChar).Value = locationIDs;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONsFromReader(reader);
        }
    }

    public List<LOCATION> GetAllLOCATIONsByDatenAmountLocationIDsStatus(string status, string locationIDs, int agentID, string fromDate, string toDate, int amount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbuMatu_GetAllLOCATIONForReportByDatenAmountLocationIDsStatus", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = agentID;
            command.Parameters.Add("@FROMDATE", SqlDbType.DateTime).Value = DateTime.Parse(fromDate);
            command.Parameters.Add("@TODATE", SqlDbType.DateTime).Value = DateTime.Parse(toDate);;
            command.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = amount;
            command.Parameters.Add("@LOCATIONIDs", SqlDbType.NVarChar).Value = locationIDs;
            command.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = status;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONsFromReader(reader);
        }
    }

    public List<LOCATION> GetAllLOCATIONsForReportByDatenAmountCustomerIDs(string customerIDs, string receiverIDs, int agentID, string fromDate, string toDate, int amount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbuMatu_GetAllLOCATIONForReportByDatenAmountCustomers", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = agentID;
            command.Parameters.Add("@FROMDATE", SqlDbType.DateTime).Value = DateTime.Parse(fromDate);
            command.Parameters.Add("@TODATE", SqlDbType.DateTime).Value = DateTime.Parse(toDate);;
            command.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = amount;
            command.Parameters.Add("@CUSIDs", SqlDbType.NVarChar).Value = customerIDs;
            command.Parameters.Add("@RECEIVERIDs", SqlDbType.NVarChar).Value = receiverIDs;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONsFromReader(reader);
        }
    }


    public List<LOCATION> GetLOCATIONsFromReader(IDataReader reader)
    {
        List<LOCATION> lOCATIONs = new List<LOCATION>();

        while (reader.Read())
        {
            lOCATIONs.Add(GetLOCATIONFromReader(reader));
        }
        return lOCATIONs;
    }

    public LOCATION GetLOCATIONFromReader(IDataReader reader)
    {
        try
        {
            LOCATION lOCATION = new LOCATION
                (
                    (int)reader["LOCATIONID"],
                    reader["COUNTRY"].ToString(),
                    reader["CITY"].ToString(),
                    reader["BRANCH"].ToString(),
                    reader["BRANCH_CODE"].ToString(),
                    (int)reader["SEQUENCE"],
                    (int)reader["AGENTID"],
                    (decimal)reader["AGENTRATE"]
                );
            return lOCATION;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public LOCATION GetLOCATIONFromReaderByRate(IDataReader reader)
    {
        try
        {
            LOCATION lOCATION = new LOCATION
                (
                    (int)reader["LOCATIONID"],
                    reader["COUNTRY"].ToString(),
                    reader["CITY"].ToString(),
                    reader["BRANCH"].ToString(),
                    reader["BRANCH_CODE"].ToString(),
                    (int)reader["SEQUENCE"],
                    (int)reader["AGENTID"],
                    (decimal)reader["AGENTRATE"]
                );
            return lOCATION;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public LOCATION GetLOCATIONByID(int lOCATIONID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetLOCATIONByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = lOCATIONID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLOCATIONFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public LOCATION GetLOCATIONByIDByAGNETID(int lOCATIONID, int aGENTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetLOCATIONByIDByAGENTID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = lOCATIONID;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = aGENTID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLOCATIONFromReaderByRate(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLOCATION(LOCATION lOCATION)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertLOCATION", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LOCATIONID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = lOCATION.COUNTRY;
            cmd.Parameters.Add("@CITY", SqlDbType.VarChar).Value = lOCATION.CITY;
            cmd.Parameters.Add("@BRANCH", SqlDbType.VarChar).Value = lOCATION.BRANCH;
            cmd.Parameters.Add("@BRANCH_CODE", SqlDbType.VarChar).Value = lOCATION.BRANCH_CODE;
            cmd.Parameters.Add("@SEQUENCE", SqlDbType.Int).Value = lOCATION.SEQUENCE;
            cmd.Parameters.Add("@AGENTID", SqlDbType.Int).Value = lOCATION.AGENTID;
            cmd.Parameters.Add("@AGENTRATE", SqlDbType.Int).Value = lOCATION.AGENTRATE;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LOCATIONID"].Value;
        }
    }

    public bool UpdateLOCATION(LOCATION lOCATION)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateLOCATION", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = lOCATION.LOCATIONID;
            cmd.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = lOCATION.COUNTRY;
            cmd.Parameters.Add("@CITY", SqlDbType.VarChar).Value = lOCATION.CITY;
            cmd.Parameters.Add("@BRANCH", SqlDbType.VarChar).Value = lOCATION.BRANCH;
            cmd.Parameters.Add("@BRANCH_CODE", SqlDbType.VarChar).Value = lOCATION.BRANCH_CODE;
            cmd.Parameters.Add("@SEQUENCE", SqlDbType.Int).Value = lOCATION.SEQUENCE;
            cmd.Parameters.Add("@AGENTID", SqlDbType.Int).Value = lOCATION.AGENTID;
            cmd.Parameters.Add("@AGENTRATE", SqlDbType.Int).Value = lOCATION.AGENTRATE;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
