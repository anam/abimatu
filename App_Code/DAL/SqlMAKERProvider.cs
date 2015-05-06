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

public class SqlMAKERProvider:DataAccessObject
{
	public SqlMAKERProvider()
    {
    }


    public bool DeleteMAKER(int mAKERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteMAKER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAKERID", SqlDbType.Int).Value = mAKERID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<MAKER> GetAllMAKERs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllMAKERs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetMAKERsFromReader(reader);
        }
    }
    public List<MAKER> GetMAKERsFromReader(IDataReader reader)
    {
        List<MAKER> mAKERs = new List<MAKER>();

        while (reader.Read())
        {
            mAKERs.Add(GetMAKERFromReader(reader));
        }
        return mAKERs;
    }

    public MAKER GetMAKERFromReader(IDataReader reader)
    {
        try
        {
            MAKER mAKER = new MAKER
                (
                    (int)reader["MAKERID"],
                    reader["MAKERNAME"].ToString(),
                    reader["MAKERADDRESS1"].ToString(),
                    reader["MAKERADDRESS2"].ToString(),
                    reader["MAKERCITY"].ToString(),
                    (char)reader["MAKERSTATE"],
                    reader["MAKERZIP"].ToString(),
                    reader["MAKERPHONE1"].ToString(),
                    reader["MAKERPHONE2"].ToString(),
                    reader["MANAGER"].ToString(),
                    reader["ACCOUNTNO"].ToString(),
                    reader["ROUTINGNO"].ToString(),
                    (int)reader["CHECKCOUNT"],
                    (int)reader["CHECKAMOUNT"],
                    (int)reader["BADCHECKCOUNT"],
                    (int)reader["BADCHECKAMOUNT"],
                    (int)reader["AMOUNTDUE"],
                    reader["CREATEDBY"].ToString(),
                    (DateTime)reader["CREATEDON"],
                    reader["UPDATEDBY"].ToString(),
                    (DateTime)reader["UPDATEDON"],
                    (char)reader["ISOFACVERIFIED"],
                    reader["MAKERREMARKS"].ToString()
                );
             return mAKER;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public MAKER GetMAKERByID(int mAKERID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetMAKERByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MAKERID", SqlDbType.Int).Value = mAKERID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetMAKERFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertMAKER(MAKER mAKER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertMAKER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAKERID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MAKERNAME", SqlDbType.VarChar).Value = mAKER.MAKERNAME;
            cmd.Parameters.Add("@MAKERADDRESS1", SqlDbType.VarChar).Value = mAKER.MAKERADDRESS1;
            cmd.Parameters.Add("@MAKERADDRESS2", SqlDbType.VarChar).Value = mAKER.MAKERADDRESS2;
            cmd.Parameters.Add("@MAKERCITY", SqlDbType.VarChar).Value = mAKER.MAKERCITY;
            cmd.Parameters.Add("@MAKERSTATE", SqlDbType.Char).Value = mAKER.MAKERSTATE;
            cmd.Parameters.Add("@MAKERZIP", SqlDbType.VarChar).Value = mAKER.MAKERZIP;
            cmd.Parameters.Add("@MAKERPHONE1", SqlDbType.VarChar).Value = mAKER.MAKERPHONE1;
            cmd.Parameters.Add("@MAKERPHONE2", SqlDbType.VarChar).Value = mAKER.MAKERPHONE2;
            cmd.Parameters.Add("@MANAGER", SqlDbType.VarChar).Value = mAKER.MANAGER;
            cmd.Parameters.Add("@ACCOUNTNO", SqlDbType.VarChar).Value = mAKER.ACCOUNTNO;
            cmd.Parameters.Add("@ROUTINGNO", SqlDbType.VarChar).Value = mAKER.ROUTINGNO;
            cmd.Parameters.Add("@CHECKCOUNT", SqlDbType.Int).Value = mAKER.CHECKCOUNT;
            cmd.Parameters.Add("@CHECKAMOUNT", SqlDbType.Int).Value = mAKER.CHECKAMOUNT;
            cmd.Parameters.Add("@BADCHECKCOUNT", SqlDbType.Int).Value = mAKER.BADCHECKCOUNT;
            cmd.Parameters.Add("@BADCHECKAMOUNT", SqlDbType.Int).Value = mAKER.BADCHECKAMOUNT;
            cmd.Parameters.Add("@AMOUNTDUE", SqlDbType.Int).Value = mAKER.AMOUNTDUE;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = mAKER.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = mAKER.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.VarChar).Value = mAKER.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = mAKER.UPDATEDON;
            cmd.Parameters.Add("@ISOFACVERIFIED", SqlDbType.Char).Value = mAKER.ISOFACVERIFIED;
            cmd.Parameters.Add("@MAKERREMARKS", SqlDbType.VarChar).Value = mAKER.MAKERREMARKS;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@MAKERID"].Value;
        }
    }

    public bool UpdateMAKER(MAKER mAKER)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateMAKER", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MAKERID", SqlDbType.Int).Value = mAKER.MAKERID;
            cmd.Parameters.Add("@MAKERNAME", SqlDbType.VarChar).Value = mAKER.MAKERNAME;
            cmd.Parameters.Add("@MAKERADDRESS1", SqlDbType.VarChar).Value = mAKER.MAKERADDRESS1;
            cmd.Parameters.Add("@MAKERADDRESS2", SqlDbType.VarChar).Value = mAKER.MAKERADDRESS2;
            cmd.Parameters.Add("@MAKERCITY", SqlDbType.VarChar).Value = mAKER.MAKERCITY;
            cmd.Parameters.Add("@MAKERSTATE", SqlDbType.Char).Value = mAKER.MAKERSTATE;
            cmd.Parameters.Add("@MAKERZIP", SqlDbType.VarChar).Value = mAKER.MAKERZIP;
            cmd.Parameters.Add("@MAKERPHONE1", SqlDbType.VarChar).Value = mAKER.MAKERPHONE1;
            cmd.Parameters.Add("@MAKERPHONE2", SqlDbType.VarChar).Value = mAKER.MAKERPHONE2;
            cmd.Parameters.Add("@MANAGER", SqlDbType.VarChar).Value = mAKER.MANAGER;
            cmd.Parameters.Add("@ACCOUNTNO", SqlDbType.VarChar).Value = mAKER.ACCOUNTNO;
            cmd.Parameters.Add("@ROUTINGNO", SqlDbType.VarChar).Value = mAKER.ROUTINGNO;
            cmd.Parameters.Add("@CHECKCOUNT", SqlDbType.Int).Value = mAKER.CHECKCOUNT;
            cmd.Parameters.Add("@CHECKAMOUNT", SqlDbType.Int).Value = mAKER.CHECKAMOUNT;
            cmd.Parameters.Add("@BADCHECKCOUNT", SqlDbType.Int).Value = mAKER.BADCHECKCOUNT;
            cmd.Parameters.Add("@BADCHECKAMOUNT", SqlDbType.Int).Value = mAKER.BADCHECKAMOUNT;
            cmd.Parameters.Add("@AMOUNTDUE", SqlDbType.Int).Value = mAKER.AMOUNTDUE;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = mAKER.CREATEDBY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = mAKER.CREATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.VarChar).Value = mAKER.UPDATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = mAKER.UPDATEDON;
            cmd.Parameters.Add("@ISOFACVERIFIED", SqlDbType.Char).Value = mAKER.ISOFACVERIFIED;
            cmd.Parameters.Add("@MAKERREMARKS", SqlDbType.VarChar).Value = mAKER.MAKERREMARKS;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
