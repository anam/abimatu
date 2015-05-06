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

public class SqlWUABOVE3000Provider:DataAccessObject
{
	public SqlWUABOVE3000Provider()
    {
    }


    public bool DeleteWUABOVE3000(int wUABOVE3000ID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteWUABOVE3000", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WUABOVE3000ID", SqlDbType.Int).Value = wUABOVE3000ID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<WUABOVE3000> GetAllWUABOVE3000s()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllWUABOVE3000s", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetWUABOVE3000sFromReader(reader);
        }
    }
    public List<WUABOVE3000> GetWUABOVE3000sFromReader(IDataReader reader)
    {
        List<WUABOVE3000> wUABOVE3000s = new List<WUABOVE3000>();

        while (reader.Read())
        {
            wUABOVE3000s.Add(GetWUABOVE3000FromReader(reader));
        }
        return wUABOVE3000s;
    }

    public WUABOVE3000 GetWUABOVE3000FromReader(IDataReader reader)
    {
        try
        {
            WUABOVE3000 wUABOVE3000 = new WUABOVE3000
                (
                    (int)reader["WUABOVE3000ID"],
                    (DateTime)reader["DT"],
                    reader["CUST_ID"].ToString(),
                    reader["SENDERNAME"].ToString(),
                    reader["SENDERADDRESS"].ToString(),
                    reader["SENDERCITY"].ToString(),
                    (char)reader["SENDERSTATE"],
                    reader["SENDERZIP"].ToString(),
                    (int)reader["AMOUNT"],
                    reader["MTCN"].ToString(),
                    (int)reader["EMP_ID"],
                    (int)reader["STATION_ID"],
                    (int)reader["SHIFT_ID"]
                );
             return wUABOVE3000;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public WUABOVE3000 GetWUABOVE3000ByID(int wUABOVE3000ID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetWUABOVE3000ByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@WUABOVE3000ID", SqlDbType.Int).Value = wUABOVE3000ID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetWUABOVE3000FromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertWUABOVE3000(WUABOVE3000 wUABOVE3000)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertWUABOVE3000", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WUABOVE3000ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DT", SqlDbType.DateTime).Value = wUABOVE3000.DT;
            cmd.Parameters.Add("@CUST_ID", SqlDbType.VarChar).Value = wUABOVE3000.CUST_ID;
            cmd.Parameters.Add("@SENDERNAME", SqlDbType.VarChar).Value = wUABOVE3000.SENDERNAME;
            cmd.Parameters.Add("@SENDERADDRESS", SqlDbType.VarChar).Value = wUABOVE3000.SENDERADDRESS;
            cmd.Parameters.Add("@SENDERCITY", SqlDbType.VarChar).Value = wUABOVE3000.SENDERCITY;
            cmd.Parameters.Add("@SENDERSTATE", SqlDbType.Char).Value = wUABOVE3000.SENDERSTATE;
            cmd.Parameters.Add("@SENDERZIP", SqlDbType.VarChar).Value = wUABOVE3000.SENDERZIP;
            cmd.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = wUABOVE3000.AMOUNT;
            cmd.Parameters.Add("@MTCN", SqlDbType.VarChar).Value = wUABOVE3000.MTCN;
            cmd.Parameters.Add("@EMP_ID", SqlDbType.Int).Value = wUABOVE3000.EMP_ID;
            cmd.Parameters.Add("@STATION_ID", SqlDbType.Int).Value = wUABOVE3000.STATION_ID;
            cmd.Parameters.Add("@SHIFT_ID", SqlDbType.Int).Value = wUABOVE3000.SHIFT_ID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@WUABOVE3000ID"].Value;
        }
    }

    public bool UpdateWUABOVE3000(WUABOVE3000 wUABOVE3000)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateWUABOVE3000", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WUABOVE3000ID", SqlDbType.Int).Value = wUABOVE3000.WUABOVE3000ID;
            cmd.Parameters.Add("@DT", SqlDbType.DateTime).Value = wUABOVE3000.DT;
            cmd.Parameters.Add("@CUST_ID", SqlDbType.VarChar).Value = wUABOVE3000.CUST_ID;
            cmd.Parameters.Add("@SENDERNAME", SqlDbType.VarChar).Value = wUABOVE3000.SENDERNAME;
            cmd.Parameters.Add("@SENDERADDRESS", SqlDbType.VarChar).Value = wUABOVE3000.SENDERADDRESS;
            cmd.Parameters.Add("@SENDERCITY", SqlDbType.VarChar).Value = wUABOVE3000.SENDERCITY;
            cmd.Parameters.Add("@SENDERSTATE", SqlDbType.Char).Value = wUABOVE3000.SENDERSTATE;
            cmd.Parameters.Add("@SENDERZIP", SqlDbType.VarChar).Value = wUABOVE3000.SENDERZIP;
            cmd.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = wUABOVE3000.AMOUNT;
            cmd.Parameters.Add("@MTCN", SqlDbType.VarChar).Value = wUABOVE3000.MTCN;
            cmd.Parameters.Add("@EMP_ID", SqlDbType.Int).Value = wUABOVE3000.EMP_ID;
            cmd.Parameters.Add("@STATION_ID", SqlDbType.Int).Value = wUABOVE3000.STATION_ID;
            cmd.Parameters.Add("@SHIFT_ID", SqlDbType.Int).Value = wUABOVE3000.SHIFT_ID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
