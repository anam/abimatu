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

public class SqlVAULTTRANSProvider:DataAccessObject
{
	public SqlVAULTTRANSProvider()
    {
    }


    public bool DeleteVAULTTRANS(int vAULTTRANSID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteVAULTTRANS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VAULTTRANSID", SqlDbType.Int).Value = vAULTTRANSID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<VAULTTRANS> GetAllVAULTTRANSs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllVAULTTRANSs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetVAULTTRANSsFromReader(reader);
        }
    }
    public List<VAULTTRANS> GetVAULTTRANSsFromReader(IDataReader reader)
    {
        List<VAULTTRANS> vAULTTRANSs = new List<VAULTTRANS>();

        while (reader.Read())
        {
            vAULTTRANSs.Add(GetVAULTTRANSFromReader(reader));
        }
        return vAULTTRANSs;
    }

    public VAULTTRANS GetVAULTTRANSFromReader(IDataReader reader)
    {
        try
        {
            VAULTTRANS vAULTTRANS = new VAULTTRANS
                (
                    (int)reader["VAULTTRANSID"],
                    (DateTime)reader["DT"],
                    (int)reader["STATIONID"],
                    (int)reader["AMOUNT"]
                );
             return vAULTTRANS;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public VAULTTRANS GetVAULTTRANSByID(int vAULTTRANSID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetVAULTTRANSByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@VAULTTRANSID", SqlDbType.Int).Value = vAULTTRANSID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetVAULTTRANSFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertVAULTTRANS(VAULTTRANS vAULTTRANS)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertVAULTTRANS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VAULTTRANSID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DT", SqlDbType.DateTime).Value = vAULTTRANS.DT;
            cmd.Parameters.Add("@STATIONID", SqlDbType.Int).Value = vAULTTRANS.STATIONID;
            cmd.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = vAULTTRANS.AMOUNT;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@VAULTTRANSID"].Value;
        }
    }

    public bool UpdateVAULTTRANS(VAULTTRANS vAULTTRANS)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateVAULTTRANS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VAULTTRANSID", SqlDbType.Int).Value = vAULTTRANS.VAULTTRANSID;
            cmd.Parameters.Add("@DT", SqlDbType.DateTime).Value = vAULTTRANS.DT;
            cmd.Parameters.Add("@STATIONID", SqlDbType.Int).Value = vAULTTRANS.STATIONID;
            cmd.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = vAULTTRANS.AMOUNT;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
