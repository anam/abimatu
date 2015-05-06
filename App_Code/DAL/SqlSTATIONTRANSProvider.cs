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

public class SqlSTATIONTRANSProvider:DataAccessObject
{
	public SqlSTATIONTRANSProvider()
    {
    }


    public bool DeleteSTATIONTRANS(int sTATIONTRANSID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteSTATIONTRANS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STATIONTRANSID", SqlDbType.Int).Value = sTATIONTRANSID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<STATIONTRANS> GetAllSTATIONTRANSs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllSTATIONTRANSs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSTATIONTRANSsFromReader(reader);
        }
    }
    public List<STATIONTRANS> GetSTATIONTRANSsFromReader(IDataReader reader)
    {
        List<STATIONTRANS> sTATIONTRANSs = new List<STATIONTRANS>();

        while (reader.Read())
        {
            sTATIONTRANSs.Add(GetSTATIONTRANSFromReader(reader));
        }
        return sTATIONTRANSs;
    }

    public STATIONTRANS GetSTATIONTRANSFromReader(IDataReader reader)
    {
        try
        {
            STATIONTRANS sTATIONTRANS = new STATIONTRANS
                (
                    (int)reader["STATIONTRANSID"],
                    (DateTime)reader["DT"],
                    reader["STATIONFROM"].ToString(),
                    reader["STATIONTO"].ToString(),
                    (int)reader["AMOUNT"],
                    (char)reader["ISACCEPTED"],
                    (int)reader["EMP_ID"],
                    (int)reader["SHIFT_ID"],
                    (int)reader["TRANSFER_EMP_ID"]
                );
             return sTATIONTRANS;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STATIONTRANS GetSTATIONTRANSByID(int sTATIONTRANSID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetSTATIONTRANSByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@STATIONTRANSID", SqlDbType.Int).Value = sTATIONTRANSID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetSTATIONTRANSFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSTATIONTRANS(STATIONTRANS sTATIONTRANS)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertSTATIONTRANS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STATIONTRANSID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DT", SqlDbType.DateTime).Value = sTATIONTRANS.DT;
            cmd.Parameters.Add("@STATIONFROM", SqlDbType.VarChar).Value = sTATIONTRANS.STATIONFROM;
            cmd.Parameters.Add("@STATIONTO", SqlDbType.VarChar).Value = sTATIONTRANS.STATIONTO;
            cmd.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = sTATIONTRANS.AMOUNT;
            cmd.Parameters.Add("@ISACCEPTED", SqlDbType.Char).Value = sTATIONTRANS.ISACCEPTED;
            cmd.Parameters.Add("@EMP_ID", SqlDbType.Int).Value = sTATIONTRANS.EMP_ID;
            cmd.Parameters.Add("@SHIFT_ID", SqlDbType.Int).Value = sTATIONTRANS.SHIFT_ID;
            cmd.Parameters.Add("@TRANSFER_EMP_ID", SqlDbType.Int).Value = sTATIONTRANS.TRANSFER_EMP_ID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@STATIONTRANSID"].Value;
        }
    }

    public bool UpdateSTATIONTRANS(STATIONTRANS sTATIONTRANS)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateSTATIONTRANS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STATIONTRANSID", SqlDbType.Int).Value = sTATIONTRANS.STATIONTRANSID;
            cmd.Parameters.Add("@DT", SqlDbType.DateTime).Value = sTATIONTRANS.DT;
            cmd.Parameters.Add("@STATIONFROM", SqlDbType.VarChar).Value = sTATIONTRANS.STATIONFROM;
            cmd.Parameters.Add("@STATIONTO", SqlDbType.VarChar).Value = sTATIONTRANS.STATIONTO;
            cmd.Parameters.Add("@AMOUNT", SqlDbType.Int).Value = sTATIONTRANS.AMOUNT;
            cmd.Parameters.Add("@ISACCEPTED", SqlDbType.Char).Value = sTATIONTRANS.ISACCEPTED;
            cmd.Parameters.Add("@EMP_ID", SqlDbType.Int).Value = sTATIONTRANS.EMP_ID;
            cmd.Parameters.Add("@SHIFT_ID", SqlDbType.Int).Value = sTATIONTRANS.SHIFT_ID;
            cmd.Parameters.Add("@TRANSFER_EMP_ID", SqlDbType.Int).Value = sTATIONTRANS.TRANSFER_EMP_ID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
