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

public class SqlFOODITEM_TRANSMASTERProvider:DataAccessObject
{
	public SqlFOODITEM_TRANSMASTERProvider()
    {
    }
    public DataTable GetAllFOODITEM_TRANSMASTERByREFCODEForReport(string referenceCode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllFOODITEM_TRANSMASTERByREFCODEForReport", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@REFCODE", SqlDbType.VarChar).Value = referenceCode;
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            return dt;
        }
    }

    public bool DeleteFOODITEM_TRANSMASTER(int fOODITEM_TRANSMASTERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteFOODITEM_TRANSMASTER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FOODITEM_TRANSMASTERID", SqlDbType.Int).Value = fOODITEM_TRANSMASTERID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<FOODITEM_TRANSMASTER> GetAllFOODITEM_TRANSMASTERs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllFOODITEM_TRANSMASTERs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetFOODITEM_TRANSMASTERsFromReader(reader);
        }
    }

    public List<FOODITEM_TRANSMASTER> GetAllFOODITEM_TRANSMASTERsForReport(string status, string locationIDs, int agentID, string fromDate, string toDate, int amount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllFoodTRANSsForLocationWiseReport", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = agentID;
            command.Parameters.Add("@FROMDATE", SqlDbType.DateTime).Value = DateTime.Parse(fromDate);
            command.Parameters.Add("@TODATE", SqlDbType.DateTime).Value = DateTime.Parse(toDate);
            command.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = amount;
            command.Parameters.Add("@LOCATIONIDs", SqlDbType.NVarChar).Value = locationIDs;
            command.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = status;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetFOODITEM_TRANSMASTERsForReportFromReader(reader);
        }
    }

    public List<FOODITEM_TRANSMASTER> GetFOODITEM_TRANSMASTERsForReportFromReader(IDataReader reader)
    {
        List<FOODITEM_TRANSMASTER> fOODITEM_TRANSMASTERs = new List<FOODITEM_TRANSMASTER>();

        while (reader.Read())
        {
            fOODITEM_TRANSMASTERs.Add(GetFOODITEM_TRANSMASTERForReportFromReader(reader));
        }
        return fOODITEM_TRANSMASTERs;
    }

    public FOODITEM_TRANSMASTER GetFOODITEM_TRANSMASTERForReportFromReader(IDataReader reader)
    {
        try
        {
            FOODITEM_TRANSMASTER fOODITEM_TRANSMASTER = new FOODITEM_TRANSMASTER
                (
                    (int)reader["FOODITEM_TRANSMASTERID"],
                    (DateTime)reader["TDATE"],
                    (int)reader["CID"],
                    (int)reader["LID"],
                    (int)reader["AID"],
                    (decimal)reader["TOTALAMT"],
                    reader["TRANSSTATUS"].ToString(),
                    reader["REFCODE"].ToString(),
                    (int)reader["RECID"],
                    (DateTime)reader["RECDATE"],
                    (int)reader["STOREID"],
                    (DateTime)reader["CREATEDON"],
                    (int)reader["CREATEDBY"],
                    (DateTime)reader["UPDATEDON"],
                    (int)reader["UPDATEDBY"],
                    reader["COUNTRY"].ToString(),
                    reader["CITY"].ToString(),
                    reader["BRANCH"].ToString(),
                    reader["BRANCH_CODE"].ToString(),
                    reader["CUSTOMERFULLNAME"].ToString(),
                    reader["RECEIVERFULLNAME"].ToString()
                );
            return fOODITEM_TRANSMASTER;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<FOODITEM_TRANSMASTER> GetFOODITEM_TRANSMASTERsFromReader(IDataReader reader)
    {
        List<FOODITEM_TRANSMASTER> fOODITEM_TRANSMASTERs = new List<FOODITEM_TRANSMASTER>();

        while (reader.Read())
        {
            fOODITEM_TRANSMASTERs.Add(GetFOODITEM_TRANSMASTERFromReader(reader));
        }
        return fOODITEM_TRANSMASTERs;
    }

    public FOODITEM_TRANSMASTER GetFOODITEM_TRANSMASTERFromReader(IDataReader reader)
    {
        try
        {
            FOODITEM_TRANSMASTER fOODITEM_TRANSMASTER = new FOODITEM_TRANSMASTER
                (
                    (int)reader["FOODITEM_TRANSMASTERID"],
                    (DateTime)reader["TDATE"],
                    (int)reader["CID"],
                    (int)reader["LID"],
                    (int)reader["AID"],
                    (decimal)reader["TOTALAMT"],
                    reader["TRANSSTATUS"].ToString(),
                    reader["REFCODE"].ToString(),
                    (int)reader["RECID"],
                    (DateTime)reader["RECDATE"],
                    (int)reader["STOREID"],
                    (DateTime)reader["CREATEDON"],
                    (int)reader["CREATEDBY"],
                    (DateTime)reader["UPDATEDON"],
                    (int)reader["UPDATEDBY"]
                );
             return fOODITEM_TRANSMASTER;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public FOODITEM_TRANSMASTER GetFOODITEM_TRANSMASTERByID(int fOODITEM_TRANSMASTERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetFOODITEM_TRANSMASTERByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FOODITEM_TRANSMASTERID", SqlDbType.Int).Value = fOODITEM_TRANSMASTERID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetFOODITEM_TRANSMASTERFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public FOODITEM_TRANSMASTER GetFOODITEM_TRANSMASTERByRefCode(string refCode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetFOODITEM_TRANSMASTERByRefCode", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@REFCODE", SqlDbType.VarChar).Value = refCode;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetFOODITEM_TRANSMASTERFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertFOODITEM_TRANSMASTER(FOODITEM_TRANSMASTER fOODITEM_TRANSMASTER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertFOODITEM_TRANSMASTER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FOODITEM_TRANSMASTERID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TDATE", SqlDbType.DateTime).Value = fOODITEM_TRANSMASTER.TDATE;
            cmd.Parameters.Add("@CID", SqlDbType.Int).Value = fOODITEM_TRANSMASTER.CID;
            cmd.Parameters.Add("@LID", SqlDbType.Int).Value = fOODITEM_TRANSMASTER.LID;
            cmd.Parameters.Add("@AID", SqlDbType.Int).Value = fOODITEM_TRANSMASTER.AID;
            cmd.Parameters.Add("@TOTALAMT", SqlDbType.Decimal).Value = fOODITEM_TRANSMASTER.TOTALAMT;
            cmd.Parameters.Add("@TRANSSTATUS", SqlDbType.VarChar).Value = fOODITEM_TRANSMASTER.TRANSSTATUS;
            cmd.Parameters.Add("@REFCODE", SqlDbType.VarChar).Value = fOODITEM_TRANSMASTER.REFCODE;
            cmd.Parameters.Add("@RECID", SqlDbType.Int).Value = fOODITEM_TRANSMASTER.RECID;
            cmd.Parameters.Add("@RECDATE", SqlDbType.DateTime).Value = fOODITEM_TRANSMASTER.RECDATE;
            cmd.Parameters.Add("@STOREID", SqlDbType.Int).Value = fOODITEM_TRANSMASTER.STOREID;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = fOODITEM_TRANSMASTER.CREATEDON;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = fOODITEM_TRANSMASTER.CREATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = fOODITEM_TRANSMASTER.UPDATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = fOODITEM_TRANSMASTER.UPDATEDBY;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@FOODITEM_TRANSMASTERID"].Value;
        }
    }

    public bool UpdateFOODITEM_TRANSMASTER(FOODITEM_TRANSMASTER fOODITEM_TRANSMASTER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateFOODITEM_TRANSMASTER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FOODITEM_TRANSMASTERID", SqlDbType.Int).Value = fOODITEM_TRANSMASTER.FOODITEM_TRANSMASTERID;
            cmd.Parameters.Add("@TDATE", SqlDbType.DateTime).Value = fOODITEM_TRANSMASTER.TDATE;
            cmd.Parameters.Add("@CID", SqlDbType.Int).Value = fOODITEM_TRANSMASTER.CID;
            cmd.Parameters.Add("@LID", SqlDbType.Int).Value = fOODITEM_TRANSMASTER.LID;
            cmd.Parameters.Add("@AID", SqlDbType.Int).Value = fOODITEM_TRANSMASTER.AID;
            cmd.Parameters.Add("@TOTALAMT", SqlDbType.Decimal).Value = fOODITEM_TRANSMASTER.TOTALAMT;
            cmd.Parameters.Add("@TRANSSTATUS", SqlDbType.VarChar).Value = fOODITEM_TRANSMASTER.TRANSSTATUS;
            cmd.Parameters.Add("@REFCODE", SqlDbType.VarChar).Value = fOODITEM_TRANSMASTER.REFCODE;
            cmd.Parameters.Add("@RECID", SqlDbType.Int).Value = fOODITEM_TRANSMASTER.RECID;
            cmd.Parameters.Add("@RECDATE", SqlDbType.DateTime).Value = fOODITEM_TRANSMASTER.RECDATE;
            cmd.Parameters.Add("@STOREID", SqlDbType.Int).Value = fOODITEM_TRANSMASTER.STOREID;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = fOODITEM_TRANSMASTER.CREATEDON;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = fOODITEM_TRANSMASTER.CREATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = fOODITEM_TRANSMASTER.UPDATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = fOODITEM_TRANSMASTER.UPDATEDBY;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataTable GetAllFoodTransForLocationWiseForReport(string status, string locationIDs, int agentID, string fromDate, string toDate, int amount)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllFoodTRANSsForLocationWiseReport", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AGENTID", SqlDbType.Int).Value = agentID;
            command.Parameters.Add("@FROMDATE", SqlDbType.DateTime).Value = DateTime.Parse(fromDate);
            command.Parameters.Add("@TODATE", SqlDbType.DateTime).Value = DateTime.Parse(toDate);
            command.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = amount;
            command.Parameters.Add("@LOCATIONIDs", SqlDbType.NVarChar).Value = locationIDs;
            command.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = status;

            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            return dt;
        }
    }
}
