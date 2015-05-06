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

public class SqlCHECKCASHEDProvider:DataAccessObject
{
	public SqlCHECKCASHEDProvider()
    {
    }


    public bool DeleteCHECKCASHED(int cHECKCASHEDID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteCHECKCASHED", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CHECKCASHEDID", SqlDbType.Int).Value = cHECKCASHEDID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<CHECKCASHED> GetAllCHECKCASHEDs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllCHECKCASHEDs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCHECKCASHEDsFromReader(reader);
        }
    }
    public List<CHECKCASHED> GetCHECKCASHEDsFromReader(IDataReader reader)
    {
        List<CHECKCASHED> cHECKCASHEDs = new List<CHECKCASHED>();

        while (reader.Read())
        {
            cHECKCASHEDs.Add(GetCHECKCASHEDFromReader(reader));
        }
        return cHECKCASHEDs;
    }

    public CHECKCASHED GetCHECKCASHEDFromReader(IDataReader reader)
    {
        try
        {
            CHECKCASHED cHECKCASHED = new CHECKCASHED
                (
                    (int)reader["CHECKCASHEDID"],
                    (DateTime)reader["CHKDT"],
                    (int)reader["CUSTID"],
                    (int)reader["MAKERID"],
                    reader["CHKTYPE"].ToString(),
                    reader["CHKNO"].ToString(),
                    (int)reader["CHKAMOUNT"],
                    (int)reader["CHKFEES"],
                    (int)reader["CHKAMOUNTOWE"],
                    (char)reader["ISDEPOSITED"],
                    reader["EMP_ID"].ToString(),
                    reader["SHIFT_ID"].ToString(),
                    reader["STATION_ID"].ToString(),
                    reader["CREATEDBY"].ToString(),
                    (DateTime)reader["CREATEDON"],
                    (char)reader["ISBAD"],
                    (int)reader["BADCHECKAMOUNTOWE"],
                    reader["BADCHECKREMARKS"].ToString()
                );
             return cHECKCASHED;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public CHECKCASHED GetCHECKCASHEDByID(int cHECKCASHEDID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetCHECKCASHEDByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CHECKCASHEDID", SqlDbType.Int).Value = cHECKCASHEDID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetCHECKCASHEDFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertCHECKCASHED(CHECKCASHED cHECKCASHED)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertCHECKCASHED", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CHECKCASHEDID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CHKDT", SqlDbType.DateTime).Value = cHECKCASHED.CHKDT;
            cmd.Parameters.Add("@CUSTID", SqlDbType.Int).Value = cHECKCASHED.CUSTID;
            cmd.Parameters.Add("@MAKERID", SqlDbType.Int).Value = cHECKCASHED.MAKERID;
            cmd.Parameters.Add("@CHKTYPE", SqlDbType.VarChar).Value = cHECKCASHED.CHKTYPE;
            cmd.Parameters.Add("@CHKNO", SqlDbType.VarChar).Value = cHECKCASHED.CHKNO;
            cmd.Parameters.Add("@CHKAMOUNT", SqlDbType.Int).Value = cHECKCASHED.CHKAMOUNT;
            cmd.Parameters.Add("@CHKFEES", SqlDbType.Int).Value = cHECKCASHED.CHKFEES;
            cmd.Parameters.Add("@CHKAMOUNTOWE", SqlDbType.Int).Value = cHECKCASHED.CHKAMOUNTOWE;
            cmd.Parameters.Add("@ISDEPOSITED", SqlDbType.Char).Value = cHECKCASHED.ISDEPOSITED;
            cmd.Parameters.Add("@EMP_ID", SqlDbType.VarChar).Value = cHECKCASHED.EMP_ID;
            cmd.Parameters.Add("@SHIFT_ID", SqlDbType.VarChar).Value = cHECKCASHED.SHIFT_ID;
            cmd.Parameters.Add("@STATION_ID", SqlDbType.VarChar).Value = cHECKCASHED.STATION_ID;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = cHECKCASHED.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = cHECKCASHED.CREATEDON;
            cmd.Parameters.Add("@ISBAD", SqlDbType.Char).Value = cHECKCASHED.ISBAD;
            cmd.Parameters.Add("@BADCHECKAMOUNTOWE", SqlDbType.Int).Value = cHECKCASHED.BADCHECKAMOUNTOWE;
            cmd.Parameters.Add("@BADCHECKREMARKS", SqlDbType.VarChar).Value = cHECKCASHED.BADCHECKREMARKS;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CHECKCASHEDID"].Value;
        }
    }

    public bool UpdateCHECKCASHED(CHECKCASHED cHECKCASHED)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateCHECKCASHED", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CHECKCASHEDID", SqlDbType.Int).Value = cHECKCASHED.CHECKCASHEDID;
            cmd.Parameters.Add("@CHKDT", SqlDbType.DateTime).Value = cHECKCASHED.CHKDT;
            cmd.Parameters.Add("@CUSTID", SqlDbType.Int).Value = cHECKCASHED.CUSTID;
            cmd.Parameters.Add("@MAKERID", SqlDbType.Int).Value = cHECKCASHED.MAKERID;
            cmd.Parameters.Add("@CHKTYPE", SqlDbType.VarChar).Value = cHECKCASHED.CHKTYPE;
            cmd.Parameters.Add("@CHKNO", SqlDbType.VarChar).Value = cHECKCASHED.CHKNO;
            cmd.Parameters.Add("@CHKAMOUNT", SqlDbType.Int).Value = cHECKCASHED.CHKAMOUNT;
            cmd.Parameters.Add("@CHKFEES", SqlDbType.Int).Value = cHECKCASHED.CHKFEES;
            cmd.Parameters.Add("@CHKAMOUNTOWE", SqlDbType.Int).Value = cHECKCASHED.CHKAMOUNTOWE;
            cmd.Parameters.Add("@ISDEPOSITED", SqlDbType.Char).Value = cHECKCASHED.ISDEPOSITED;
            cmd.Parameters.Add("@EMP_ID", SqlDbType.VarChar).Value = cHECKCASHED.EMP_ID;
            cmd.Parameters.Add("@SHIFT_ID", SqlDbType.VarChar).Value = cHECKCASHED.SHIFT_ID;
            cmd.Parameters.Add("@STATION_ID", SqlDbType.VarChar).Value = cHECKCASHED.STATION_ID;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = cHECKCASHED.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = cHECKCASHED.CREATEDON;
            cmd.Parameters.Add("@ISBAD", SqlDbType.Char).Value = cHECKCASHED.ISBAD;
            cmd.Parameters.Add("@BADCHECKAMOUNTOWE", SqlDbType.Int).Value = cHECKCASHED.BADCHECKAMOUNTOWE;
            cmd.Parameters.Add("@BADCHECKREMARKS", SqlDbType.VarChar).Value = cHECKCASHED.BADCHECKREMARKS;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
