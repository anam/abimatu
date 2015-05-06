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

public class SqlSPR_COMMISSIONProvider:DataAccessObject
{
	public SqlSPR_COMMISSIONProvider()
    {
    }


    public bool DeleteSPR_COMMISSION(int sPR_COMMISSIONID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteSPR_COMMISSION", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SPR_COMMISSIONID", SqlDbType.Int).Value = sPR_COMMISSIONID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<SPR_COMMISSION> GetAllSPR_COMMISSIONs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllSPR_COMMISSIONs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSPR_COMMISSIONsFromReader(reader);
        }
    }
    public List<SPR_COMMISSION> GetSPR_COMMISSIONsFromReader(IDataReader reader)
    {
        List<SPR_COMMISSION> sPR_COMMISSIONs = new List<SPR_COMMISSION>();

        while (reader.Read())
        {
            sPR_COMMISSIONs.Add(GetSPR_COMMISSIONFromReader(reader));
        }
        return sPR_COMMISSIONs;
    }

    public SPR_COMMISSION GetSPR_COMMISSIONFromReader(IDataReader reader)
    {
        try
        {
            SPR_COMMISSION sPR_COMMISSION = new SPR_COMMISSION
                (
                    (int)reader["SPR_COMMISSIONID"],
                    reader["STYPE"].ToString(),
                    reader["SPLAN"].ToString(),
                    reader["SASL"].ToString(),
                    (int)reader["SYEAR"],
                    (int)reader["BASECOMM"],
                    (int)reader["ASLCOMM"],
                    (int)reader["TYPECOMM"],
                    (int)reader["YEARCOMM"]
                );
             return sPR_COMMISSION;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public SPR_COMMISSION GetSPR_COMMISSIONByID(int sPR_COMMISSIONID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetSPR_COMMISSIONByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SPR_COMMISSIONID", SqlDbType.Int).Value = sPR_COMMISSIONID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetSPR_COMMISSIONFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSPR_COMMISSION(SPR_COMMISSION sPR_COMMISSION)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertSPR_COMMISSION", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SPR_COMMISSIONID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@STYPE", SqlDbType.VarChar).Value = sPR_COMMISSION.STYPE;
            cmd.Parameters.Add("@SPLAN", SqlDbType.VarChar).Value = sPR_COMMISSION.SPLAN;
            cmd.Parameters.Add("@SASL", SqlDbType.VarChar).Value = sPR_COMMISSION.SASL;
            cmd.Parameters.Add("@SYEAR", SqlDbType.Int).Value = sPR_COMMISSION.SYEAR;
            cmd.Parameters.Add("@BASECOMM", SqlDbType.Int).Value = sPR_COMMISSION.BASECOMM;
            cmd.Parameters.Add("@ASLCOMM", SqlDbType.Int).Value = sPR_COMMISSION.ASLCOMM;
            cmd.Parameters.Add("@TYPECOMM", SqlDbType.Int).Value = sPR_COMMISSION.TYPECOMM;
            cmd.Parameters.Add("@YEARCOMM", SqlDbType.Int).Value = sPR_COMMISSION.YEARCOMM;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SPR_COMMISSIONID"].Value;
        }
    }

    public bool UpdateSPR_COMMISSION(SPR_COMMISSION sPR_COMMISSION)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateSPR_COMMISSION", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SPR_COMMISSIONID", SqlDbType.Int).Value = sPR_COMMISSION.SPR_COMMISSIONID;
            cmd.Parameters.Add("@STYPE", SqlDbType.VarChar).Value = sPR_COMMISSION.STYPE;
            cmd.Parameters.Add("@SPLAN", SqlDbType.VarChar).Value = sPR_COMMISSION.SPLAN;
            cmd.Parameters.Add("@SASL", SqlDbType.VarChar).Value = sPR_COMMISSION.SASL;
            cmd.Parameters.Add("@SYEAR", SqlDbType.Int).Value = sPR_COMMISSION.SYEAR;
            cmd.Parameters.Add("@BASECOMM", SqlDbType.Int).Value = sPR_COMMISSION.BASECOMM;
            cmd.Parameters.Add("@ASLCOMM", SqlDbType.Int).Value = sPR_COMMISSION.ASLCOMM;
            cmd.Parameters.Add("@TYPECOMM", SqlDbType.Int).Value = sPR_COMMISSION.TYPECOMM;
            cmd.Parameters.Add("@YEARCOMM", SqlDbType.Int).Value = sPR_COMMISSION.YEARCOMM;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
