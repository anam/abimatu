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

public class SqlFOODITEM_TRANSDETAILProvider:DataAccessObject
{
	public SqlFOODITEM_TRANSDETAILProvider()
    {
    }


    public bool DeleteFOODITEM_TRANSDETAIL(int fOODITEM_TRANSDETAILID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteFOODITEM_TRANSDETAIL", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FOODITEM_TRANSDETAILID", SqlDbType.Int).Value = fOODITEM_TRANSDETAILID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool DeleteFOODITEM_TRANSDETAILByTID(int tID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_DeleteFOODITEM_TRANSDETAILByTID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TID", SqlDbType.Int).Value = tID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
    public List<FOODITEM_TRANSDETAIL> GetAllFOODITEM_TRANSDETAILs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetAllFOODITEM_TRANSDETAILs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetFOODITEM_TRANSDETAILsFromReader(reader);
        }
    }

    public List<FOODITEM_TRANSMASTERDETAIL> GetAllFOODITEM_TRANSDETAILByFoodTransID(int foodTransID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetFOODITEM_TRANSDETAILByFoodTransID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TID", SqlDbType.Int).Value = foodTransID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetFOODITEM_TRANSMASTERDETAILsFromReader(reader);
        }
    }

    public List<FOODITEM_TRANSMASTERDETAIL> GetFOODITEM_TRANSMASTERDETAILsFromReader(IDataReader reader)
    {
        List<FOODITEM_TRANSMASTERDETAIL> fOODITEM_TRANSDETAILs = new List<FOODITEM_TRANSMASTERDETAIL>();

        while (reader.Read())
        {
            fOODITEM_TRANSDETAILs.Add(GetFOODITEM_TRANSMASTERDETAILFromReader(reader));
        }
        return fOODITEM_TRANSDETAILs;
    }

    public FOODITEM_TRANSMASTERDETAIL GetFOODITEM_TRANSMASTERDETAILFromReader(IDataReader reader)
    {
        try
        {
            FOODITEM_TRANSMASTERDETAIL fOODITEM_TRANSDETAIL = new FOODITEM_TRANSMASTERDETAIL
                (
                    (int)reader["FID"],
                    (decimal)reader["FRATE"],
                    (int)reader["FQTY"],
                    (decimal)reader["SUBTOTAL"],
                    (int)reader["CUSTID"],
                    (int)reader["LOCATIONID"],
                    (int)reader["RECEIVERID"],
                    (decimal)reader["TOTALAMT"]
                );
            return fOODITEM_TRANSDETAIL;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public List<FOODITEM_TRANSDETAIL> GetFOODITEM_TRANSDETAILsFromReader(IDataReader reader)
    {
        List<FOODITEM_TRANSDETAIL> fOODITEM_TRANSDETAILs = new List<FOODITEM_TRANSDETAIL>();

        while (reader.Read())
        {
            fOODITEM_TRANSDETAILs.Add(GetFOODITEM_TRANSDETAILFromReader(reader));
        }
        return fOODITEM_TRANSDETAILs;
    }

    public FOODITEM_TRANSDETAIL GetFOODITEM_TRANSDETAILFromReader(IDataReader reader)
    {
        try
        {
            FOODITEM_TRANSDETAIL fOODITEM_TRANSDETAIL = new FOODITEM_TRANSDETAIL
                (
                    (int)reader["FOODITEM_TRANSDETAILID"],
                    (int)reader["TID"],
                    (int)reader["FID"],
                    (decimal)reader["FRATE"],
                    (int)reader["FQTY"],
                    (DateTime)reader["CREATEDON"],
                    (int)reader["CREATEDBY"],
                    (DateTime)reader["UPDATEDON"],
                    (int)reader["UPDATEDBY"]
                );
             return fOODITEM_TRANSDETAIL;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public FOODITEM_TRANSDETAIL GetFOODITEM_TRANSDETAILByID(int fOODITEM_TRANSDETAILID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("AbiMatuEnterprise_GetFOODITEM_TRANSDETAILByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FOODITEM_TRANSDETAILID", SqlDbType.Int).Value = fOODITEM_TRANSDETAILID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetFOODITEM_TRANSDETAILFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertFOODITEM_TRANSDETAIL(FOODITEM_TRANSDETAIL fOODITEM_TRANSDETAIL)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_InsertFOODITEM_TRANSDETAIL", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FOODITEM_TRANSDETAILID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TID", SqlDbType.Int).Value = fOODITEM_TRANSDETAIL.TID;
            cmd.Parameters.Add("@FID", SqlDbType.Int).Value = fOODITEM_TRANSDETAIL.FID;
            cmd.Parameters.Add("@FRATE", SqlDbType.Decimal).Value = fOODITEM_TRANSDETAIL.FRATE;
            cmd.Parameters.Add("@FQTY", SqlDbType.Int).Value = fOODITEM_TRANSDETAIL.FQTY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = fOODITEM_TRANSDETAIL.CREATEDON;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = fOODITEM_TRANSDETAIL.CREATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = fOODITEM_TRANSDETAIL.UPDATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = fOODITEM_TRANSDETAIL.UPDATEDBY;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@FOODITEM_TRANSDETAILID"].Value;
        }
    }

    public bool UpdateFOODITEM_TRANSDETAIL(FOODITEM_TRANSDETAIL fOODITEM_TRANSDETAIL)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AbiMatuEnterprise_UpdateFOODITEM_TRANSDETAIL", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FOODITEM_TRANSDETAILID", SqlDbType.Int).Value = fOODITEM_TRANSDETAIL.FOODITEM_TRANSDETAILID;
            cmd.Parameters.Add("@TID", SqlDbType.Int).Value = fOODITEM_TRANSDETAIL.TID;
            cmd.Parameters.Add("@FID", SqlDbType.Int).Value = fOODITEM_TRANSDETAIL.FID;
            cmd.Parameters.Add("@FRATE", SqlDbType.Decimal).Value = fOODITEM_TRANSDETAIL.FRATE;
            cmd.Parameters.Add("@FQTY", SqlDbType.Int).Value = fOODITEM_TRANSDETAIL.FQTY;
            cmd.Parameters.Add("@CREATEDON", SqlDbType.DateTime).Value = fOODITEM_TRANSDETAIL.CREATEDON;
            cmd.Parameters.Add("@CREATEDBY", SqlDbType.Int).Value = fOODITEM_TRANSDETAIL.CREATEDBY;
            cmd.Parameters.Add("@UPDATEDON", SqlDbType.DateTime).Value = fOODITEM_TRANSDETAIL.UPDATEDON;
            cmd.Parameters.Add("@UPDATEDBY", SqlDbType.Int).Value = fOODITEM_TRANSDETAIL.UPDATEDBY;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
