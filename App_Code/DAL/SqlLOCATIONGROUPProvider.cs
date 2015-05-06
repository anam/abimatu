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

public class SqlLOCATIONGROUPProvider:DataAccessObject
{
	public SqlLOCATIONGROUPProvider()
    {
    }


    public bool DeleteLOCATIONGROUP(int lOCATIONGROUPID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteLOCATIONGROUP", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LOCATIONGROUPID", SqlDbType.Int).Value = lOCATIONGROUPID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<LOCATIONGROUP> GetAllLOCATIONGROUPs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATIONGROUPs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONGROUPsFromReader(reader);
        }
    }

    public List<LOCATIONGROUP> GetAllLOCATIONGROUPsFood()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllLOCATIONGROUPsFood", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLOCATIONGROUPsFromReader(reader);
        }
    }

    public List<LOCATIONGROUP> GetLOCATIONGROUPsFromReader(IDataReader reader)
    {
        List<LOCATIONGROUP> lOCATIONGROUPs = new List<LOCATIONGROUP>();

        while (reader.Read())
        {
            lOCATIONGROUPs.Add(GetLOCATIONGROUPFromReader(reader));
        }
        return lOCATIONGROUPs;
    }

    public LOCATIONGROUP GetLOCATIONGROUPFromReader(IDataReader reader)
    {
        try
        {
            LOCATIONGROUP lOCATIONGROUP = new LOCATIONGROUP
                (
                    (int)reader["LOCATIONGROUPID"],
                    (DateTime)reader["ADDEDDATE"],
                    reader["GROUPNAME"].ToString()
                );
             return lOCATIONGROUP;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public LOCATIONGROUP GetLOCATIONGROUPByID(int lOCATIONGROUPID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetLOCATIONGROUPByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LOCATIONGROUPID", SqlDbType.Int).Value = lOCATIONGROUPID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLOCATIONGROUPFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLOCATIONGROUP(LOCATIONGROUP lOCATIONGROUP)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertLOCATIONGROUP", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LOCATIONGROUPID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ADDEDDATE", SqlDbType.DateTime).Value = lOCATIONGROUP.ADDEDDATE;
            cmd.Parameters.Add("@GROUPNAME", SqlDbType.NVarChar).Value = lOCATIONGROUP.GROUPNAME;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LOCATIONGROUPID"].Value;
        }
    }

    public bool UpdateLOCATIONGROUP(LOCATIONGROUP lOCATIONGROUP)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateLOCATIONGROUP", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LOCATIONGROUPID", SqlDbType.Int).Value = lOCATIONGROUP.LOCATIONGROUPID;
            cmd.Parameters.Add("@ADDEDDATE", SqlDbType.DateTime).Value = lOCATIONGROUP.ADDEDDATE;
            cmd.Parameters.Add("@GROUPNAME", SqlDbType.NVarChar).Value = lOCATIONGROUP.GROUPNAME;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
