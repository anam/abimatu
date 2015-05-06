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

public class SqlGTRANSProvider:DataAccessObject
{
	public SqlGTRANSProvider()
    {
    }


    public bool DeleteGTRANS(int gTRANSID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteGTRANS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GTRANSID", SqlDbType.Int).Value = gTRANSID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<GTRANS> GetAllGTRANSs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllGTRANSs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetGTRANSsFromReader(reader);
        }
    }
    public List<GTRANS> GetGTRANSsFromReader(IDataReader reader)
    {
        List<GTRANS> gTRANSs = new List<GTRANS>();

        while (reader.Read())
        {
            gTRANSs.Add(GetGTRANSFromReader(reader));
        }
        return gTRANSs;
    }

    public GTRANS GetGTRANSFromReader(IDataReader reader)
    {
        try
        {
            GTRANS gTRANS = new GTRANS
                (
                    (int)reader["GTRANSID"],
                    reader["UTILITYID"].ToString(),
                    reader["CUSTID"].ToString(),
                    reader["STOREID"].ToString(),
                    reader["LOCATIONID"].ToString(),
                    (DateTime)reader["TRANSDATE"],
                    reader["TRANSACC"].ToString(),
                    (int)reader["TRANSAMT"],
                    (int)reader["TRANSFEES"],
                    (int)reader["TRANSCASH"],
                    (int)reader["TRANSCHECK"],
                    reader["AUTHCODE"].ToString(),
                    reader["EMPID"].ToString(),
                    reader["STATIONID"].ToString(),
                    reader["SHIFTID"].ToString(),
                    (char)reader["VOIDFLAG"],
                    reader["VOIDAUTHORIZATION"].ToString()
                );
             return gTRANS;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public GTRANS GetGTRANSByID(int gTRANSID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetGTRANSByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@GTRANSID", SqlDbType.Int).Value = gTRANSID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetGTRANSFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertGTRANS(GTRANS gTRANS)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertGTRANS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GTRANSID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@UTILITYID", SqlDbType.VarChar).Value = gTRANS.UTILITYID;
            cmd.Parameters.Add("@CUSTID", SqlDbType.VarChar).Value = gTRANS.CUSTID;
            cmd.Parameters.Add("@STOREID", SqlDbType.VarChar).Value = gTRANS.STOREID;
            cmd.Parameters.Add("@LOCATIONID", SqlDbType.VarChar).Value = gTRANS.LOCATIONID;
            cmd.Parameters.Add("@TRANSDATE", SqlDbType.DateTime).Value = gTRANS.TRANSDATE;
            cmd.Parameters.Add("@TRANSACC", SqlDbType.VarChar).Value = gTRANS.TRANSACC;
            cmd.Parameters.Add("@TRANSAMT", SqlDbType.Int).Value = gTRANS.TRANSAMT;
            cmd.Parameters.Add("@TRANSFEES", SqlDbType.Int).Value = gTRANS.TRANSFEES;
            cmd.Parameters.Add("@TRANSCASH", SqlDbType.Int).Value = gTRANS.TRANSCASH;
            cmd.Parameters.Add("@TRANSCHECK", SqlDbType.Int).Value = gTRANS.TRANSCHECK;
            cmd.Parameters.Add("@AUTHCODE", SqlDbType.VarChar).Value = gTRANS.AUTHCODE;
            cmd.Parameters.Add("@EMPID", SqlDbType.VarChar).Value = gTRANS.EMPID;
            cmd.Parameters.Add("@STATIONID", SqlDbType.VarChar).Value = gTRANS.STATIONID;
            cmd.Parameters.Add("@SHIFTID", SqlDbType.VarChar).Value = gTRANS.SHIFTID;
            cmd.Parameters.Add("@VOIDFLAG", SqlDbType.Char).Value = gTRANS.VOIDFLAG;
            cmd.Parameters.Add("@VOIDAUTHORIZATION", SqlDbType.VarChar).Value = gTRANS.VOIDAUTHORIZATION;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@GTRANSID"].Value;
        }
    }

    public bool UpdateGTRANS(GTRANS gTRANS)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateGTRANS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GTRANSID", SqlDbType.Int).Value = gTRANS.GTRANSID;
            cmd.Parameters.Add("@UTILITYID", SqlDbType.VarChar).Value = gTRANS.UTILITYID;
            cmd.Parameters.Add("@CUSTID", SqlDbType.VarChar).Value = gTRANS.CUSTID;
            cmd.Parameters.Add("@STOREID", SqlDbType.VarChar).Value = gTRANS.STOREID;
            cmd.Parameters.Add("@LOCATIONID", SqlDbType.VarChar).Value = gTRANS.LOCATIONID;
            cmd.Parameters.Add("@TRANSDATE", SqlDbType.DateTime).Value = gTRANS.TRANSDATE;
            cmd.Parameters.Add("@TRANSACC", SqlDbType.VarChar).Value = gTRANS.TRANSACC;
            cmd.Parameters.Add("@TRANSAMT", SqlDbType.Int).Value = gTRANS.TRANSAMT;
            cmd.Parameters.Add("@TRANSFEES", SqlDbType.Int).Value = gTRANS.TRANSFEES;
            cmd.Parameters.Add("@TRANSCASH", SqlDbType.Int).Value = gTRANS.TRANSCASH;
            cmd.Parameters.Add("@TRANSCHECK", SqlDbType.Int).Value = gTRANS.TRANSCHECK;
            cmd.Parameters.Add("@AUTHCODE", SqlDbType.VarChar).Value = gTRANS.AUTHCODE;
            cmd.Parameters.Add("@EMPID", SqlDbType.VarChar).Value = gTRANS.EMPID;
            cmd.Parameters.Add("@STATIONID", SqlDbType.VarChar).Value = gTRANS.STATIONID;
            cmd.Parameters.Add("@SHIFTID", SqlDbType.VarChar).Value = gTRANS.SHIFTID;
            cmd.Parameters.Add("@VOIDFLAG", SqlDbType.Char).Value = gTRANS.VOIDFLAG;
            cmd.Parameters.Add("@VOIDAUTHORIZATION", SqlDbType.VarChar).Value = gTRANS.VOIDAUTHORIZATION;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
