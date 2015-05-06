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

public class SqlLOCATIONMAPPINGProvider:DataAccessObject
{
	public SqlLOCATIONMAPPINGProvider()
    {
    }


    public bool DeleteLOCATIONMAPPING(int lOCATIONMAPPINGID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteLOCATIONMAPPING", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LOCATIONMAPPINGID", SqlDbType.Int).Value = lOCATIONMAPPINGID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<LOCATIONMAPPING> GetAllLOCATIONMAPPINGs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATIONMAPPINGs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONMAPPINGsFromReader(reader);
        }
    }
    public List<LOCATIONMAPPING> GetLOCATIONMAPPINGsFromReader(IDataReader reader)
    {
        List<LOCATIONMAPPING> lOCATIONMAPPINGs = new List<LOCATIONMAPPING>();

        while (reader.Read())
        {
            lOCATIONMAPPINGs.Add(GetLOCATIONMAPPINGFromReader(reader));
        }
        return lOCATIONMAPPINGs;
    }

    public LOCATIONMAPPING GetLOCATIONMAPPINGFromReader(IDataReader reader)
    {
        try
        {
            LOCATIONMAPPING lOCATIONMAPPING = new LOCATIONMAPPING
                (
                    (int)reader["LOCATIONMAPPINGID"],
                    (DateTime)reader["ADDEDDATE"],
                    (int)reader["LOCATIONID"],
                    (int)reader["LOCATIONGROUPID"]
                );
             return lOCATIONMAPPING;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public LOCATIONMAPPING GetLOCATIONMAPPINGByID(int lOCATIONMAPPINGID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetLOCATIONMAPPINGByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LOCATIONMAPPINGID", SqlDbType.Int).Value = lOCATIONMAPPINGID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLOCATIONMAPPINGFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLOCATIONMAPPING(LOCATIONMAPPING lOCATIONMAPPING)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertLOCATIONMAPPING", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LOCATIONMAPPINGID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ADDEDDATE", SqlDbType.DateTime).Value = lOCATIONMAPPING.ADDEDDATE;
            cmd.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = lOCATIONMAPPING.LOCATIONID;
            cmd.Parameters.Add("@LOCATIONGROUPID", SqlDbType.Int).Value = lOCATIONMAPPING.LOCATIONGROUPID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LOCATIONMAPPINGID"].Value;
        }
    }

    public bool UpdateLOCATIONMAPPING(LOCATIONMAPPING lOCATIONMAPPING)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateLOCATIONMAPPING", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LOCATIONMAPPINGID", SqlDbType.Int).Value = lOCATIONMAPPING.LOCATIONMAPPINGID;
            cmd.Parameters.Add("@ADDEDDATE", SqlDbType.DateTime).Value = lOCATIONMAPPING.ADDEDDATE;
            cmd.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = lOCATIONMAPPING.LOCATIONID;
            cmd.Parameters.Add("@LOCATIONGROUPID", SqlDbType.Int).Value = lOCATIONMAPPING.LOCATIONGROUPID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public List<LOCATIONMAPPING> GetLOCATIONMAPPINGByLOCATIONID(int locationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetLOCATIONMAPPINGByLOCATIONID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LOCATIONID", SqlDbType.Int).Value = locationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONMAPPINGsFromReader(reader);
        }
    }

    public List<LOCATIONMAPPING> GetLOCATIONMAPPINGByLOCATIONGROUPID(int groupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetLOCATIONMAPPINGByLOCATIONGROUPID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LOCATIONGROUPID", SqlDbType.Int).Value = groupID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONMAPPINGsFromReader(reader);
        }
    }
}
