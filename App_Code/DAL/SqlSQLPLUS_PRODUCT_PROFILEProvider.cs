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

public class SqlSQLPLUS_PRODUCT_PROFILEProvider:DataAccessObject
{
	public SqlSQLPLUS_PRODUCT_PROFILEProvider()
    {
    }


    public bool DeleteSQLPLUS_PRODUCT_PROFILE(int sQLPLUS_PRODUCT_PROFILEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteSQLPLUS_PRODUCT_PROFILE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SQLPLUS_PRODUCT_PROFILEID", SqlDbType.Int).Value = sQLPLUS_PRODUCT_PROFILEID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<SQLPLUS_PRODUCT_PROFILE> GetAllSQLPLUS_PRODUCT_PROFILEs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllSQLPLUS_PRODUCT_PROFILEs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSQLPLUS_PRODUCT_PROFILEsFromReader(reader);
        }
    }
    public List<SQLPLUS_PRODUCT_PROFILE> GetSQLPLUS_PRODUCT_PROFILEsFromReader(IDataReader reader)
    {
        List<SQLPLUS_PRODUCT_PROFILE> sQLPLUS_PRODUCT_PROFILEs = new List<SQLPLUS_PRODUCT_PROFILE>();

        while (reader.Read())
        {
            sQLPLUS_PRODUCT_PROFILEs.Add(GetSQLPLUS_PRODUCT_PROFILEFromReader(reader));
        }
        return sQLPLUS_PRODUCT_PROFILEs;
    }

    public SQLPLUS_PRODUCT_PROFILE GetSQLPLUS_PRODUCT_PROFILEFromReader(IDataReader reader)
    {
        try
        {
            SQLPLUS_PRODUCT_PROFILE sQLPLUS_PRODUCT_PROFILE = new SQLPLUS_PRODUCT_PROFILE
                (
                    (int)reader["SQLPLUS_PRODUCT_PROFILEID"],
                    reader["PRODUCT"].ToString(),
                    (int)reader["USERID"],
                    reader["ATTRIBUTE"].ToString(),
                    reader["SCOPE"].ToString(),
                    (int)reader["NUMERIC_VALUE"],
                    reader["CHAR_VALUE"].ToString(),
                    (DateTime)reader["DATE_VALUE"],
                    (int)reader["LONG_VALUE"]
                );
             return sQLPLUS_PRODUCT_PROFILE;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public SQLPLUS_PRODUCT_PROFILE GetSQLPLUS_PRODUCT_PROFILEByID(int sQLPLUS_PRODUCT_PROFILEID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetSQLPLUS_PRODUCT_PROFILEByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SQLPLUS_PRODUCT_PROFILEID", SqlDbType.Int).Value = sQLPLUS_PRODUCT_PROFILEID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetSQLPLUS_PRODUCT_PROFILEFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSQLPLUS_PRODUCT_PROFILE(SQLPLUS_PRODUCT_PROFILE sQLPLUS_PRODUCT_PROFILE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertSQLPLUS_PRODUCT_PROFILE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SQLPLUS_PRODUCT_PROFILEID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PRODUCT", SqlDbType.VarChar).Value = sQLPLUS_PRODUCT_PROFILE.PRODUCT;
            cmd.Parameters.Add("@USERID", SqlDbType.Int).Value = sQLPLUS_PRODUCT_PROFILE.USERID;
            cmd.Parameters.Add("@ATTRIBUTE", SqlDbType.VarChar).Value = sQLPLUS_PRODUCT_PROFILE.ATTRIBUTE;
            cmd.Parameters.Add("@SCOPE", SqlDbType.VarChar).Value = sQLPLUS_PRODUCT_PROFILE.SCOPE;
            cmd.Parameters.Add("@NUMERIC_VALUE", SqlDbType.Int).Value = sQLPLUS_PRODUCT_PROFILE.NUMERIC_VALUE;
            cmd.Parameters.Add("@CHAR_VALUE", SqlDbType.VarChar).Value = sQLPLUS_PRODUCT_PROFILE.CHAR_VALUE;
            cmd.Parameters.Add("@DATE_VALUE", SqlDbType.DateTime).Value = sQLPLUS_PRODUCT_PROFILE.DATE_VALUE;
            cmd.Parameters.Add("@LONG_VALUE", SqlDbType.Int).Value = sQLPLUS_PRODUCT_PROFILE.LONG_VALUE;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SQLPLUS_PRODUCT_PROFILEID"].Value;
        }
    }

    public bool UpdateSQLPLUS_PRODUCT_PROFILE(SQLPLUS_PRODUCT_PROFILE sQLPLUS_PRODUCT_PROFILE)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateSQLPLUS_PRODUCT_PROFILE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SQLPLUS_PRODUCT_PROFILEID", SqlDbType.Int).Value = sQLPLUS_PRODUCT_PROFILE.SQLPLUS_PRODUCT_PROFILEID;
            cmd.Parameters.Add("@PRODUCT", SqlDbType.VarChar).Value = sQLPLUS_PRODUCT_PROFILE.PRODUCT;
            cmd.Parameters.Add("@USERID", SqlDbType.Int).Value = sQLPLUS_PRODUCT_PROFILE.USERID;
            cmd.Parameters.Add("@ATTRIBUTE", SqlDbType.VarChar).Value = sQLPLUS_PRODUCT_PROFILE.ATTRIBUTE;
            cmd.Parameters.Add("@SCOPE", SqlDbType.VarChar).Value = sQLPLUS_PRODUCT_PROFILE.SCOPE;
            cmd.Parameters.Add("@NUMERIC_VALUE", SqlDbType.Int).Value = sQLPLUS_PRODUCT_PROFILE.NUMERIC_VALUE;
            cmd.Parameters.Add("@CHAR_VALUE", SqlDbType.VarChar).Value = sQLPLUS_PRODUCT_PROFILE.CHAR_VALUE;
            cmd.Parameters.Add("@DATE_VALUE", SqlDbType.DateTime).Value = sQLPLUS_PRODUCT_PROFILE.DATE_VALUE;
            cmd.Parameters.Add("@LONG_VALUE", SqlDbType.Int).Value = sQLPLUS_PRODUCT_PROFILE.LONG_VALUE;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
