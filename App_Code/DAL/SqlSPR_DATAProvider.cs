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

public class SqlSPR_DATAProvider:DataAccessObject
{
	public SqlSPR_DATAProvider()
    {
    }


    public bool DeleteSPR_DATA(int sPR_DATAID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteSPR_DATA", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SPR_DATAID", SqlDbType.Int).Value = sPR_DATAID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<SPR_DATA> GetAllSPR_DATAs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllSPR_DATAs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSPR_DATAsFromReader(reader);
        }
    }
    public List<SPR_DATA> GetSPR_DATAsFromReader(IDataReader reader)
    {
        List<SPR_DATA> sPR_DATAs = new List<SPR_DATA>();

        while (reader.Read())
        {
            sPR_DATAs.Add(GetSPR_DATAFromReader(reader));
        }
        return sPR_DATAs;
    }

    public SPR_DATA GetSPR_DATAFromReader(IDataReader reader)
    {
        try
        {
            SPR_DATA sPR_DATA = new SPR_DATA
                (
                    (int)reader["SPR_DATAID"],
                    reader["STYPE"].ToString(),
                    reader["MRC"].ToString(),
                    (int)reader["DCOMM"]
                );
             return sPR_DATA;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public SPR_DATA GetSPR_DATAByID(int sPR_DATAID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetSPR_DATAByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SPR_DATAID", SqlDbType.Int).Value = sPR_DATAID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetSPR_DATAFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSPR_DATA(SPR_DATA sPR_DATA)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertSPR_DATA", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SPR_DATAID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@STYPE", SqlDbType.VarChar).Value = sPR_DATA.STYPE;
            cmd.Parameters.Add("@MRC", SqlDbType.VarChar).Value = sPR_DATA.MRC;
            cmd.Parameters.Add("@DCOMM", SqlDbType.Int).Value = sPR_DATA.DCOMM;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SPR_DATAID"].Value;
        }
    }

    public bool UpdateSPR_DATA(SPR_DATA sPR_DATA)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateSPR_DATA", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SPR_DATAID", SqlDbType.Int).Value = sPR_DATA.SPR_DATAID;
            cmd.Parameters.Add("@STYPE", SqlDbType.VarChar).Value = sPR_DATA.STYPE;
            cmd.Parameters.Add("@MRC", SqlDbType.VarChar).Value = sPR_DATA.MRC;
            cmd.Parameters.Add("@DCOMM", SqlDbType.Int).Value = sPR_DATA.DCOMM;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
