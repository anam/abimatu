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

public class SqlSCHEDULEProvider:DataAccessObject
{
	public SqlSCHEDULEProvider()
    {
    }


    public bool DeleteSCHEDULE(int sCHEDULEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteSCHEDULE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SCHEDULEID", SqlDbType.Int).Value = sCHEDULEID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<SCHEDULE> GetAllSCHEDULEs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllSCHEDULEs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSCHEDULEsFromReader(reader);
        }
    }
    public List<SCHEDULE> GetSCHEDULEsFromReader(IDataReader reader)
    {
        List<SCHEDULE> sCHEDULEs = new List<SCHEDULE>();

        while (reader.Read())
        {
            sCHEDULEs.Add(GetSCHEDULEFromReader(reader));
        }
        return sCHEDULEs;
    }

    public SCHEDULE GetSCHEDULEFromReader(IDataReader reader)
    {
        try
        {
            SCHEDULE sCHEDULE = new SCHEDULE
                (
                    (int)reader["SCHEDULEID"],
                    (int)reader["EMP_ID"],
                    (DateTime)reader["STDT"],
                    (DateTime)reader["ENDDT"],
                    reader["MON"].ToString(),
                    reader["TUE"].ToString(),
                    reader["WED"].ToString(),
                    reader["THS"].ToString(),
                    reader["FRI"].ToString(),
                    reader["SAT"].ToString(),
                    reader["SUN"].ToString()
                );
             return sCHEDULE;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public SCHEDULE GetSCHEDULEByID(int sCHEDULEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetSCHEDULEByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SCHEDULEID", SqlDbType.Int).Value = sCHEDULEID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetSCHEDULEFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSCHEDULE(SCHEDULE sCHEDULE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertSCHEDULE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SCHEDULEID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EMP_ID", SqlDbType.Int).Value = sCHEDULE.EMP_ID;
            cmd.Parameters.Add("@STDT", SqlDbType.DateTime).Value = sCHEDULE.STDT;
            cmd.Parameters.Add("@ENDDT", SqlDbType.DateTime).Value = sCHEDULE.ENDDT;
            cmd.Parameters.Add("@MON", SqlDbType.VarChar).Value = sCHEDULE.MON;
            cmd.Parameters.Add("@TUE", SqlDbType.VarChar).Value = sCHEDULE.TUE;
            cmd.Parameters.Add("@WED", SqlDbType.VarChar).Value = sCHEDULE.WED;
            cmd.Parameters.Add("@THS", SqlDbType.VarChar).Value = sCHEDULE.THS;
            cmd.Parameters.Add("@FRI", SqlDbType.VarChar).Value = sCHEDULE.FRI;
            cmd.Parameters.Add("@SAT", SqlDbType.VarChar).Value = sCHEDULE.SAT;
            cmd.Parameters.Add("@SUN", SqlDbType.VarChar).Value = sCHEDULE.SUN;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SCHEDULEID"].Value;
        }
    }

    public bool UpdateSCHEDULE(SCHEDULE sCHEDULE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateSCHEDULE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SCHEDULEID", SqlDbType.Int).Value = sCHEDULE.SCHEDULEID;
            cmd.Parameters.Add("@EMP_ID", SqlDbType.Int).Value = sCHEDULE.EMP_ID;
            cmd.Parameters.Add("@STDT", SqlDbType.DateTime).Value = sCHEDULE.STDT;
            cmd.Parameters.Add("@ENDDT", SqlDbType.DateTime).Value = sCHEDULE.ENDDT;
            cmd.Parameters.Add("@MON", SqlDbType.VarChar).Value = sCHEDULE.MON;
            cmd.Parameters.Add("@TUE", SqlDbType.VarChar).Value = sCHEDULE.TUE;
            cmd.Parameters.Add("@WED", SqlDbType.VarChar).Value = sCHEDULE.WED;
            cmd.Parameters.Add("@THS", SqlDbType.VarChar).Value = sCHEDULE.THS;
            cmd.Parameters.Add("@FRI", SqlDbType.VarChar).Value = sCHEDULE.FRI;
            cmd.Parameters.Add("@SAT", SqlDbType.VarChar).Value = sCHEDULE.SAT;
            cmd.Parameters.Add("@SUN", SqlDbType.VarChar).Value = sCHEDULE.SUN;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
