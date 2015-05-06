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

public class SqlTRANSFERACCOUNTProvider:DataAccessObject
{
	public SqlTRANSFERACCOUNTProvider()
    {
    }


    public bool DeleteTRANSFERACCOUNT(int tRANSFERACCOUNTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteTRANSFERACCOUNT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TRANSFERACCOUNTID", SqlDbType.Int).Value = tRANSFERACCOUNTID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<TRANSFERACCOUNT> GetAllTRANSFERACCOUNTs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllTRANSFERACCOUNTs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetTRANSFERACCOUNTsFromReader(reader);
        }
    }
    public List<TRANSFERACCOUNT> GetTRANSFERACCOUNTsFromReader(IDataReader reader)
    {
        List<TRANSFERACCOUNT> tRANSFERACCOUNTs = new List<TRANSFERACCOUNT>();

        while (reader.Read())
        {
            tRANSFERACCOUNTs.Add(GetTRANSFERACCOUNTFromReader(reader));
        }
        return tRANSFERACCOUNTs;
    }

    public TRANSFERACCOUNT GetTRANSFERACCOUNTFromReader(IDataReader reader)
    {
        try
        {
            TRANSFERACCOUNT tRANSFERACCOUNT = new TRANSFERACCOUNT
                (
                    (int)reader["TRANSFERACCOUNTID"],
                    (char)reader["ACCTYPE"],
                    reader["ACCNAME"].ToString()
                );
             return tRANSFERACCOUNT;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public TRANSFERACCOUNT GetTRANSFERACCOUNTByID(int tRANSFERACCOUNTID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetTRANSFERACCOUNTByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TRANSFERACCOUNTID", SqlDbType.Int).Value = tRANSFERACCOUNTID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetTRANSFERACCOUNTFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertTRANSFERACCOUNT(TRANSFERACCOUNT tRANSFERACCOUNT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertTRANSFERACCOUNT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TRANSFERACCOUNTID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ACCTYPE", SqlDbType.Char).Value = tRANSFERACCOUNT.ACCTYPE;
            cmd.Parameters.Add("@ACCNAME", SqlDbType.VarChar).Value = tRANSFERACCOUNT.ACCNAME;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@TRANSFERACCOUNTID"].Value;
        }
    }

    public bool UpdateTRANSFERACCOUNT(TRANSFERACCOUNT tRANSFERACCOUNT)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateTRANSFERACCOUNT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TRANSFERACCOUNTID", SqlDbType.Int).Value = tRANSFERACCOUNT.TRANSFERACCOUNTID;
            cmd.Parameters.Add("@ACCTYPE", SqlDbType.Char).Value = tRANSFERACCOUNT.ACCTYPE;
            cmd.Parameters.Add("@ACCNAME", SqlDbType.VarChar).Value = tRANSFERACCOUNT.ACCNAME;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
