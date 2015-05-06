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

public class SqlSALESSTORESERVICESProvider:DataAccessObject
{
	public SqlSALESSTORESERVICESProvider()
    {
    }


    public bool DeleteSALESSTORESERVICES(int sALESSTORESERVICESID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteSALESSTORESERVICES", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SALESSTORESERVICESID", SqlDbType.Int).Value = sALESSTORESERVICESID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<SALESSTORESERVICES> GetAllSALESSTORESERVICESs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllSALESSTORESERVICESs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSALESSTORESERVICESsFromReader(reader);
        }
    }
    public List<SALESSTORESERVICES> GetSALESSTORESERVICESsFromReader(IDataReader reader)
    {
        List<SALESSTORESERVICES> sALESSTORESERVICESs = new List<SALESSTORESERVICES>();

        while (reader.Read())
        {
            sALESSTORESERVICESs.Add(GetSALESSTORESERVICESFromReader(reader));
        }
        return sALESSTORESERVICESs;
    }

    public SALESSTORESERVICES GetSALESSTORESERVICESFromReader(IDataReader reader)
    {
        try
        {
            SALESSTORESERVICES sALESSTORESERVICES = new SALESSTORESERVICES
                (
                    (int)reader["SALESSTORESERVICESID"],
                    reader["SERVICETYPE"].ToString(),
                    reader["SERVICENAME"].ToString(),
                    (int)reader["SERVICEFEE"],
                    reader["ISQUICKACCESS"].ToString(),
                    reader["ISTAXABLE"].ToString(),
                    reader["PAYMENTMODE"].ToString(),
                    (int)reader["ITEMINSTOCK"],
                    (int)reader["REORDERLEVEL"],
                    (int)reader["COSTPRICE"],
                    (int)reader["RETAILPRICE"],
                    (DateTime)reader["CREATEDON"],
                    reader["CREATEDBY"].ToString(),
                    (DateTime)reader["UPDATEDON"],
                    reader["UPDATEDBY"].ToString(),
                    (int)reader["COMM"],
                    reader["ISCOMMCOUNTED"].ToString()
                );
             return sALESSTORESERVICES;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public SALESSTORESERVICES GetSALESSTORESERVICESByID(int sALESSTORESERVICESID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetSALESSTORESERVICESByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SALESSTORESERVICESID", SqlDbType.Int).Value = sALESSTORESERVICESID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetSALESSTORESERVICESFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSALESSTORESERVICES(SALESSTORESERVICES sALESSTORESERVICES)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertSALESSTORESERVICES", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SALESSTORESERVICESID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SERVICETYPE", SqlDbType.VarChar).Value = sALESSTORESERVICES.SERVICETYPE;
            cmd.Parameters.Add("@SERVICENAME", SqlDbType.VarChar).Value = sALESSTORESERVICES.SERVICENAME;
            cmd.Parameters.Add("@SERVICEFEE", SqlDbType.Int).Value = sALESSTORESERVICES.SERVICEFEE;
            cmd.Parameters.Add("@ISQUICKACCESS", SqlDbType.VarChar).Value = sALESSTORESERVICES.ISQUICKACCESS;
            cmd.Parameters.Add("@ISTAXABLE", SqlDbType.VarChar).Value = sALESSTORESERVICES.ISTAXABLE;
            cmd.Parameters.Add("@PAYMENTMODE", SqlDbType.VarChar).Value = sALESSTORESERVICES.PAYMENTMODE;
            cmd.Parameters.Add("@ITEMINSTOCK", SqlDbType.Int).Value = sALESSTORESERVICES.ITEMINSTOCK;
            cmd.Parameters.Add("@REORDERLEVEL", SqlDbType.Int).Value = sALESSTORESERVICES.REORDERLEVEL;
            cmd.Parameters.Add("@COSTPRICE", SqlDbType.Int).Value = sALESSTORESERVICES.COSTPRICE;
            cmd.Parameters.Add("@RETAILPRICE", SqlDbType.Int).Value = sALESSTORESERVICES.RETAILPRICE;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = sALESSTORESERVICES.CREATEDON;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = sALESSTORESERVICES.CREATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = sALESSTORESERVICES.UPDATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.VarChar).Value = sALESSTORESERVICES.UPDATEDBY;
            cmd.Parameters.Add("@COMM", SqlDbType.Int).Value = sALESSTORESERVICES.COMM;
            cmd.Parameters.Add("@ISCOMMCOUNTED", SqlDbType.VarChar).Value = sALESSTORESERVICES.ISCOMMCOUNTED;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SALESSTORESERVICESID"].Value;
        }
    }

    public bool UpdateSALESSTORESERVICES(SALESSTORESERVICES sALESSTORESERVICES)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateSALESSTORESERVICES", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SALESSTORESERVICESID", SqlDbType.Int).Value = sALESSTORESERVICES.SALESSTORESERVICESID;
            cmd.Parameters.Add("@SERVICETYPE", SqlDbType.VarChar).Value = sALESSTORESERVICES.SERVICETYPE;
            cmd.Parameters.Add("@SERVICENAME", SqlDbType.VarChar).Value = sALESSTORESERVICES.SERVICENAME;
            cmd.Parameters.Add("@SERVICEFEE", SqlDbType.Int).Value = sALESSTORESERVICES.SERVICEFEE;
            cmd.Parameters.Add("@ISQUICKACCESS", SqlDbType.VarChar).Value = sALESSTORESERVICES.ISQUICKACCESS;
            cmd.Parameters.Add("@ISTAXABLE", SqlDbType.VarChar).Value = sALESSTORESERVICES.ISTAXABLE;
            cmd.Parameters.Add("@PAYMENTMODE", SqlDbType.VarChar).Value = sALESSTORESERVICES.PAYMENTMODE;
            cmd.Parameters.Add("@ITEMINSTOCK", SqlDbType.Int).Value = sALESSTORESERVICES.ITEMINSTOCK;
            cmd.Parameters.Add("@REORDERLEVEL", SqlDbType.Int).Value = sALESSTORESERVICES.REORDERLEVEL;
            cmd.Parameters.Add("@COSTPRICE", SqlDbType.Int).Value = sALESSTORESERVICES.COSTPRICE;
            cmd.Parameters.Add("@RETAILPRICE", SqlDbType.Int).Value = sALESSTORESERVICES.RETAILPRICE;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = sALESSTORESERVICES.CREATEDON;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = sALESSTORESERVICES.CREATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = sALESSTORESERVICES.UPDATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.VarChar).Value = sALESSTORESERVICES.UPDATEDBY;
            cmd.Parameters.Add("@COMM", SqlDbType.Int).Value = sALESSTORESERVICES.COMM;
            cmd.Parameters.Add("@ISCOMMCOUNTED", SqlDbType.VarChar).Value = sALESSTORESERVICES.ISCOMMCOUNTED;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
