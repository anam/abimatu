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

public class SqlSERVICESProvider:DataAccessObject
{
	public SqlSERVICESProvider()
    {
    }


    public bool DeleteSERVICES(int sERVICESID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteSERVICES", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SERVICESID", SqlDbType.Int).Value = sERVICESID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<SERVICES> GetAllSERVICESs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllSERVICESs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSERVICESsFromReader(reader);
        }
    }
    public List<SERVICES> GetSERVICESsFromReader(IDataReader reader)
    {
        List<SERVICES> sERVICESs = new List<SERVICES>();

        while (reader.Read())
        {
            sERVICESs.Add(GetSERVICESFromReader(reader));
        }
        return sERVICESs;
    }

    public SERVICES GetSERVICESFromReader(IDataReader reader)
    {
        try
        {
            SERVICES sERVICES = new SERVICES
                (
                    (int)reader["SERVICESID"],
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
                    reader["ISCOMMCOUNTED"].ToString(),
                    (int)reader["SERVICECOMM"],
                    (int)reader["STORECOMM"],
                    reader["QUICKBOOKSERVICENAME"].ToString(),
                    reader["QUICKBOOKSERVICEACCOUNT"].ToString()
                );
             return sERVICES;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public SERVICES GetSERVICESByID(int sERVICESID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetSERVICESByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SERVICESID", SqlDbType.Int).Value = sERVICESID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetSERVICESFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSERVICES(SERVICES sERVICES)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertSERVICES", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SERVICESID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SERVICETYPE", SqlDbType.VarChar).Value = sERVICES.SERVICETYPE;
            cmd.Parameters.Add("@SERVICENAME", SqlDbType.VarChar).Value = sERVICES.SERVICENAME;
            cmd.Parameters.Add("@SERVICEFEE", SqlDbType.Int).Value = sERVICES.SERVICEFEE;
            cmd.Parameters.Add("@ISQUICKACCESS", SqlDbType.VarChar).Value = sERVICES.ISQUICKACCESS;
            cmd.Parameters.Add("@ISTAXABLE", SqlDbType.VarChar).Value = sERVICES.ISTAXABLE;
            cmd.Parameters.Add("@PAYMENTMODE", SqlDbType.VarChar).Value = sERVICES.PAYMENTMODE;
            cmd.Parameters.Add("@ITEMINSTOCK", SqlDbType.Int).Value = sERVICES.ITEMINSTOCK;
            cmd.Parameters.Add("@REORDERLEVEL", SqlDbType.Int).Value = sERVICES.REORDERLEVEL;
            cmd.Parameters.Add("@COSTPRICE", SqlDbType.Int).Value = sERVICES.COSTPRICE;
            cmd.Parameters.Add("@RETAILPRICE", SqlDbType.Int).Value = sERVICES.RETAILPRICE;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = sERVICES.CREATEDON;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = sERVICES.CREATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = sERVICES.UPDATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.VarChar).Value = sERVICES.UPDATEDBY;
            cmd.Parameters.Add("@COMM", SqlDbType.Int).Value = sERVICES.COMM;
            cmd.Parameters.Add("@ISCOMMCOUNTED", SqlDbType.VarChar).Value = sERVICES.ISCOMMCOUNTED;
            cmd.Parameters.Add("@SERVICECOMM", SqlDbType.Int).Value = sERVICES.SERVICECOMM;
            cmd.Parameters.Add("@STORECOMM", SqlDbType.Int).Value = sERVICES.STORECOMM;
            cmd.Parameters.Add("@QUICKBOOKSERVICENAME", SqlDbType.VarChar).Value = sERVICES.QUICKBOOKSERVICENAME;
            cmd.Parameters.Add("@QUICKBOOKSERVICEACCOUNT", SqlDbType.VarChar).Value = sERVICES.QUICKBOOKSERVICEACCOUNT;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SERVICESID"].Value;
        }
    }

    public bool UpdateSERVICES(SERVICES sERVICES)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateSERVICES", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SERVICESID", SqlDbType.Int).Value = sERVICES.SERVICESID;
            cmd.Parameters.Add("@SERVICETYPE", SqlDbType.VarChar).Value = sERVICES.SERVICETYPE;
            cmd.Parameters.Add("@SERVICENAME", SqlDbType.VarChar).Value = sERVICES.SERVICENAME;
            cmd.Parameters.Add("@SERVICEFEE", SqlDbType.Int).Value = sERVICES.SERVICEFEE;
            cmd.Parameters.Add("@ISQUICKACCESS", SqlDbType.VarChar).Value = sERVICES.ISQUICKACCESS;
            cmd.Parameters.Add("@ISTAXABLE", SqlDbType.VarChar).Value = sERVICES.ISTAXABLE;
            cmd.Parameters.Add("@PAYMENTMODE", SqlDbType.VarChar).Value = sERVICES.PAYMENTMODE;
            cmd.Parameters.Add("@ITEMINSTOCK", SqlDbType.Int).Value = sERVICES.ITEMINSTOCK;
            cmd.Parameters.Add("@REORDERLEVEL", SqlDbType.Int).Value = sERVICES.REORDERLEVEL;
            cmd.Parameters.Add("@COSTPRICE", SqlDbType.Int).Value = sERVICES.COSTPRICE;
            cmd.Parameters.Add("@RETAILPRICE", SqlDbType.Int).Value = sERVICES.RETAILPRICE;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = sERVICES.CREATEDON;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = sERVICES.CREATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = sERVICES.UPDATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.VarChar).Value = sERVICES.UPDATEDBY;
            cmd.Parameters.Add("@COMM", SqlDbType.Int).Value = sERVICES.COMM;
            cmd.Parameters.Add("@ISCOMMCOUNTED", SqlDbType.VarChar).Value = sERVICES.ISCOMMCOUNTED;
            cmd.Parameters.Add("@SERVICECOMM", SqlDbType.Int).Value = sERVICES.SERVICECOMM;
            cmd.Parameters.Add("@STORECOMM", SqlDbType.Int).Value = sERVICES.STORECOMM;
            cmd.Parameters.Add("@QUICKBOOKSERVICENAME", SqlDbType.VarChar).Value = sERVICES.QUICKBOOKSERVICENAME;
            cmd.Parameters.Add("@QUICKBOOKSERVICEACCOUNT", SqlDbType.VarChar).Value = sERVICES.QUICKBOOKSERVICEACCOUNT;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
