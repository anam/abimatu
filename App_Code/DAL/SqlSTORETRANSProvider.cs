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

public class SqlSTORETRANSProvider:DataAccessObject
{
	public SqlSTORETRANSProvider()
    {
    }


    public bool DeleteSTORETRANS(int sTORETRANSID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteSTORETRANS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STORETRANSID", SqlDbType.Int).Value = sTORETRANSID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<STORETRANS> GetAllSTORETRANSs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllSTORETRANSs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSTORETRANSsFromReader(reader);
        }
    }
    public List<STORETRANS> GetSTORETRANSsFromReader(IDataReader reader)
    {
        List<STORETRANS> sTORETRANSs = new List<STORETRANS>();

        while (reader.Read())
        {
            sTORETRANSs.Add(GetSTORETRANSFromReader(reader));
        }
        return sTORETRANSs;
    }

    public STORETRANS GetSTORETRANSFromReader(IDataReader reader)
    {
        try
        {
            STORETRANS sTORETRANS = new STORETRANS
                (
                    (int)reader["STORETRANSID"],
                    (DateTime)reader["DT"],
                    (int)reader["EMP_ID"],
                    (int)reader["SHIFT_ID"],
                    (int)reader["STATION_ID"],
                    (int)reader["CURRREG"],
                    (int)reader["REGOPEN"],
                    (int)reader["REGCLOSE"],
                    (char)reader["REGOPENSTATUS"],
                    (char)reader["REGCLOSESTATUS"],
                    (DateTime)reader["CLOSEDT"],
                    reader["TOTTIME"].ToString(),
                    (int)reader["TOTSECONDS"],
                    (int)reader["DIFF"]
                );
             return sTORETRANS;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STORETRANS GetSTORETRANSByID(int sTORETRANSID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetSTORETRANSByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@STORETRANSID", SqlDbType.Int).Value = sTORETRANSID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetSTORETRANSFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSTORETRANS(STORETRANS sTORETRANS)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertSTORETRANS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STORETRANSID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DT", SqlDbType.DateTime).Value = sTORETRANS.DT;
            cmd.Parameters.Add("@EMP_ID", SqlDbType.Int).Value = sTORETRANS.EMP_ID;
            cmd.Parameters.Add("@SHIFT_ID", SqlDbType.Int).Value = sTORETRANS.SHIFT_ID;
            cmd.Parameters.Add("@STATION_ID", SqlDbType.Int).Value = sTORETRANS.STATION_ID;
            cmd.Parameters.Add("@CURRREG", SqlDbType.Int).Value = sTORETRANS.CURRREG;
            cmd.Parameters.Add("@REGOPEN", SqlDbType.Int).Value = sTORETRANS.REGOPEN;
            cmd.Parameters.Add("@REGCLOSE", SqlDbType.Int).Value = sTORETRANS.REGCLOSE;
            cmd.Parameters.Add("@REGOPENSTATUS", SqlDbType.Char).Value = sTORETRANS.REGOPENSTATUS;
            cmd.Parameters.Add("@REGCLOSESTATUS", SqlDbType.Char).Value = sTORETRANS.REGCLOSESTATUS;
            cmd.Parameters.Add("@CLOSEDT", SqlDbType.DateTime).Value = sTORETRANS.CLOSEDT;
            cmd.Parameters.Add("@TOTTIME", SqlDbType.VarChar).Value = sTORETRANS.TOTTIME;
            cmd.Parameters.Add("@TOTSECONDS", SqlDbType.Int).Value = sTORETRANS.TOTSECONDS;
            cmd.Parameters.Add("@DIFF", SqlDbType.Int).Value = sTORETRANS.DIFF;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@STORETRANSID"].Value;
        }
    }

    public bool UpdateSTORETRANS(STORETRANS sTORETRANS)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateSTORETRANS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STORETRANSID", SqlDbType.Int).Value = sTORETRANS.STORETRANSID;
            cmd.Parameters.Add("@DT", SqlDbType.DateTime).Value = sTORETRANS.DT;
            cmd.Parameters.Add("@EMP_ID", SqlDbType.Int).Value = sTORETRANS.EMP_ID;
            cmd.Parameters.Add("@SHIFT_ID", SqlDbType.Int).Value = sTORETRANS.SHIFT_ID;
            cmd.Parameters.Add("@STATION_ID", SqlDbType.Int).Value = sTORETRANS.STATION_ID;
            cmd.Parameters.Add("@CURRREG", SqlDbType.Int).Value = sTORETRANS.CURRREG;
            cmd.Parameters.Add("@REGOPEN", SqlDbType.Int).Value = sTORETRANS.REGOPEN;
            cmd.Parameters.Add("@REGCLOSE", SqlDbType.Int).Value = sTORETRANS.REGCLOSE;
            cmd.Parameters.Add("@REGOPENSTATUS", SqlDbType.Char).Value = sTORETRANS.REGOPENSTATUS;
            cmd.Parameters.Add("@REGCLOSESTATUS", SqlDbType.Char).Value = sTORETRANS.REGCLOSESTATUS;
            cmd.Parameters.Add("@CLOSEDT", SqlDbType.DateTime).Value = sTORETRANS.CLOSEDT;
            cmd.Parameters.Add("@TOTTIME", SqlDbType.VarChar).Value = sTORETRANS.TOTTIME;
            cmd.Parameters.Add("@TOTSECONDS", SqlDbType.Int).Value = sTORETRANS.TOTSECONDS;
            cmd.Parameters.Add("@DIFF", SqlDbType.Int).Value = sTORETRANS.DIFF;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
