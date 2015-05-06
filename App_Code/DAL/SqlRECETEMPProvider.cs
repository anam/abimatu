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

public class SqlRECETEMPProvider:DataAccessObject
{
	public SqlRECETEMPProvider()
    {
    }


    public bool DeleteRECETEMP(int rECETEMPID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteRECETEMP", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RECETEMPID", SqlDbType.Int).Value = rECETEMPID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<RECETEMP> GetAllRECETEMPs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllRECETEMPs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetRECETEMPsFromReader(reader);
        }
    }
    public List<RECETEMP> GetRECETEMPsFromReader(IDataReader reader)
    {
        List<RECETEMP> rECETEMPs = new List<RECETEMP>();

        while (reader.Read())
        {
            rECETEMPs.Add(GetRECETEMPFromReader(reader));
        }
        return rECETEMPs;
    }

    public RECETEMP GetRECETEMPFromReader(IDataReader reader)
    {
        try
        {
            RECETEMP rECETEMP = new RECETEMP
                (
                    (int)reader["RECETEMPID"],
                    (int)reader["RECEID"]
                );
             return rECETEMP;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public RECETEMP GetRECETEMPByID(int rECETEMPID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetRECETEMPByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RECETEMPID", SqlDbType.Int).Value = rECETEMPID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetRECETEMPFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertRECETEMP(RECETEMP rECETEMP)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertRECETEMP", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RECETEMPID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RECEID", SqlDbType.Int).Value = rECETEMP.RECEID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RECETEMPID"].Value;
        }
    }

    public bool UpdateRECETEMP(RECETEMP rECETEMP)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateRECETEMP", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RECETEMPID", SqlDbType.Int).Value = rECETEMP.RECETEMPID;
            cmd.Parameters.Add("@RECEID", SqlDbType.Int).Value = rECETEMP.RECEID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
